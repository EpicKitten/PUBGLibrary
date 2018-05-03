using System;
using System.Collections.Generic;

namespace PUBGLibrary.API
{
    /// <summary>
    /// The match data requested
    /// </summary>
    public class APIMatch
    {
        /// <summary>
        /// The bare JSON of the request;
        /// </summary>
        public string BaseJSON;
        public string MatchID;
        /// <summary>
        /// Time of match completion
        /// </summary>
        public DateTimeOffset? CreatedAt;
        /// <summary>
        /// List of players with stats included
        /// </summary>
        public List<APIPlayer> PlayerList = new List<APIPlayer>();
        /// <summary>
        /// Length of match in seconds
        /// </summary>
        public int Duration;
        /// <summary>
        /// The gamemode played
        /// </summary>
        /// <remarks>Might be the same as the Gamemode enum</remarks>
        public string Gamemode;
        /// <summary>
        /// The name of the map
        /// </summary>
        public string MapName;
        /// <summary>
        /// The Platform-Region shard 
        /// </summary>
        public PlatformRegionShard PRS_ID;
        /// <summary>
        /// A list of teams in the match
        /// </summary>
        public List<APITeam> TeamList = new List<APITeam>();
        /// <summary>
        /// The direct link to the Telemetry file
        /// </summary>
        public string TelemetryURL;
    }
}
