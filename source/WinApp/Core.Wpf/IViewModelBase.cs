namespace WinApp.Core.Wpf
{
    using System.ComponentModel;

    internal interface IViewModelBase : INotifyPropertyChanged
    {
        string ApplicationName { get; }
    }
}