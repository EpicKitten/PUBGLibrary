using System.Collections.Generic;

namespace PUBGLibrary.API
{
    /// <summary>
    /// Rosters track the scores of each opposing group of participants. Rosters can have one or many participants depending on the game mode. Roster objects are only meaningful within the context of a match and are not exposed as a standalone resource.
    /// </summary>
    /// <remarks>I think this is sqauds based ont he wording</remarks>
    public class APIRoster
    {
        /// <summary>
        /// Roster ID
        /// </summary>
        public string ID;
        /// <summary>
        /// List of participants
        /// </summary>
        public List<APIParticipant> participants;
        /// <summary>
        /// Indicates if this roster won the match
        /// </summary>
        /// <remarks>Why is this not a bool?</remarks>
        public string Won;
        /// <summary>
        /// Platform-region Shard
        /// </summary>
        public string ShardID;
    }
}
