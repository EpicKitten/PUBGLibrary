using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUBGLibrary.API
{
    public class API
    {
        private string APIKey;
        public string PlatformRegion;
        public APIRequest APIRequest;
        public API(string MatchID, Platform platform, Region KnownRegion, string APIKey)
        {
            SetPlatformRegion(KnownRegion, platform);
            APIRequest.RequestSingleMatch(APIKey, PlatformRegion, MatchID);
        }
        public API(string ReplayDirectoryPath, string APIKey)
        {
            Replay.Replay replay = new Replay.Replay(ReplayDirectoryPath);
            SetPlatformRegion(replay.Summary.KnownRegion);
            APIRequest.RequestSingleMatch(APIKey, PlatformRegion, replay.Info.MatchID);
        }
        public API(Replay.Replay replay, string APIKey)
        {
            SetPlatformRegion(replay.Summary.KnownRegion);
            APIRequest.RequestSingleMatch(APIKey, PlatformRegion, replay.Info.MatchID);
            
        }
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
    public enum Platform
    {
        PC,
        Xbox,
    }
    public enum PlatformRegionPC
    {
        PC_KRJP,
        PC_NA,
        PC_EU,
        PC_OC,
        PC_KAKAO,
        PCS_EA,
        PC_SA,
        PC_AS,
    }
    public enum PlatformRegionXbox
    {
        Xbox_AS,
        Xbox_EU,
        Xbox_NA,
        Xbox_OC,
    }
}
