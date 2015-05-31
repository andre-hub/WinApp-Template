using System.Windows;
using System.Windows.Threading;
using WinApp.Views;

namespace WinApp
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var container = ComponentsContainer.Current;
            var view = new MainWindow { DataContext = container.GetMainWindowViewModel() };
            view.Show();
        }

        private void AppDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            this.ShowErrorBox(e.Exception.ToString());
            e.Handled = true;
        }

        private void ShowErrorBox(string text)
        {
            MessageBox.Show(text, Constants.ApplicationName, MessageBoxButton.OK, MessageBoxImage.Stop);
        }
    }
}