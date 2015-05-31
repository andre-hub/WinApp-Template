using System.Windows;
using WinApp.ViewModels;

namespace WinApp.Views
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel mainWindowViewModel;

        public MainWindow()
        {
            if (DataContext == null)
            {
                DataContext = new MainWindowViewModel();
            }
            InitializeComponent();
        }
    }
}