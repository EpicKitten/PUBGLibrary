using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace PUBGLibrary.API
{
    public class APIRequest
    {
        public APIMatch match = new APIMatch();
        public APIRequest()
        {
            
        }
        /// <summary>
        /// Requests a single match from the PUBG Developer API
        /// </summary>
        /// <param name="APIKey">The API Key to use during the request</param>
        /// <param name="PlatformRegion">The platform-region of the request (xbox-na, pc-oc, etc)</param>
        /// <param name="MatchID">The Match ID of the map</param>
        /// <returns>If null, the request failed</returns>
        public JObject RequestSingleMatch(string APIKey, string PlatformRegion, string MatchID)
        {
            string WEBSERVICE_URL = "https://api.playbattlegrounds.com/shards/" + PlatformRegion + "/matches/" + MatchID;
            var webRequest = System.Net.WebRequest.Create(WEBSERVICE_URL);
            if (webRequest != null)
            {
                webRequest.Method = "GET";
                webRequest.Timeout = 20000;
                webRequest.ContentType = "application/json";
                webRequest.Headers.Add("Authorization", APIKey);
                webRequest.Headers.Add("Accept", "application/json");
                using (Stream s = webRequest.GetResponse().GetResponseStream())
                {
                    using (StreamReader sr = new StreamReader(s))
                    {
                        var jsonResponse = sr.ReadToEnd();
                        return JObject.Parse(jsonResponse);
                    }
                }
            }
            return null;
        }
    }
}
