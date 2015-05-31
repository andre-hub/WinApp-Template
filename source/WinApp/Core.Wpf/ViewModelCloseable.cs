namespace WinApp.Core.Wpf
{
    using System;

    public class ViewModelCloseable : ViewModelBase, IViewModelCloseable
    {
        protected ViewModelCloseable(string applicationName, IShortMessage message)
            : base(applicationName, message)
        {
        }

        public event EventHandler RequestClose;

        protected void OnRequestClose()
        {
            if (this.RequestClose != null)
            {
                this.RequestClose(this, EventArgs.Empty);
            }
        }
    }
}