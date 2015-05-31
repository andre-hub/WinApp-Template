using WinApp.Dtos;

namespace WinApp.Models
{
    internal interface IServiceModel
    {
        ProjectData GetDataFromService();

        string ApplicationVersion();
    }
}