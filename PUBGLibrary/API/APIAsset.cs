namespace PUBGLibrary.API
{
    /// <summary>
    /// Asset objects contain a URL string that links to a telemetry.json file, which will contain an array of event objects that provide further insight into a match.
    /// </summary>
    public class APIAsset
    {
        /// <summary>
        /// Asset ID
        /// </summary>
       public string ID;
        /// <summary>
        /// Identifies the studio and game
        /// </summary>
       public string TitleID;
        /// <summary>
        /// Platform-region shard
        /// </summary>
       public string ShardID;
        /// <summary>
        /// Telemetry
        /// </summary>
       public string Name;
        /// <summary>
        /// 
        /// </summary>
       public string Description;
        /// <summary>
        /// Time of telemetry creation
        /// </summary>
       public string CreatedAt;
        /// <summary>
        /// telemetry.json
        /// </summary>
       public string Filename;
        /// <summary>
        /// application/json
        /// </summary>
       public string ContentType;
        /// <summary>
        /// Link to the telemetry.json file
        /// </summary>
       public string URL;

    }
}
