namespace PUBGLibrary.API
{
    /// <summary>
    /// Participant objects represent each player in the context of a match. Each participant will have a single player relationship which can be used to locate the player's aggregated liftime stats. Participant objects are only meaningful within the context of a match and are not exposed as a standalone resource.
    /// </summary>
    public class APIParticipant
    {
        /// <summary>
        /// Participant ID
        /// </summary>
        public string ID;
        /// <summary>
        /// Stats particular to participants
        /// </summary>
        public string Stats;
        /// <summary>
        /// N/A
        /// </summary>
        public string Actor;
        /// <summary>
        /// Platform-region shard
        /// </summary>
        public string ShardID;
    }
}
