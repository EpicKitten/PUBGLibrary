using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace PUBGLibrary.API
{
    /// <summary>
    /// Gets the status of the API Service
    /// </summary>
    public class APIStatus
    {
        /// <summary>
        /// Toggles depending on if the API is online
        /// </summary>
        public bool bIsOnline;
        /// <summary>
        /// Holds web errors for direct viewing
        /// </summary>
        public Exception error;
        /// <summary>
        /// 
        /// </summary>
        public string type;
        /// <summary>
        /// The ID of the API (always pubg-api)
        /// </summary>
        public string ID;
        /// <summary>
        /// The most recent release date of the API
        /// </summary>
        public DateTime APIVersionRelease;
        /// <summary>
        /// The version of the API service
        /// </summary>
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
