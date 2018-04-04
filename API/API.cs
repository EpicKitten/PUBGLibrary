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
        /// Request a single user using their AccountID
        /// </summary>
        /// <param name="AccountID"></param>
        /// <param name="platformRegionShard"></param>
        /// <returns></returns>
        public APIUser RequestSingleUser(string AccountID, PlatformRegionShard platformRegionShard)
        {
            APIRequest request = new APIRequest();
            return request.RequestSingleUser(APIKey, GetEnumDescription(platformRegionShard), AccountID);
        }
        /// <summary>
        /// Reuest multiple users using either their Account ID or their PUBG Name
        /// </summary>
        /// <param name="IDSToSearch">The list of names/ID to search</param>
        /// <param name="platformRegionShard">The Platform-Region to search</param>
        /// <param name="userSearchType">The type of search</param>
        /// <returns></returns>
        public List<APIUser> RequestMultiUser(List<string> IDSToSearch, PlatformRegionShard platformRegionShard, UserSearchType userSearchType = UserSearchType.PUBGName)
        {
            APIRequest request = new APIRequest();
            return request.RequestMultiUser(APIKey, GetEnumDescription(platformRegionShard), IDSToSearch, userSearchType);
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
        /// PC Korea/Japan
        /// </summary>
        [JsonProperty("pc-krjp")]
        [Description("pc-krjp")]
        PC_KRJP,
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
