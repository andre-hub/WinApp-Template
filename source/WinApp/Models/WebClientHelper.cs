namespace WinApp.Models
{
    using System.Net;

    public class WebClientHelper : IWebClientHelper
    {
        private int timeout = 1000 * 3;

        public HttpWebRequest CreateHttpWebRequest(string url)
        {
            HttpWebRequest request = CreateRequest(url);
            return request;
        }

        private HttpWebRequest CreateRequest(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Timeout = timeout;
            request.ReadWriteTimeout = request.Timeout;
            return request;
        }
    }
}