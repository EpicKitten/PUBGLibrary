using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Reflection;

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
        public APIRequest APIRequest;
        /// <summary>
        /// The base class for the PUBG API
        /// </summary>
        /// <param name="MatchID">The match ID to look up</param>
        /// <param name="platform">The platform the replay was made on</param>
        /// <param name="KnownRegion">The region the replay was made in</param>
        /// <param name="APIKey">The API key to use</param>
        public API(string MatchID, PlatformRegionShard platformRegionShard, string APIKey)
        {
            APIRequest.RequestSingleMatch(APIKey, GetEnumDescription(platformRegionShard), MatchID);
        }
        /// <summary>
        /// The base class for the PUBG API
        /// </summary>
        /// <param name="ReplayDirectoryPath">The directory path to the replay folder</param>
        /// <param name="APIKey">The API key to use</param>
        public API(string ReplayDirectoryPath, string APIKey)
        {
            Replay.Replay replay = new Replay.Replay(ReplayDirectoryPath);
            APIRequest.RequestSingleMatch(APIKey, GetEnumDescription(replay.Summary.KnownRegion), replay.Info.MatchID);
        }
        /// <summary>
        /// The base class for the PUBG API
        /// </summary>
        /// <param name="replay">The replay class for a PUBG replay</param>
        /// <param name="APIKey">The API key to use</param>
        public API(Replay.Replay replay, string APIKey)
        {
            APIRequest.RequestSingleMatch(APIKey, GetEnumDescription(replay.Summary.KnownRegion), replay.Info.MatchID);   
        }
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
        Unknown,
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
        [JsonProperty("xbox-as")]
        [Description("xbox-oc")]
        Xbox_OC
    }
}
