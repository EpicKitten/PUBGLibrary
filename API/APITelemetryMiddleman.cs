// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using PUBGLibrary.API;
//
//    var TelemetryPhrase = TelemetryPhrase.FromJson(jsonString);

#pragma warning disable 1591 //Supresses the need to comment every varible
namespace PUBGLibrary.API
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class TelemetryPhrase
    {
        [JsonProperty("MatchId")]
        public string MatchId { get; set; }

        [JsonProperty("PingQuality")]
        public string PingQuality { get; set; }

        [JsonProperty("_V")]
        public int? V { get; set; }

        [JsonProperty("_D")]
        public DateTimeOffset? D { get; set; }

        [JsonProperty("_U")]
        public bool? U { get; set; }

        [JsonProperty("_T")]
        public T? T { get; set; }

        [JsonProperty("result")]
        public bool? Result { get; set; }

        [JsonProperty("errorMessage")]
        public string ErrorMessage { get; set; }

        [JsonProperty("accountId")]
        public string AccountId { get; set; }

        [JsonProperty("common")]
        public Common Common { get; set; }

        [JsonProperty("character")]
        public Attacker Character { get; set; }

        [JsonProperty("elapsedTime")]
        public long? ElapsedTime { get; set; }

        [JsonProperty("numAlivePlayers")]
        public long? NumAlivePlayers { get; set; }

        [JsonProperty("under30FPS")]
        public long? Under30Fps { get; set; }

        [JsonProperty("under60FPS")]
        public long? Under60Fps { get; set; }

        [JsonProperty("attackId")]
        public long? AttackId { get; set; }

        [JsonProperty("attacker")]
        public Attacker Attacker { get; set; }

        [JsonProperty("attackType")]
        public string AttackType { get; set; }

        [JsonProperty("weapon")]
        public ChildItem Weapon { get; set; }

        [JsonProperty("vehicle")]
        public Vehicle Vehicle { get; set; }

        [JsonProperty("item")]
        public ChildItem Item { get; set; }

        [JsonProperty("mapName")]
        public string MapName { get; set; }

        [JsonProperty("weatherId")]
        public string WeatherId { get; set; }

        [JsonProperty("characters")]
        public List<Character> Characters { get; set; }

        [JsonProperty("gameState")]
        public gameState GameState { get; set; }

        [JsonProperty("parentItem")]
        public ChildItem ParentItem { get; set; }

        [JsonProperty("childItem")]
        public ChildItem ChildItem { get; set; }

        [JsonProperty("victim")]
        public Attacker Victim { get; set; }

        [JsonProperty("damageTypeCategory")]
        public string DamageTypeCategory { get; set; }

        [JsonProperty("damageReason")]
        public string DamageReason { get; set; }

        [JsonProperty("damage")]
        public double? Damage { get; set; }

        [JsonProperty("damageCauserName")]
        public string DamageCauserName { get; set; }

        [JsonProperty("killer")]
        public Attacker Killer { get; set; }

        [JsonProperty("distance")]
        public double? Distance { get; set; }

        [JsonProperty("itemPackage")]
        public ItemPackage ItemPackage { get; set; }
    }

    public partial class Attacker
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("teamId")]
        public int? TeamId { get; set; }

        [JsonProperty("health")]
        public double? Health { get; set; }

        [JsonProperty("location")]
        public AttackerLocation Location { get; set; }

        [JsonProperty("ranking")]
        public int? Ranking { get; set; }

        [JsonProperty("accountId")]
        public string AccountId { get; set; }
    }

    public partial class AttackerLocation
    {
        [JsonProperty("x")]
        public double? X { get; set; }

        [JsonProperty("y")]
        public double? Y { get; set; }

        [JsonProperty("z")]
        public double? Z { get; set; }
    }

    public partial class Character
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("teamId")]
        public long? TeamId { get; set; }

        [JsonProperty("health")]
        public long? Health { get; set; }

        [JsonProperty("location")]
        public PurpleLocation Location { get; set; }

        [JsonProperty("ranking")]
        public long? Ranking { get; set; }

        [JsonProperty("accountId")]
        public string AccountId { get; set; }
    }

    public partial class PurpleLocation
    {
        [JsonProperty("x")]
        public double? X { get; set; }

        [JsonProperty("y")]
        public double? Y { get; set; }

        [JsonProperty("z")]
        public double? Z { get; set; }
    }

    public partial class ChildItem
    {
        [JsonProperty("itemId")]
        public string ItemId { get; set; }

        [JsonProperty("stackCount")]
        public int? StackCount { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("subCategory")]
        public string SubCategory { get; set; }

        [JsonProperty("attachedItems")]
        public List<string> AttachedItems { get; set; }
    }

    public partial class Common
    {
        [JsonProperty("matchId")]
        public string MatchId { get; set; }

        [JsonProperty("mapName")]
        public MapName? MapName { get; set; }

        [JsonProperty("isGame")]
        public double? IsGame { get; set; }
    }

#pragma warning disable IDE1006 // Naming Styles
    public partial class gameState
#pragma warning restore IDE1006 // Naming Styles
    {
        [JsonProperty("elapsedTime")]
        public int? ElapsedTime { get; set; }

        [JsonProperty("numAliveTeams")]
        public int? NumAliveTeams { get; set; }

        [JsonProperty("numJoinPlayers")]
        public int? NumJoinPlayers { get; set; }

        [JsonProperty("numStartPlayers")]
        public int? NumStartPlayers { get; set; }

        [JsonProperty("numAlivePlayers")]
        public int? NumAlivePlayers { get; set; }

        [JsonProperty("safetyZonePosition")]
        public Position SafetyZonePosition { get; set; }

        [JsonProperty("safetyZoneRadius")]
        public double? SafetyZoneRadius { get; set; }

        [JsonProperty("poisonGasWarningPosition")]
        public Position PoisonGasWarningPosition { get; set; }

        [JsonProperty("poisonGasWarningRadius")]
        public double? PoisonGasWarningRadius { get; set; }

        [JsonProperty("redZonePosition")]
        public Position RedZonePosition { get; set; }

        [JsonProperty("redZoneRadius")]
        public long? RedZoneRadius { get; set; }
    }

    public partial class Position
    {
        [JsonProperty("x")]
        public double? X { get; set; }

        [JsonProperty("y")]
        public double? Y { get; set; }

        [JsonProperty("z")]
        public long? Z { get; set; }
    }

    public partial class ItemPackage
    {
        [JsonProperty("itemPackageId")]
        public string ItemPackageId { get; set; }

        [JsonProperty("location")]
        public AttackerLocation Location { get; set; }

        [JsonProperty("items")]
        public List<ChildItem> Items { get; set; }
    }

    public partial class Vehicle
    {
        [JsonProperty("vehicleType")]
        public string VehicleType { get; set; }

        [JsonProperty("vehicleId")]
        public VehicleId? VehicleId { get; set; }

        [JsonProperty("healthPercent")]
        public double? HealthPercent { get; set; }

        [JsonProperty("feulPercent")]
        public double? FeulPercent { get; set; }
    }

    /// 
    /// 
    /// 
    /// 
    /// REMEMBER TO ADD STRING TO VALUE TO STRING
    /// 
    /// 
    /// 
    public enum AttackType
    {
        RedZone,
        Weapon
    };

    public enum SubCategory
    {
        Backpack,
        Boost,
        Fuel,
        Handgun,
        Headgear,
        Heal,
        Main,
        Melee,
        Throwable,
        Vest,
        None,
        Empty,
    };

    public enum MapName
    {
        DesertMain,
        ErangelMain,
        Empty
    };

    public enum DamageReason
    {
        ArmShot,
        HeadShot,
        LegShot,
        PelvisShot,
        TorsoShot,
        NonSpecific,
        None,
    };

    public enum DamageTypeCategory
    {
        DamageBlueZone,
        DamageDrown,
        DamageExplosionGrenade,
        DamageExplosionRedZone,
        DamageExplosionVehicle,
        DamageGroggy,
        DamageGun,
        DamageInstantFall,
        DamageMelee,
        DamageMolotov,
        DamageVehicleCrashHit,
        DamageVehicleHit,
        Empty
    };

    public enum T
    {
        LogCarePackageLand,
        LogCarePackageSpawn,
        LogGameStatePeriodic,
        LogItemAttach,
        LogItemDetach,
        LogItemDrop,
        LogItemEquip,
        LogItemPickup,
        LogItemUnequip,
        LogItemUse,
        LogMatchDefinition,
        LogMatchEnd,
        LogMatchStart,
        LogPlayerAttack,
        LogPlayerCreate,
        LogPlayerKill,
        LogPlayerLogin,
        LogPlayerLogout,
        LogPlayerPosition,
        LogPlayerTakeDamage,
        LogVehicleDestroy,
        LogVehicleLeave,
        LogVehicleRide
    };

    public enum VehicleId
    {
        AquaRailA01_C,
        BoatPG117_C,
        BpMotorbike04_C,
        BpMotorbike04_Desert_C,
        BpMotorbike04_SideCar_C,
        BpMotorbike04_SideCarDesert_C,
        BpPickupTruckA01_C,
        BpPickupTruckA02_C,
        BpPickupTruckA03_C,
        BpPickupTruckA04_C,
        BpPickupTruckA05_C,
        BpPickupTruckB01_C,
        BpPickupTruckB02_C,
        BpPickupTruckB03_C,
        BpPickupTruckB04_C,
        BpPickupTruckB05_C,
        BpVanA01_C,
        BpVanA02_C,
        BpVanA03_C,
        BuggyA01_C,
        BuggyA02_C,
        BuggyA03_C,
        BuggyA04_C,
        BuggyA05_C,
        BuggyA06_C,
        Uaz_A_01_C,
        Uaz_C_01_C,
        Uaz_B_01_C,
        Dacia_A_01_v2_C,
        Dacia_A_02_v2_C,
        Dacia_A_03_v2_C,
        Dacia_A_04_v2_C,
        DummyTransportAircraft_C,
        ParachutePlayer_C,
        PG117_A_01_C,
        Empty
    }
    
    public enum VehicleType
    {
        Empty,
        FloatingVehicle,
        Parachute,
        TransportAircraft,
        WheeledVehicle
    };

    public partial class TelemetryPhrase
    {
        public static List<TelemetryPhrase> FromJson(string json) => JsonConvert.DeserializeObject<List<TelemetryPhrase>>(json, Converter.Settings);
    }

    static class AttackTypeExtensions
    {
        public static AttackType? ValueForString(string str)
        {
            switch (str)
            {
                case "RedZone": return AttackType.RedZone;
                case "Weapon": return AttackType.Weapon;
                default: return null;
            }
        }

        public static AttackType ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }

        public static void WriteJson(this AttackType value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case AttackType.RedZone: serializer.Serialize(writer, "RedZone"); break;
                case AttackType.Weapon: serializer.Serialize(writer, "Weapon"); break;
            }
        }
    }

    static class SubCategoryExtensions
    {
        public static SubCategory? ValueForString(string str)
        {
            switch (str)
            {
                case "Backpack": return SubCategory.Backpack;
                case "Boost": return SubCategory.Boost;
                case "": return SubCategory.Empty;
                case "Fuel": return SubCategory.Fuel;
                case "Handgun": return SubCategory.Handgun;
                case "Headgear": return SubCategory.Headgear;
                case "Heal": return SubCategory.Heal;
                case "Main": return SubCategory.Main;
                case "Melee": return SubCategory.Melee;
                case "None": return SubCategory.None;
                case "Throwable": return SubCategory.Throwable;
                case "Vest": return SubCategory.Vest;
                default: return null;
            }
        }

        public static SubCategory ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }

        public static void WriteJson(this SubCategory value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case SubCategory.Backpack: serializer.Serialize(writer, "Backpack"); break;
                case SubCategory.Boost: serializer.Serialize(writer, "Boost"); break;
                case SubCategory.Empty: serializer.Serialize(writer, ""); break;
                case SubCategory.Fuel: serializer.Serialize(writer, "Fuel"); break;
                case SubCategory.Handgun: serializer.Serialize(writer, "Handgun"); break;
                case SubCategory.Headgear: serializer.Serialize(writer, "Headgear"); break;
                case SubCategory.Heal: serializer.Serialize(writer, "Heal"); break;
                case SubCategory.Main: serializer.Serialize(writer, "Main"); break;
                case SubCategory.Melee: serializer.Serialize(writer, "Melee"); break;
                case SubCategory.None: serializer.Serialize(writer, "None"); break;
                case SubCategory.Throwable: serializer.Serialize(writer, "Throwable"); break;
                case SubCategory.Vest: serializer.Serialize(writer, "Vest"); break;
            }
        }
    }

    static class MapNameExtensions
    {
        public static MapName? ValueForString(string str)
        {
            switch (str)
            {
                case "Desert_Main": return MapName.DesertMain;
                case "Erangel_Main": return MapName.ErangelMain;
                case "": return MapName.Empty;
                default: return null;
            }
        }

        public static MapName ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }

        public static void WriteJson(this MapName value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case MapName.DesertMain: serializer.Serialize(writer, "Desert_Main"); break;
                case MapName.ErangelMain: serializer.Serialize(writer, "Erangel_Main"); break;
                case MapName.Empty: serializer.Serialize(writer, ""); break;
            }
        }
    }

    
    static class DamageReasonExtensions
    {
        public static DamageReason? ValueForString(string str)
        {
            switch (str)
            {
                case "ArmShot": return DamageReason.ArmShot;
                case "HeadShot": return DamageReason.HeadShot;
                case "LegShot": return DamageReason.LegShot;
                case "NonSpecific": return DamageReason.NonSpecific;
                case "None": return DamageReason.None;
                case "PelvisShot": return DamageReason.PelvisShot;
                case "TorsoShot": return DamageReason.TorsoShot;
                default: return null;
            }
        }

        public static DamageReason ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }

        public static void WriteJson(this DamageReason value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case DamageReason.ArmShot: serializer.Serialize(writer, "ArmShot"); break;
                case DamageReason.HeadShot: serializer.Serialize(writer, "HeadShot"); break;
                case DamageReason.LegShot: serializer.Serialize(writer, "LegShot"); break;
                case DamageReason.NonSpecific: serializer.Serialize(writer, "NonSpecific"); break;
                case DamageReason.None: serializer.Serialize(writer, "None"); break;
                case DamageReason.PelvisShot: serializer.Serialize(writer, "PelvisShot"); break;
                case DamageReason.TorsoShot: serializer.Serialize(writer, "TorsoShot"); break;
            }
        }
    }

    static class DamageTypeCategoryExtensions
    {
        public static DamageTypeCategory? ValueForString(string str)
        {
            switch (str)
            {
                case "Damage_BlueZone": return DamageTypeCategory.DamageBlueZone;
                case "Damage_Drown": return DamageTypeCategory.DamageDrown;
                case "Damage_Explosion_Grenade": return DamageTypeCategory.DamageExplosionGrenade;
                case "Damage_Explosion_RedZone": return DamageTypeCategory.DamageExplosionRedZone;
                case "Damage_Explosion_Vehicle": return DamageTypeCategory.DamageExplosionVehicle;
                case "Damage_Groggy": return DamageTypeCategory.DamageGroggy;
                case "Damage_Gun": return DamageTypeCategory.DamageGun;
                case "Damage_Instant_Fall": return DamageTypeCategory.DamageInstantFall;
                case "Damage_Melee": return DamageTypeCategory.DamageMelee;
                case "Damage_Molotov": return DamageTypeCategory.DamageMolotov;
                case "Damage_VehicleCrashHit": return DamageTypeCategory.DamageVehicleCrashHit;
                case "Damage_VehicleHit": return DamageTypeCategory.DamageVehicleHit;
                case "": return DamageTypeCategory.Empty;
                default: return null;
            }
        }

        public static DamageTypeCategory ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }

        public static void WriteJson(this DamageTypeCategory value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case DamageTypeCategory.DamageBlueZone: serializer.Serialize(writer, "Damage_BlueZone"); break;
                case DamageTypeCategory.DamageDrown: serializer.Serialize(writer, "Damage_Drown"); break;
                case DamageTypeCategory.DamageExplosionGrenade: serializer.Serialize(writer, "Damage_Explosion_Grenade"); break;
                case DamageTypeCategory.DamageExplosionRedZone: serializer.Serialize(writer, "Damage_Explosion_RedZone"); break;
                case DamageTypeCategory.DamageExplosionVehicle: serializer.Serialize(writer, "Damage_Explosion_Vehicle"); break;
                case DamageTypeCategory.DamageGroggy: serializer.Serialize(writer, "Damage_Groggy"); break;
                case DamageTypeCategory.DamageGun: serializer.Serialize(writer, "Damage_Gun"); break;
                case DamageTypeCategory.DamageInstantFall: serializer.Serialize(writer, "Damage_Instant_Fall"); break;
                case DamageTypeCategory.DamageMelee: serializer.Serialize(writer, "Damage_Melee"); break;
                case DamageTypeCategory.DamageMolotov: serializer.Serialize(writer, "Damage_Molotov"); break;
                case DamageTypeCategory.DamageVehicleCrashHit: serializer.Serialize(writer, "Damage_VehicleCrashHit"); break;
                case DamageTypeCategory.DamageVehicleHit: serializer.Serialize(writer, "Damage_VehicleHit"); break;
                case DamageTypeCategory.Empty: serializer.Serialize(writer, ""); break;
            }
        }
    }

    

    static class TExtensions
    {
        public static T? ValueForString(string str)
        {
            switch (str)
            {
                case "LogCarePackageLand": return T.LogCarePackageLand;
                case "LogCarePackageSpawn": return T.LogCarePackageSpawn;
                case "LogGameStatePeriodic": return T.LogGameStatePeriodic;
                case "LogItemAttach": return T.LogItemAttach;
                case "LogItemDetach": return T.LogItemDetach;
                case "LogItemDrop": return T.LogItemDrop;
                case "LogItemEquip": return T.LogItemEquip;
                case "LogItemPickup": return T.LogItemPickup;
                case "LogItemUnequip": return T.LogItemUnequip;
                case "LogItemUse": return T.LogItemUse;
                case "LogMatchDefinition": return T.LogMatchDefinition;
                case "LogMatchEnd": return T.LogMatchEnd;
                case "LogMatchStart": return T.LogMatchStart;
                case "LogPlayerAttack": return T.LogPlayerAttack;
                case "LogPlayerCreate": return T.LogPlayerCreate;
                case "LogPlayerKill": return T.LogPlayerKill;
                case "LogPlayerLogin": return T.LogPlayerLogin;
                case "LogPlayerLogout": return T.LogPlayerLogout;
                case "LogPlayerPosition": return T.LogPlayerPosition;
                case "LogPlayerTakeDamage": return T.LogPlayerTakeDamage;
                case "LogVehicleDestroy": return T.LogVehicleDestroy;
                case "LogVehicleLeave": return T.LogVehicleLeave;
                case "LogVehicleRide": return T.LogVehicleRide;
                default: return null;
            }
        }

        public static T ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }

        public static void WriteJson(this T value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case T.LogCarePackageLand: serializer.Serialize(writer, "LogCarePackageLand"); break;
                case T.LogCarePackageSpawn: serializer.Serialize(writer, "LogCarePackageSpawn"); break;
                case T.LogGameStatePeriodic: serializer.Serialize(writer, "LogGameStatePeriodic"); break;
                case T.LogItemAttach: serializer.Serialize(writer, "LogItemAttach"); break;
                case T.LogItemDetach: serializer.Serialize(writer, "LogItemDetach"); break;
                case T.LogItemDrop: serializer.Serialize(writer, "LogItemDrop"); break;
                case T.LogItemEquip: serializer.Serialize(writer, "LogItemEquip"); break;
                case T.LogItemPickup: serializer.Serialize(writer, "LogItemPickup"); break;
                case T.LogItemUnequip: serializer.Serialize(writer, "LogItemUnequip"); break;
                case T.LogItemUse: serializer.Serialize(writer, "LogItemUse"); break;
                case T.LogMatchDefinition: serializer.Serialize(writer, "LogMatchDefinition"); break;
                case T.LogMatchEnd: serializer.Serialize(writer, "LogMatchEnd"); break;
                case T.LogMatchStart: serializer.Serialize(writer, "LogMatchStart"); break;
                case T.LogPlayerAttack: serializer.Serialize(writer, "LogPlayerAttack"); break;
                case T.LogPlayerCreate: serializer.Serialize(writer, "LogPlayerCreate"); break;
                case T.LogPlayerKill: serializer.Serialize(writer, "LogPlayerKill"); break;
                case T.LogPlayerLogin: serializer.Serialize(writer, "LogPlayerLogin"); break;
                case T.LogPlayerLogout: serializer.Serialize(writer, "LogPlayerLogout"); break;
                case T.LogPlayerPosition: serializer.Serialize(writer, "LogPlayerPosition"); break;
                case T.LogPlayerTakeDamage: serializer.Serialize(writer, "LogPlayerTakeDamage"); break;
                case T.LogVehicleDestroy: serializer.Serialize(writer, "LogVehicleDestroy"); break;
                case T.LogVehicleLeave: serializer.Serialize(writer, "LogVehicleLeave"); break;
                case T.LogVehicleRide: serializer.Serialize(writer, "LogVehicleRide"); break;
            }
        }
    }

    static class VehicleIdExtensions
    {
        public static VehicleId? ValueForString(string str)
        {
            switch (str)
            {
                case "AquaRail_A_01_C": return VehicleId.AquaRailA01_C;
                case "Boat_PG117_C": return VehicleId.BoatPG117_C;
                case "BP_Motorbike_04_C": return VehicleId.BpMotorbike04_C;
                case "BP_Motorbike_04_Desert_C": return VehicleId.BpMotorbike04_Desert_C;
                case "BP_Motorbike_04_SideCar_C": return VehicleId.BpMotorbike04_SideCar_C;
                case "BP_Motorbike_04_SideCar_Desert_C": return VehicleId.BpMotorbike04_SideCarDesert_C;
                case "BP_PickupTruck_A_01_C": return VehicleId.BpPickupTruckA01_C;
                case "BP_PickupTruck_A_02_C": return VehicleId.BpPickupTruckA02_C;
                case "BP_PickupTruck_A_03_C": return VehicleId.BpPickupTruckA03_C;
                case "BP_PickupTruck_A_04_C": return VehicleId.BpPickupTruckA04_C;
                case "BP_PickupTruck_A_05_C": return VehicleId.BpPickupTruckA05_C;
                case "BP_PickupTruck_B_01_C": return VehicleId.BpPickupTruckB01_C;
                case "BP_PickupTruck_B_02_C": return VehicleId.BpPickupTruckB02_C;
                case "BP_PickupTruck_B_03_C": return VehicleId.BpPickupTruckB03_C;
                case "BP_PickupTruck_B_04_C": return VehicleId.BpPickupTruckB04_C;
                case "BP_PickupTruck_B_05_C": return VehicleId.BpPickupTruckB05_C;
                case "BP_Van_A_01_C": return VehicleId.BpVanA01_C;
                case "BP_Van_A_02_C": return VehicleId.BpVanA02_C;
                case "BP_Van_A_03_C": return VehicleId.BpVanA03_C;
                case "Buggy_A_01_C": return VehicleId.BuggyA01_C;
                case "Buggy_A_02_C": return VehicleId.BuggyA02_C;
                case "Buggy_A_03_C": return VehicleId.BuggyA03_C;
                case "Buggy_A_04_C": return VehicleId.BuggyA04_C;
                case "Buggy_A_05_C": return VehicleId.BuggyA05_C;
                case "Buggy_A_06_C": return VehicleId.BuggyA06_C;
                case "Uaz_A_01_C": return VehicleId.Uaz_A_01_C;
                case "Uaz_B_01_C": return VehicleId.Uaz_B_01_C;
                case "Uaz_C_01_C": return VehicleId.Uaz_C_01_C;
                case "Dacia_A_01_v2_C": return VehicleId.Dacia_A_01_v2_C;
                case "Dacia_A_02_v2_C": return VehicleId.Dacia_A_02_v2_C;
                case "Dacia_A_03_v2_C": return VehicleId.Dacia_A_03_v2_C;
                case "Dacia_A_04_v2_C": return VehicleId.Dacia_A_04_v2_C;
                case "DummyTransportAircraft_C": return VehicleId.DummyTransportAircraft_C;
                case "": return VehicleId.Empty;
                case "ParachutePlayer_C": return VehicleId.ParachutePlayer_C;
                case "PG117_A_01_C": return VehicleId.PG117_A_01_C;
                default: return null;
            }
        }

        public static VehicleId ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }

        public static void WriteJson(this VehicleId value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case VehicleId.AquaRailA01_C: serializer.Serialize(writer, "AquaRail_A_01_C"); break;
                case VehicleId.BoatPG117_C: serializer.Serialize(writer, "Boat_PG117_C"); break;
                case VehicleId.BpMotorbike04_C: serializer.Serialize(writer, "BP_Motorbike_04_C"); break;
                case VehicleId.BpMotorbike04_Desert_C: serializer.Serialize(writer, "BP_Motorbike_04_Desert_C"); break;
                case VehicleId.BpMotorbike04_SideCar_C: serializer.Serialize(writer, "BP_Motorbike_04_SideCar_C"); break;
                case VehicleId.BpMotorbike04_SideCarDesert_C: serializer.Serialize(writer, "BP_Motorbike_04_SideCar_Desert_C"); break;
                case VehicleId.BpPickupTruckA01_C: serializer.Serialize(writer, "BP_PickupTruck_A_01_C"); break;
                case VehicleId.BpPickupTruckA02_C: serializer.Serialize(writer, "BP_PickupTruck_A_02_C"); break;
                case VehicleId.BpPickupTruckA03_C: serializer.Serialize(writer, "BP_PickupTruck_A_03_C"); break;
                case VehicleId.BpPickupTruckA04_C: serializer.Serialize(writer, "BP_PickupTruck_A_04_C"); break;
                case VehicleId.BpPickupTruckA05_C: serializer.Serialize(writer, "BP_PickupTruck_A_05_C"); break;
                case VehicleId.BpPickupTruckB01_C: serializer.Serialize(writer, "BP_PickupTruck_B_01_C"); break;
                case VehicleId.BpPickupTruckB02_C: serializer.Serialize(writer, "BP_PickupTruck_B_02_C"); break;
                case VehicleId.BpPickupTruckB03_C: serializer.Serialize(writer, "BP_PickupTruck_B_03_C"); break;
                case VehicleId.BpPickupTruckB04_C: serializer.Serialize(writer, "BP_PickupTruck_B_04_C"); break;
                case VehicleId.BpPickupTruckB05_C: serializer.Serialize(writer, "BP_PickupTruck_B_05_C"); break;
                case VehicleId.BpVanA01_C: serializer.Serialize(writer, "BP_Van_A_01_C"); break;
                case VehicleId.BpVanA02_C: serializer.Serialize(writer, "BP_Van_A_02_C"); break;
                case VehicleId.BpVanA03_C: serializer.Serialize(writer, "BP_Van_A_03_C"); break;
                case VehicleId.BuggyA01_C: serializer.Serialize(writer, "Buggy_A_01_C"); break;
                case VehicleId.BuggyA02_C: serializer.Serialize(writer, "Buggy_A_02_C"); break;
                case VehicleId.BuggyA03_C: serializer.Serialize(writer, "Buggy_A_03_C"); break;
                case VehicleId.BuggyA04_C: serializer.Serialize(writer, "Buggy_A_04_C"); break;
                case VehicleId.BuggyA05_C: serializer.Serialize(writer, "Buggy_A_05_C"); break;
                case VehicleId.BuggyA06_C: serializer.Serialize(writer, "Buggy_A_06_C"); break;
                case VehicleId.Dacia_A_02_v2_C: serializer.Serialize(writer, "Dacia_A_02_v2_C"); break;
                case VehicleId.Dacia_A_03_v2_C: serializer.Serialize(writer, "Dacia_A_03_v2_C"); break;
                case VehicleId.Dacia_A_04_v2_C: serializer.Serialize(writer, "Dacia_A_04_v2_C"); break;
                case VehicleId.Uaz_A_01_C: serializer.Serialize(writer, "Uaz_A_01_C"); break;
                case VehicleId.Uaz_B_01_C: serializer.Serialize(writer, "Uaz_B_01_C"); break;
                case VehicleId.Uaz_C_01_C: serializer.Serialize(writer, "Uaz_C_01_C"); break;
                case VehicleId.DummyTransportAircraft_C: serializer.Serialize(writer, "DummyTransportAircraft_C"); break;
                case VehicleId.Empty: serializer.Serialize(writer, ""); break;
                case VehicleId.ParachutePlayer_C: serializer.Serialize(writer, "ParachutePlayer_C"); break;
                case VehicleId.PG117_A_01_C: serializer.Serialize(writer, "PG117_A_01_C"); break;
            }
        }
    }

    static class VehicleTypeExtensions
    {
        public static VehicleType? ValueForString(string str)
        {
            switch (str)
            {
                case "": return VehicleType.Empty;
                case "FloatingVehicle": return VehicleType.FloatingVehicle;
                case "Parachute": return VehicleType.Parachute;
                case "TransportAircraft": return VehicleType.TransportAircraft;
                case "WheeledVehicle": return VehicleType.WheeledVehicle;
                default: return null;
            }
        }

        public static VehicleType ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }
    }
    internal class Converter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(AttackType) || t == typeof(SubCategory) || t == typeof(MapName) || t == typeof(DamageReason) || t == typeof(DamageTypeCategory) || t == typeof(T) || t == typeof(VehicleId) || t == typeof(VehicleType) || t == typeof(AttackType?) || t == typeof(SubCategory?) || t == typeof(MapName?) || t == typeof(DamageReason?) || t == typeof(DamageTypeCategory?) || t == typeof(T?) || t == typeof(VehicleId?) || t == typeof(VehicleType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (t == typeof(AttackType))
                return AttackTypeExtensions.ReadJson(reader, serializer);
            if (t == typeof(SubCategory))
                return SubCategoryExtensions.ReadJson(reader, serializer);
            if (t == typeof(MapName))
                return MapNameExtensions.ReadJson(reader, serializer);
            if (t == typeof(DamageReason))
                return DamageReasonExtensions.ReadJson(reader, serializer);
            if (t == typeof(DamageTypeCategory))
                return DamageTypeCategoryExtensions.ReadJson(reader, serializer);
            if (t == typeof(T))
                return TExtensions.ReadJson(reader, serializer);
            if (t == typeof(VehicleId))
                return VehicleIdExtensions.ReadJson(reader, serializer);
            if (t == typeof(VehicleType))
                return VehicleTypeExtensions.ReadJson(reader, serializer);
            if (t == typeof(AttackType?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return AttackTypeExtensions.ReadJson(reader, serializer);
            }
            if (t == typeof(SubCategory?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return SubCategoryExtensions.ReadJson(reader, serializer);
            }
            if (t == typeof(MapName?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return MapNameExtensions.ReadJson(reader, serializer);
            }
            if (t == typeof(DamageReason?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return DamageReasonExtensions.ReadJson(reader, serializer);
            }
            if (t == typeof(DamageTypeCategory?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return DamageTypeCategoryExtensions.ReadJson(reader, serializer);
            }
            if (t == typeof(T?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return TExtensions.ReadJson(reader, serializer);
            }
            if (t == typeof(VehicleId?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return VehicleIdExtensions.ReadJson(reader, serializer);
            }
            if (t == typeof(VehicleType?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return VehicleTypeExtensions.ReadJson(reader, serializer);
            }
            throw new Exception("Unknown type");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new Converter(),
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
#pragma warning restore 1591