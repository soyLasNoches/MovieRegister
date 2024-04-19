using FirebirdSql.Data.FirebirdClient;
using MoviesRegister.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRegister.DAL
{
    class FBDataCacheObject
    {

        private List<string> _ParamsIndexs = new List<string>();
        private List<object> _ParamsValues = new List<object>();
        private string _CommandText = "";
        private SortableBindingList<object> _ListObjects = null;

        public FBDataCacheObject()
        {
            this._ListObjects = new SortableBindingList<object>();
        }

        public void DoCache<T>(FbCommand fbCmd, SortableBindingList<T> cacheListObject)
        {
            _CommandText = fbCmd.CommandText;

            _ParamsIndexs.Clear();
            _ParamsValues.Clear();
            for (int i = 0; i < fbCmd.Parameters.Count; i++)
            {
                _ParamsIndexs.Add(fbCmd.Parameters[i].ParameterName);
                _ParamsValues.Add(fbCmd.Parameters[i].Value);
            }

            _ListObjects.Clear();
            for (int i = 0; i < cacheListObject.Count; i++)
                _ListObjects.Add(cacheListObject[i]);
        }

        public bool IsCachedObject(FbCommand fbCmd)
        {
            bool IsCached = false;
            if ((_CommandText == fbCmd.CommandText) && (_ParamsIndexs.Count == fbCmd.Parameters.Count))
            {
                IsCached = true;
                for (int i = 0; i < fbCmd.Parameters.Count; i++)
                    if (!_ParamsValues[i].Equals(fbCmd.Parameters[_ParamsIndexs[i]].Value))
                        IsCached = false;
            }

            return IsCached;
        }

        public void Clear()
        {
            for (int i = 0; i < _ParamsIndexs.Count; i++)
            {
                _ParamsIndexs[i] = "";
                _ParamsValues[i] = null;
            }
            _ParamsIndexs.Clear();
            _ParamsValues.Clear();
            _ListObjects.Clear();
        }

        public SortableBindingList<object> CachedlistObject()
        {
            return _ListObjects;
        }
    }

    class FBDataCacheContainer
    {
        private Type _CachedType = null;
        private List<FBDataCacheObject> cachedObjects = new List<FBDataCacheObject>();

        public FBDataCacheContainer(Type cachedType)
        {
            this._CachedType = cachedType;
        }

        public bool IsCachedType(Type cachedType)
        {
            return _CachedType == cachedType;
        }

        public Type CachedType()
        {
            return _CachedType;
        }

        public void ClearCache()
        {
            for (int i = 0; i < cachedObjects.Count; i++)
                cachedObjects[i].Clear();
            cachedObjects.Clear();
        }

        public SortableBindingList<object> GetCachedObject(FbCommand fbCmd)
        {
            for (int i = 0; i < cachedObjects.Count; i++)
                if (cachedObjects[i].IsCachedObject(fbCmd))
                {
                    if (i != 0)
                    {
                        FBDataCacheObject temp = cachedObjects[0];
                        cachedObjects[0] = cachedObjects[i];
                        cachedObjects[i] = temp;
                    }
                    return cachedObjects[0].CachedlistObject();
                }

            return null;
        }

        public void DoCachedObject<T>(FbCommand fbCmd, SortableBindingList<T> listObjects)
        {
            while (cachedObjects.Count > 4096)
                cachedObjects.RemoveAt(0);

            int addToCache = -1;
            for (int i = 0; i < cachedObjects.Count; i++)
                if (cachedObjects[i].IsCachedObject(fbCmd))
                {
                    addToCache = i;
                    break;
                }

            if (addToCache == -1)
            {
                cachedObjects.Add(new FBDataCacheObject());
                addToCache = cachedObjects.Count - 1;
            }

            cachedObjects[addToCache].DoCache<T>(fbCmd, listObjects);
        }
    }

    class FBDataCacheController
    {
        private List<FBDataCacheContainer> _Container = new List<FBDataCacheContainer>();
        private bool _Enabled = false;
        private bool _Internal = false;
        private bool _AutoClean = true;

        public FBDataCacheController()
        {
        }

        public void EnableCache()
        {
            _Enabled = true;
        }

        public void DisableCache()
        {
            _Enabled = false;
            if (_AutoClean)
                ClearCache();
        }

        public void SetAutoCleanCache(bool autoClean)
        {
            _AutoClean = autoClean;
            if (_AutoClean)
                ClearCache();
        }

        public void ClearCache()
        {
            for (int i = 0; i < _Container.Count; i++)
                _Container[i].ClearCache();
        }

        public bool IsEnabled()
        {
            return _Enabled;
        }

        public bool ExecuteCacheControl<T>(FbCommand fbCmd, ref SortableBindingList<T> List)
        {
            if (_Internal)
                return false;

            if (!IsEnabled())
                return false;

            SortableBindingList<object> cached = null;
            for (int i = 0; i < _Container.Count; i++)
                if (_Container[i].IsCachedType(typeof(T)))
                {
                    cached = _Container[i].GetCachedObject(fbCmd);
                    if (cached != null)
                        break;
                }

            if (cached != null)
            {
                for (int i = 0; i < cached.Count; i++)
                    List.Add((T)cached[i]);

                return true;
            }
            else
                return false;
        }

        public bool SetCacheControl<T>(FbCommand fbCmd, ref SortableBindingList<T> List)
        {
            if (!IsEnabled())
                return false;

            int addToCache = -1;
            for (int i = 0; i < _Container.Count; i++)
                if (_Container[i].IsCachedType(typeof(T)))
                {
                    addToCache = i;
                    break;
                }

            if (addToCache == -1)
            {
                _Container.Add(new FBDataCacheContainer(typeof(T)));
                addToCache = _Container.Count - 1;
            }

            _Container[addToCache].DoCachedObject<T>(fbCmd, List);

            return true;
        }
    }
}
