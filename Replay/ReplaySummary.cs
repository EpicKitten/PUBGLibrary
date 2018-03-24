using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using PUBGLibrary.API;

namespace PUBGLibrary.Replay
{
    /// <summary>
    /// A list of weather types (Missing - fog/rain)
    /// </summary>
    public enum Weather
    {
        Unknown,
        [EnumMember(Value = "Sunny Clear")]
        SunnyClear,
        Sunrise,
        Sunny,
        Sunset,
    }
    /// <summary>
    /// Used for storing data from the ReplaySummary file found in the replay files
    /// </summary>
    public class ReplaySummary
    {
        [JsonProperty("bIsServerRecording")]
        public bool IsServerRecording;

        [JsonProperty("matchId")]
        public string MatchID;

        [JsonProperty("numPlayers")]
        public int PlayerCount;
        
        [JsonProperty("numTeams")]
        public int TeamsCount;
        
        public float AvgPlayersPerTeam
        {
            get
            {
                return PlayerCount / TeamsCount;
            }
        }

        [JsonProperty("regionName")]
        private string RegionName
        {
            set
            {
                switch (value)
                {
                    case "sea":
                        KnownRegion = PlatformRegionShard.PC_SEA;
                        District = value;
                        break;
                    case "sa":
                        KnownRegion = PlatformRegionShard.PC_SA;
                        District = value;
                        break;
                    case "na":
                        KnownRegion = PlatformRegionShard.PC_NA;
                        District = value;
                        break;
                    case "oc":
                        KnownRegion = PlatformRegionShard.PC_OC;
                        District = value;
                        break;
                    case "as":
                        KnownRegion = PlatformRegionShard.PC_AS;
                        District = value;
                        break;
                    case "krjp":
                        KnownRegion = PlatformRegionShard.PC_KRJP;
                        District = value;
                        break;
                    case "eu":
                        KnownRegion = PlatformRegionShard.PC_EU;
                        District = value;
                        break;
                }
            }
        }
        public PlatformRegionShard KnownRegion = PlatformRegionShard.Unknown;
        public string District;

        [JsonProperty("weatherName")]
        private string WeatherName
        {
            set
            {
                switch (value)
                {
                    case "Weather_Clear_02":
                        KnownWeather = Weather.SunnyClear;
                        Climate = value;
                        break;

                    case "Weather_Desert_Sunrise":
                        KnownWeather = Weather.Sunrise;
                        Climate = value;
                        break;

                    case "Weather_Desert_Clear":
                    case "Weather_Clear":
                        KnownWeather = Weather.Sunny;
                        Climate = value;
                        break;

                    case "Weather_Dark":
                        KnownWeather = Weather.Sunset;
                        Climate = value;
                        break;
                    default:
                        KnownWeather = Weather.Unknown;
                        Climate = value;
                        break;
                }
            }
        }
        public Weather KnownWeather = Weather.Unknown;
        /// <summary>
        /// The direct weather string from the ReplaySummary file
        /// </summary>
        public string Climate;

        [JsonProperty("playerStateSummaries")]
        public ReplaySummaryTeammate[] Teammates;
        public int NumTeammates
        {
            get
            {
                return Teammates.Length;
            }
        }
    }

    public class ReplaySummaryTeammate
    {
        [JsonProperty("playerName")]
        public string PlayerName;

        [JsonProperty("uniqueId")]
        public ulong PlayerID;

        [JsonProperty("teamNumber")]
        public int PlayerTeamID;

        public bool IsRecordingUser = false;

        [JsonProperty("ranking")]
        public int Ranking;

        [JsonProperty("headShots")]
        public int Headshots;

        [JsonProperty("numKills")]
        public int Kills;

        /// <summary>
        /// Longest kill by the player, in centimeters.
        /// </summary>
        [JsonProperty("longestDistanceKill")]
        public float LongestDistanceKillInCM;

        /// <summary>
        /// Longest kill by the player, in meters.
        /// </summary>
        public decimal LongestDistanceKillInM
        {
            get
            {
                return Decimal.Round(((decimal)LongestDistanceKillInCM / 100), 2);
            }
        }
        
        [JsonProperty("totalGivenDamages")]
        public float TotalGivenDamages;

        /// <summary>
        /// Total distance moved by the player, in meters.
        /// </summary>
        [JsonProperty("totalMovedDistanceMeter")]
        public float TotalMovedDistanceInM;

        /// <summary>
        /// Total distance moved by the player, in meters or kilometers.
        /// </summary>
        public string TotalMovedDistanceHumanReadable
        {
            get
            {
                if (TotalMovedDistanceInM > 1000)
                {
                    return Decimal.Round(((decimal)TotalMovedDistanceInM / 1000), 2) + " km";
                }
                else
                {
                    return Decimal.Round((decimal)TotalMovedDistanceInM, 2) + " m";
                }
            }
        }
    }
}