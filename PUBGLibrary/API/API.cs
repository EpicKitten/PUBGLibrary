namespace PUBGLibrary.API
{
    /// <summary>
    /// The base class for the PUBG API
    /// </summary>
    public class API
    {
        /// <summary>
        /// The API key used during requests
        /// </summary>
        private string APIKey;
        /// <summary>
        /// The Platform-Region shard used during requests
        /// </summary>
        public string PlatformRegion;
        public APIRequest APIRequest;
        /// <summary>
        /// The base class for the PUBG API
        /// </summary>
        /// <param name="MatchID">The match ID to look up</param>
        /// <param name="platform">The platform the replay was made on</param>
        /// <param name="KnownRegion">The region the replay was made in</param>
        /// <param name="APIKey">The API key to use</param>
        public API(string MatchID, Platform platform, Region KnownRegion, string APIKey)
        {
            SetPlatformRegion(KnownRegion, platform);
            APIRequest.RequestSingleMatch(APIKey, PlatformRegion, MatchID);
        }
        /// <summary>
        /// The base class for the PUBG API
        /// </summary>
        /// <param name="ReplayDirectoryPath">The directory path to the replay folder</param>
        /// <param name="APIKey">The API key to use</param>
        public API(string ReplayDirectoryPath, string APIKey)
        {
            Replay.Replay replay = new Replay.Replay(ReplayDirectoryPath);
            SetPlatformRegion(replay.Summary.KnownRegion);
            APIRequest.RequestSingleMatch(APIKey, PlatformRegion, replay.Info.MatchID);
        }
        /// <summary>
        /// The base class for the PUBG API
        /// </summary>
        /// <param name="replay">The replay class for a PUBG replay</param>
        /// <param name="APIKey">The API key to use</param>
        public API(Replay.Replay replay, string APIKey)
        {
            SetPlatformRegion(replay.Summary.KnownRegion);
            APIRequest.RequestSingleMatch(APIKey, PlatformRegion, replay.Info.MatchID);
            
        }
        /// <summary>
        /// Sets the Platform-Region
        /// </summary>
        /// <param name="region">The region the API should query about</param>
        /// <param name="platform">The platform the API should query about</param>
        public void SetPlatformRegion(Region region, Platform platform = Platform.PC)
        {
            switch (platform)
            {
                case Platform.PC:
                    switch (region)
                    {
                        case Region.NorthAmerica:
                            PlatformRegion = "pc-na";
                            break;
                        case Region.Europe:
                            PlatformRegion = "pc-eu";
                            break;
                        case Region.KoreaJapan:
                            PlatformRegion = "pc-krjp";
                            break;
                        case Region.Asia:
                            PlatformRegion = "pc-as";
                            break;
                        case Region.Oceania:
                            PlatformRegion = "pc-oc";
                            break;
                        case Region.SouthAmerica:
                            PlatformRegion = "pc-sa";
                            break;
                        case Region.SouthAsia:
                            PlatformRegion = "pc-sea";
                            break;
                        case Region.Kakao:
                            PlatformRegion = "pc-kakao";
                            break;
                    }
                    break;
                case Platform.Xbox:
                    switch (region)
                    {
                        case Region.NorthAmerica:
                            PlatformRegion = "xbox-na";
                            break;
                        case Region.Europe:
                            PlatformRegion = "xbox-eu";
                            break;
                        case Region.Asia:
                            PlatformRegion = "xbox-as";
                            break;
                        case Region.Oceania:
                            PlatformRegion = "xbox-oc";
                            break;
                    }
                    break;
            }
        }
    }
    /// <summary>
    /// The platforms replays are recorded on
    /// </summary>
    public enum Platform
    {
        PC,
        Xbox,
    }
}
