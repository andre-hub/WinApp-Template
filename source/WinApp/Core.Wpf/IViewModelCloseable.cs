namespace WinApp.Core.Wpf
{
    using System;

    public interface IViewModelCloseable
    {
        event EventHandler RequestClose;
    }
}