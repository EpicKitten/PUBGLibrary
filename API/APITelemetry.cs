using System;
using System.Collections.Generic;

namespace PUBGLibrary.API
{
    public class APITelemetry
    {
        public LogMatchDefinition LogMatchDefinition = new LogMatchDefinition();
        public List<LogPlayerCreate> LogPlayerCreateList = new List<LogPlayerCreate>();
        public List<LogCarePackageLand> LogCarePackageLandList = new List<LogCarePackageLand>();
        public List<LogCarePackageSpawn> LogCarePackageSpawnList = new List<LogCarePackageSpawn>();
        public List<LogPlayerLogin> LogPlayerLoginList = new List<LogPlayerLogin>();
        public List<LogGameStatePeriodic> LogGameStatePeriodicList = new List<LogGameStatePeriodic>();
        public LogMatchEnd LogMatchEnd = new LogMatchEnd();
        public List<LogItemAttach> logItemAttachList = new List<LogItemAttach>();
        public List<LogPlayerAttack> logPlayerAttackList = new List<LogPlayerAttack>();
        public LogMatchStart LogMatchStart = new LogMatchStart();
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
        public List<LogItemDrop> LogItemDropList = new List<LogItemDrop>();
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
    public class LogItemDetach
    {
        public Player Player = new Player();
        public Item ParentItem = new Item();
        public Item ChildItem = new Item();
        public DateTimeOffset DateTime = new DateTimeOffset();
    }
    public class LogItemAttach
    {
        public Player Player = new Player();
        public Item ParentItem = new Item();
        public Item ChildItem = new Item();
        public DateTimeOffset DateTime = new DateTimeOffset();
    }
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
    public class LogMatchStart
    {
        public string MapName;
        public string Weather;
        public List<Player> PlayerList = new List<Player>();
        public DateTimeOffset DateTimeOffset = new DateTimeOffset();
    }
    public class LogPlayerCreate
    {
        public Player Player = new Player();
        public DateTime Date = new DateTime();
    }
    public class LogMatchDefinition
    {
        public string MatchID;
        public string PingQuality;
        public int Version;
        public DateTimeOffset Event_timestamp = new DateTimeOffset();
    }
    public class LogCarePackageLand
    {
        public CarePackage CarePackage = new CarePackage();
    }
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
        public string ItemID;
        public int StackCount;
        public string Categroy;
        public string SubCategroy;
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
