namespace WinApp
{
    using Models;
    using System.Configuration;
    using System.Reflection;
    using ViewModels;
    using WinApp.Core.Wpf;

    internal class ComponentsContainer
    {
        private static ComponentsContainer instance = new ComponentsContainer();

        internal static ComponentsContainer Current
        {
            get { return instance; }
        }

        public MainWindowViewModel GetMainWindowViewModel()
        {
            var testUrl = ConfigurationManager.AppSettings["TestUrl"];
            var testSetting = ConfigurationManager.AppSettings["TestSetting"];
            var webClientHelper = new WebClientHelper();
            var shortMessage = new ShortMessage(Constants.ApplicationName);
            var version = Assembly.GetAssembly(typeof(ComponentsContainer)).GetName().Version;
            var serviceModel = new ServiceModel(testUrl, testSetting, webClientHelper, version);
            return new MainWindowViewModel(Constants.ApplicationName, shortMessage, serviceModel);
        }
    }
}