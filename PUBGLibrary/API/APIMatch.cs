using System;
using System.Collections.Generic;

namespace PUBGLibrary.API
{
    /// <summary>
    /// Match records are created every time players complete a game session. Each match contains high level information about the game session, i.e.gameMode, etc.
    /// </summary>
    public class APIMatch
    {
        /// <summary>
        /// Match ID
        /// </summary>
        public string ID;
        /// <summary>
        /// Time of match completion
        /// </summary>
        public DateTime CreatedAt;
        /// <summary>
        /// 
        /// </summary>
        public List<APIRoster> Rosters;
        /// <summary>
        /// 
        /// </summary>
        public List<APIAsset> assets;
        /// <summary>
        /// 
        /// </summary>
        public string stats;
        /// <summary>
        /// The duration of the match
        /// </summary>
        public int Duration;
        /// <summary>
        /// Game mode played
        /// </summary>
        public string GameMode;
        /// <summary>
        /// 
        /// </summary>
        public string PatchVerison;
        /// <summary>
        /// Identifies the studio and game
        /// </summary>
        public string TitleID;
        /// <summary>
        /// Platform-region shard
        /// </summary>
        public string ShardID;
        /// <summary>
        /// 
        /// </summary>
        public string Tags;

    }
}
