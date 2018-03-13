using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUBGLibrary.API
{
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
        /// N/A
        /// </summary>
        public int Duration;
        /// <summary>
        /// Game mode played
        /// </summary>
        public string GameMode;
        /// <summary>
        /// N/A
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
