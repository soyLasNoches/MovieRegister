using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRegister.Base
{
    public class SortableBindingList<T> : BindingList<T>
    {
        #region Sorting
        private bool _IsSorted;

        public SortableBindingList()
        {
        }

        public SortableBindingList(IList<T> list) : base(list)
        {
        }

        protected override bool SupportsSortingCore
        {
            get { return true; }
        }

        protected override void ApplySortCore(PropertyDescriptor property, ListSortDirection direction)
        {
            SortCore(property, direction);
        }

        public void Sort(string collumnName, ListSortDirection direction)
        {
            if (this.Items.Count > 0)
            {
                PropertyDescriptorCollection properties =
                    TypeDescriptor.GetProperties(this.Items[0].GetType());
                PropertyDescriptor property = properties.Find(collumnName, false);
                if (property == null)
                    throw (new ArgumentNullException("Invalid Collumn Name (collumnName parameter)."));
                SortCore(property, direction);
            }
        }

        private void SortCore(PropertyDescriptor property, ListSortDirection direction)
        {
            List<T> items = this.Items as List<T>;
            if (null != items)
            {
                PropertyComparer<T> pc = new PropertyComparer<T>(property, direction);
                items.Sort(pc);
                _IsSorted = true;
            }
            else
            {
                _IsSorted = false;
            }
        }

        public void Sort(IComparer<T> comparer)
        {
            if (this.Items.Count > 0)
            {
                List<T> items = this.Items as List<T>;
                if (null != items)
                {
                    items.Sort(comparer);
                    _IsSorted = true;
                }
                else
                {
                    _IsSorted = false;
                }
            }
        }

        protected override bool IsSortedCore
        {
            get { return _IsSorted; }
        }

        protected override void RemoveSortCore()
        {
            _IsSorted = false;
        }
        #endregion

        #region Searching
        protected override bool SupportsSearchingCore
        {
            get { return true; }
        }

        protected override int FindCore(PropertyDescriptor property, object key)
        {
            if (property == null)
                return -1;

            List<T> items = this.Items as List<T>;
            foreach (T item in items)
            {
                string value = property.GetValue(item).ToString();
                if (key.ToString() == value) return IndexOf(item);
            }

            return -1;
        }

        public object GetItem(string collumnName, object collumnValue)
        {
            if (this.Items.Count == 0)
                return null;

            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(this.Items[0].GetType());
            PropertyDescriptor property = properties.Find(collumnName, false);

            if (property == null)
                throw (new ArgumentNullException("Invalid Column Name (collumnName parameter)."));
            int i = FindCore(property, collumnValue);

            return (i == -1) ? null : (object)this.Items[i];
        }
        #endregion

        #region Filter
        private List<T> _AllItems = new List<T>();
        private Predicate<T> _Predicate;

        public void Filter(Predicate<T> predicate)
        {
            _Predicate = predicate;
            Filter();
        }

        private void Filter()
        {
            base.Items.Clear();
            foreach (T obj in _AllItems)
            {
                if ((_Predicate == null) || _Predicate(obj))
                    base.Items.Add(obj);
            }
            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        protected override void InsertItem(int index, T item)
        {
            _AllItems.Add(item);
            base.InsertItem(index, item);
        }

        protected override void RemoveItem(int index)
        {
            _AllItems.Remove(Items[index]);
            base.RemoveItem(index);
        }

        protected override void ClearItems()
        {
            _AllItems.Clear();
            base.ClearItems();
        }

        protected override void SetItem(int index, T item)
        {
            _AllItems[_AllItems.IndexOf(Items[index])] = item;
            base.SetItem(index, item);
        }
        #endregion

        public DataTable ToDataTable(string tableName)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable(tableName);
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in base.Items)
            {
                for (int i = 0; i < values.Length; i++)
                    values[i] = props[i].GetValue(item) ?? DBNull.Value;
                table.Rows.Add(values);
            }
            return table;
        }
    }
}
