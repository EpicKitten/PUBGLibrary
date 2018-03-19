using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Text;

namespace PUBGLibrary.API
{
    /// <summary>
    /// Handles single and multi-match requests
    /// </summary>
    public class APIRequest
    {
        public APIMatch match;
        public WebException exception;
        public string JSONString;
        /// <summary>
        /// Requests a single match from the PUBG Developer API
        /// </summary>
        /// <param name="APIKey">The API Key to use during the request</param>
        /// <param name="PlatformRegion">The platform-region of the request (xbox-na, pc-oc, etc)</param>
        /// <param name="MatchID">The Match ID of the map</param>
        /// <returns>If null, the request failed</returns>
        public void RequestSingleMatch(string APIKey, string PlatformRegion, string MatchID)
        {
            APIStatus status = new APIStatus();
            if (status.bIsOnline)
            {
                try
                {
                    string APIURL = "https://api.playbattlegrounds.com/shards/" + PlatformRegion + "/matches/" + MatchID;
                    var webRequest = WebRequest.Create(APIURL);
                    var APIRequest = (HttpWebRequest)webRequest;
                    APIRequest.PreAuthenticate = true;
                    APIRequest.Headers.Add("Authorization", "Bearer " + APIKey);
                    APIRequest.Headers.Add("Access-Control-Allow-Origins", "*");
                    APIRequest.Headers.Add("Access-Control-Expose-Headers", "Content-Length");
                    APIRequest.Accept = "application/json";
                    using (var APIResponse = APIRequest.GetResponse())
                    {
                        using (var responseStream = APIResponse.GetResponseStream())
                        {
                            var myStreamReader = new StreamReader(responseStream, Encoding.Default);
                            JSONString = myStreamReader.ReadToEnd();
                            Phraser(JSONString);
                        }
                    }
                }
                catch (WebException e)
                {
                    exception = e;
                    return;
                }
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
