using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Text;

namespace PUBGLibrary.API
{
    /// <summary>
    /// Handles single and multi-match requests
    /// </summary>
    public class APIRequest
    {
        public APIMatch Match;
        public APITelemetry Telemetry;
        public WebException exception;
        public string JSONString;
        /// <summary>
        /// Requests a single match from the PUBG Developer API
        /// </summary>
        /// <param name="APIKey">The API Key to use during the request</param>
        /// <param name="PlatformRegion">The platform-region of the request (xbox-na, pc-oc, etc)</param>
        /// <param name="MatchID">The Match ID of the map</param>
        /// <returns>If null, the request failed</returns>
        public APIRequest RequestSingleMatch(string APIKey, string PlatformRegion, string MatchID)
        {
            APIStatus status = new APIStatus();
            APIRequest APIRequest = new APIRequest();
            if (status.bIsOnline)
            {
                try
                {
                    string APIURL = "https://api.playbattlegrounds.com/shards/" + PlatformRegion + "/matches/" + MatchID;
                    var webRequest = WebRequest.Create(APIURL);
                    var HTTPAPIRequest = (HttpWebRequest)webRequest;
                    HTTPAPIRequest.PreAuthenticate = true;
                    HTTPAPIRequest.Headers.Add("Authorization", "Bearer " + APIKey);
                    HTTPAPIRequest.Headers.Add("Access-Control-Allow-Origins", "*");
                    HTTPAPIRequest.Headers.Add("Access-Control-Expose-Headers", "Content-Length");
                    HTTPAPIRequest.Accept = "application/json";
                    using (var APIResponse = HTTPAPIRequest.GetResponse())
                    {
                        using (var responseStream = APIResponse.GetResponseStream())
                        {
                            var myStreamReader = new StreamReader(responseStream, Encoding.Default);
                            
                            APIRequest.JSONString = myStreamReader.ReadToEnd();
                            APIRequest.Match = MatchPhraser(APIRequest.JSONString);
                            using (WebClient client = new WebClient())
                            {
                                APIRequest.Telemetry = TelemetryPhraser(client.DownloadString(APIRequest.Match.TelemetryURL));
                            }
                            return APIRequest;
                            
                        }
                    }
                }
                catch (WebException e)
                {
                    APIRequest = new APIRequest
                    {
                        exception = e
                    };
                    return APIRequest;
                }
            }
            return APIRequest;
        }
        public APIRequest RequestFilteredMatches(string APIKey, string PlatformRegion, string filterstring)
        {
            APIStatus status = new APIStatus();
            APIRequest APIRequest = new APIRequest();
            if (status.bIsOnline)
            {
                try
                {
                    string APIURL = "https://api.playbattlegrounds.com/shards/" + PlatformRegion + "/matches/?" + filterstring;
                    var webRequest = WebRequest.Create(APIURL);
                    var HTTPAPIRequest = (HttpWebRequest)webRequest;
                    HTTPAPIRequest.PreAuthenticate = true;
                    HTTPAPIRequest.Headers.Add("Authorization", "Bearer " + APIKey);
                    HTTPAPIRequest.Headers.Add("Access-Control-Allow-Origins", "*");
                    HTTPAPIRequest.Headers.Add("Access-Control-Expose-Headers", "Content-Length");
                    HTTPAPIRequest.Accept = "application/json";
                    using (var APIResponse = HTTPAPIRequest.GetResponse())
                    {
                        using (var responseStream = APIResponse.GetResponseStream())
                        {
                            var myStreamReader = new StreamReader(responseStream, Encoding.Default);

                            APIRequest.JSONString = myStreamReader.ReadToEnd();
                            //APIRequest.Match = MatchPhraser(APIRequest.JSONString);
                            //using (WebClient client = new WebClient())
                            //{
                            //    APIRequest.Telemetry = TelemetryPhraser(client.DownloadString(APIRequest.Match.TelemetryURL));
                            //}
                            return APIRequest;

                        }
                    }
                }
                catch (WebException e)
                {
                    APIRequest = new APIRequest
                    {
                        exception = e
                    };
                    return APIRequest;
                }
            }
            return APIRequest;
        }
        public APIRequest RequestFilteredMatches(
            string APIKey,
            string PlatformRegion,
            FilterType filterTypeA,
            string FilterDataA,
            FilterType filterTypeB = FilterType.None,
            string FilterDataB = "",
            FilterType filterTypeC = FilterType.None,
            string FilterDataC = ""
            )
        {
            StringBuilder filterbuild = new StringBuilder();
            filterbuild.Append(API.GetEnumDescription(filterTypeA)).Append(FilterDataA);
            Console.WriteLine("https://api.playbattlegrounds.com/shards/" + PlatformRegion + "/matches/?" + filterbuild.ToString());
            return RequestFilteredMatches(APIKey, PlatformRegion, filterbuild.ToString());
            //if (filterTypeB != FilterType.None)
            //{
            //    filterbuild.Append("&").Append(API.GetEnumDescription(filterTypeB)).Append(FilterDataB);
            //}
            //if (filterTypeC != FilterType.None)
            //{
            //    filterbuild.Append("&").Append(API.GetEnumDescription(filterTypeC)).Append(FilterDataC);
            //}
        }
        public APIMatch MatchPhraser(string JSONstring)
        {
            var jsonmatch = Phraser.FromJson(JSONstring);
            APIMatch Match = new APIMatch();
            foreach (var item in jsonmatch.Included)
            {
                if (item.Type == DatumType.Participant)
                {
                    if (item.Attributes.Stats != null)
                    {
                        APIPlayer player = new APIPlayer();
                        player = item.Attributes.Stats;
                        Match.PlayerList.Add(player);
                    }
                }
                if (item.Type == DatumType.Roster)
                {
                    if (item.Relationships.Participants.Data != null)
                    {
                        APITeam team = new APITeam();
                        foreach (var teamamte in item.Relationships.Participants.Data)
                        {
                            team.TeammateIDList.Add(teamamte.Id);
                        }
                        team.TeamID = (int)item.Attributes.Stats.TeamId;
                        team.rank = (int)item.Attributes.Stats.Rank;
                        team.Won = false;
                        if (item.Attributes.Won == Won.True)
                        {
                            team.Won = true;
                        }
                        Match.TeamList.Add(team);
                    }
                }
                if (item.Type == DatumType.Asset)
                {
                    if (item.Attributes.Url != null)
                    {
                        if (item.Attributes.Name == "telemetry")
                        {
                            Match.TelemetryURL = item.Attributes.Url;
                        }
                    }
                }

            }
            return Match;
        }
        public APITelemetry TelemetryPhraser(string JSONstring)
        {
            var jsontelemetry = TelemetryPhrase.FromJson(JSONstring);
            APITelemetry Telemetry = new APITelemetry();
            foreach (TelemetryPhrase telem in jsontelemetry)
            {
                switch (telem.T)
                {   
                    case T.LogCarePackageLand:
                        LogCarePackageLand logCarePackageLand = new LogCarePackageLand();
                        logCarePackageLand.CarePackage.CarePackageID = telem.ItemPackage.ItemPackageId;
                        logCarePackageLand.CarePackage.DateTimeOffset = (DateTimeOffset)telem.D;
                        foreach (ChildItem childitem in telem.ItemPackage.Items)
                        {
                            Item item = new Item
                            {
                                Categroy = childitem.Category,
                                ItemID = childitem.ItemId,
                                StackCount = (int)childitem.StackCount,
                                SubCategroy = childitem.SubCategory
                            };
                            logCarePackageLand.CarePackage.Items.Add(item);
                        }
                        logCarePackageLand.CarePackage.Location.X = (double)telem.ItemPackage.Location.X;
                        logCarePackageLand.CarePackage.Location.Y = (double)telem.ItemPackage.Location.Y;
                        logCarePackageLand.CarePackage.Location.Z = (double)telem.ItemPackage.Location.Z;
                        Telemetry.LogCarePackageLandList.Add(logCarePackageLand);
                        break;
                    case T.LogCarePackageSpawn:
                        LogCarePackageSpawn logCarePackageSpawn = new LogCarePackageSpawn();
                        logCarePackageSpawn.CarePackage.CarePackageID = telem.ItemPackage.ItemPackageId;
                        logCarePackageSpawn.CarePackage.DateTimeOffset = (DateTimeOffset)telem.D;
                        foreach (ChildItem childitem in telem.ItemPackage.Items)
                        {
                            Item item = new Item
                            {
                                Categroy = childitem.Category,
                                ItemID = childitem.ItemId,
                                StackCount = (int)childitem.StackCount,
                                SubCategroy = childitem.SubCategory
                            };
                            logCarePackageSpawn.CarePackage.Items.Add(item);
                        }
                        logCarePackageSpawn.CarePackage.Location.X = (double)telem.ItemPackage.Location.X;
                        logCarePackageSpawn.CarePackage.Location.Y = (double)telem.ItemPackage.Location.Y;
                        logCarePackageSpawn.CarePackage.Location.Z = (double)telem.ItemPackage.Location.Z;
                        Telemetry.LogCarePackageSpawnList.Add(logCarePackageSpawn);
                        break;
                    case T.LogGameStatePeriodic:
                        LogGameStatePeriodic logGameStatePeriodic = new LogGameStatePeriodic();
                        logGameStatePeriodic.GameState.ElapsedTime = (int)telem.GameState.ElapsedTime;
                        logGameStatePeriodic.GameState.NumAlivePlayers = (int)telem.GameState.NumAlivePlayers;
                        logGameStatePeriodic.GameState.NumAliveTeams = (int)telem.GameState.NumAliveTeams;
                        logGameStatePeriodic.GameState.NumJoinPlayers = (int)telem.GameState.NumJoinPlayers;
                        logGameStatePeriodic.GameState.NumStartPlayers = (int)telem.GameState.NumStartPlayers;
                        logGameStatePeriodic.GameState.SafeZone.X = (double)telem.GameState.SafetyZonePosition.X;
                        logGameStatePeriodic.GameState.SafeZone.Y = (double)telem.GameState.SafetyZonePosition.Y;
                        logGameStatePeriodic.GameState.SafeZone.Z = (double)telem.GameState.SafetyZonePosition.Z;
                        logGameStatePeriodic.GameState.SafeZone.Radius = (double)telem.GameState.SafetyZoneRadius;
                        logGameStatePeriodic.GameState.RedZone.X = (double)telem.GameState.RedZonePosition.X;
                        logGameStatePeriodic.GameState.RedZone.Y = (double)telem.GameState.RedZonePosition.Y;
                        logGameStatePeriodic.GameState.RedZone.Z = (double)telem.GameState.RedZonePosition.Z;
                        logGameStatePeriodic.GameState.RedZone.Radius = (double)telem.GameState.RedZoneRadius;
                        logGameStatePeriodic.GameState.BlueZone.X = (double)telem.GameState.PoisonGasWarningPosition.X;
                        logGameStatePeriodic.GameState.BlueZone.Y = (double)telem.GameState.PoisonGasWarningPosition.Y;
                        logGameStatePeriodic.GameState.BlueZone.Z = (double)telem.GameState.PoisonGasWarningPosition.Z;
                        logGameStatePeriodic.GameState.BlueZone.Radius = (double)telem.GameState.PoisonGasWarningRadius;
                        logGameStatePeriodic.GameState.DateTimeOffset = (DateTimeOffset)telem.D;
                        Telemetry.LogGameStatePeriodicList.Add(logGameStatePeriodic);
                        break;
                    case T.LogItemAttach:
                        LogItemAttach LogItemAttach = new LogItemAttach();
                        LogItemAttach.Player.AccountID = telem.Character.AccountId;
                        LogItemAttach.Player.Health = (double)telem.Character.Health;
                        LogItemAttach.Player.Location.X = (double)telem.Character.Location.X;
                        LogItemAttach.Player.Location.Y = (double)telem.Character.Location.Y;
                        LogItemAttach.Player.Location.Z = (double)telem.Character.Location.Z;
                        LogItemAttach.Player.PUBGName = telem.Character.Name;
                        LogItemAttach.Player.Ranking = (int)telem.Character.Ranking;
                        LogItemAttach.Player.TeamID = (int)telem.Character.TeamId;
                        LogItemAttach.DateTime = (DateTimeOffset)telem.D;
                        LogItemAttach.ParentItem.Categroy = telem.ParentItem.Category;
                        LogItemAttach.ParentItem.ItemID = telem.ParentItem.ItemId;
                        LogItemAttach.ParentItem.StackCount = (int)telem.ParentItem.StackCount;
                        LogItemAttach.ParentItem.SubCategroy = telem.ParentItem.SubCategory;
                        LogItemAttach.ChildItem.Categroy = telem.ChildItem.Category;
                        LogItemAttach.ChildItem.ItemID = telem.ChildItem.ItemId;
                        LogItemAttach.ChildItem.StackCount = (int)telem.ChildItem.StackCount;
                        LogItemAttach.ChildItem.SubCategroy = telem.ChildItem.SubCategory;
                        Telemetry.logItemAttachList.Add(LogItemAttach);
                        break;
                    case T.LogItemDetach:
                        LogItemDetach logItemDetach = new LogItemDetach();
                        logItemDetach.Player.AccountID = telem.Character.AccountId;
                        logItemDetach.Player.Health = (double)telem.Character.Health;
                        logItemDetach.Player.Location.X = (double)telem.Character.Location.X;
                        logItemDetach.Player.Location.Y = (double)telem.Character.Location.Y;
                        logItemDetach.Player.Location.Z = (double)telem.Character.Location.Z;
                        logItemDetach.Player.PUBGName = telem.Character.Name;
                        logItemDetach.Player.Ranking = (int)telem.Character.Ranking;
                        logItemDetach.Player.TeamID = (int)telem.Character.TeamId;
                        logItemDetach.DateTime = (DateTimeOffset)telem.D;
                        logItemDetach.ParentItem.Categroy = telem.ParentItem.Category;
                        logItemDetach.ParentItem.ItemID = telem.ParentItem.ItemId;
                        logItemDetach.ParentItem.StackCount = (int)telem.ParentItem.StackCount;
                        logItemDetach.ParentItem.SubCategroy = telem.ParentItem.SubCategory;
                        logItemDetach.ParentItem.AttachedItems = telem.ParentItem.AttachedItems;
                        logItemDetach.ChildItem.Categroy = telem.ChildItem.Category;
                        logItemDetach.ChildItem.ItemID = telem.ChildItem.ItemId;
                        logItemDetach.ChildItem.StackCount = (int)telem.ChildItem.StackCount;
                        logItemDetach.ChildItem.SubCategroy = telem.ChildItem.SubCategory;
                        logItemDetach.ChildItem.AttachedItems = telem.ChildItem.AttachedItems;
                        Telemetry.LogItemDetachList.Add(logItemDetach);
                        break;
                    case T.LogItemDrop:
                        LogItemDrop logItemDrop = new LogItemDrop();
                        logItemDrop.Player.AccountID = telem.Character.AccountId;
                        logItemDrop.Player.Health = (double)telem.Character.Health;
                        logItemDrop.Player.Location.X = (double)telem.Character.Location.X;
                        logItemDrop.Player.Location.Y = (double)telem.Character.Location.Y;
                        logItemDrop.Player.Location.Z = (double)telem.Character.Location.Z;
                        logItemDrop.Player.PUBGName = telem.Character.Name;
                        logItemDrop.Player.Ranking = (int)telem.Character.Ranking;
                        logItemDrop.Player.TeamID = (int)telem.Character.TeamId;
                        logItemDrop.DroppedItem.Categroy = telem.Item.Category;
                        logItemDrop.DroppedItem.ItemID = telem.Item.ItemId;
                        logItemDrop.DroppedItem.StackCount = (int)telem.Item.StackCount;
                        logItemDrop.DroppedItem.SubCategroy = telem.Item.SubCategory;
                        Telemetry.LogItemDropList.Add(logItemDrop);
                        break;
                    case T.LogItemEquip:
                        LogItemEquip logItemEquip = new LogItemEquip();
                        logItemEquip.Player.AccountID = telem.Character.AccountId;
                        logItemEquip.Player.Health = (double)telem.Character.Health;
                        logItemEquip.Player.Location.X = (double)telem.Character.Location.X;
                        logItemEquip.Player.Location.Y = (double)telem.Character.Location.Y;
                        logItemEquip.Player.Location.Z = (double)telem.Character.Location.Z;
                        logItemEquip.Player.PUBGName = telem.Character.Name;
                        logItemEquip.Player.Ranking = (int)telem.Character.Ranking;
                        logItemEquip.Player.TeamID = (int)telem.Character.TeamId;
                        logItemEquip.EquipedItem.Categroy = telem.Item.Category;
                        logItemEquip.EquipedItem.ItemID = telem.Item.ItemId;
                        logItemEquip.EquipedItem.StackCount = (int)telem.Item.StackCount;
                        logItemEquip.EquipedItem.SubCategroy = telem.Item.SubCategory;
                        Telemetry.LogItemEquipList.Add(logItemEquip);
                        break;
                    case T.LogItemPickup:
                        LogItemPickup logItemPickup = new LogItemPickup();
                        logItemPickup.Player.AccountID = telem.Character.AccountId;
                        logItemPickup.Player.Health = (double)telem.Character.Health;
                        logItemPickup.Player.Location.X = (double)telem.Character.Location.X;
                        logItemPickup.Player.Location.Y = (double)telem.Character.Location.Y;
                        logItemPickup.Player.Location.Z = (double)telem.Character.Location.Z;
                        logItemPickup.Player.PUBGName = telem.Character.Name;
                        logItemPickup.Player.Ranking = (int)telem.Character.Ranking;
                        logItemPickup.Player.TeamID = (int)telem.Character.TeamId;
                        logItemPickup.PickedupItem.Categroy = telem.Item.Category;
                        logItemPickup.PickedupItem.ItemID = telem.Item.ItemId;
                        logItemPickup.PickedupItem.StackCount = (int)telem.Item.StackCount;
                        logItemPickup.PickedupItem.SubCategroy = telem.Item.SubCategory;
                        Telemetry.LogItemPickupList.Add(logItemPickup);
                        break;
                    case T.LogItemUnequip:
                        LogItemUnequip logItemUnequip = new LogItemUnequip();
                        logItemUnequip.Player.AccountID = telem.Character.AccountId;
                        logItemUnequip.Player.Health = (double)telem.Character.Health;
                        logItemUnequip.Player.Location.X = (double)telem.Character.Location.X;
                        logItemUnequip.Player.Location.Y = (double)telem.Character.Location.Y;
                        logItemUnequip.Player.Location.Z = (double)telem.Character.Location.Z;
                        logItemUnequip.Player.PUBGName = telem.Character.Name;
                        logItemUnequip.Player.Ranking = (int)telem.Character.Ranking;
                        logItemUnequip.Player.TeamID = (int)telem.Character.TeamId;
                        logItemUnequip.UnequipedItem.Categroy = telem.Item.Category;
                        logItemUnequip.UnequipedItem.ItemID = telem.Item.ItemId;
                        logItemUnequip.UnequipedItem.StackCount = (int)telem.Item.StackCount;
                        logItemUnequip.UnequipedItem.SubCategroy = telem.Item.SubCategory;
                        Telemetry.LogItemUnequipList.Add(logItemUnequip);
                        break;
                    case T.LogItemUse:
                        LogItemUse logItemUse = new LogItemUse();
                        logItemUse.Player.AccountID = telem.Character.AccountId;
                        logItemUse.Player.Health = (double)telem.Character.Health;
                        logItemUse.Player.Location.X = (double)telem.Character.Location.X;
                        logItemUse.Player.Location.Y = (double)telem.Character.Location.Y;
                        logItemUse.Player.Location.Z = (double)telem.Character.Location.Z;
                        logItemUse.Player.PUBGName = telem.Character.Name;
                        logItemUse.Player.Ranking = (int)telem.Character.Ranking;
                        logItemUse.Player.TeamID = (int)telem.Character.TeamId;
                        logItemUse.UsedItem.Categroy = telem.Item.Category;
                        logItemUse.UsedItem.ItemID = telem.Item.ItemId;
                        logItemUse.UsedItem.StackCount = (int)telem.Item.StackCount;
                        logItemUse.UsedItem.SubCategroy = telem.Item.SubCategory;
                        Telemetry.LogItemUseList.Add(logItemUse);
                        break;
                    case T.LogMatchDefinition:
                        Telemetry.LogMatchDefinition.MatchID = telem.MatchId;
                        Telemetry.LogMatchDefinition.PingQuality = telem.PingQuality;
                        Telemetry.LogMatchDefinition.Version = (int)telem.V;
                        Telemetry.LogMatchDefinition.Event_timestamp = (DateTimeOffset)telem.D;
                        break;
                    case T.LogMatchEnd:
                        Telemetry.LogMatchEnd.DateTimeOffset = (DateTimeOffset)telem.D;
                        foreach (Character person in telem.Characters)
                        {
                            Player player = new Player
                            {
                                AccountID = person.AccountId,
                                PUBGName = person.Name,
                                Health = (double)person.Health
                            };
                            player.Location.X = (double)person.Location.X;
                            player.Location.Y = (double)person.Location.Y;
                            player.Location.Z = (double)person.Location.Z;
                            Telemetry.LogMatchEnd.PlayerList.Add(player);
                        }
                        break;
                    case T.LogMatchStart:
                        Telemetry.LogMatchStart.DateTimeOffset = (DateTimeOffset)telem.D;
                        Telemetry.LogMatchStart.MapName = telem.MapName;
                        Telemetry.LogMatchStart.Weather = telem.WeatherId;
                        foreach (Character person in telem.Characters)
                        {
                            Player player = new Player
                            {
                                AccountID = person.AccountId,
                                PUBGName = person.Name,
                                Health = (double)person.Health
                            };
                            player.Location.X = (double)person.Location.X;
                            player.Location.Y = (double)person.Location.Y;
                            player.Location.Z = (double)person.Location.Z;
                            Telemetry.LogMatchStart.PlayerList.Add(player);
                        }
                        break;
                    case T.LogPlayerAttack:
                        LogPlayerAttack logPlayerAttack = new LogPlayerAttack
                        {
                            AttackID = (double)telem.AttackId,
                            AttackType = telem.AttackType
                        };
                        logPlayerAttack.Transport.fuelPercent = (int)telem.Vehicle.FeulPercent;
                        logPlayerAttack.Transport.healthPercent = (double)telem.Vehicle.HealthPercent;
                        logPlayerAttack.Transport.vehicleID = (VehicleId)telem.Vehicle.VehicleId;
                        logPlayerAttack.Transport.vehicleType = telem.Vehicle.VehicleType;
                        logPlayerAttack.Attacker.AccountID = telem.Attacker.AccountId;
                        logPlayerAttack.Attacker.Health = (double)telem.Attacker.Health;
                        logPlayerAttack.Attacker.Location.X = (double)telem.Attacker.Location.X;
                        logPlayerAttack.Attacker.Location.Y = (double)telem.Attacker.Location.Y;
                        logPlayerAttack.Attacker.Location.Z = (double)telem.Attacker.Location.Z;
                        logPlayerAttack.Attacker.PUBGName = telem.Attacker.Name;
                        logPlayerAttack.Attacker.Ranking = (int)telem.Attacker.Ranking;
                        logPlayerAttack.Attacker.TeamID = (int)telem.Attacker.TeamId;
                        logPlayerAttack.AttackerWeapon.Categroy = telem.Weapon.Category;
                        logPlayerAttack.AttackerWeapon.SubCategroy = telem.Weapon.SubCategory;
                        logPlayerAttack.AttackerWeapon.ItemID = telem.Weapon.ItemId;
                        logPlayerAttack.AttackerWeapon.StackCount = (int)telem.Weapon.StackCount;
                        logPlayerAttack.DateTimeOffset = (DateTimeOffset)telem.D;
                        Telemetry.logPlayerAttackList.Add(logPlayerAttack);
                        break;
                    case T.LogPlayerCreate:
                        LogPlayerCreate logPlayerCreate = new LogPlayerCreate();
                        logPlayerCreate.Player.PUBGName = telem.Character.Name;
                        logPlayerCreate.Player.Health = (double)telem.Character.Health;
                        logPlayerCreate.Player.AccountID = telem.Character.AccountId;
                        logPlayerCreate.Player.Ranking = (int)telem.Character.Ranking;
                        logPlayerCreate.Player.TeamID = (int)telem.Character.TeamId;
                        logPlayerCreate.Player.Location.X = (double)telem.Character.Location.X;
                        logPlayerCreate.Player.Location.Y = (double)telem.Character.Location.Y;
                        logPlayerCreate.Player.Location.Z = (double)telem.Character.Location.Z;
                        Telemetry.LogPlayerCreateList.Add(logPlayerCreate);
                        break;
                    case T.LogPlayerKill:
                        LogPlayerKill logPlayerKill = new LogPlayerKill
                        {
                            AttackID = (double)telem.AttackId
                        };
                        logPlayerKill.Killer.AccountID = telem.Killer.AccountId;
                        logPlayerKill.Killer.Health = (double)telem.Killer.Health;
                        logPlayerKill.Killer.Location.X = (double)telem.Killer.Location.X;
                        logPlayerKill.Killer.Location.Y = (double)telem.Killer.Location.Y;
                        logPlayerKill.Killer.Location.Z = (double)telem.Killer.Location.Z;
                        logPlayerKill.Killer.PUBGName = telem.Killer.Name;
                        logPlayerKill.Killer.Ranking = (int)telem.Killer.Ranking;
                        logPlayerKill.Killer.TeamID = (int)telem.Killer.TeamId;
                        logPlayerKill.Victim.AccountID = telem.Victim.AccountId;
                        logPlayerKill.Victim.Health = (double)telem.Victim.Health;
                        logPlayerKill.Victim.Location.X = (double)telem.Victim.Location.X;
                        logPlayerKill.Victim.Location.Y = (double)telem.Victim.Location.Y;
                        logPlayerKill.Victim.Location.Z = (double)telem.Victim.Location.Z;
                        logPlayerKill.Victim.PUBGName = telem.Victim.Name;
                        logPlayerKill.Victim.Ranking = (int)telem.Victim.Ranking;
                        logPlayerKill.Victim.TeamID = (int)telem.Victim.TeamId;
                        logPlayerKill.DamageCauser.DamageCauserName = telem.DamageCauserName;
                        logPlayerKill.DateTimeOffset = (DateTimeOffset)telem.D;
                        Telemetry.LogPlayerKillList.Add(logPlayerKill);
                        break;
                    case T.LogPlayerLogin:
                        LogPlayerLogin logPlayerLogin = new LogPlayerLogin
                        {
                            AccountID = telem.AccountId,
                            DateTime = (DateTimeOffset)telem.D,
                            Result = (bool)telem.Result,
                            ErrorMessage = telem.ErrorMessage
                        };
                        break;
                    case T.LogPlayerLogout:
                        LogPlayerLogout logPlayerLogout = new LogPlayerLogout
                        {
                            AccountID = telem.AccountId,
                            DateTimeOffset = (DateTimeOffset)telem.D
                        };
                        Telemetry.LogPlayerLogoutList.Add(logPlayerLogout);
                        break;
                    case T.LogPlayerPosition:
                        LogPlayerPosition logPlayerPosition = new LogPlayerPosition();
                        logPlayerPosition.LoggedPlayer.AccountID = telem.Character.AccountId;
                        logPlayerPosition.LoggedPlayer.Health = (double)telem.Character.Health;
                        logPlayerPosition.LoggedPlayer.Location.X = (double)telem.Character.Location.X;
                        logPlayerPosition.LoggedPlayer.Location.Y = (double)telem.Character.Location.Y;
                        logPlayerPosition.LoggedPlayer.Location.Z = (double)telem.Character.Location.Z;
                        logPlayerPosition.LoggedPlayer.PUBGName = telem.Character.Name;
                        logPlayerPosition.LoggedPlayer.Ranking = (int)telem.Character.Ranking;
                        logPlayerPosition.LoggedPlayer.TeamID = (int)telem.Character.TeamId;
                        logPlayerPosition.ElapsedTime = (int)telem.ElapsedTime;
                        logPlayerPosition.numAlivePlayers = (int)telem.NumAlivePlayers;
                        logPlayerPosition.UnderThirtyFPS = (int)telem.Under30Fps;
                        logPlayerPosition.UnderSixtyFPS = (int)telem.Under60Fps;
                        logPlayerPosition.DateTimeOffset = (DateTimeOffset)telem.D;
                        Telemetry.LogPlayerPositionList.Add(logPlayerPosition);
                        break;
                    case T.LogPlayerTakeDamage:
                        LogPlayerTakeDamage logPlayerTakeDamage = new LogPlayerTakeDamage();
                        logPlayerTakeDamage.Attacker.AccountID = telem.Attacker.AccountId;
                        logPlayerTakeDamage.Attacker.Health = (double)telem.Attacker.Health;
                        logPlayerTakeDamage.Attacker.Location.X = (double)telem.Attacker.Location.X;
                        logPlayerTakeDamage.Attacker.Location.Y = (double)telem.Attacker.Location.Y;
                        logPlayerTakeDamage.Attacker.Location.Z = (double)telem.Attacker.Location.Z;
                        logPlayerTakeDamage.Attacker.PUBGName = telem.Attacker.Name;
                        logPlayerTakeDamage.Attacker.Ranking = (int)telem.Attacker.Ranking;
                        logPlayerTakeDamage.Attacker.TeamID = (int)telem.Attacker.TeamId;
                        logPlayerTakeDamage.Victim.AccountID = telem.Victim.AccountId;
                        logPlayerTakeDamage.Victim.Health = (double)telem.Victim.Health;
                        logPlayerTakeDamage.Victim.Location.X = (double)telem.Victim.Location.X;
                        logPlayerTakeDamage.Victim.Location.Y = (double)telem.Victim.Location.Y;
                        logPlayerTakeDamage.Victim.Location.Z = (double)telem.Victim.Location.Z;
                        logPlayerTakeDamage.Victim.PUBGName = telem.Victim.Name;
                        logPlayerTakeDamage.Victim.Ranking = (int)telem.Victim.Ranking;
                        logPlayerTakeDamage.Victim.TeamID = (int)telem.Victim.TeamId;
                        logPlayerTakeDamage.Damage.DamageTypeCategory = telem.DamageTypeCategory;
                        logPlayerTakeDamage.Damage.DamageReason = telem.DamageReason;
                        logPlayerTakeDamage.Damage.DamageAmount = (double)telem.Damage;
                        logPlayerTakeDamage.Damage.DamageCauserName = telem.DamageCauserName;
                        logPlayerTakeDamage.DateTimeOffset = (DateTimeOffset)telem.D;
                        Telemetry.LogPlayerTakeDamageList.Add(logPlayerTakeDamage);
                        break;
                    case T.LogVehicleDestroy:
                        LogVehicleDestroy logVehicleDestroy = new LogVehicleDestroy();
                        logVehicleDestroy.Attacker.AccountID = telem.Attacker.AccountId;
                        logVehicleDestroy.Attacker.Health = (double)telem.Attacker.Health;
                        logVehicleDestroy.Attacker.Location.X = (double)telem.Attacker.Location.X;
                        logVehicleDestroy.Attacker.Location.Y = (double)telem.Attacker.Location.Y;
                        logVehicleDestroy.Attacker.Location.Z = (double)telem.Attacker.Location.Z;
                        logVehicleDestroy.Attacker.PUBGName = telem.Attacker.Name;
                        logVehicleDestroy.Attacker.Ranking = (int)telem.Attacker.Ranking;
                        logVehicleDestroy.Attacker.TeamID = (int)telem.Attacker.TeamId;
                        logVehicleDestroy.DestroyedVehicle.fuelPercent = (int)telem.Vehicle.FeulPercent;
                        logVehicleDestroy.DestroyedVehicle.healthPercent = (double)telem.Vehicle.HealthPercent;
                        logVehicleDestroy.DestroyedVehicle.vehicleID = (VehicleId)telem.Vehicle.VehicleId;
                        logVehicleDestroy.DestroyedVehicle.vehicleType = telem.Vehicle.VehicleType;
                        Telemetry.LogVehicleDestroyList.Add(logVehicleDestroy);
                        break;
                    case T.LogVehicleLeave:
                        LogVehicleLeave logVehicleLeave = new LogVehicleLeave();
                        logVehicleLeave.Player.AccountID = telem.Character.AccountId;
                        logVehicleLeave.Player.Health = (double)telem.Character.Health;
                        logVehicleLeave.Player.Location.X = (double)telem.Character.Location.X;
                        logVehicleLeave.Player.Location.Y = (double)telem.Character.Location.Y;
                        logVehicleLeave.Player.Location.Z = (double)telem.Character.Location.Z;
                        logVehicleLeave.Player.PUBGName = telem.Character.Name;
                        logVehicleLeave.Player.Ranking = (int)telem.Character.Ranking;
                        logVehicleLeave.Player.TeamID = (int)telem.Character.TeamId;
                        logVehicleLeave.Vehicle.fuelPercent = (int)telem.Vehicle.FeulPercent;
                        logVehicleLeave.Vehicle.healthPercent = (double)telem.Vehicle.HealthPercent;
                        logVehicleLeave.Vehicle.vehicleID = (VehicleId)telem.Vehicle.VehicleId;
                        logVehicleLeave.Vehicle.vehicleType = telem.Vehicle.VehicleType;
                        Telemetry.LogVehicleLeaveList.Add(logVehicleLeave);
                        break;
                    case T.LogVehicleRide:
                        LogVehicleRide logVehicleRide = new LogVehicleRide();
                        logVehicleRide.Player.AccountID = telem.Character.AccountId;
                        logVehicleRide.Player.Health = (double)telem.Character.Health;
                        logVehicleRide.Player.Location.X = (double)telem.Character.Location.X;
                        logVehicleRide.Player.Location.Y = (double)telem.Character.Location.Y;
                        logVehicleRide.Player.Location.Z = (double)telem.Character.Location.Z;
                        logVehicleRide.Player.PUBGName = telem.Character.Name;
                        logVehicleRide.Player.Ranking = (int)telem.Character.Ranking;
                        logVehicleRide.Player.TeamID = (int)telem.Character.TeamId;
                        logVehicleRide.Vehicle.fuelPercent = (int)telem.Vehicle.FeulPercent;
                        logVehicleRide.Vehicle.healthPercent = (double)telem.Vehicle.HealthPercent;
                        logVehicleRide.Vehicle.vehicleID = (VehicleId)telem.Vehicle.VehicleId;
                        logVehicleRide.Vehicle.vehicleType = telem.Vehicle.VehicleType;
                        Telemetry.LogVehicleRideList.Add(logVehicleRide);
                        break;
                }
            }
            return Telemetry;
        }
    }
    public enum FilterType
    {
        None,
        /// <summary>
        /// Filter by player IDs
        /// </summary>
        [Description("filter[playerIds]=")]
        playerIDs,
        /// <summary>
        /// Filter by player names
        /// </summary>
        [Description("filter[playerNames]=")]
        playerNames,
        /// <summary>
        /// Filter by game mode
        /// </summary>
        [Description("filter[gameMode]=")]
        GameMode,
    }
}
