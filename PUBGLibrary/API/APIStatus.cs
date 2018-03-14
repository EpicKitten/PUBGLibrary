using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace PUBGLibrary.API
{
    public class APIStatus
    {
        public bool bIsOnline;
        public Exception error;
        public string type;
        public string ID;
        public DateTime APIVersionRelease;
        public string Version;
        /// <summary>
        /// Gets the status of the API
        /// </summary>
        public APIStatus()
        {
            try
            {
                string WEBSERVICE_URL = "https://api.playbattlegrounds.com/status";
                var webRequest = System.Net.WebRequest.Create(WEBSERVICE_URL);
                if (webRequest != null)
                {
                    webRequest.Method = "GET";
                    webRequest.Timeout = 20000;
                    webRequest.ContentType = "application/json";
                    using (Stream s = webRequest.GetResponse().GetResponseStream())
                    {
                        using (StreamReader sr = new StreamReader(s))
                        {
                            var jsonResponse = sr.ReadToEnd();
                            bIsOnline = true;
                            JObject status = JObject.Parse(jsonResponse);
                            type = (string)status["data"]["type"];
                            ID = (string)status["data"]["id"];
                            APIVersionRelease = (DateTime)status["data"]["attributes"]["releasedAt"];
                            Version = (string)status["data"]["attributes"]["version"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                bIsOnline = false;
                error = e;
            }
        }
    }
}
