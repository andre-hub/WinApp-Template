namespace WinApp.Core.Wpf
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Windows.Input;

    public class ViewModelBase : IViewModelBase
    {
        private readonly TraceSource _trace = new TraceSource(typeof(ViewModelBase).Namespace);

        private readonly IShortMessage _shortMessage;

        protected ViewModelBase(string applicationName, IShortMessage message)
        {
            this._shortMessage = message;
            this.ApplicationName = applicationName;
        }

        protected void WaitAction(Action action)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            try
            {
                action();
            }
            catch (TimeoutException ex)
            {
                this._shortMessage.MessageBoxError(ex.Message);
            }
            catch (Exception ex)
            {
                _trace.TraceEvent(TraceEventType.Error, 0, ex.ToString());
                this._shortMessage.MessageBoxError(ex.Message);
            }
            finally
            {
                Mouse.OverrideCursor = null;
            }
        }

        protected IShortMessage Message
        {
            get
            {
                return this._shortMessage;
            }
        }

        public string ApplicationName { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}