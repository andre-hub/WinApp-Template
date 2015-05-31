namespace WinApp.Models
{
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Web.Script.Serialization;

    public static class ResponseExtension
    {
        private static readonly JavaScriptSerializer _javaScriptSerializer = new JavaScriptSerializer();

        public static Dictionary<string, object> ToDictionary(this WebResponse webResponse)
        {
            using (var webStream = webResponse.GetResponseStream())
            {
                if (webStream == null)
                {
                    {
                        return new Dictionary<string, object>();
                    }
                }
                StreamReader readStream = ConvertToStreamReader(webResponse, webStream);
                var data = readStream.ReadToEnd();
                readStream.Dispose();
                return _javaScriptSerializer.Deserialize<Dictionary<string, object>>(data);
            }
        }

        public static string ToHtmlString(this WebResponse webResponse)
        {
            string data;
            using (var webStream = webResponse.GetResponseStream())
            {
                if (webStream == null)
                {
                    return string.Empty;
                }
                StreamReader readStream = ConvertToStreamReader(webResponse, webStream);
                data = readStream.ReadToEnd();
                readStream.Dispose();
            }
            return data;
        }

        private static StreamReader ConvertToStreamReader(WebResponse webResponse, Stream webStream)
        {
            StreamReader readStream = null;
            HttpWebResponse response = webResponse as HttpWebResponse;
            if (!(webResponse is HttpWebResponse) || response.CharacterSet == null)
            {
                readStream = new StreamReader(webStream);
            }
            else
            {
                readStream = new StreamReader(webStream, Encoding.GetEncoding(response.CharacterSet));
            }
            return readStream;
        }
    }
}