using System;
using System.Collections.Generic;

namespace PUBGLibrary.API
{
    /// <summary>
    /// The structure of the Telemetry file retuend by the API
    /// </summary>
    public class APITelemetry
    {
        /// <summary>
        /// The bare JSON request
        /// </summary>
        public string BaseJSON;
        /// <summary>
        /// Basic match information about the creation of the match
        /// </summary>
        public LogMatchDefinition LogMatchDefinition = new LogMatchDefinition();
        /// <summary>
        /// Information about the match start, including a list of players, the weather type, etc
        /// </summary>
        public LogMatchStart LogMatchStart = new LogMatchStart();
        /// <summary>
        /// Information about the match end, including a list of players, and the time
        /// </summary>
        public LogMatchEnd LogMatchEnd = new LogMatchEnd();
        /// <summary>
        /// A list of all the players created by the server at match start, including location, health, and ranking of the player
        /// </summary>
        public List<LogPlayerCreate> LogPlayerCreateList = new List<LogPlayerCreate>();
        /// <summary>
        /// A list of all air drops that land including the carpackage model, location, and all items in the air drop
        /// </summary>
        public List<LogCarePackageLand> LogCarePackageLandList = new List<LogCarePackageLand>();
        /// <summary>
        /// A list of all air drops that spawn including the carpackage model, location, and all items in the air drop
        /// </summary>
        public List<LogCarePackageSpawn> LogCarePackageSpawnList = new List<LogCarePackageSpawn>();
        /// <summary>
        /// A list of all attempts by players to join the server
        /// </summary>
        public List<LogPlayerLogin> LogPlayerLoginList = new List<LogPlayerLogin>();
        public List<LogGameStatePeriodic> LogGameStatePeriodicList = new List<LogGameStatePeriodic>();
        /// <summary>
        /// A list of all times a ttachment is being attached
        /// </summary>
        public List<LogItemAttach> logItemAttachList = new List<LogItemAttach>();
        public List<LogPlayerAttack> logPlayerAttackList = new List<LogPlayerAttack>();
        public List<LogPlayerKill> LogPlayerKillList = new List<LogPlayerKill>();
        public List<LogPlayerPosition> LogPlayerPositionList = new List<LogPlayerPosition>();
        public List<LogPlayerLogout> LogPlayerLogoutList = new List<LogPlayerLogout>();
        public List<LogPlayerTakeDamage> LogPlayerTakeDamageList = new List<LogPlayerTakeDamage>();
        public List<LogVehicleDestroy> LogVehicleDestroyList = new List<LogVehicleDestroy>();
        public List<LogVehicleLeave> LogVehicleLeaveList = new List<LogVehicleLeave>();
        public List<LogVehicleRide> LogVehicleRideList = new List<LogVehicleRide>();
        public List<LogItemUse> LogItemUseList = new List<LogItemUse>();
        public List<LogItemUnequip> LogItemUnequipList = new List<LogItemUnequip>();
        public List<LogItemPickup> LogItemPickupList = new List<LogItemPickup>();
        public List<LogItemEquip> LogItemEquipList = new List<LogItemEquip>();
        /// <summary>
        /// A list of all times a item is dropped
        /// </summary>
        public List<LogItemDrop> LogItemDropList = new List<LogItemDrop>();
        /// <summary>
        /// A list of all times a attachment is being deattached
        /// </summary>
        public List<LogItemDetach> LogItemDetachList = new List<LogItemDetach>();

        /// <summary>
        /// Creates a list of players with events attached to them
        /// </summary>
        /// <remarks>Goes through every list and searches for data from the AccountID</remarks>
        public List<PlayerSpecificLog> PlayerSpecificLogList
        {
            get
            {
                List<PlayerSpecificLog> TempPSLL = new List<PlayerSpecificLog>();
                foreach (Player player in LogMatchStart.PlayerList)
                {
                    PlayerSpecificLog playerSpecificLog = new PlayerSpecificLog
                    {
                        PUBGName = player.PUBGName,
                        AccountID = player.AccountID
                    };
                    foreach (LogPlayerCreate createdPlayer in LogPlayerCreateList)
                    {
                        if (createdPlayer.Player.AccountID == player.AccountID)
                        {
                            playerSpecificLog.LogPlayerCreateList.Add(createdPlayer);
                        }
                    }
                    foreach (LogPlayerLogin loggedinPlayer in LogPlayerLoginList)
                    {
                        if (loggedinPlayer.AccountID == player.AccountID)
                        {
                            playerSpecificLog.LogPlayerLoginList.Add(loggedinPlayer);
                        }
                    }
                    foreach (LogItemAttach attacheditem in logItemAttachList)
                    {
                        if (attacheditem.Player.AccountID == player.AccountID)
                        {
                            playerSpecificLog.logItemAttachList.Add(attacheditem);
                        }
                    }
                    foreach (LogPlayerAttack playerattack in logPlayerAttackList)
                    {
                        if (playerattack.Attacker.AccountID == player.AccountID)
                        {
                            playerSpecificLog.logPlayerAttackList.Add(playerattack);
                        }
                    }
                    foreach (LogPlayerKill playerkill in LogPlayerKillList)
                    {
                        if ((playerkill.Killer.AccountID == player.AccountID) || (playerkill.Victim.AccountID == player.AccountID))
                        {
                            playerSpecificLog.LogPlayerKillList.Add(playerkill);
                        }
                    }
                    foreach (LogPlayerPosition playerpos in LogPlayerPositionList)
                    {
                        if (playerpos.LoggedPlayer.AccountID == player.AccountID)
                        {
                            playerSpecificLog.LogPlayerPositionList.Add(playerpos);
                        }
                    }
                    foreach (LogPlayerLogout loggedoutplayer in LogPlayerLogoutList)
                    {
                        if (loggedoutplayer.AccountID == player.AccountID)
                        {
                            playerSpecificLog.LogPlayerLogoutList.Add(loggedoutplayer);
                        }
                    }
                    foreach(LogPlayerTakeDamage playerdmg in LogPlayerTakeDamageList)
                    {
                        if ((playerdmg.Attacker.AccountID == player.AccountID) || (playerdmg.Victim.AccountID == player.AccountID))
                        {
                            playerSpecificLog.LogPlayerTakeDamageList.Add(playerdmg);
                        }
                    }
                    foreach (LogVehicleDestroy destroyedcar in LogVehicleDestroyList)
                    {
                        if (destroyedcar.Attacker.AccountID == player.AccountID)
                        {
                            playerSpecificLog.LogVehicleDestroyList.Add(destroyedcar);
                        }
                    }
                    foreach (LogVehicleLeave leftcar in LogVehicleLeaveList)
                    {
                        if (leftcar.Player.AccountID == player.AccountID)
                        {
                            playerSpecificLog.LogVehicleLeaveList.Add(leftcar);
                        }
                    }
                    foreach (LogVehicleRide uber in LogVehicleRideList)
                    {
                        if (uber.Player.AccountID == player.AccountID)
                        {
                            playerSpecificLog.LogVehicleRideList.Add(uber);
                        }
                    }
                    foreach (LogItemUse useditem in LogItemUseList)
                    {
                        if (useditem.Player.AccountID == player.AccountID)
                        {
                            playerSpecificLog.LogItemUseList.Add(useditem);
                        }
                    }
                    foreach (LogItemUnequip unequippeditem in LogItemUnequipList)
                    {
                        if (unequippeditem.Player.AccountID == player.AccountID)
                        {
                            playerSpecificLog.LogItemUnequipList.Add(unequippeditem);
                        }
                    }
                    foreach (LogItemPickup pickedupitem in LogItemPickupList)
                    {
                        if (pickedupitem.Player.AccountID == player.AccountID)
                        {
                            playerSpecificLog.LogItemPickupList.Add(pickedupitem);
                        }
                    }
                    foreach (LogItemEquip equippeditem in LogItemEquipList)
                    {
                        if (equippeditem.Player.AccountID == player.AccountID)
                        {
                            playerSpecificLog.LogItemEquipList.Add(equippeditem);
                        }
                    }
                    foreach (LogItemDrop droppeditem in LogItemDropList)
                    {
                        if (droppeditem.Player.AccountID == player.AccountID)
                        {
                            playerSpecificLog.LogItemDropList.Add(droppeditem);
                        }
                    }
                    foreach (LogItemDetach detacheditem in LogItemDetachList)
                    {
                        if (detacheditem.Player.AccountID == player.AccountID)
                        {
                            playerSpecificLog.LogItemDetachList.Add(detacheditem);
                        }
                    }
                    TempPSLL.Add(playerSpecificLog);
                }
                return TempPSLL;
            }
        }
        /// <summary>
        /// Search the PlayerSpecificLog list for a Account ID or PUBG Name
        /// </summary>
        /// <param name="input">The AccountID (i.e, account.g8743hfb31023bhf13bbuf3190321fwu) or PUBGName of the player to search for </param>
        /// <param name="searchType">The type of search to perform</param>
        /// <returns>A PlayerSpecificLog class to call associated lists with</returns>
        public PlayerSpecificLog GetPlayerSpecificLog(string input, SearchType searchType = SearchType.AccountID)
        {
            foreach (PlayerSpecificLog psl in PlayerSpecificLogList)
            {
                switch (searchType)
                {
                    case SearchType.AccountID:
                        if (psl.AccountID == input)
                        {
                            return psl;
                        }
                        break;
                    case SearchType.PUBGName:
                        if (psl.PUBGName == input)
                        {
                            return psl;
                        }
                        break;
                }

            }
            return new PlayerSpecificLog();
        }

    }
    /// <summary>
    /// The search type to use when searching for player data
    /// </summary>
    public enum SearchType
    {
        /// <summary>
        /// Search by account ID (i.e, account.g8743hfb31023bhf13bbuf3190321fwu)
        /// </summary>
        AccountID,
        /// <summary>
        /// Search by PUBG name (i.e epickitten)
        /// </summary>
        PUBGName
    }
    /// <summary>
    /// All data related to a single player
    /// </summary>
    public class PlayerSpecificLog
    {
        /// <summary>
        /// The player's PUBG name
        /// </summary>
        public string PUBGName;
        /// <summary>
        /// The player's account ID
        /// </summary>
        public string AccountID;
        /// <summary>
        /// When the player logs into the server
        /// </summary>
        public List<LogPlayerLogin> LogPlayerLoginList = new List<LogPlayerLogin>();
        /// <summary>
        /// When the server actually creates the player in game
        /// </summary>
        public List<LogPlayerCreate> LogPlayerCreateList = new List<LogPlayerCreate>();
        /// <summary>
        /// When the player attaches a attachment to a gun
        /// </summary>
        public List<LogItemAttach> logItemAttachList = new List<LogItemAttach>();
        /// <summary>
        /// When the player damages anything that isnt another player
        /// </summary>
        public List<LogPlayerAttack> logPlayerAttackList = new List<LogPlayerAttack>();
        /// <summary>
        /// When the player kills another player
        /// </summary>
        public List<LogPlayerKill> LogPlayerKillList = new List<LogPlayerKill>();
        /// <summary>
        /// The position of the player every 10 seconds
        /// </summary>
        public List<LogPlayerPosition> LogPlayerPositionList = new List<LogPlayerPosition>();
        /// <summary>
        /// When the player logs out
        /// </summary>
        public List<LogPlayerLogout> LogPlayerLogoutList = new List<LogPlayerLogout>();
        /// <summary>
        /// When the player hurts another player
        /// </summary>
        public List<LogPlayerTakeDamage> LogPlayerTakeDamageList = new List<LogPlayerTakeDamage>();
        /// <summary>
        /// When the player causes a vehicle to explode
        /// </summary>
        public List<LogVehicleDestroy> LogVehicleDestroyList = new List<LogVehicleDestroy>();
        /// <summary>
        /// When the player leaves a vehicle (this includes the parachute and plane)
        /// </summary>
        public List<LogVehicleLeave> LogVehicleLeaveList = new List<LogVehicleLeave>();
        /// <summary>
        /// When the player gets in a vehicle (this includes the parachute and plane)
        /// </summary>
        public List<LogVehicleRide> LogVehicleRideList = new List<LogVehicleRide>();
        /// <summary>
        /// When the player uses a item (First Aid Kit, etc)
        /// </summary>
        public List<LogItemUse> LogItemUseList = new List<LogItemUse>();
        /// <summary>
        /// When the player unequips a item 
        /// </summary>
        public List<LogItemUnequip> LogItemUnequipList = new List<LogItemUnequip>();
        /// <summary>
        /// When the player picks up a item
        /// </summary>
        public List<LogItemPickup> LogItemPickupList = new List<LogItemPickup>();
        /// <summary>
        /// When the player equips a item (guns, smokes, etc)
        /// </summary>
        public List<LogItemEquip> LogItemEquipList = new List<LogItemEquip>();
        /// <summary>
        /// When the player drops a item
        /// </summary>
        public List<LogItemDrop> LogItemDropList = new List<LogItemDrop>();
        /// <summary>
        /// When the player removes a attachment
        /// </summary>
        public List<LogItemDetach> LogItemDetachList = new List<LogItemDetach>();
    }
    /// 
    /// 
    /// Events
    /// 
    ///
    public class LogItemDrop
    {
        public Player Player = new Player();
        public Item DroppedItem = new Item();
        public DateTimeOffset DateTimeOffset = new DateTimeOffset();
    }
    public class LogItemEquip
    {
        public Player Player = new Player();
        public Item EquipedItem = new Item();
        public DateTimeOffset DateTimeOffset = new DateTimeOffset();
    }
    public class LogItemPickup
    {
        public Player Player = new Player();
        public Item PickedupItem = new Item();
        public DateTimeOffset DateTimeOffset = new DateTimeOffset();
    }
    public class LogItemUnequip
    {
        public Player Player = new Player();
        public Item UnequipedItem = new Item();
        public DateTimeOffset DateTimeOffset = new DateTimeOffset();
    }
    public class LogItemUse
    {
        public Player Player = new Player();
        public Item UsedItem = new Item();
        public DateTimeOffset DateTimeOffset = new DateTimeOffset();
    }
    public class LogVehicleRide
    {
        public Player Player = new Player();
        public Transport Vehicle = new Transport();
        public DateTimeOffset DateTimeOffset = new DateTimeOffset();
    }
    public class LogVehicleLeave
    {
        public Player Player = new Player();
        public Transport Vehicle = new Transport();
        public DateTimeOffset DateTimeOffset = new DateTimeOffset();
    }
    public class LogVehicleDestroy
    {
        public double AttackID;
        public Player Attacker = new Player();
        public Transport DestroyedVehicle = new Transport();
        public DateTimeOffset DateTimeOffset = new DateTimeOffset();
    }
    public class LogPlayerTakeDamage
    {
        public double AttackID;
        public Player Attacker = new Player();
        public Player Victim = new Player();
        public Damage Damage = new Damage();
        public DateTimeOffset DateTimeOffset = new DateTimeOffset();
    }

    public class LogPlayerLogout
    {
        public string AccountID;
        public DateTimeOffset DateTimeOffset;
    }
    public class LogPlayerPosition
    {
        public Player LoggedPlayer = new Player();
        public int ElapsedTime;
        public int numAlivePlayers;
        public int UnderThirtyFPS;
        public int UnderSixtyFPS;
        public DateTimeOffset DateTimeOffset = new DateTimeOffset();
    }
    public class LogPlayerKill
    {
        public double AttackID;
        public Player Killer = new Player();
        public Player Victim = new Player();
        public DamageCauser DamageCauser = new DamageCauser();
        public DateTimeOffset DateTimeOffset = new DateTimeOffset();
    }
    public class LogPlayerAttack
    {
        public double AttackID;
        public Player Attacker = new Player();
        public string AttackType;
        public Item AttackerWeapon = new Item();
        public Transport Transport = new Transport();
        public DateTimeOffset DateTimeOffset = new DateTimeOffset();
    }
    /// <summary>
    /// When a player removes a attachment from a gun
    /// </summary>
    public class LogItemDetach
    {
        /// <summary>
        /// The player performing the action
        /// </summary>
        public Player Player = new Player();
        /// <summary>
        /// The item child item is being removed from (usually a gun)
        /// </summary>
        public Item ParentItem = new Item();
        /// <summary>
        /// The item being removed from the parent item (i.e Item_Attach_Weapon_Magazine_QuickDraw_Large_C, Item_Attach_Weapon_Upper_CQBSS_C, etc)
        /// </summary>
        public Item ChildItem = new Item();
        /// <summary>
        /// When the action was performed
        /// </summary>
        public DateTimeOffset DateTime = new DateTimeOffset();
    }
    /// <summary>
    /// When a player adds a attachment to a gun
    /// </summary>
    public class LogItemAttach
    {
        /// <summary>
        /// The player performing the action
        /// </summary>
        public Player Player = new Player();
        /// <summary>
        /// The item child item is attaching to (usually a gun)
        /// </summary>
        public Item ParentItem = new Item();
        /// <summary>
        /// The item being attached to the parent item (i.e Item_Attach_Weapon_Magazine_QuickDraw_Large_C, Item_Attach_Weapon_Upper_CQBSS_C, etc)
        /// </summary>
        public Item ChildItem = new Item();
        /// <summary>
        /// When the action was performed
        /// </summary>
        public DateTimeOffset DateTime = new DateTimeOffset();
    }
    /// <summary>
    /// Information about the match end, including a list of players, and the time
    /// </summary>
    public class LogMatchEnd
    {
        public List<Player> PlayerList = new List<Player>();
        public DateTimeOffset DateTimeOffset = new DateTimeOffset();
    }
    public class LogPlayerLogin
    {
        /// <summary>
        /// If the login failed or not
        /// </summary>
        public bool Result;
        public string AccountID;
        public string ErrorMessage;
        public DateTimeOffset DateTime = new DateTimeOffset();
    }
    /// <summary>
    /// Information about the match start, including a list of player, the weather type, etc
    /// </summary>
    public class LogMatchStart
    {
        public string MapName;
        public string Weather;
        public List<Player> PlayerList = new List<Player>();
        public DateTimeOffset DateTimeOffset = new DateTimeOffset();
    }
    /// <summary>
    /// A player created by the server at match start, including location, health, and ranking of the player
    /// </summary>
    public class LogPlayerCreate
    {
        public Player Player = new Player();
        public DateTime Date = new DateTime();
    }
    /// <summary>
    /// Basic match information about the creation of the match
    /// </summary>
    public class LogMatchDefinition
    {
        public string MatchID;
        public string PingQuality;
        public int Version;
        public DateTimeOffset Event_timestamp = new DateTimeOffset();
    }
    /// <summary>
    /// Information about air drops loaction and items in the drop
    /// </summary>
    public class LogCarePackageLand
    {
        public CarePackage CarePackage = new CarePackage();
    }
    /// <summary>
    /// Information about air drops loaction and items in the drop
    /// </summary>
    public class LogCarePackageSpawn
    {
        public CarePackage CarePackage = new CarePackage();
    }
    public class LogGameStatePeriodic
    {
        public GameState GameState = new GameState();
    }
    ///
    /// 
    /// Sub Event Classes
    /// 
    /// 
    public class Damage
    {
        public string DamageTypeCategory;
        public string DamageReason;
        public double DamageAmount;
        public string DamageCauserName;
        
    }
    public class DamageCauser
    {
        public string DamageTypeCategory;
        public string DamageCauserName;
        public int Distance;
    }
    public class Transport
    {
        public string vehicleType;
        public VehicleId vehicleID;
        public double healthPercent;
        public int fuelPercent;
    }
    public class GameState
    {
        public int ElapsedTime;
        public int NumAliveTeams;
        public int NumJoinPlayers;
        public int NumStartPlayers;
        public int NumAlivePlayers;
        public SafeZone SafeZone = new SafeZone();
        public BlueZone BlueZone = new BlueZone();
        public RedZone RedZone = new RedZone();
        public DateTimeOffset DateTimeOffset = new DateTimeOffset();
    }
    public class SafeZone
    {
        public double X;
        public double Y;
        public double Z;
        public double Radius;
    }
    public class BlueZone
    {
        public double X;
        public double Y;
        public double Z;
        public double Radius;
    }
    public class RedZone
    {
        public double X;
        public double Y;
        public double Z;
        public double Radius;
    }
    public class CarePackage
    {
        public string CarePackageID;
        public Location Location = new Location();
        public List<Item> Items = new List<Item>();
        public DateTimeOffset DateTimeOffset;
    }
    public class Item
    {
        /// <summary>
        /// The name of the item (i.e Item_Attach_Weapon_Magazine_QuickDraw_Large_C, Item_Attach_Weapon_Upper_CQBSS_C, etc)
        /// </summary>
        public string ItemID;
        /// <summary>
        /// The amount in the stack
        /// </summary>
        public int StackCount;
        /// <summary>
        /// The type of item (i.e Attachment, Weapon, Use, etc)
        /// </summary>
        public string Categroy;
        /// <summary>
        /// The sub categroy of the item (i.e Heal, None, etc)
        /// </summary>
        public string SubCategroy;
        /// <summary>
        /// A list of already attached items
        /// </summary>
        public List<string> AttachedItems;
    }
    public class Player
    {
        public string PUBGName;
        public string AccountID;
        public int TeamID;
        public double Health;
        public Location Location = new Location();
        public int Ranking;
    }
    public class Location
    {
        public double X;
        public double Y;
        public double Z;
    }
    
}
