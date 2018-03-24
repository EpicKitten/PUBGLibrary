using System;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace PUBGLibrary
{
    /// <summary>
    /// List of gamemodes in PUBG
    /// </summary>
    public enum GameMode
    {
        Unknown,
        
        [EnumMember(Value = "solo")]
        SoloTPP,
        
        [EnumMember(Value = "solo-fpp")]
        SoloFPP,
        
        [EnumMember(Value = "duo")]
        DuoTPP,
        
        [EnumMember(Value = "duo-fpp")]
        DuoFPP,
        
        [EnumMember(Value = "squad")]
        SquadTPP,
        
        [EnumMember(Value = "squad-fpp")]
        SquadFPP,

        [EnumMember(Value = "custom")]
        Custom,
    }

    /// <summary>
    /// List of maps in PUBG
    /// </summary>
    public enum GameMap
    {
        Unknown,
        
        [EnumMember(Value = "Desert_Main")]
        Miramar,
        
        [EnumMember(Value = "Erangel_Main")]
        Erangel,
    }

    /// <summary>
    /// List of server types in PUBG
    /// </summary>
    public enum ServerType
    {
        Unknown,
        Official,
        Custom,
    }
    /// <summary>
    /// Information from the PUBG .replayinfo file
    /// </summary>
    public class ReplayInfo
    {
        /// <summary>
        /// The length of the replay in miliseconds.
        /// </summary>
        [JsonProperty("LengthInMS")]
        public int LengthInMs; //Length of the recording in miliseconds

        /// <summary>
        /// The verison of UE4 netcode used when the replay was created.
        /// </summary>
        /// <remarks>
        /// Dec. 25 2017 - Was 720898
        /// </remarks>
        public int NetworkVersion;

        /// <summary>
        /// Always 0, UE4 has it commented as “Engine changelist built from”.
        /// </summary>
        /// <remarks>
        /// Has never changed since Dec. 25 2017
        /// Update Mar. 7 2018 - Still 0
        /// </remarks>
        public int Changelist; 


        /// <summary>
        /// A string containing multipe values.
        /// </summary>
        public string FriendlyName
        {
            set
            {
                friendlyName = value;

                string[] parts = friendlyName.Split('.');

                switch (parts[2])
                {
                    case "official":
                        ServerType = ServerType.Official;
                        break;

                    case "custom":
                        ServerType = ServerType.Custom;
                        CustomHost = parts[3];
                        break;

                    default:
                        ServerType = ServerType.Unknown;
                        break;
                }

                ServerId = parts[9].Remove(0, parts[9].Length - 6);
                MatchID = parts[9];
            }

            get
            {
                return friendlyName;
            }
        }
        private string friendlyName;
        /// <summary>
        /// The Match ID of the match, used for looking up the match using the API
        /// </summary>
        public string MatchID;

        /// <summary>
        /// The ServerType (Official, Custom, etc).
        /// </summary>
        public ServerType ServerType = ServerType.Unknown;
        private string ServerId
        {
            set
            {
                ServerID = value.ToUpper();
            }
        }

        /// <summary>
        /// The server ID of the server the replay was created on.
        /// </summary>
        public string ServerID;

        /// <summary>
        /// If CustomHost is set, it will appear here
        /// </summary>
        public string CustomHost = null;

        /// <summary>
        /// The size of the replay in bytes.
        /// </summary>
        public ulong DemoFileLastOffset;

        /// <summary>
        /// Always 0, never used.
        /// </summary>
        public int SizeInBytes;


        [JsonProperty("Timestamp")]
        private double UnixTimeStamp
        {
            set
            {
                TimeStamp = value;
                TimeStampISO = (new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local)).AddMilliseconds(value);
            }
            get
            {
                return TimeStamp;
            }
        }

        /// <summary>
        /// The Unix time (Epoch) of when the replay was created
        /// </summary>
        public double TimeStamp;

        /// <summary>
        /// When the replay started in Unix time (Epoch)
        /// </summary>
        public double ReplayStartTime
        {
            get
            {
                return TimeStamp - (LengthInMs / 1000);
            }
        }
        /// <summary>
        /// The Datetime of when the replay was created in ISO format
        /// </summary>
        public DateTime TimeStampISO;

        /// <summary>
        /// Never used, always false.
        /// </summary>
        [JsonProperty("bIsLive")]
        public bool IsLive;

        /// <summary>
        /// Never used, always false.
        /// </summary>
        [JsonProperty("bIncomplete")]
        public bool IsIncomplete;

        /// <summary>
        /// Never used, always false. Probably used server-side.
        /// </summary>
        [JsonProperty("bIsServerRecording")]
        public bool IsServerRecording;

        /// <summary>
        /// If true, PUBG won't delete or allow the user to delete the replay.
        /// </summary>
        /// <remarks>
        /// Add ability to toggle this
        /// </remarks>
        [JsonProperty("bShouldKeep")]
        public bool ShouldKeep;

        /// <summary>
        /// The mode played in the replay file (duo, squad-fpp, etc).
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public GameMode Mode;

        /// <summary>
        /// The recording user's SteamID64 in MD5 hash (Pre 1.0 replays just have the SteamID64).
        /// </summary>
        public string RecordUserId;

        /// <summary>
        /// The recording user's PUBG name.
        /// </summary>
        public string RecordUserNickName;

        /// <summary>
        /// The map the replay was recorded on
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public GameMap MapName;

        /// <summary>
        /// Always true, rare instances have causes this to be false
        /// </summary>
        [JsonProperty("bAllDeadOrWin")]
        public bool AllDeadOrWin;

        /// <summary>
        /// If true, the replay is clipped for use in a report
        /// </summary>
        [JsonProperty("bIsClip")]
        public bool IsClip;

        /// <summary>
        /// The length of the clip
        /// </summary>
        [JsonProperty("ClipTime")]
        public double ClipLength;

        /// <summary>
        /// The time the clip starts
        /// </summary>
        public double ClipStartTime;

        /// <summary>
        /// The time the clip ends
        /// </summary>
        public double ClipEndTime;

        /// <summary>
        /// The SteamID of the person being reported
        /// </summary>
        [JsonProperty("ClipTargetUserId")]
        public string ClipTargetSteamID;

        /// <summary>
        /// The PUBG name of the person being reported
        /// </summary>
        [JsonProperty("ClipTargetUserNickName")]
        public string ClipTargetPUBGName;
        public bool HasReplayToken = false;
        /// <summary>
        /// The replay report token
        /// </summary>
        public ReplayReportToken ReplayReportToken;
        
        [JsonProperty("ReportToken")]
        private string ReportToken
        {
            set
            {
                HasReplayToken = true;
                ReplayReportToken = new ReplayReportToken(value);
            }
        }
    }
    public class ReplayReportToken
    {
        /// <summary>  
        ///  The full JSON Web Token, Base64 encoded in three parts.
        /// </summary>  
        /// <remarks>
        ///  The first part is the "Header" that contains the Algorithm and Type
        ///  The second part is the "Payload" that contains all of PUBG's Data (AccountID, MatchID, JWT_ID, NotBeforePrecise, ExpiresPrecise, and Issuer
        ///  The thrid part is the "Signature" which is Base64 encoded with a Base64 encoded sercert
        /// </remarks>
        public string Token;

        /// <summary>
        /// The Algorithm used to sign the JWT.
        /// </summary>
        /// <remarks>
        /// PUBG uses HMAC SHA-256, HS256 in the file
        /// </remarks>
        public string Algorithm;

        /// <summary>
        /// The Header Parameter to identify that it's a JWT .
        /// </summary>
        /// <remarks>
        /// PUBG uses this even though all current verisons of JWT ignore this
        /// </remarks>
        public string Type;

        /// <summary>
        /// A internal PUBG Account ID, not the same as RecordUserId.
        /// </summary>
        /// <remarks>
        /// Some account ID that seems unrelated to the SteamID (not a MD5 of it, etc)
        /// </remarks>
        public string AccountID;

        /// <summary>
        /// The ID or FriendlyName of the match played in the replay.
        /// </summary>
        /// <remarks>
        /// Same as MatchID in the Summary file and in the ReplayInfo file
        /// </remarks>
        public string MatchID;

        /// <summary>
        /// Provides a unique identifier for the JWT.
        /// </summary>
        public string JWT_ID;

        /// <summary>
        /// The Unix time (Epoch) of the start of when this token can be used.
        /// </summary>
        public double NotBeforePrecise;

        /// <summary>
        /// The local DateTime of the start of when this token can be used.
        /// </summary>
        public DateTime NotBefore;

        /// <summary>
        /// The Unix time (Epoch) of the end of when this token can be used.
        /// </summary>
        public double ExpiresPrecise;

        /// <summary>
        /// The local DateTime of the end of when this token can be used.
        /// </summary>
        public DateTime Expires;

        /// <summary>
        /// This identifies the principal that issued the JWT.
        /// </summary>
        /// <remarks>
        /// prod-live for Public Builds
        /// 
        /// </remarks>
        public string Issuer;

        /// <summary>
        /// The signature to signing the JWT in hex.
        /// </summary>
        public string Signature;

        public ReplayReportToken(string _token)
        {
            Token = _token;
            string[] tokenBreak = Token.Split('.');
            string null0 = tokenBreak[0];

            string null1 = tokenBreak[1];
            string null2 = tokenBreak[2];
            JObject header = Utils.Utils.Base64DecodeJSON(tokenBreak[0]);
            JObject payload = Utils.Utils.Base64DecodeJSON(tokenBreak[1]);
            Algorithm = (string)header["alg"];
            Type = (string)header["typ"];
            AccountID = (string)payload["aid"];
            MatchID = (string)payload["mid"];
            JWT_ID = (string)payload["jti"];
            NotBeforePrecise = (double)payload["nbf"];
            NotBefore = (new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local)).AddSeconds((double)payload["nbf"]);
            ExpiresPrecise = (double)payload["exp"];
            Expires = (new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local)).AddSeconds((double)payload["exp"]);
            Issuer = (string)payload["iss"];
            Signature = BitConverter.ToString(Encoding.ASCII.GetBytes(tokenBreak[2])).Replace("-", "");
        }
    }
}