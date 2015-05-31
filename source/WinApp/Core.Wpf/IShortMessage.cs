namespace WinApp.Core.Wpf
{
    using System.Windows;

    public interface IShortMessage
    {
        void MessageBoxWarning(string message);

        void MessageBoxError(string message);

        MessageBoxResult YesNoAnswerBox(string message, MessageBoxImage icon = MessageBoxImage.Question);

        void MessageBoxOk(string message);
    }
}