using WinApp.Core.Wpf;
using WinApp.Dtos;
using WinApp.Models;

namespace WinApp.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        private readonly IServiceModel serviceModel;

        public MainWindowViewModel() : base(string.Empty, null)
        {
            // For Designer
        }

        public MainWindowViewModel(string applicationName, IShortMessage message, IServiceModel serviceModel) : base(applicationName, message)
        {
            this.serviceModel = serviceModel;
            RefreshData();
        }

        public string ApplicationNameWithVersion
        {
            get
            {
                if (serviceModel == null)
                {
                    return ApplicationName;
                }
                return string.Concat(ApplicationName, " - ", serviceModel.ApplicationVersion());
            }
        }

        public ProjectData ProjectData { get; set; }

        private void RefreshData()
        {
            WaitAction(() =>
                {
                    ProjectData = serviceModel.GetDataFromService();
                });
        }
    }
}