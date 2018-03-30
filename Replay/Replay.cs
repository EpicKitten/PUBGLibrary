using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;

namespace PUBGLibrary.Replay
{
    /// <summary>
    /// Begining of the Replay class
    /// </summary>
    public class Replay
    {
        /// <summary>
        /// Path to the replay directory
        /// </summary>
        public string Path;

        public ReplayInfo Info;
        public ReplaySummary Summary;
        
        /// <summary>
        /// Begining of the Replay class
        /// </summary>
        /// <param name="DirectoryPath">Path to the replay directory</param>
        public Replay(string DirectoryPath)
        {
            Path = DirectoryPath;
            Info = DecryptReplayInfoFile();
            Summary = DecryptReplaySummaryFile();
            for (int i = 0; i < Summary.NumTeammates; i++)
            {
                if (Utils.Utils.CreateMD5(Summary.Teammates[i].PlayerID.ToString()) == Info.RecordUserId)
                {
                    Summary.Teammates[i].IsRecordingUser = true;
                    break;
                }
            }
        }
        /// <summary>
        /// Shifts all bytes in the file by 1 to reveal readable JSON in the newest ReplaySummary file
        /// </summary>
        /// <returns></returns>
        private ReplaySummary DecryptReplaySummaryFile()
        {
            string filename = null;
            
            foreach (string replay in Directory.GetFiles(Path + "\\data"))
            {
                if (replay.Contains("ReplaySummary"))
                {
                    filename = replay;
                }
            }

            if (filename == null)
            {
                throw new Exception("ReplaySummary file is not found");
            }
            
            string summaryJson = Utils.Utils.UE4StringSerializer(filename, 1);
            Console.WriteLine(summaryJson);
            return JsonConvert.DeserializeObject<ReplaySummary>(summaryJson);
        }
        /// <summary>
        /// Shifts all bytes in the file by 1 to reveal readable JSON in the .replayinfo file
        /// </summary>
        /// <returns></returns>
        private ReplayInfo DecryptReplayInfoFile()
        {
            string infoJson = Utils.Utils.UE4StringSerializer(Path + "\\PUBG.replayinfo");
            return JsonConvert.DeserializeObject<ReplayInfo>(infoJson);
        }

        /// <summary>
        /// Gets the recording user's ReplaySummaryTeammate
        /// </summary>
        public ReplaySummaryTeammate Recorder
        {
            get
            {
                return Summary.Teammates.First(player => player.PlayerName == Info.RecordUserNickName);
            }
        }

        /// <summary>
        /// Gets the size of the replay
        /// </summary>
        /// <returns>Returns the size of the replay</returns>
        public double Size()
        {
            return Utils.Utils.GetDirectorySize(Path);
        }

        private string customName = null;
        
        /// <summary>
        /// Gets the custom name for the replay if it has one
        /// </summary>
        public string CustomName
        {
            get
            {
                if (customName == null)
                {
                    customName = "[null]";

                    if (File.Exists(Path + "\\customInfo.json"))
                    {
                        JObject custom_file = JObject.Parse(File.ReadAllText(Path + "\\customInfo.json"));
                        customName = (string) custom_file["customName"];
                    }
                }

                return customName;
            }

            set
            {
                customName = value;

                JObject custom_file;
                if (File.Exists(Path + "\\customInfo.json"))
                {
                    custom_file = JObject.Parse(File.ReadAllText(Path + "\\customInfo.json"));
                    custom_file["customName"] = value;
                }
                else
                {
                    custom_file = new JObject(new JProperty("customName", value));
                }
                
                File.WriteAllText(Path + "\\customInfo.json", custom_file.ToString());
            }
        }
        /// <summary>
        /// Creates a overview of the replay in JSON format
        /// </summary>
        /// <param name="file_path">The file path to save the MatchOverview to, extenstion included.</param>
        /// <param name="CustomHost">Add the name of the person hosting the custom lobby</param>
        /// <param name="FriendlyName">Add the FriendlyName string</param>
        /// <param name="LengthInMS">Add the length of the replay in MS</param>
        /// <param name="MapName">Add the name of the map</param>
        /// <param name="Mode">Add the mode (will be "custom" in custom games)</param>
        /// <param name="NetworkVerison">Add the network verison</param>
        /// <param name="RecordingUserIDMD5">Add the MD5 hash of the recording user</param>
        /// <param name="RecordingUserPUBGName">Add the PUBG name of the recording user</param>
        /// <param name="ServerID">Add the server ID the replay was created on</param>
        /// <param name="ServerType">Add if the server was official or not</param>
        /// <param name="TimestampUTC">Add the UTC time of when the replay was created</param>
        /// <param name="TimestampPrecise">Add the Unix (Epoch) time of when the replay was created</param>
        /// <param name="PlayerCount">Add the player count</param>
        /// <param name="TeamCount">Add the number of teams</param>
        /// <param name="NumTeammates">Add the number of teammates</param>
        /// <param name="TeamID">Add the team numbe recording user's number</param>
        /// <param name="RecordingUserStats">Add the recording user's stats</param>
        /// <param name="RecordingUserTeammatesStats">Add the recording user's teammates stats</param>
        /// <param name="EventLog">Add all knocks and kills the recording user could have seen</param>
        /// <param name="SHA256ReplayHash">Add the SHA256 hash from ToZipFile</param>
        /// <param name="ReplayStartTime">Add the unix time of when the replay started</param>
        public string CreateMatchOverview(
            string file_path,
            bool FriendlyName = true,
            bool CustomHost = true,
            bool ReplayStartTime = true,
            bool LengthInMS = true,
            bool MapName = true,
            bool Mode = true,
            bool NetworkVerison = true,
            bool RecordingUserIDMD5 = true,
            bool RecordingUserPUBGName = true,
            bool ServerID = true,
            bool ServerType = true,
            bool TimestampUTC = true,
            bool TimestampPrecise = true,
            bool PlayerCount = true,
            bool TeamCount = true,
            bool NumTeammates = true,
            bool TeamID = true,
            bool RecordingUserStats = true,
            bool RecordingUserTeammatesStats = true,
            bool EventLog = true,
            string SHA256ReplayHash = "")
        {
            JObject MatchOverviewJSON = new JObject();
            if(FriendlyName)
            {
                MatchOverviewJSON.Add("FriendlyName", Info.FriendlyName);
            }
            if (ReplayStartTime)
            {
                MatchOverviewJSON.Add("ReplayStartTime", Info.ReplayStartTime);
            }
            if (LengthInMS)
            {
                MatchOverviewJSON.Add("LengthInMS", Info.LengthInMs);
            }
            if (TimestampPrecise)
            {
                MatchOverviewJSON.Add("TimeStamp", Info.TimeStamp);
            }
            if (TimestampUTC)
            {
                MatchOverviewJSON.Add("TimestampISO", Info.TimeStampISO);
            }
            if (MapName)
            {
                MatchOverviewJSON.Add("MapName", Info.MapName.ToString());
            }
            if (Mode)
            {
                MatchOverviewJSON.Add("Mode", Info.Mode.ToString());
            }
            if (ServerID)
            {
                MatchOverviewJSON.Add("ServerID", Info.ServerID);
            }
            if (ServerType)
            {
                MatchOverviewJSON.Add("ServerType", Info.ServerType.ToString());
            }
            if (NetworkVerison)
            {
                MatchOverviewJSON.Add("NetworkVersion", Info.NetworkVersion);
            }
            if (RecordingUserPUBGName)
            {
                MatchOverviewJSON.Add("RecordingUserPUBGName", Info.RecordUserNickName);
            }
            if (RecordingUserIDMD5)
            {
                MatchOverviewJSON.Add("RecordingUserIDMD5", Info.RecordUserId);
            }
            if (PlayerCount)
            {
                MatchOverviewJSON.Add("PlayerCount", Summary.PlayerCount);
            }
            if (TeamCount)
            {
                MatchOverviewJSON.Add("TeamCount", Summary.TeamsCount);
            }
            if (NumTeammates)
            {
                MatchOverviewJSON.Add("NumTeammates", Summary.NumTeammates);
            }
            if (RecordingUserStats)
            {
                JArray RecordingUserStatsArray = new JArray();
                JObject RUSAContainer = new JObject
                {
                    { "PlayerName", Recorder.PlayerName },
                    { "PlayerID", Recorder.PlayerID },
                    { "TeamID", Recorder.PlayerTeamID },
                    { "Ranking", Recorder.Ranking },
                    { "IsRecordingPlayer", Recorder.IsRecordingUser },
                    { "Kills", Recorder.Kills },
                    { "Headshots", Recorder.Headshots },
                    { "TotalDamage", Recorder.TotalGivenDamages },
                    { "LongestDistanceKillInCM", Recorder.LongestDistanceKillInCM },
                    { "LongestDistanceKillInM", Recorder.LongestDistanceKillInM },
                    { "TotalDistanceMovedinM", Recorder.TotalMovedDistanceInM },
                    { "TotalDistanceMovedinMorKM)", Recorder.TotalMovedDistanceHumanReadable }
                };
                RecordingUserStatsArray.Add(RUSAContainer);
                MatchOverviewJSON.Add("RecordingUserStatsArray", RecordingUserStatsArray);
             
            }
            if (RecordingUserTeammatesStats)
            {
                JArray TeammatesStatsArray = new JArray();
                List<JObject> Team = new List<JObject>();
                for (int i = 0; i < Summary.NumTeammates; i++)
                {
                    Team.Add(new JObject());
                    if (Summary.Teammates[i].PlayerID != Recorder.PlayerID)
                    {
                        Team[i].Add("PlayerName", Summary.Teammates[i].PlayerName);
                        Team[i].Add("PlayerID", Summary.Teammates[i].PlayerID);
                        Team[i].Add("TeamID", Summary.Teammates[i].PlayerTeamID);
                        Team[i].Add("Ranking", Summary.Teammates[i].Ranking);
                        Team[i].Add("IsRecordingPlayer", Summary.Teammates[i].IsRecordingUser);
                        Team[i].Add("Kills", Summary.Teammates[i].Kills);
                        Team[i].Add("Headshots", Summary.Teammates[i].Headshots);
                        Team[i].Add("TotalDamage", Summary.Teammates[i].TotalGivenDamages);
                        Team[i].Add("LongestDistanceKillInCM", Summary.Teammates[i].LongestDistanceKillInCM);
                        Team[i].Add("LongestDistanceKillInM", Summary.Teammates[i].LongestDistanceKillInM);
                        Team[i].Add("TotalDistanceMovedinM", Summary.Teammates[i].TotalMovedDistanceInM);
                        Team[i].Add("TotalMovedDistanceHumanReadable", Summary.Teammates[i].TotalMovedDistanceHumanReadable);
                        TeammatesStatsArray.Add(Team[i]);
                    }
                }
                MatchOverviewJSON.Add("TeammatesStatsArray", TeammatesStatsArray);
            }
            if (EventLog)
            {
                JArray EventLogArray = new JArray();
                List<JObject> EventList = new List<JObject>();
                for (int i = 0; i < Events().Count; i++)
                {
                    IReplayEvent replayEvent = Events()[i];
                    EventList.Add(new JObject());
                    EventList[i].Add("Time", replayEvent.GetList()[0].ToString());
                    EventList[i].Add("InstigatorSteam64ID", replayEvent.GetList()[1].ToString());
                    EventList[i].Add("InstigatorPUBGName", replayEvent.GetList()[2].ToString());
                    EventList[i].Add("Verb", replayEvent.GetList()[3].ToString());
                    EventList[i].Add("VictimSteam64ID", replayEvent.GetList()[4].ToString());
                    EventList[i].Add("VictimPUBGName", replayEvent.GetList()[5].ToString());
                    EventLogArray.Add(EventList);
                }
                MatchOverviewJSON.Add("EventLog", EventLogArray);
            }
            if (SHA256ReplayHash != "")
            {
                MatchOverviewJSON.Add("SHA256ZipHash", SHA256ReplayHash);
            }
            File.WriteAllText(file_path, MatchOverviewJSON.ToString());
            return MatchOverviewJSON.ToString();
        }
        /// <summary>
        /// All kills and downs that happened within the 1KM circle of the recording player
        /// </summary>
        /// <returns>List of Kills and DBNOs</returns>
        public List<ReplayEvent> Events()
        {
            List<ReplayEvent> events = new List<ReplayEvent>();
            
            foreach (string file in Directory.GetFiles(Path + "\\data"))
            {
                string eventPath = Path + "\\events" + file.Substring(file.LastIndexOf('\\'));
                
                string dataJson = Utils.Utils.UE4StringSerializer(file, 1);
                string eventJson = Utils.Utils.UE4StringSerializer(eventPath);
                
                ReplayEventMeta meta = JsonConvert.DeserializeObject<ReplayEventMeta>(eventJson);

                switch (meta.Group)
                {
                    case "groggy":
                        ReplayKnockEvent knockEvent = JsonConvert.DeserializeObject<ReplayKnockEvent>(dataJson);
                        knockEvent.Time = meta.Time;
                        events.Add(knockEvent);
                        break;
                    
                    case "kill":
                        ReplayKillEvent killEvent = JsonConvert.DeserializeObject<ReplayKillEvent>(dataJson);
                        killEvent.Time = meta.Time;
                        events.Add(killEvent);
                        break;
                    
                    case "ReplaySummary":
                    case "level":
                        break;
                    
                    default:
                        Console.WriteLine($"Unknown event type: {meta.Group} for event {meta.Id}");
                        break;
                }
            }
            events.Sort((x,y) => x.Time.CompareTo(y.Time));
            return events;
        }
        /// <summary>
        /// Creates a zip file from the replay
        /// </summary>
        /// <param name="DestinationFileName">The zip file path to save the replay to</param>
        /// <returns>SHA256 hash of the zipfile</returns>
        public string ToZipFile(string DestinationFileName)
        {
            ZipFile.CreateFromDirectory(Path, DestinationFileName, CompressionLevel.Optimal, true);
            using (FileStream stream = File.OpenRead(DestinationFileName))
            {
                var sha = new SHA256Managed();
                byte[] checksum = sha.ComputeHash(stream);
                return BitConverter.ToString(checksum).Replace("-", String.Empty);
            }
        }
    }
#pragma warning disable 649
    class ReplayEventMeta
    {
        [JsonProperty("id")]
        public string Id;

        [JsonProperty("group")]
        public string Group;

        [JsonProperty("time1")]
        public int Time;
    }
}
#pragma warning restore 649