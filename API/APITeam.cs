
using System.Collections.Generic;

namespace PUBGLibrary.API
{
    /// <summary>
    /// Team structure from the match file returned by the API
    /// </summary>
    public class APITeam
    {
        /// <summary>
        /// The rank the team got in the match (i.e 3rd in a match)
        /// </summary>
        public int rank;
        /// <summary>
        /// The team ID referenced in the Replay file (Tab menu of when watch a replay)
        /// </summary>
        public int TeamID;
        /// <summary>
        /// If the team won, this is true
        /// </summary>
        public bool Won;
        /// <summary>
        /// The list of teammates int he team, based on a GUID also contained in the player
        /// </summary>
        public List<string> TeammateIDList = new List<string>();
        /// <summary>
        /// The size of the team
        /// </summary>
        public int TeamSize
        {
            get
            {
                return TeammateIDList.Count;
            }
        }
    }
}
