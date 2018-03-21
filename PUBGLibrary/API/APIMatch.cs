using System;
using System.Collections.Generic;

namespace PUBGLibrary.API
{
    public class APIMatch
    {
        /// <summary>
        /// Time of match completion
        /// </summary>
        public DateTime CreatedAt;
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
        public PlatformRegionShard PRS_ID;
        public List<APITeam> TeamList = new List<APITeam>();
        public string TelemetryURL;
    }
}
