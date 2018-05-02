using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Threading;

namespace PUBGLibrary.API
{
    /// <summary>
    /// The base class for the PUBG API
    /// </summary>
    public class API
    {
        /// <summary>
        /// The API key used during requests
        /// </summary>
        private string APIKey;
        /// <summary>
        /// The base class for the PUBG API
        /// </summary>
        /// <param name="API_Key">The API key to use during requests</param>
        public API(string API_Key)
        {
            APIKey = API_Key;
        }
        /// <summary>
        /// Request a single match using a MatchID and Platform-Region Shard that the match was played in
        /// </summary>
        /// <param name="MatchID">The MatchID to look up</param>
        /// <param name="platformRegionShard">The region the match was played in</param>
        /// <returns></returns>
        public APIRequest RequestMatch(string MatchID, PlatformRegionShard platformRegionShard)
        {
            APIRequest APIRequest = new APIRequest();
            APIRequest request = APIRequest.RequestSingleMatch(APIKey, GetEnumDescription(platformRegionShard), MatchID);
            return request;
        }
        /// <summary>
        /// Request a single match using a PUBG replay
        /// </summary>
        /// <param name="ReplayDirectoryPath">The replay to look up</param>
        /// <returns></returns>
        public APIRequest RequestMatch(string ReplayDirectoryPath)
        {
            Replay.Replay replay = new Replay.Replay(ReplayDirectoryPath);
            APIRequest APIRequest = new APIRequest();
            return APIRequest.RequestSingleMatch(APIKey, GetEnumDescription(replay.Summary.KnownRegion), replay.Info.MatchID);
        }
        /// <summary>
        /// Request a single match using the Replay class
        /// </summary>
        /// <param name="replay">The replay to read</param>
        /// <returns></returns>
        public APIRequest RequestMatch(Replay.Replay replay)
        {
            APIRequest APIRequest = new APIRequest();
            return APIRequest.RequestSingleMatch(APIKey, GetEnumDescription(replay.Summary.KnownRegion), replay.Info.MatchID);
        }
        /// <summary>
        /// Requests multiple matches from a list of replay files
        /// </summary>
        /// <param name="replays">Replays to request</param>
        /// <param name="RateLimitPerMintue">The ratelimit on the API key given (How many times we can ask the PUBG API about a match)</param>
        /// <returns></returns>
        public List<APIRequest> RequestMatches(List<Replay.Replay> replays, int RateLimitPerMintue)
        {
            List<APIRequest> APIRequestList = new List<APIRequest>();
            if (replays.Count <= RateLimitPerMintue)
            {
                foreach (Replay.Replay replay in replays)
                {
                    APIRequestList.Add(RequestMatch(replay));
                }
                return APIRequestList;
            }
            else
            {
                int requestsmade = 0;
                do
                {
                    for (int i = 0; i < RateLimitPerMintue; i++)
                    {
                        
                        APIRequestList.Add(RequestMatch(replays[requestsmade]));
                        requestsmade++;
                    }
                    Thread.Sleep(60000);

                } while (requestsmade < replays.Count);
                return APIRequestList;
            }

        }
        /// <summary>
        /// Request a single user or multipe users on the same platform and region
        /// </summary>
        /// <param name="PlayerID1">The first user to request</param>
        /// <param name="PlayerID2">The second user to request</param>
        /// <param name="PlayerID3">The thrid user to request</param>
        /// <param name="PlayerID4">The forth user to request</param>
        /// <param name="PlayerID5">The fifth user to request</param>
        /// <param name="PlayerID6">The sixth user to request</param>
        /// <param name="platformRegionShard">The Platform-Region shard to search in</param>
        /// <param name="userSearchType">The type of ID to search by</param>
        /// <returns></returns>
        public List<APIUser> RequestUser(string PlayerID1, PlatformRegionShard platformRegionShard = PlatformRegionShard.PC_NA, UserSearchType userSearchType = UserSearchType.PUBGName, string PlayerID2 = "", string PlayerID3 = "", string PlayerID4 = "", string PlayerID5 = "", string PlayerID6 = "")
        {
            List<string> IDsToSearch = new List<string>() { PlayerID1 };
            if (PlayerID2 != "")
            {
                IDsToSearch.Add(PlayerID2);
            }
            if (PlayerID3 != "")
            {
                IDsToSearch.Add(PlayerID3);
            }
            if (PlayerID4 != "")
            {
                IDsToSearch.Add(PlayerID4);
            }
            if (PlayerID5 != "")
            {
                IDsToSearch.Add(PlayerID5);
            }
            if (PlayerID6 != "")
            {
                IDsToSearch.Add(PlayerID6);
            }
            APIRequest request = new APIRequest();
            return request.RequestUser(APIKey, GetEnumDescription(platformRegionShard), IDsToSearch, userSearchType);
        }
        /// <summary>
        /// Watch a single user or multipe users on the same platform and region
        /// </summary>
        /// <param name="PlayerID1">The first user to watch</param>
        /// <param name="PlayerID2">The second user to watch</param>
        /// <param name="PlayerID3">The thrid user to watch</param>
        /// <param name="PlayerID4">The forth user to watch</param>
        /// <param name="PlayerID5">The fifth user to watch</param>
        /// <param name="PlayerID6">The sixth user to watch</param>
        /// <param name="platformRegionShard">That platform to watch</param>
        /// <param name="userSearchType">The </param>
        /// <returns></returns>
        public APIWatchdog WatchUser(string PlayerID1, PlatformRegionShard platformRegionShard = PlatformRegionShard.PC_NA, UserSearchType userSearchType = UserSearchType.PUBGName, string PlayerID2 = "", string PlayerID3 = "", string PlayerID4 = "")
        {
            APIWatchdog watchdog = new APIWatchdog();
            List<string> IDsToWatch = new List<string>() { PlayerID1 };
            if (PlayerID2 != "")
            {
                IDsToWatch.Add(PlayerID2);
            }
            if (PlayerID3 != "")
            {
                IDsToWatch.Add(PlayerID3);
            }
            if (PlayerID4 != "")
            {
                IDsToWatch.Add(PlayerID4);
            }
            watchdog.WatchMultiUser(APIKey, IDsToWatch, GetEnumDescription(platformRegionShard), userSearchType);
            return watchdog;
        }
        public List<string> FetchMatchSamples(PlatformRegionShard platformRegionShard = PlatformRegionShard.PC_NA)
        {
            APIRequest request = new APIRequest();
            return request.RequestSamples(APIKey, GetEnumDescription(platformRegionShard));
        }
        public List<APISeason> RequestPlatformRegionSeasons(PlatformRegionShard platformRegionShard = PlatformRegionShard.PC_NA)
        {
            APIRequest request = new APIRequest();
            return request.RequestRegionSeasons(APIKey, GetEnumDescription(platformRegionShard));
        }
        /// <summary>
        /// Gets the description tag from Enums
        /// </summary>
        /// <param name="value">The enum value you want to read</param>
        /// <returns></returns>
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return value.ToString();
            }
        }
    }
    /// <summary>
    /// The Platform and Region varibles
    /// </summary>
    public enum PlatformRegionShard
    {
        /// <summary>
        /// PC North America
        /// </summary>
        [JsonProperty("pc-na")]
        [Description("pc-na")]
        PC_NA,
        /// <summary>
        /// PC Europe
        /// </summary>
        [JsonProperty("pc-eu")]
        [Description("pc-eu")]
        PC_EU,
        /// <summary>
        /// PC Korea
        /// </summary>
        [JsonProperty("pc-kr")]
        [Description("pc-kr")]
        PC_KR,
        /// <summary>
        /// PC Japan
        /// </summary>
        [JsonProperty("pc-jp")]
        [Description("pc-jp")]
        PC_JP,
        /// <summary>
        /// PC Asia
        /// </summary>
        [JsonProperty("pc-as")]
        [Description("pc-as")]
        PC_AS,
        /// <summary>
        /// PC Oceania
        /// </summary>
        [JsonProperty("pc-oc")]
        [Description("pc-oc")]
        PC_OC,
        /// <summary>
        /// PC South and Central Amercia
        /// </summary>
        [JsonProperty("pc-sa")]
        [Description("pc-sa")]
        PC_SA,
        /// <summary>
        /// PC South East Asia
        /// </summary>
        [JsonProperty("pc-sea")]
        [Description("pc-sea")]
        PC_SEA,
        /// <summary>
        /// Alternative platform to Steam (https://www.kakaogames.com/)
        /// </summary>
        [JsonProperty("pc-kakao")]
        [Description("pc-kakao")] 
        PC_KAKAO,
        /// <summary>
        /// Xbox North America
        /// </summary>
        [JsonProperty("xbox-na")]
        [Description("xbox-na")]
        Xbox_NA,
        /// <summary>
        /// Xbox Europe
        /// </summary>
        [JsonProperty("xbox-eu")]
        [Description("xbox-eu")]
        Xbox_EU,
        /// <summary>
        /// Xbox Asia
        /// </summary>
        [JsonProperty("xbox-as")]
        [Description("xbox-as")]
        Xbox_AS,
        /// <summary>
        /// Xbox Oceania
        /// </summary>
        [JsonProperty("xbox-oc")]
        [Description("xbox-oc")]
        Xbox_OC
    }
}
