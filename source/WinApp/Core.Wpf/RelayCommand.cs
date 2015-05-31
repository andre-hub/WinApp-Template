namespace WinApp.Core.Wpf
{
    using System;
    using System.Windows.Input;

    internal class RelayCommand<T> : ICommand
    {
        private readonly bool _canExecute;
        private readonly Action<T> _action;

        public RelayCommand(Action<T> action)
        {
            this._action = action;
            this._canExecute = true;
        }

        public RelayCommand(bool canExecute, Action<T> action)
        {
            this._canExecute = canExecute;
            this._action = action;
        }

        public bool CanExecute(object parameter)
        {
            return this._canExecute;
        }

        public void Execute(object parameter)
        {
            this._action((T)parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}