using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoviesRegister.Base
{
    public partial class BaseForm : Form
    {
        private bool _LoadError = false;
        private bool _SuspendedDrawing = false;

        public BaseForm()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);

            InitializeComponent();
        }

        protected bool LoadError
        {
            get { return _LoadError; }
            set { _LoadError = value; }
        }

        ////protected virtual bool Salvar()
        ////{
        ////    // Salvar...
        ////    return true;
        ////}

        protected virtual void SalvarEFechar()
        {
            // Salvar e fechar...
        }

        protected virtual void SalvarENovo()
        {
            // Salvar e novo...
        }

        protected virtual void Excluir()
        {
            // Excluir...
        }

        protected virtual void ItemAnterior()
        {
            // Mover para cima...
        }

        protected virtual void ProximoItem()
        {
            // Mover para baixo...
        }

        private void BaseForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                return;
            }

            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.S:
                        ////Salvar();
                        break;
                    case Keys.F4:
                        SalvarEFechar();
                        break;
                    case Keys.N:
                        SalvarENovo();
                        break;
                    case Keys.Delete:
                        Excluir();
                        break;
                    case Keys.Up:
                        e.SuppressKeyPress = true;
                        ItemAnterior();
                        break;
                    case Keys.Down:
                        e.SuppressKeyPress = true;
                        ProximoItem();
                        break;
                }
            }
        }

        public DialogResult ShowDialog(IWin32Window owner)
        {
            return (LoadError) ? DialogResult.Abort : base.ShowDialog(owner);
        }

        private const int WM_SETREDRAW = 11;

        public static void SuspendDrawing(Control control)
        {
            Message msgSuspendUpdate = Message.Create(control.Handle, WM_SETREDRAW, IntPtr.Zero,
                IntPtr.Zero);

            NativeWindow window = NativeWindow.FromHandle(control.Handle);
            window.DefWndProc(ref msgSuspendUpdate);
        }

        public static void ResumeDrawing(Control control)
        {
            IntPtr wparam = new IntPtr(1);
            Message msgResumeUpdate = Message.Create(control.Handle, WM_SETREDRAW, wparam,
                IntPtr.Zero);

            NativeWindow window = NativeWindow.FromHandle(control.Handle);
            window.DefWndProc(ref msgResumeUpdate);
            control.Refresh();
            foreach (Control c in control.Controls)
                c.Refresh();
        }

        public bool IsSuspendedDrawing()
        {
            return this._SuspendedDrawing;
        }

        public void SuspendDrawing()
        {
            if (_SuspendedDrawing)
                return;

            _SuspendedDrawing = true;
            BaseForm.SuspendDrawing(this);
        }

        public void ResumeDrawing()
        {
            if (!_SuspendedDrawing)
                return;

            _SuspendedDrawing = false;
            BaseForm.ResumeDrawing(this);
        }
    }
}
