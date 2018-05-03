using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace PUBGLibrary.API
{
    /// <summary>
    /// Handles single and multi-match requests
    /// </summary>
    public class APIRequest
    {
        /// <summary>
        /// The match requested
        /// </summary>
        public APIMatch Match;
        /// <summary>
        /// The telemetry data from the requested match
        /// </summary>
        public APITelemetry Telemetry;
        /// <summary>
        /// If a exception happens during the request, it will be stored in this varible
        /// </summary>
        public WebException exception;
        public int RateLimit;
        public int RateLimitRemaining;
        public DateTimeOffset RateLimitReset;
        /// <summary>
        /// Requests a single match from the PUBG Developer API
        /// </summary>
        /// <param name="APIKey">The API Key to use during the request</param>
        /// <param name="PlatformRegion">The platform-region of the request (xbox-na, pc-oc, etc)</param>
        /// <param name="MatchID">The Match ID of the map</param>
        /// <returns>If null, the request failed</returns>
        /// 
        public APIRequest RequestSingleMatch(string APIKey, string PlatformRegion, string MatchID, bool DownloadTelemetryAutomatically )
        {
            APIStatus status = new APIStatus();
            APIRequest APIRequest = new APIRequest();
            if (status.bIsOnline)
            {
                try
                {
                    string APIURL = "https://api.playbattlegrounds.com/shards/" + PlatformRegion + "/matches/" + MatchID;
                    var webRequest = WebRequest.Create(APIURL);
                    var HTTPAPIRequest = (HttpWebRequest)webRequest;
                    HTTPAPIRequest.PreAuthenticate = true;
                    HTTPAPIRequest.Headers.Add("Authorization", "Bearer " + APIKey);
                    HTTPAPIRequest.Headers.Add("Access-Control-Allow-Origins", "*");
                    HTTPAPIRequest.Headers.Add("Access-Control-Expose-Headers", "Content-Length");
                    HTTPAPIRequest.Accept = "application/json";
                    using (var APIResponse = HTTPAPIRequest.GetResponse())
                    {
                        using (var responseStream = APIResponse.GetResponseStream())
                        {
                            var myStreamReader = new StreamReader(responseStream, Encoding.Default);
                            
                            APIRequest.Match = MatchPhraser(myStreamReader.ReadToEnd());

                            if ( DownloadTelemetryAutomatically )
                            {
                                using ( WebClient client = new WebClient() )
                                {
                                    APIRequest.Telemetry = TelemetryPhraser( client.DownloadString( APIRequest.Match.TelemetryURL ) );
                                }
                            }
                            else
                            {
                                APIRequest.Telemetry = new APITelemetry();
                            }
                            APIRequest.RateLimit = int.Parse( APIResponse.Headers.GetValues( "X-Ratelimit-Limit" )[0] );
                            APIRequest.RateLimitReset = Utils.Utils.UnixTimestampToDateTime( double.Parse( APIResponse.Headers.GetValues( "X-Ratelimit-Reset" )[0] ) );
                            APIRequest.RateLimitRemaining = int.Parse( APIResponse.Headers.GetValues( "X-Ratelimit-Remaining" )[0] );
                            return APIRequest;
                        }
                    }
                }
                catch (WebException e)
                {
                    APIRequest = new APIRequest
                    {
                        exception = e
                    };
                    return APIRequest;
                }
            }
            return APIRequest;
        }
        /// <summary>
        /// Request a single or multiple users from the PUBG Developer API
        /// </summary>
        /// <param name="APIKey">The API key to use during the request</param>
        /// <param name="PlatformRegion">The Platform-Region to search (i.e pc-na, xbox-eu)</param>
        /// <param name="ID">The list of PUBG Names or AccountIDs to search, max is 6</param>
        /// <param name="SearchType"></param>
        /// <returns></returns>
        public List<APIUser> RequestUser(string APIKey, string PlatformRegion, List<string> ID, UserSearchType SearchType = UserSearchType.PUBGName)
        {
            string filterstring = string.Empty;
            switch (SearchType)
            {
                case UserSearchType.PUBGName:
                    filterstring = "?filter[playerNames]=";
                    break;
                case UserSearchType.AccountID:
                    filterstring = "?filter[playerIds]=";
                    break;
            }
            List<APIUser> users = new List<APIUser>();
            APIStatus status = new APIStatus();
            if (status.bIsOnline)
            {
                try
                {
                    string APIURL = "https://api.playbattlegrounds.com/shards/" + PlatformRegion + "/players" + filterstring + string.Join(",", ID.ToArray());
                    var webRequest = WebRequest.Create(APIURL);
                    var HTTPAPIRequest = (HttpWebRequest)webRequest;
                    HTTPAPIRequest.PreAuthenticate = true;
                    HTTPAPIRequest.Headers.Add("Authorization", "Bearer " + APIKey);
                    HTTPAPIRequest.Headers.Add("Access-Control-Allow-Origins", "*");
                    HTTPAPIRequest.Headers.Add("Access-Control-Expose-Headers", "Content-Length");
                    HTTPAPIRequest.Accept = "application/json";
                    using (var APIResponse = HTTPAPIRequest.GetResponse())
                    {
                        using (var responseStream = APIResponse.GetResponseStream())
                        {
                            var myStreamReader = new StreamReader(responseStream, Encoding.Default);
                            foreach (JObject jsonuser in JObject.Parse(myStreamReader.ReadToEnd())["data"])
                            {
                                users.Add(UserPhraser(jsonuser));
                            }
                        }
                    }
                }
                catch (WebException e)
                {
                    APIUser user = new APIUser
                    {
                        WebException = e
                    };
                    users.Add(user);
                }
            }
            return users;
        }
        public List<string> RequestSamples(string APIKey, string PlatformRegion)
        {
            APIStatus status = new APIStatus();
            List<string> MatchList = new List<string>();
            if (status.bIsOnline)
            {

                try
                {
                    string APIURL = "https://api.playbattlegrounds.com/shards/" + PlatformRegion + "/samples";
                    var webRequest = WebRequest.Create(APIURL);
                    var HTTPAPIRequest = (HttpWebRequest)webRequest;
                    HTTPAPIRequest.PreAuthenticate = true;
                    HTTPAPIRequest.Headers.Add("Authorization", "Bearer " + APIKey);
                    HTTPAPIRequest.Headers.Add("Access-Control-Allow-Origins", "*");
                    HTTPAPIRequest.Headers.Add("Access-Control-Expose-Headers", "Content-Length");
                    HTTPAPIRequest.Accept = "application/json";
                    using (var APIResponse = HTTPAPIRequest.GetResponse())
                    {
                        using (var responseStream = APIResponse.GetResponseStream())
                        {
                            var myStreamReader = new StreamReader(responseStream, Encoding.Default);
                            
                            foreach (JObject matchitem in JObject.Parse(myStreamReader.ReadToEnd())["data"]["relationships"]["matches"]["data"])
                            {
                                MatchList.Add((string)matchitem["id"]);
                            }
                            return MatchList;
                        }
                    }
                }
                catch (WebException e)
                {
                    APIUser user = new APIUser
                    {
                        WebException = e
                    };
                }
            }
            return MatchList;
        }
        public List<APISeason> RequestRegionSeasons(string APIKey, string PlatformRegion)
        {
            APIStatus status = new APIStatus();
            List<APISeason> SeasonList = new List<APISeason>();
            if (status.bIsOnline)
            {

                try
                {
                    string APIURL = "https://api.playbattlegrounds.com/shards/" + PlatformRegion + "/seasons";
                    var webRequest = WebRequest.Create(APIURL);
                    var HTTPAPIRequest = (HttpWebRequest)webRequest;
                    HTTPAPIRequest.PreAuthenticate = true;
                    HTTPAPIRequest.Headers.Add("Authorization", "Bearer " + APIKey);
                    HTTPAPIRequest.Headers.Add("Access-Control-Allow-Origins", "*");
                    HTTPAPIRequest.Headers.Add("Access-Control-Expose-Headers", "Content-Length");
                    HTTPAPIRequest.Accept = "application/json";
                    using (var APIResponse = HTTPAPIRequest.GetResponse())
                    {
                        using (var responseStream = APIResponse.GetResponseStream())
                        {
                            var myStreamReader = new StreamReader(responseStream, Encoding.Default);
                            foreach (JObject seasonitem in JObject.Parse(myStreamReader.ReadToEnd())["data"])
                            {
                                SeasonList.Add(new APISeason() {
                                    SeasonType = (string)seasonitem["type"],
                                    SeasonName = (string)seasonitem["id"],
                                    isCurrentSeason = (bool)seasonitem["attributes"]["isCurrentSeason"],
                                    isOffseason = (bool)seasonitem["attributes"]["isOffseason"]
                                });
                            }
                            return SeasonList;
                        }
                    }
                }
                catch (WebException e)
                {
                    APIUser user = new APIUser
                    {
                        WebException = e
                    };
                }
            }
            return SeasonList;
        }
        public APIPlayerSeason RequestPlayerSeason(string APIKey, string AccountID, string SeasonName, string PlatformRegion)
        {
            APIStatus status = new APIStatus();
            APIPlayerSeason PlayerSeason = new APIPlayerSeason();
            if (status.bIsOnline)
            {

                try
                {
                    string APIURL = "https://api.playbattlegrounds.com/shards/" + PlatformRegion + "/players/" + AccountID + "/seasons/" + SeasonName;
                    var webRequest = WebRequest.Create(APIURL);
                    var HTTPAPIRequest = (HttpWebRequest)webRequest;
                    HTTPAPIRequest.PreAuthenticate = true;
                    HTTPAPIRequest.Headers.Add("Authorization", "Bearer " + APIKey);
                    HTTPAPIRequest.Headers.Add("Access-Control-Allow-Origins", "*");
                    HTTPAPIRequest.Headers.Add("Access-Control-Expose-Headers", "Content-Length");
                    HTTPAPIRequest.Accept = "application/json";
                    using (var APIResponse = HTTPAPIRequest.GetResponse())
                    {
                        using (var responseStream = APIResponse.GetResponseStream())
                        {
                            var myStreamReader = new StreamReader(responseStream, Encoding.Default);
                            JObject stats = JObject.Parse(myStreamReader.ReadToEnd());
                            PlayerSeason.Duo = new APIPlayerSeasonStats()
                            {
                                Assists = (int)stats["data"]["attributes"]["gameModeStats"]["duo"]["assists"],
                                Boosts = (int)stats["data"]["attributes"]["gameModeStats"]["duo"]["boosts"],
                                DBNOs = (int)stats["data"]["attributes"]["gameModeStats"]["duo"]["dBNOs"],
                                DailyKills = (int)stats["data"]["attributes"]["gameModeStats"]["duo"]["dailyKills"],
                                DamageDealt = (double)stats["data"]["attributes"]["gameModeStats"]["duo"]["damageDealt"],
                                Days = (int)stats["data"]["attributes"]["gameModeStats"]["duo"]["days"],
                                HeadshotKills = (int)stats["data"]["attributes"]["gameModeStats"]["duo"]["headshotKills"],
                                Heals = (int)stats["data"]["attributes"]["gameModeStats"]["duo"]["heals"],
                                KillPoints = (double)stats["data"]["attributes"]["gameModeStats"]["duo"]["killPoints"],
                                Kills = (int)stats["data"]["attributes"]["gameModeStats"]["duo"]["kills"],
                                LongestKill = (double)stats["data"]["attributes"]["gameModeStats"]["duo"]["longestKill"],
                                LongestTimeSurvived = (double)stats["data"]["attributes"]["gameModeStats"]["duo"]["longestTimeSurvived"],
                                Losses = (int)stats["data"]["attributes"]["gameModeStats"]["duo"]["losses"],
                                MaxKillStreaks = (int)stats["data"]["attributes"]["gameModeStats"]["duo"]["maxKillStreaks"],
                                MostSurvivalTime = (double)stats["data"]["attributes"]["gameModeStats"]["duo"]["mostSurvivalTime"],
                                Revives = (int)stats["data"]["attributes"]["gameModeStats"]["duo"]["revives"],
                                RideDistance = (double)stats["data"]["attributes"]["gameModeStats"]["duo"]["rideDistance"],
                                RoadKills = (int)stats["data"]["attributes"]["gameModeStats"]["duo"]["roadKills"],
                                RoundMostKills = (int)stats["data"]["attributes"]["gameModeStats"]["duo"]["roundMostKills"],
                                RoundsPlayed = (int)stats["data"]["attributes"]["gameModeStats"]["duo"]["roundsPlayed"],
                                Suicides = (int)stats["data"]["attributes"]["gameModeStats"]["duo"]["suicides"],
                                TeamKills = (int)stats["data"]["attributes"]["gameModeStats"]["duo"]["teamKills"],
                                TimeSurvived = (double)stats["data"]["attributes"]["gameModeStats"]["duo"]["timeSurvived"],
                                Top10s = (int)stats["data"]["attributes"]["gameModeStats"]["duo"]["top10s"],
                                VehicleDestroys = (int)stats["data"]["attributes"]["gameModeStats"]["duo"]["vehicleDestroys"],
                                WalkDistance = (double)stats["data"]["attributes"]["gameModeStats"]["duo"]["walkDistance"],
                                WeaponsAcquired = (int)stats["data"]["attributes"]["gameModeStats"]["duo"]["weaponsAcquired"],
                                WeeklyKills = (int)stats["data"]["attributes"]["gameModeStats"]["duo"]["weeklyKills"],
                                WinPoints = (double)stats["data"]["attributes"]["gameModeStats"]["duo"]["winPoints"],
                                Wins = (int)stats["data"]["attributes"]["gameModeStats"]["duo"]["wins"],

                            };
                            PlayerSeason.Duo_FPP = new APIPlayerSeasonStats()
                            {
                                Assists = (int)stats["data"]["attributes"]["gameModeStats"]["duo-fpp"]["assists"],
                                Boosts = (int)stats["data"]["attributes"]["gameModeStats"]["duo-fpp"]["boosts"],
                                DBNOs = (int)stats["data"]["attributes"]["gameModeStats"]["duo-fpp"]["dBNOs"],
                                DailyKills = (int)stats["data"]["attributes"]["gameModeStats"]["duo-fpp"]["dailyKills"],
                                DamageDealt = (double)stats["data"]["attributes"]["gameModeStats"]["duo-fpp"]["damageDealt"],
                                Days = (int)stats["data"]["attributes"]["gameModeStats"]["duo-fpp"]["days"],
                                HeadshotKills = (int)stats["data"]["attributes"]["gameModeStats"]["duo-fpp"]["headshotKills"],
                                Heals = (int)stats["data"]["attributes"]["gameModeStats"]["duo-fpp"]["heals"],
                                KillPoints = (double)stats["data"]["attributes"]["gameModeStats"]["duo-fpp"]["killPoints"],
                                Kills = (int)stats["data"]["attributes"]["gameModeStats"]["duo-fpp"]["kills"],
                                LongestKill = (double)stats["data"]["attributes"]["gameModeStats"]["duo-fpp"]["longestKill"],
                                LongestTimeSurvived = (double)stats["data"]["attributes"]["gameModeStats"]["duo-fpp"]["longestTimeSurvived"],
                                Losses = (int)stats["data"]["attributes"]["gameModeStats"]["duo-fpp"]["losses"],
                                MaxKillStreaks = (int)stats["data"]["attributes"]["gameModeStats"]["duo-fpp"]["maxKillStreaks"],
                                MostSurvivalTime = (double)stats["data"]["attributes"]["gameModeStats"]["duo-fpp"]["mostSurvivalTime"],
                                Revives = (int)stats["data"]["attributes"]["gameModeStats"]["duo-fpp"]["revives"],
                                RideDistance = (double)stats["data"]["attributes"]["gameModeStats"]["duo-fpp"]["rideDistance"],
                                RoadKills = (int)stats["data"]["attributes"]["gameModeStats"]["duo-fpp"]["roadKills"],
                                RoundMostKills = (int)stats["data"]["attributes"]["gameModeStats"]["duo-fpp"]["roundMostKills"],
                                RoundsPlayed = (int)stats["data"]["attributes"]["gameModeStats"]["duo-fpp"]["roundsPlayed"],
                                Suicides = (int)stats["data"]["attributes"]["gameModeStats"]["duo-fpp"]["suicides"],
                                TeamKills = (int)stats["data"]["attributes"]["gameModeStats"]["duo-fpp"]["teamKills"],
                                TimeSurvived = (double)stats["data"]["attributes"]["gameModeStats"]["duo-fpp"]["timeSurvived"],
                                Top10s = (int)stats["data"]["attributes"]["gameModeStats"]["duo-fpp"]["top10s"],
                                VehicleDestroys = (int)stats["data"]["attributes"]["gameModeStats"]["duo-fpp"]["vehicleDestroys"],
                                WalkDistance = (double)stats["data"]["attributes"]["gameModeStats"]["duo-fpp"]["walkDistance"],
                                WeaponsAcquired = (int)stats["data"]["attributes"]["gameModeStats"]["duo-fpp"]["weaponsAcquired"],
                                WeeklyKills = (int)stats["data"]["attributes"]["gameModeStats"]["duo-fpp"]["weeklyKills"],
                                WinPoints = (double)stats["data"]["attributes"]["gameModeStats"]["duo-fpp"]["winPoints"],
                                Wins = (int)stats["data"]["attributes"]["gameModeStats"]["duo-fpp"]["wins"],
                            };
                            PlayerSeason.Solo = new APIPlayerSeasonStats()
                            {
                                Assists = (int)stats["data"]["attributes"]["gameModeStats"]["solo"]["assists"],
                                Boosts = (int)stats["data"]["attributes"]["gameModeStats"]["solo"]["boosts"],
                                DBNOs = (int)stats["data"]["attributes"]["gameModeStats"]["solo"]["dBNOs"],
                                DailyKills = (int)stats["data"]["attributes"]["gameModeStats"]["solo"]["dailyKills"],
                                DamageDealt = (double)stats["data"]["attributes"]["gameModeStats"]["solo"]["damageDealt"],
                                Days = (int)stats["data"]["attributes"]["gameModeStats"]["solo"]["days"],
                                HeadshotKills = (int)stats["data"]["attributes"]["gameModeStats"]["solo"]["headshotKills"],
                                Heals = (int)stats["data"]["attributes"]["gameModeStats"]["solo"]["heals"],
                                KillPoints = (double)stats["data"]["attributes"]["gameModeStats"]["solo"]["killPoints"],
                                Kills = (int)stats["data"]["attributes"]["gameModeStats"]["solo"]["kills"],
                                LongestKill = (double)stats["data"]["attributes"]["gameModeStats"]["solo"]["longestKill"],
                                LongestTimeSurvived = (double)stats["data"]["attributes"]["gameModeStats"]["solo"]["longestTimeSurvived"],
                                Losses = (int)stats["data"]["attributes"]["gameModeStats"]["solo"]["losses"],
                                MaxKillStreaks = (int)stats["data"]["attributes"]["gameModeStats"]["solo"]["maxKillStreaks"],
                                MostSurvivalTime = (double)stats["data"]["attributes"]["gameModeStats"]["solo"]["mostSurvivalTime"],
                                Revives = (int)stats["data"]["attributes"]["gameModeStats"]["solo"]["revives"],
                                RideDistance = (double)stats["data"]["attributes"]["gameModeStats"]["solo"]["rideDistance"],
                                RoadKills = (int)stats["data"]["attributes"]["gameModeStats"]["solo"]["roadKills"],
                                RoundMostKills = (int)stats["data"]["attributes"]["gameModeStats"]["solo"]["roundMostKills"],
                                RoundsPlayed = (int)stats["data"]["attributes"]["gameModeStats"]["solo"]["roundsPlayed"],
                                Suicides = (int)stats["data"]["attributes"]["gameModeStats"]["solo"]["suicides"],
                                TeamKills = (int)stats["data"]["attributes"]["gameModeStats"]["solo"]["teamKills"],
                                TimeSurvived = (double)stats["data"]["attributes"]["gameModeStats"]["solo"]["timeSurvived"],
                                Top10s = (int)stats["data"]["attributes"]["gameModeStats"]["solo"]["top10s"],
                                VehicleDestroys = (int)stats["data"]["attributes"]["gameModeStats"]["solo"]["vehicleDestroys"],
                                WalkDistance = (double)stats["data"]["attributes"]["gameModeStats"]["solo"]["walkDistance"],
                                WeaponsAcquired = (int)stats["data"]["attributes"]["gameModeStats"]["solo"]["weaponsAcquired"],
                                WeeklyKills = (int)stats["data"]["attributes"]["gameModeStats"]["solo"]["weeklyKills"],
                                WinPoints = (double)stats["data"]["attributes"]["gameModeStats"]["solo"]["winPoints"],
                                Wins = (int)stats["data"]["attributes"]["gameModeStats"]["solo"]["wins"],
                            };
                            PlayerSeason.Solo_FPP = new APIPlayerSeasonStats()
                            {
                                Assists = (int)stats["data"]["attributes"]["gameModeStats"]["solo-fpp"]["assists"],
                                Boosts = (int)stats["data"]["attributes"]["gameModeStats"]["solo-fpp"]["boosts"],
                                DBNOs = (int)stats["data"]["attributes"]["gameModeStats"]["solo-fpp"]["dBNOs"],
                                DailyKills = (int)stats["data"]["attributes"]["gameModeStats"]["solo-fpp"]["dailyKills"],
                                DamageDealt = (double)stats["data"]["attributes"]["gameModeStats"]["solo-fpp"]["damageDealt"],
                                Days = (int)stats["data"]["attributes"]["gameModeStats"]["solo-fpp"]["days"],
                                HeadshotKills = (int)stats["data"]["attributes"]["gameModeStats"]["solo-fpp"]["headshotKills"],
                                Heals = (int)stats["data"]["attributes"]["gameModeStats"]["solo-fpp"]["heals"],
                                KillPoints = (double)stats["data"]["attributes"]["gameModeStats"]["solo-fpp"]["killPoints"],
                                Kills = (int)stats["data"]["attributes"]["gameModeStats"]["solo-fpp"]["kills"],
                                LongestKill = (double)stats["data"]["attributes"]["gameModeStats"]["solo-fpp"]["longestKill"],
                                LongestTimeSurvived = (double)stats["data"]["attributes"]["gameModeStats"]["solo-fpp"]["longestTimeSurvived"],
                                Losses = (int)stats["data"]["attributes"]["gameModeStats"]["solo-fpp"]["losses"],
                                MaxKillStreaks = (int)stats["data"]["attributes"]["gameModeStats"]["solo-fpp"]["maxKillStreaks"],
                                MostSurvivalTime = (double)stats["data"]["attributes"]["gameModeStats"]["solo-fpp"]["mostSurvivalTime"],
                                Revives = (int)stats["data"]["attributes"]["gameModeStats"]["solo-fpp"]["revives"],
                                RideDistance = (double)stats["data"]["attributes"]["gameModeStats"]["solo-fpp"]["rideDistance"],
                                RoadKills = (int)stats["data"]["attributes"]["gameModeStats"]["solo-fpp"]["roadKills"],
                                RoundMostKills = (int)stats["data"]["attributes"]["gameModeStats"]["solo-fpp"]["roundMostKills"],
                                RoundsPlayed = (int)stats["data"]["attributes"]["gameModeStats"]["solo-fpp"]["roundsPlayed"],
                                Suicides = (int)stats["data"]["attributes"]["gameModeStats"]["solo-fpp"]["suicides"],
                                TeamKills = (int)stats["data"]["attributes"]["gameModeStats"]["solo-fpp"]["teamKills"],
                                TimeSurvived = (double)stats["data"]["attributes"]["gameModeStats"]["solo-fpp"]["timeSurvived"],
                                Top10s = (int)stats["data"]["attributes"]["gameModeStats"]["solo-fpp"]["top10s"],
                                VehicleDestroys = (int)stats["data"]["attributes"]["gameModeStats"]["solo-fpp"]["vehicleDestroys"],
                                WalkDistance = (double)stats["data"]["attributes"]["gameModeStats"]["solo-fpp"]["walkDistance"],
                                WeaponsAcquired = (int)stats["data"]["attributes"]["gameModeStats"]["solo-fpp"]["weaponsAcquired"],
                                WeeklyKills = (int)stats["data"]["attributes"]["gameModeStats"]["solo-fpp"]["weeklyKills"],
                                WinPoints = (double)stats["data"]["attributes"]["gameModeStats"]["solo-fpp"]["winPoints"],
                                Wins = (int)stats["data"]["attributes"]["gameModeStats"]["solo-fpp"]["wins"],
                            };
                            PlayerSeason.Squad = new APIPlayerSeasonStats()
                            {
                                Assists = (int)stats["data"]["attributes"]["gameModeStats"]["squad"]["assists"],
                                Boosts = (int)stats["data"]["attributes"]["gameModeStats"]["squad"]["boosts"],
                                DBNOs = (int)stats["data"]["attributes"]["gameModeStats"]["squad"]["dBNOs"],
                                DailyKills = (int)stats["data"]["attributes"]["gameModeStats"]["squad"]["dailyKills"],
                                DamageDealt = (double)stats["data"]["attributes"]["gameModeStats"]["squad"]["damageDealt"],
                                Days = (int)stats["data"]["attributes"]["gameModeStats"]["squad"]["days"],
                                HeadshotKills = (int)stats["data"]["attributes"]["gameModeStats"]["squad"]["headshotKills"],
                                Heals = (int)stats["data"]["attributes"]["gameModeStats"]["squad"]["heals"],
                                KillPoints = (double)stats["data"]["attributes"]["gameModeStats"]["squad"]["killPoints"],
                                Kills = (int)stats["data"]["attributes"]["gameModeStats"]["squad"]["kills"],
                                LongestKill = (double)stats["data"]["attributes"]["gameModeStats"]["squad"]["longestKill"],
                                LongestTimeSurvived = (double)stats["data"]["attributes"]["gameModeStats"]["squad"]["longestTimeSurvived"],
                                Losses = (int)stats["data"]["attributes"]["gameModeStats"]["squad"]["losses"],
                                MaxKillStreaks = (int)stats["data"]["attributes"]["gameModeStats"]["squad"]["maxKillStreaks"],
                                MostSurvivalTime = (double)stats["data"]["attributes"]["gameModeStats"]["squad"]["mostSurvivalTime"],
                                Revives = (int)stats["data"]["attributes"]["gameModeStats"]["squad"]["revives"],
                                RideDistance = (double)stats["data"]["attributes"]["gameModeStats"]["squad"]["rideDistance"],
                                RoadKills = (int)stats["data"]["attributes"]["gameModeStats"]["squad"]["roadKills"],
                                RoundMostKills = (int)stats["data"]["attributes"]["gameModeStats"]["squad"]["roundMostKills"],
                                RoundsPlayed = (int)stats["data"]["attributes"]["gameModeStats"]["squad"]["roundsPlayed"],
                                Suicides = (int)stats["data"]["attributes"]["gameModeStats"]["squad"]["suicides"],
                                TeamKills = (int)stats["data"]["attributes"]["gameModeStats"]["squad"]["teamKills"],
                                TimeSurvived = (double)stats["data"]["attributes"]["gameModeStats"]["squad"]["timeSurvived"],
                                Top10s = (int)stats["data"]["attributes"]["gameModeStats"]["squad"]["top10s"],
                                VehicleDestroys = (int)stats["data"]["attributes"]["gameModeStats"]["squad"]["vehicleDestroys"],
                                WalkDistance = (double)stats["data"]["attributes"]["gameModeStats"]["squad"]["walkDistance"],
                                WeaponsAcquired = (int)stats["data"]["attributes"]["gameModeStats"]["squad"]["weaponsAcquired"],
                                WeeklyKills = (int)stats["data"]["attributes"]["gameModeStats"]["squad"]["weeklyKills"],
                                WinPoints = (double)stats["data"]["attributes"]["gameModeStats"]["squad"]["winPoints"],
                                Wins = (int)stats["data"]["attributes"]["gameModeStats"]["squad"]["wins"],
                            };
                            PlayerSeason.Squad_FPP = new APIPlayerSeasonStats()
                            {
                                Assists = (int)stats["data"]["attributes"]["gameModeStats"]["squad-fpp"]["assists"],
                                Boosts = (int)stats["data"]["attributes"]["gameModeStats"]["squad-fpp"]["boosts"],
                                DBNOs = (int)stats["data"]["attributes"]["gameModeStats"]["squad-fpp"]["dBNOs"],
                                DailyKills = (int)stats["data"]["attributes"]["gameModeStats"]["squad-fpp"]["dailyKills"],
                                DamageDealt = (double)stats["data"]["attributes"]["gameModeStats"]["squad-fpp"]["damageDealt"],
                                Days = (int)stats["data"]["attributes"]["gameModeStats"]["squad-fpp"]["days"],
                                HeadshotKills = (int)stats["data"]["attributes"]["gameModeStats"]["squad-fpp"]["headshotKills"],
                                Heals = (int)stats["data"]["attributes"]["gameModeStats"]["squad-fpp"]["heals"],
                                KillPoints = (double)stats["data"]["attributes"]["gameModeStats"]["squad-fpp"]["killPoints"],
                                Kills = (int)stats["data"]["attributes"]["gameModeStats"]["squad-fpp"]["kills"],
                                LongestKill = (double)stats["data"]["attributes"]["gameModeStats"]["squad-fpp"]["longestKill"],
                                LongestTimeSurvived = (double)stats["data"]["attributes"]["gameModeStats"]["squad-fpp"]["longestTimeSurvived"],
                                Losses = (int)stats["data"]["attributes"]["gameModeStats"]["squad-fpp"]["losses"],
                                MaxKillStreaks = (int)stats["data"]["attributes"]["gameModeStats"]["squad-fpp"]["maxKillStreaks"],
                                MostSurvivalTime = (double)stats["data"]["attributes"]["gameModeStats"]["squad-fpp"]["mostSurvivalTime"],
                                Revives = (int)stats["data"]["attributes"]["gameModeStats"]["squad-fpp"]["revives"],
                                RideDistance = (double)stats["data"]["attributes"]["gameModeStats"]["squad-fpp"]["rideDistance"],
                                RoadKills = (int)stats["data"]["attributes"]["gameModeStats"]["squad-fpp"]["roadKills"],
                                RoundMostKills = (int)stats["data"]["attributes"]["gameModeStats"]["squad-fpp"]["roundMostKills"],
                                RoundsPlayed = (int)stats["data"]["attributes"]["gameModeStats"]["squad-fpp"]["roundsPlayed"],
                                Suicides = (int)stats["data"]["attributes"]["gameModeStats"]["squad-fpp"]["suicides"],
                                TeamKills = (int)stats["data"]["attributes"]["gameModeStats"]["squad-fpp"]["teamKills"],
                                TimeSurvived = (double)stats["data"]["attributes"]["gameModeStats"]["squad-fpp"]["timeSurvived"],
                                Top10s = (int)stats["data"]["attributes"]["gameModeStats"]["squad-fpp"]["top10s"],
                                VehicleDestroys = (int)stats["data"]["attributes"]["gameModeStats"]["squad-fpp"]["vehicleDestroys"],
                                WalkDistance = (double)stats["data"]["attributes"]["gameModeStats"]["squad-fpp"]["walkDistance"],
                                WeaponsAcquired = (int)stats["data"]["attributes"]["gameModeStats"]["squad-fpp"]["weaponsAcquired"],
                                WeeklyKills = (int)stats["data"]["attributes"]["gameModeStats"]["squad-fpp"]["weeklyKills"],
                                WinPoints = (double)stats["data"]["attributes"]["gameModeStats"]["squad-fpp"]["winPoints"],
                                Wins = (int)stats["data"]["attributes"]["gameModeStats"]["squad-fpp"]["wins"],
                            };
                            PlayerSeason.Squad_Matches = new List<string>() { };
                            foreach (JObject matchitem in stats["data"]["relationships"]["matchesSquad"]["data"])
                            {
                               PlayerSeason.Squad_Matches.Add((string)matchitem["id"]);
                            }
                            PlayerSeason.Squad_FPP_Matches = new List<string>() { };
                            foreach (JObject matchitem in stats["data"]["relationships"]["matchesSquadFPP"]["data"])
                            {
                                PlayerSeason.Squad_FPP_Matches.Add((string)matchitem["id"]);
                            }
                            PlayerSeason.Solo_Matches = new List<string>() { };
                            foreach (JObject matchitem in stats["data"]["relationships"]["matchesSolo"]["data"])
                            {
                                PlayerSeason.Solo_Matches.Add((string)matchitem["id"]);
                            }
                            PlayerSeason.Solo_FPP_Matches = new List<string>() { };
                            foreach (JObject matchitem in stats["data"]["relationships"]["matchesSoloFPP"]["data"])
                            {
                                PlayerSeason.Solo_FPP_Matches.Add((string)matchitem["id"]);
                            }
                            PlayerSeason.Duo_Matches = new List<string>() { };
                            foreach (JObject matchitem in stats["data"]["relationships"]["matchesDuo"]["data"])
                            {
                                PlayerSeason.Duo_Matches.Add((string)matchitem["id"]);
                            }
                            PlayerSeason.Duo_FPP_Matches = new List<string>() { };
                            foreach (JObject matchitem in stats["data"]["relationships"]["matchesDuoFPP"]["data"])
                            {
                                PlayerSeason.Duo_FPP_Matches.Add((string)matchitem["id"]);
                            }
                            return PlayerSeason;
                        }
                    }
                }
                catch (WebException e)
                {
                    APIUser user = new APIUser
                    {
                        WebException = e
                    };
                }
            }
            return PlayerSeason;
        }
        /// <summary>
        /// Parses the match JSON string from the API
        /// </summary>
        /// <param name="JSONstring">The match JSON string to parse</param>
        /// <returns></returns>
        public APIMatch MatchPhraser(string JSONstring)
        {
            var jsonmatch = Phraser.FromJson(JSONstring);
            APIMatch Match = new APIMatch
            {
                BaseJSON = JSONstring,
                MatchID = jsonmatch.Data.Id,
                MapName = jsonmatch.Data.Attributes.MapName,
                Gamemode = jsonmatch.Data.Attributes.GameMode,
                Duration = (int)jsonmatch.Data.Attributes.Duration
            };
            foreach (var item in jsonmatch.Included)
            {
                if (item.Type == DatumType.Participant)
                {
                    if (item.Attributes.Stats != null)
                    {
                        APIPlayer player = new APIPlayer();
                        player = item.Attributes.Stats;
                        Match.PlayerList.Add(player);
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
                        Match.TeamList.Add(team);
                    }
                }
                if (item.Type == DatumType.Asset)
                {
                    if (item.Attributes.Url != null)
                    {
                        if (item.Attributes.Name == "telemetry")
                        {
                            Match.TelemetryURL = item.Attributes.Url;
                        }
                    }
                }

            }
            return Match;
        }
        /// <summary>
        /// Parses the telemetry JSON string from the API
        /// </summary>
        /// <param name="JSONstring">The telemetry JSON string to parse</param>
        /// <returns></returns>
        public APITelemetry TelemetryPhraser(string JSONstring)
        {
            var jsontelemetry = TelemetryPhrase.FromJson(JSONstring);
            APITelemetry Telemetry = new APITelemetry
            {
                BaseJSON = JSONstring
            };
            foreach (TelemetryPhrase telem in jsontelemetry)
            {
                switch (telem.T)
                {   
                    case T.LogCarePackageLand:
                        LogCarePackageLand logCarePackageLand = new LogCarePackageLand();
                        logCarePackageLand.CarePackage.CarePackageID = telem.ItemPackage.ItemPackageId;
                        logCarePackageLand.CarePackage.DateTimeOffset = (DateTimeOffset)telem.D;
                        foreach (ChildItem childitem in telem.ItemPackage.Items)
                        {
                            Item item = new Item
                            {
                                Categroy = childitem.Category,
                                ItemID = childitem.ItemId,
                                StackCount = (int)childitem.StackCount,
                                SubCategroy = childitem.SubCategory
                            };
                            logCarePackageLand.CarePackage.Items.Add(item);
                        }
                        logCarePackageLand.CarePackage.Position.X = (double)telem.ItemPackage.Position.X;
                        logCarePackageLand.CarePackage.Position.Y = (double)telem.ItemPackage.Position.Y;
                        logCarePackageLand.CarePackage.Position.Z = (double)telem.ItemPackage.Position.Z;
                        Telemetry.LogCarePackageLandList.Add(logCarePackageLand);
                        break;
                    case T.LogCarePackageSpawn:
                        LogCarePackageSpawn logCarePackageSpawn = new LogCarePackageSpawn();
                        logCarePackageSpawn.CarePackage.CarePackageID = telem.ItemPackage.ItemPackageId;
                        logCarePackageSpawn.CarePackage.DateTimeOffset = (DateTimeOffset)telem.D;
                        foreach (ChildItem childitem in telem.ItemPackage.Items)
                        {
                            Item item = new Item
                            {
                                Categroy = childitem.Category,
                                ItemID = childitem.ItemId,
                                StackCount = (int)childitem.StackCount,
                                SubCategroy = childitem.SubCategory
                            };
                            logCarePackageSpawn.CarePackage.Items.Add(item);
                        }
                        logCarePackageSpawn.CarePackage.Position.X = (double)telem.ItemPackage.Position.X;
                        logCarePackageSpawn.CarePackage.Position.Y = (double)telem.ItemPackage.Position.Y;
                        logCarePackageSpawn.CarePackage.Position.Z = (double)telem.ItemPackage.Position.Z;
                        Telemetry.LogCarePackageSpawnList.Add(logCarePackageSpawn);
                        break;
                    case T.LogGameStatePeriodic:
                        LogGameStatePeriodic logGameStatePeriodic = new LogGameStatePeriodic();
                        logGameStatePeriodic.GameState.ElapsedTime = (int)telem.GameState.ElapsedTime;
                        logGameStatePeriodic.GameState.NumAlivePlayers = (int)telem.GameState.NumAlivePlayers;
                        logGameStatePeriodic.GameState.NumAliveTeams = (int)telem.GameState.NumAliveTeams;
                        logGameStatePeriodic.GameState.NumJoinPlayers = (int)telem.GameState.NumJoinPlayers;
                        logGameStatePeriodic.GameState.NumStartPlayers = (int)telem.GameState.NumStartPlayers;
                        logGameStatePeriodic.GameState.SafeZone.X = (double)telem.GameState.SafetyZonePosition.X;
                        logGameStatePeriodic.GameState.SafeZone.Y = (double)telem.GameState.SafetyZonePosition.Y;
                        logGameStatePeriodic.GameState.SafeZone.Z = (double)telem.GameState.SafetyZonePosition.Z;
                        logGameStatePeriodic.GameState.SafeZone.Radius = (double)telem.GameState.SafetyZoneRadius;
                        logGameStatePeriodic.GameState.RedZone.X = (double)telem.GameState.RedZonePosition.X;
                        logGameStatePeriodic.GameState.RedZone.Y = (double)telem.GameState.RedZonePosition.Y;
                        logGameStatePeriodic.GameState.RedZone.Z = (double)telem.GameState.RedZonePosition.Z;
                        logGameStatePeriodic.GameState.RedZone.Radius = (double)telem.GameState.RedZoneRadius;
                        logGameStatePeriodic.GameState.BlueZone.X = (double)telem.GameState.PoisonGasWarningPosition.X;
                        logGameStatePeriodic.GameState.BlueZone.Y = (double)telem.GameState.PoisonGasWarningPosition.Y;
                        logGameStatePeriodic.GameState.BlueZone.Z = (double)telem.GameState.PoisonGasWarningPosition.Z;
                        logGameStatePeriodic.GameState.BlueZone.Radius = (double)telem.GameState.PoisonGasWarningRadius;
                        logGameStatePeriodic.GameState.DateTimeOffset = (DateTimeOffset)telem.D;
                        Telemetry.LogGameStatePeriodicList.Add(logGameStatePeriodic);
                        break;
                    case T.LogItemAttach:
                        LogItemAttach LogItemAttach = new LogItemAttach
                        {
                            Player = telem.Character,
                            DateTime = (DateTimeOffset)telem.D
                        };
                        LogItemAttach.ParentItem.Categroy = telem.ParentItem.Category;
                        LogItemAttach.ParentItem.ItemID = telem.ParentItem.ItemId;
                        LogItemAttach.ParentItem.StackCount = (int)telem.ParentItem.StackCount;
                        LogItemAttach.ParentItem.SubCategroy = telem.ParentItem.SubCategory;
                        LogItemAttach.ChildItem.Categroy = telem.ChildItem.Category;
                        LogItemAttach.ChildItem.ItemID = telem.ChildItem.ItemId;
                        LogItemAttach.ChildItem.StackCount = (int)telem.ChildItem.StackCount;
                        LogItemAttach.ChildItem.SubCategroy = telem.ChildItem.SubCategory;
                        Telemetry.LogItemAttachList.Add(LogItemAttach);
                        break;
                    case T.LogItemDetach:
                        LogItemDetach logItemDetach = new LogItemDetach
                        {
                            Player = telem.Character,
                            DateTime = (DateTimeOffset)telem.D
                        };
                        logItemDetach.ParentItem.Categroy = telem.ParentItem.Category;
                        logItemDetach.ParentItem.ItemID = telem.ParentItem.ItemId;
                        logItemDetach.ParentItem.StackCount = (int)telem.ParentItem.StackCount;
                        logItemDetach.ParentItem.SubCategroy = telem.ParentItem.SubCategory;
                        logItemDetach.ParentItem.AttachedItems = telem.ParentItem.AttachedItems;
                        logItemDetach.ChildItem.Categroy = telem.ChildItem.Category;
                        logItemDetach.ChildItem.ItemID = telem.ChildItem.ItemId;
                        logItemDetach.ChildItem.StackCount = (int)telem.ChildItem.StackCount;
                        logItemDetach.ChildItem.SubCategroy = telem.ChildItem.SubCategory;
                        logItemDetach.ChildItem.AttachedItems = telem.ChildItem.AttachedItems;
                        Telemetry.LogItemDetachList.Add(logItemDetach);
                        break;
                    case T.LogItemDrop:
                        LogItemDrop logItemDrop = new LogItemDrop
                        {
                            Player = telem.Character
                        };
                        logItemDrop.DroppedItem.Categroy = telem.Item.Category;
                        logItemDrop.DroppedItem.ItemID = telem.Item.ItemId;
                        logItemDrop.DroppedItem.StackCount = (int)telem.Item.StackCount;
                        logItemDrop.DroppedItem.SubCategroy = telem.Item.SubCategory;
                        logItemDrop.DateTimeOffset = (DateTimeOffset)telem.D;
                        Telemetry.LogItemDropList.Add(logItemDrop);
                        break;
                    case T.LogItemEquip:
                        LogItemEquip logItemEquip = new LogItemEquip
                        {
                            Player = telem.Character
                        };
                        logItemEquip.EquipedItem.Categroy = telem.Item.Category;
                        logItemEquip.EquipedItem.ItemID = telem.Item.ItemId;
                        logItemEquip.EquipedItem.StackCount = (int)telem.Item.StackCount;
                        logItemEquip.EquipedItem.SubCategroy = telem.Item.SubCategory;
                        logItemEquip.DateTimeOffset = (DateTimeOffset)telem.D;
                        Telemetry.LogItemEquipList.Add(logItemEquip);
                        break;
                    case T.LogItemPickup:
                        LogItemPickup logItemPickup = new LogItemPickup
                        {
                            Player = telem.Character
                        };
                        logItemPickup.PickedupItem.Categroy = telem.Item.Category;
                        logItemPickup.PickedupItem.ItemID = telem.Item.ItemId;
                        logItemPickup.PickedupItem.StackCount = (int)telem.Item.StackCount;
                        logItemPickup.PickedupItem.SubCategroy = telem.Item.SubCategory;
                        logItemPickup.DateTimeOffset = (DateTimeOffset)telem.D;
                        Telemetry.LogItemPickupList.Add(logItemPickup);
                        break;
                    case T.LogItemUnequip:
                        LogItemUnequip logItemUnequip = new LogItemUnequip
                        {
                            Player = telem.Character
                        };
                        logItemUnequip.UnequipedItem.Categroy = telem.Item.Category;
                        logItemUnequip.UnequipedItem.ItemID = telem.Item.ItemId;
                        logItemUnequip.UnequipedItem.StackCount = (int)telem.Item.StackCount;
                        logItemUnequip.UnequipedItem.SubCategroy = telem.Item.SubCategory;
                        logItemUnequip.DateTimeOffset = (DateTimeOffset)telem.D;
                        Telemetry.LogItemUnequipList.Add(logItemUnequip);
                        break;
                    case T.LogItemUse:
                        LogItemUse logItemUse = new LogItemUse
                        {
                            Player = telem.Character
                        };
                        logItemUse.UsedItem.Categroy = telem.Item.Category;
                        logItemUse.UsedItem.ItemID = telem.Item.ItemId;
                        logItemUse.UsedItem.StackCount = (int)telem.Item.StackCount;
                        logItemUse.UsedItem.SubCategroy = telem.Item.SubCategory;
                        logItemUse.DateTimeOffset = (DateTimeOffset)telem.D;
                        Telemetry.LogItemUseList.Add(logItemUse);
                        break;
                    case T.LogMatchDefinition:
                        Telemetry.LogMatchDefinition.MatchID = telem.MatchId;
                        Telemetry.LogMatchDefinition.PingQuality = telem.PingQuality;
                        Telemetry.LogMatchDefinition.Version = (int)telem.V;
                        Telemetry.LogMatchDefinition.Event_timestamp = (DateTimeOffset)telem.D;
                        break;
                    case T.LogMatchEnd:
                        Telemetry.LogMatchEnd.DateTimeOffset = (DateTimeOffset)telem.D;
                        foreach (Player player in telem.Characters)
                        {
                            Telemetry.LogMatchEnd.PlayerList.Add(player);
                        }
                        break;
                    case T.LogMatchStart:
                        Telemetry.LogMatchStart.DateTimeOffset = (DateTimeOffset)telem.D;
                        Telemetry.LogMatchStart.MapName = telem.MapName;
                        Telemetry.LogMatchStart.Weather = telem.WeatherId;
                        foreach (Player player in telem.Characters)
                        {
                            Telemetry.LogMatchStart.PlayerList.Add(player);
                        }
                        break;
                    case T.LogPlayerAttack:
                        LogPlayerAttack logPlayerAttack = new LogPlayerAttack
                        {
                            AttackID = (double)telem.AttackId,
                            AttackType = telem.AttackType
                        };
                        logPlayerAttack.Transport.fuelPercent = (int)telem.Vehicle.FeulPercent;
                        logPlayerAttack.Transport.healthPercent = (double)telem.Vehicle.HealthPercent;
                        logPlayerAttack.Transport.vehicleID = (VehicleId)telem.Vehicle.VehicleId;
                        logPlayerAttack.Transport.vehicleType = telem.Vehicle.VehicleType;
                        logPlayerAttack.Attacker = telem.Attacker;
                        logPlayerAttack.AttackerWeapon.Categroy = telem.Weapon.Category;
                        logPlayerAttack.AttackerWeapon.SubCategroy = telem.Weapon.SubCategory;
                        logPlayerAttack.AttackerWeapon.ItemID = telem.Weapon.ItemId;
                        logPlayerAttack.AttackerWeapon.StackCount = (int)telem.Weapon.StackCount;
                        logPlayerAttack.DateTimeOffset = (DateTimeOffset)telem.D;
                        Telemetry.LogPlayerAttackList.Add(logPlayerAttack);
                        break;
                    case T.LogPlayerCreate:
                        LogPlayerCreate logPlayerCreate = new LogPlayerCreate
                        {
                            Player = telem.Character
                        };
                        Telemetry.LogPlayerCreateList.Add(logPlayerCreate);
                        break;
                    case T.LogPlayerKill:
                        LogPlayerKill logPlayerKill = new LogPlayerKill
                        {
                            AttackID = (double)telem.AttackId
                        };
                        logPlayerKill.Killer = telem.Killer;
                        logPlayerKill.Victim = telem.Victim;
                        logPlayerKill.DamageCauser.DamageCauserName = telem.DamageCauserName;
                        logPlayerKill.DateTimeOffset = (DateTimeOffset)telem.D;
                        Telemetry.LogPlayerKillList.Add(logPlayerKill);
                        break;
                    case T.LogPlayerLogin:
                        LogPlayerLogin logPlayerLogin = new LogPlayerLogin
                        {
                            AccountID = telem.AccountId,
                            DateTime = (DateTimeOffset)telem.D,
                            Result = (bool)telem.Result,
                            ErrorMessage = telem.ErrorMessage
                        };
                        break;
                    case T.LogPlayerLogout:
                        LogPlayerLogout logPlayerLogout = new LogPlayerLogout
                        {
                            AccountID = telem.AccountId,
                            DateTimeOffset = (DateTimeOffset)telem.D
                        };
                        Telemetry.LogPlayerLogoutList.Add(logPlayerLogout);
                        break;
                    case T.LogPlayerPosition:
                        LogPlayerPosition logPlayerPosition = new LogPlayerPosition
                        {
                            LoggedPlayer = telem.Character,
                            ElapsedTime = (int)telem.ElapsedTime,
                            numAlivePlayers = (int)telem.NumAlivePlayers,
                            //logPlayerPosition.UnderThirtyFPS = (int)telem.Under30Fps; Depreacted
                            //logPlayerPosition.UnderSixtyFPS = (int)telem.Under60Fps;  Depreacted
                            DateTimeOffset = (DateTimeOffset)telem.D
                        };
                        Telemetry.LogPlayerPositionList.Add(logPlayerPosition);
                        break;
                    case T.LogPlayerTakeDamage:
                        LogPlayerTakeDamage logPlayerTakeDamage = new LogPlayerTakeDamage
                        {
                            Attacker = telem.Attacker,
                            Victim = telem.Victim
                        };
                        logPlayerTakeDamage.Damage.DamageTypeCategory = telem.DamageTypeCategory;
                        logPlayerTakeDamage.Damage.DamageReason = telem.DamageReason;
                        logPlayerTakeDamage.Damage.DamageAmount = (double)telem.Damage;
                        logPlayerTakeDamage.Damage.DamageCauserName = telem.DamageCauserName;
                        logPlayerTakeDamage.DateTimeOffset = (DateTimeOffset)telem.D;
                        Telemetry.LogPlayerTakeDamageList.Add(logPlayerTakeDamage);
                        break;
                    case T.LogVehicleDestroy:
                        LogVehicleDestroy logVehicleDestroy = new LogVehicleDestroy
                        {
                            Attacker = telem.Attacker
                        };
                        logVehicleDestroy.DestroyedVehicle.fuelPercent = (int)telem.Vehicle.FeulPercent;
                        logVehicleDestroy.DestroyedVehicle.healthPercent = (double)telem.Vehicle.HealthPercent;
                        logVehicleDestroy.DestroyedVehicle.vehicleID = (VehicleId)telem.Vehicle.VehicleId;
                        logVehicleDestroy.DestroyedVehicle.vehicleType = telem.Vehicle.VehicleType;
                        logVehicleDestroy.DateTimeOffset = (DateTimeOffset)telem.D;
                        Telemetry.LogVehicleDestroyList.Add(logVehicleDestroy);
                        break;
                    case T.LogVehicleLeave:
                        LogVehicleLeave logVehicleLeave = new LogVehicleLeave
                        {
                            Player = telem.Character
                        };
                        logVehicleLeave.Vehicle.fuelPercent = (int)telem.Vehicle.FeulPercent;
                        logVehicleLeave.Vehicle.healthPercent = (double)telem.Vehicle.HealthPercent;
                        logVehicleLeave.Vehicle.vehicleID = (VehicleId)telem.Vehicle.VehicleId;
                        logVehicleLeave.Vehicle.vehicleType = telem.Vehicle.VehicleType;
                        logVehicleLeave.DateTimeOffset = (DateTimeOffset)telem.D;
                        Telemetry.LogVehicleLeaveList.Add(logVehicleLeave);
                        break;
                    case T.LogVehicleRide:
                        LogVehicleRide logVehicleRide = new LogVehicleRide
                        {
                            Player = telem.Character
                        };
                        logVehicleRide.Vehicle.fuelPercent = (int)telem.Vehicle.FeulPercent;
                        logVehicleRide.Vehicle.healthPercent = (double)telem.Vehicle.HealthPercent;
                        logVehicleRide.Vehicle.vehicleID = (VehicleId)telem.Vehicle.VehicleId;
                        logVehicleRide.Vehicle.vehicleType = telem.Vehicle.VehicleType;
                        logVehicleRide.DateTimeOffset = (DateTimeOffset)telem.D;
                        Telemetry.LogVehicleRideList.Add(logVehicleRide);
                        break;
                }
            }
            return Telemetry;
        }
        /// <summary>
        /// Pharses user data from JSON from the API
        /// </summary>
        /// <param name="JSONstring"></param>
        /// <returns></returns>
        public APIUser UserPhraser(string JSONstring)
        {
            APIUser user = new APIUser
            {
                BaseJSON = JSONstring
            };
            JObject parsed = JObject.Parse(JSONstring);
            user.AccountID = (string)parsed["data"]["id"];
            user.PUBGName = (string)parsed["data"]["attributes"]["name"];
            user.PRS = (string)parsed["data"]["attributes"]["shardId"];
            foreach (JObject matchitem in parsed["data"]["relationships"]["matches"]["data"])
            {
                user.ListOfMatches.Add((string)matchitem["id"]);
            }
            return user;
        }
        /// <summary>
        /// Pharses user data from a JObject from the API
        /// </summary>
        /// <param name="userdata">JObject to pharse</param>
        /// <returns></returns>
        public APIUser UserPhraser(JObject userdata)
        {
            APIUser user = new APIUser
            {
                BaseJSON = userdata.ToString()
            };
            user.AccountID = (string)userdata["id"];
            user.PUBGName = (string)userdata["attributes"]["name"];
            user.PRS = (string)userdata["attributes"]["shardId"];
            foreach (JObject matchitem in userdata["relationships"]["matches"]["data"])
            {
                user.ListOfMatches.Add((string)matchitem["id"]);
            }
            return user;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public APITelemetry PopulateTelemetry()
        {
            if( Telemetry.BaseJSON == null || Telemetry.BaseJSON.Trim().Length == 0 )
            {
                Telemetry.BaseJSON = "";
                using ( WebClient client = new WebClient() )
                {
                    Telemetry = TelemetryPhraser( client.DownloadString( Match.TelemetryURL ) );
                }
            }
            return Telemetry;
        }
    }
    /// <summary>
    /// The type of search to perform when doing a multiuser search
    /// </summary>
    public enum UserSearchType
    {
        /// <summary>
        /// Searching using PUBG names
        /// </summary>
        PUBGName,
        /// <summary>
        /// Searching using
        /// </summary>
        AccountID
    }
    public class RequestOptions
    {
        public bool SaveMatch { get; set; }
        public bool SaveMatchTelemetry { get; set; }
        public string Folderpath { get; set; }
        public static readonly RequestOptions Default = new RequestOptions()
        {
            SaveMatch = false,
            SaveMatchTelemetry = false,
            Folderpath = ""
        };
    }
}
