using System.Net;

namespace WinApp.Models
{
    public interface IWebClientHelper
    {
        HttpWebRequest CreateHttpWebRequest(string url);
    }
}