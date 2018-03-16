using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;
using System.Collections.Generic;
namespace PUBGLibrary.API
{
    /// <summary>
    /// Handles single and multi-match requests
    /// </summary>
    public class APIRequest
    {
        public APIMatch match;
        public WebException exception;
        
        public readonly string ContentType = "application/json";
        /// <summary>
        /// Requests a single match from the PUBG Developer API
        /// </summary>
        /// <param name="APIKey">The API Key to use during the request</param>
        /// <param name="PlatformRegion">The platform-region of the request (xbox-na, pc-oc, etc)</param>
        /// <param name="MatchID">The Match ID of the map</param>
        /// <returns>If null, the request failed</returns>
        public void RequestSingleMatch(string APIKey, string PlatformRegion, string MatchID)
        {
            try
            {
                 string WEBSERVICE_URL = "https://api.playbattlegrounds.com/shards/" + PlatformRegion + "/matches/" + MatchID;
                 var webRequest = WebRequest.Create(WEBSERVICE_URL);
                 if (webRequest != null)
                 {
                    webRequest.Method = "GET";
                    webRequest.Timeout = 20000;
                    webRequest.ContentType = ContentType;
                    webRequest.Headers.Add("Authorization", APIKey);
                    webRequest.Headers.Add("Access-Control-Allow-Origins", "*");
                    webRequest.Headers.Add("Access-Control-Expose-Headers", "Content-Length");
                    using (Stream s = webRequest.GetResponse().GetResponseStream())
                     {
                         using (StreamReader sr = new StreamReader(s))
                         {
                            Phraser(sr.ReadToEnd());
                         }
                     }
                 }
                 return;
            }
            catch (WebException e)
            {
                exception = e;
                return;
            }
        }
        public void Phraser(string JSONstring)
        {
            var jsonmatch = PUBGLibrary.API.Phraser.FromJson(JSONstring);
            match = new APIMatch();
            foreach (var item in jsonmatch.Included)
            {
                if (item.Type == DatumType.Participant)
                {
                    if (item.Attributes.Stats != null)
                    {
                        APIPlayer player = new APIPlayer();
                        player = item.Attributes.Stats;
                        match.PlayerList.Add(player);
                    }
                }
                if (item.Type == DatumType.Roster)
                {
                    if (item.Relationships.Participants.Data != null)
                    {
                        APITeam team = new APITeam();
                        foreach (var teamamte in item.Relationships.Participants.Data)
                        {
                            team.TeammateIDList.Add(teamamte.Id);
                        }
                        team.TeamID = (int)item.Attributes.Stats.TeamId;
                        team.rank = (int)item.Attributes.Stats.Rank;
                        team.Won = false;
                        if (item.Attributes.Won == Won.True)
                        {
                            team.Won = true;
                        }
                        match.TeamList.Add(team);
                    }
                }
            }
        }
    }
}
