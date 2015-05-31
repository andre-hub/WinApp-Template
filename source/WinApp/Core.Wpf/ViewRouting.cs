namespace WinApp.Core.Wpf
{
    using System;
    using System.Windows;

    internal class ViewRouting
    {
        private readonly Func<Window> _createView;

        private Window _view;

        public ViewRouting(Func<Window> createView)
        {
            if (createView == null)
            {
                throw new ArgumentNullException("createView");
            }
            this._createView = createView;
        }

        protected Window View
        {
            get
            {
                return this._view;
            }
        }

        public void CreateView()
        {
            if (null != this._view)
            {
                this._view.Close();
            }
            this._view = this._createView();
        }

        public void OnClose(object sender, EventArgs e)
        {
            if (null != this._view)
            {
                this._view.Close();
            }
        }

        public void OnViewShowHandler()
        {
            this.CreateView();
            this._view.ShowDialog();
        }

        public bool? OnViewShowHandler(object obj)
        {
            this.CreateView();
            _view.DataContext = obj;
            this._view.ShowDialog();
            return this._view.DialogResult;
        }
    }
}