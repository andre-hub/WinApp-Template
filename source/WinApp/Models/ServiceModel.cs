namespace WinApp.Models
{
    using System;
    using System.Diagnostics;
    using System.Net;
    using System.Text.RegularExpressions;
    using WinApp.Dtos;

    internal class ServiceModel : IServiceModel
    {
        private readonly TraceSource _trace = new TraceSource(typeof(ServiceModel).Namespace);
        private readonly string _testSetting;
        private readonly string _testUrl;
        private readonly IWebClientHelper _webClientHelper;
        private readonly Version _version;

        public ServiceModel(string testUrl, string testSetting, IWebClientHelper webClientHelper, Version version)
        {
            this._testUrl = testUrl;
            this._testSetting = testSetting;
            this._webClientHelper = webClientHelper;
            this._version = version;
        }

        public string ApplicationVersion()
        {
            return string.Format(Constants.VersionFormat, _version.Major, _version.Minor, _version.Build);
        }

        public ProjectData GetDataFromService()
        {
            var request = _webClientHelper.CreateHttpWebRequest(_testUrl);
            WebResponse webResponse;
            try
            {
                webResponse = request.GetResponse();
                return ConvertResponse(webResponse);
            }
            catch (WebException ex)
            {
                _trace.TraceEvent(TraceEventType.Error, 0, ex.ToString());
                if (ex.Message.Contains("timed out"))
                {
                    throw new TimeoutException(string.Concat("The Service ", _testUrl, " is unavailable."));
                }
                throw ex;
            }
            catch (Exception ex)
            {
                _trace.TraceEvent(TraceEventType.Error, 0, ex.ToString());
                throw ex;
            }
        }

        private ProjectData ConvertResponse(WebResponse webResponse)
        {
            var htmlDocument = webResponse.ToHtmlString();
            var projectData = new ProjectData();
            projectData.Title = FoundStringByPattern(htmlDocument, @"\<title\>(.+)+\<\/title\>", "title");
            return projectData;
        }

        private string FoundStringByPattern(string source, string pattern, string removeTag)
        {
            var foundEntry = Regex.Match(source, pattern, RegexOptions.IgnoreCase);
            var result = foundEntry.Value.Replace(string.Format(@"<{0}>", removeTag), string.Empty).Replace(string.Format(@"</{0}>", removeTag), string.Empty);
            return result;
        }
    }
}