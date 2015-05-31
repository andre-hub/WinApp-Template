namespace WinApp.Core.Wpf
{
    using System.Windows;

    internal class ShortMessage : IShortMessage
    {
        private const int MaxLength = 1400;
        private readonly string _productName;

        public ShortMessage(string productName)
        {
            this._productName = productName;
        }

        public void MessageBoxWarning(string message)
        {
            MessageBox.Show(SubString(message), this._productName, MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public void MessageBoxError(string message)
        {
            MessageBox.Show(SubString(message), this._productName, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public MessageBoxResult YesNoAnswerBox(string message, MessageBoxImage icon = MessageBoxImage.Question)
        {
            return MessageBox.Show(SubString(message), this._productName, MessageBoxButton.YesNo, icon, MessageBoxResult.No);
        }

        public void MessageBoxOk(string message)
        {
            MessageBox.Show(SubString(message), this._productName, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private static string SubString(string message)
        {
            return message.Substring(0, message.Length < MaxLength ? message.Length : MaxLength);
        }
    }
}