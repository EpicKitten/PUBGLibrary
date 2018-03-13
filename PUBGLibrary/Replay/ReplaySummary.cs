using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace PUBGLibrary
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
    /// A list of regions
    /// </summary>
    public enum Region
    {
        Unknown,
        NorthAmerica, //na - North America
        Europe, //eu - Europe
        KoreaJapan, //krjp - Korea/Japan
        Asia, //as - Asia
        Oceania, // oc - Oceania
        SouthAmerica, //sa - South and Central Amercia
        SouthAsia, //sea - South East Asia
        Kakao,  //Unknown but listed here Mar. 12 2018 5:12PM PST (https://web.archive.org/web/20180313000618/https://developer.playbattlegrounds.com/docs/en/making-requests.html
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
        private string regionName
        {
            set
            {
                switch (value)
                {
                    case "sea":
                        KnownRegion = Region.SouthAsia;
                        District = value;
                        break;
                    case "sa":
                        KnownRegion = Region.SouthAmerica;
                        District = value;
                        break;
                    case "na":
                        KnownRegion = Region.NorthAmerica;
                        District = value;
                        break;
                    case "oc":
                        KnownRegion = Region.Oceania;
                        District = value;
                        break;
                    case "as":
                        KnownRegion = Region.Asia;
                        District = value;
                        break;
                    case "krjp":
                        KnownRegion = Region.KoreaJapan;
                        District = value;
                        break;
                    case "eu":
                        KnownRegion = Region.Europe;
                        District = value;
                        break;
                    default:
                        KnownRegion = Region.Unknown;
                        District = value;
                        break;
                }
            }
        }
        public Region KnownRegion = Region.Unknown;
        public string District;

        [JsonProperty("weatherName")]
        private string weatherName
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