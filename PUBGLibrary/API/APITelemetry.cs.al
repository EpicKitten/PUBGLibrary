// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using PUBGLibrary.API;
//
//    var apiTelemetry = ApiTelemetry.FromJson(jsonString);

namespace PUBGLibrary.API
{
    using System;
    using System.Collections.Generic;
    using System.Net;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class ApiTelemetry
    {
        [JsonProperty("MatchId")]
        public string MatchId { get; set; }

        [JsonProperty("PingQuality")]
        public string PingQuality { get; set; }

        [JsonProperty("_V")]
        public long? V { get; set; }

        [JsonProperty("_D")]
        public System.DateTimeOffset? D { get; set; }

        [JsonProperty("_U")]
        public bool? U { get; set; }

        [JsonProperty("_T")]
        public T? T { get; set; }

        [JsonProperty("result")]
        public bool? Result { get; set; }

        [JsonProperty("errorMessage")]
        public ErrorMessage? ErrorMessage { get; set; }

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
        public AttackType? AttackType { get; set; }

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
        public GameState GameState { get; set; }

        [JsonProperty("victim")]
        public Attacker Victim { get; set; }

        [JsonProperty("damageTypeCategory")]
        public DamageTypeCategory? DamageTypeCategory { get; set; }

        [JsonProperty("damageReason")]
        public DamageReason? DamageReason { get; set; }

        [JsonProperty("damage")]
        public double? Damage { get; set; }

        [JsonProperty("damageCauserName")]
        public DamageCauserName? DamageCauserName { get; set; }

        [JsonProperty("parentItem")]
        public ChildItem ParentItem { get; set; }

        [JsonProperty("childItem")]
        public ChildItem ChildItem { get; set; }

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
        public Name? Name { get; set; }

        [JsonProperty("teamId")]
        public long? TeamId { get; set; }

        [JsonProperty("health")]
        public double? Health { get; set; }

        [JsonProperty("location")]
        public AttackerLocation Location { get; set; }

        [JsonProperty("ranking")]
        public long? Ranking { get; set; }

        [JsonProperty("accountId")]
        public AccountId? AccountId { get; set; }
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
        public long? X { get; set; }

        [JsonProperty("y")]
        public long? Y { get; set; }

        [JsonProperty("z")]
        public long? Z { get; set; }
    }

    public partial class ChildItem
    {
        [JsonProperty("itemId")]
        public ItemId? ItemId { get; set; }

        [JsonProperty("stackCount")]
        public long? StackCount { get; set; }

        [JsonProperty("category")]
        public Category? Category { get; set; }

        [JsonProperty("subCategory")]
        public SubCategory? SubCategory { get; set; }

        [JsonProperty("attachedItems")]
        public List<AttachedItem> AttachedItems { get; set; }
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

    public partial class GameState
    {
        [JsonProperty("elapsedTime")]
        public long? ElapsedTime { get; set; }

        [JsonProperty("numAliveTeams")]
        public long? NumAliveTeams { get; set; }

        [JsonProperty("numJoinPlayers")]
        public long? NumJoinPlayers { get; set; }

        [JsonProperty("numStartPlayers")]
        public long? NumStartPlayers { get; set; }

        [JsonProperty("numAlivePlayers")]
        public long? NumAlivePlayers { get; set; }

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
        public ItemPackageId? ItemPackageId { get; set; }

        [JsonProperty("location")]
        public AttackerLocation Location { get; set; }

        [JsonProperty("items")]
        public List<ChildItem> Items { get; set; }
    }

    public partial class Vehicle
    {
        [JsonProperty("vehicleType")]
        public VehicleType? VehicleType { get; set; }

        [JsonProperty("vehicleId")]
        public VehicleId? VehicleId { get; set; }

        [JsonProperty("healthPercent")]
        public double? HealthPercent { get; set; }

        [JsonProperty("feulPercent")]
        public double? FeulPercent { get; set; }
    }

    public enum AttackType { RedZone, Weapon };

    public enum AccountId { Account0B092Fd15222458B946C1Aac8593C7C3, Account0B119B4Ede3B4Cdfa28F0Ad03B681B91, Account11A5431F58474Ab0Bb2B2D7C740657Fe, Account132E9Fe630Be456085305E464Bb3Bc86, Account150Ee0Bf7Dd346Ed8C746A471A67Cd71, Account16969917319F47Ca8098548Ba3880Df1, Account1B569293579B4E2989675F021430D860, Account1B7Bd27Dd3984Abd941A93Bbf0Bd85Df, Account22329F9527714578A6B82A122E589C68, Account27De6D60A51D46Be8Cdb375Df154A289, Account28F4781751Be4D0C9902D4C73Bf21E83, Account2C8Cabf9E62B4A038766Badadb28889E, Account2Ed87Bbab8504B46Af004289B15Ca27E, Account32Afe13C28594A64B5801223571Ad533, Account353E62C94Ab34D168C01691Be66Cd789, Account3654E255B77B409E87B10Dcb086Ab00D, Account3B072Ab2D9654016911A3E96752460D8, Account3Bc891847Dab44Cda315Df6Cf4Fd905C, Account4719A36Cbe12484Aa05Ff572Bb77888C, Account4761Abf4F15D4F1Aaa03084163Aefa2C, Account482Cb1173C3146B58B059A05428F27F5, Account48F1D86Cebab4C22Bab4D25B9F9C0C4B, Account4Ce5Cb32Fbb14F79A70D8Bd52C31A1D3, Account4Ddc50466110494Baf8Ec3C3Bb9001Ea, Account5064F27C8Eb84C478447D8D3870D9B8F, Account5Eb38076836748D3Af8553045795953C, Account62E9Ecb32F8E494D948B40875C928Bfe, Account64Bce2D894Ee4559B7F40Ca0E1Bd11De, Account66906E0B46814Abe95D9367008896035, Account6772D1Daa3474B0D8B92944E457777B9, Account67Ffc30D9Eb14015Ad428Fd55Aa36F3B, Account680A34Ffc7254C32Aaa5634014E73E1D, Account68Aa4249F6F3427190Ccd5Bbfeb0Abbf, Account6998Fdafb41840Eab0497C7Fa097E4Cb, Account69Fc249D7C474C3E83346E0E668E75C6, Account6C2F595D6B244C22Bfa9D61Dda3Ad87B, Account6C59176537884D5Ba7Bc94830Db5A8Ed, Account7009B53728Ce4Fb582A2D6E58B9B28C5, Account7102D38856D74Caebde58E13Cec79030, Account73F1Ad05Fbed43F99496Ffe87996D0B3, Account7720Fb0476Ac4145A807Dcc8144Db36C, Account7B92D1776Cb3430480C8C957Bb76B787, Account8045177C68E14F88A064C6E5C1F312C9, Account813D19C430Cb4Ae188Bc1Fdc574890D1, Account82F45De0130B424Eb32Dec7D75681C92, Account836Ed8A0E5F849B38Cb625552B110E1B, Account8530B2D91D8C4683B04Daaad32787Cc3, Account86B94E18432E4D5Da4980B06C3F23Be5, Account8B66D706Dd97413Bb33849E08Bcd5254, Account8F92B1E58Af746138C645E5156B87000, Account91Eb8361C20F46D095D1Ad98925693D5, Account9353A4C32640470Dab4Bb81869969E43, Account964A0Ff0C8C94F0197361575F6Eaff1B, Account96Cc435Acfaf4137Be3D44F80C26E108, Account976F6170B87841Bab4Beffd56E32B63D, Account9A5Ebe0Ac2D9449B82Eba4E777057265, Account9A67E5Fab95641Ce81Efabdd73A58B31, Account9D06Fecc0Fb8448D82324D93083853C6, AccountA0C46033039F4Ccfba47Af39696Ad277, AccountA26525Af2C0A410B986910D41D8E423C, AccountA699648Be5204Bdab98E71Cd46966919, AccountA8D79A1E61964C0Bae3E0F32B55Ca258, AccountA977B90D637E490Eaa186587Abba6981, AccountAbb338E6408345E5A6D86D77A3E462E8, AccountAef791265D00449193Fc19B6Fd2Bd7D3, AccountAf68Aaf9F9Dd4Cbe9020Ada151D58201, AccountB6635477Cf6A4E8Ba78893Bb2De2E2D5, AccountB8672333Ac774369B443533F9D7556Fb, AccountB92265Ea75544Dc4963Effe31618478D, AccountBdc84A3E3314447Fa05C2D814C1236D3, AccountC0Eab56Bb90A4011805622Abae2Fc0A7, AccountC1F07355Ecfc4A93814627F7E5A2Df09, AccountC4Ddacbeef774269B19Eb5085D8Fd453, AccountCbf0Cd5595Fa4E4Bbe211350B300C5E5, AccountCc7511C415684908B6Aa8Cd756Db0927, AccountCe516C35D9B5452D80232D19E7B1B33B, AccountCfd4D2Acad654D4A93Aebe91B41Bf6Ec, AccountD34B6C1B93164B9Ab899332F120D23F5, AccountD4659Ecdcedd4022Af6C58B7C500F93A, AccountD773C28D84354414A2B283De0588Dc89, AccountD893F944A8Da46Ceab019A92C47747Ab, AccountD991B392D18C4De1966826Ab9E5Ddfd7, AccountDaf9B87684E046Ce8B1201D0A715E932, AccountDb37Da3Cda79402B95D61956E3A48D5C, AccountDd9E11D047894C86A274A40F0342F057, AccountE0A9Cb7Fe3C84651A1645A5483299162, AccountE11E2926Fc654Af685A258Dff3C73B08, AccountE413C864Dcd64112973D21C4A8B596Fa, AccountE471Fc65651640F58D85181Bea5C44D7, AccountE59E46B7Dfe247Ceb03468A1Dab084Ef, AccountE948A2506Af44429813Dae2Db32Ed22C, AccountEae2Ab68E73D4814B8491109B6C1C6E2, AccountEbe461Aa07014186B98E6Dd6Da3A43Fe, AccountEe21877Ff7Ed443Ebe9Dfefa9Feb8F12, AccountF0D08A9E5D2641948A58B6D5949891Fb, AccountF1Da1C8Db6404C9Db9Ed96267Bfbc243, AccountF632Da4B63184F43932Ecb813760499A, AccountF9Bcf26A062545E6Bcfb10Cf3F7Afe32, AccountFc69Dd36Cfd54F19B7D7Bc2Ee171B002, AccountFf90Cd2D31014769B7B5Dbfe11Cdfd13, Empty };

    public enum Name { Altavista, Andreekou, Andrew226, Andrewk503, Assassin1One7, Basil105, BerserkerMatou, BigBaby, BigDustyDNelson, Bigtittygoth, Brendarrrr, Bschroe, Bundy2, Chuckspinello, CorporateProfit, CrunkZilla, Darkdoom00, Darkkountry, DayGuyKnown, DePee1644, Deathammers, Deathmufn, DeciValentine, DigBic96, DkChef, EdsgerDjikstra, Empty, Epickitten, EverwolfGaming, FuLlbLeeD, G0DKill3R, GargaMike2112, Gerardo778, Ghost4559, Goatlicker25, Gothik, Happy404, HashCrusher, HeBro, IRResponsible, Inadequis, Ingrix, JohnMc, Jondawg, Kaos204, KeysOnTheTable, Killamonjaro, Kimjungun1, Kittywompus, LeDogeyDoge, Lunatica97, MastaFu, MayaNormusbutt, McSquirtz, Monkeybyte, NbkCoco, NbkJuice, Nerfqx, NoComp, Nostradamuru, Nrg1337, OfficerHopps, OldManHatter, Orion5814, PdEslayer, Phishaddict, PreeminentPeace, Ptb334, QRnbw, Raethiance, Raven253, ReclusiveSleet7, RezU, Rinthaugritu, Rlin06, SaltyDan486, SawzeBawze, Scotched, ShadyTactics, ShartLobster, ShrimplyAmazing, Smalbert, Spyder707, StaceeTiny, Sterkcide, The1Shoop2Sheep, The2Gtravis, ThePeaceKepper, TsundereAsukaBum, TurdFerguson, Vasaras1987, Vathas1, Vele1759, Vele1766, VexEd, WazzuXl, Wolfoftwilight, XcuseM3, Yearwargrayson, Yrotsym, ZoatTheGoat };

    public enum AttachedItem { ItemAttachWeaponLowerAngledForeGripC, ItemAttachWeaponLowerForegripC, ItemAttachWeaponMagazineExtendedLargeC, ItemAttachWeaponMagazineExtendedMediumC, ItemAttachWeaponMagazineExtendedQuickDrawLargeC, ItemAttachWeaponMagazineExtendedQuickDrawMediumC, ItemAttachWeaponMagazineExtendedQuickDrawSmallC, ItemAttachWeaponMagazineExtendedQuickDrawSniperRifleC, ItemAttachWeaponMagazineExtendedSmallC, ItemAttachWeaponMagazineExtendedSniperRifleC, ItemAttachWeaponMagazineQuickDrawLargeC, ItemAttachWeaponMagazineQuickDrawMediumC, ItemAttachWeaponMagazineQuickDrawSmallC, ItemAttachWeaponMagazineQuickDrawSniperRifleC, ItemAttachWeaponMuzzleChokeC, ItemAttachWeaponMuzzleCompensatorLargeC, ItemAttachWeaponMuzzleCompensatorMediumC, ItemAttachWeaponMuzzleCompensatorSniperRifleC, ItemAttachWeaponMuzzleFlashHiderLargeC, ItemAttachWeaponMuzzleFlashHiderMediumC, ItemAttachWeaponMuzzleFlashHiderSniperRifleC, ItemAttachWeaponMuzzleSuppressorLargeC, ItemAttachWeaponMuzzleSuppressorMediumC, ItemAttachWeaponMuzzleSuppressorSmallC, ItemAttachWeaponMuzzleSuppressorSniperRifleC, ItemAttachWeaponStockArCompositeC, ItemAttachWeaponStockShotgunBulletLoopsC, ItemAttachWeaponStockSniperRifleBulletLoopsC, ItemAttachWeaponStockSniperRifleCheekPadC, ItemAttachWeaponStockUziC, ItemAttachWeaponUpperAcog01_C, ItemAttachWeaponUpperAimpointC, ItemAttachWeaponUpperCqbssC, ItemAttachWeaponUpperDotSight01_C, ItemAttachWeaponUpperHolosightC };

    public enum Category { Ammunition, Attachment, Empty, Equipment, Use, Weapon };

    public enum ItemId { Empty, ItemAmmo12GuageC, ItemAmmo300MagnumC, ItemAmmo45AcpC, ItemAmmo556MmC, ItemAmmo762MmC, ItemAmmo9MmC, ItemAmmoBoltC, ItemArmorC01_Lv3C, ItemArmorD01_Lv2C, ItemArmorE01_Lv1C, ItemAttachWeaponLowerAngledForeGripC, ItemAttachWeaponLowerForegripC, ItemAttachWeaponLowerQuickDrawLargeCrossbowC, ItemAttachWeaponMagazineExtendedLargeC, ItemAttachWeaponMagazineExtendedMediumC, ItemAttachWeaponMagazineExtendedQuickDrawLargeC, ItemAttachWeaponMagazineExtendedQuickDrawMediumC, ItemAttachWeaponMagazineExtendedQuickDrawSmallC, ItemAttachWeaponMagazineExtendedQuickDrawSniperRifleC, ItemAttachWeaponMagazineExtendedSmallC, ItemAttachWeaponMagazineExtendedSniperRifleC, ItemAttachWeaponMagazineQuickDrawLargeC, ItemAttachWeaponMagazineQuickDrawMediumC, ItemAttachWeaponMagazineQuickDrawSmallC, ItemAttachWeaponMagazineQuickDrawSniperRifleC, ItemAttachWeaponMuzzleChokeC, ItemAttachWeaponMuzzleCompensatorLargeC, ItemAttachWeaponMuzzleCompensatorMediumC, ItemAttachWeaponMuzzleCompensatorSniperRifleC, ItemAttachWeaponMuzzleFlashHiderLargeC, ItemAttachWeaponMuzzleFlashHiderMediumC, ItemAttachWeaponMuzzleFlashHiderSniperRifleC, ItemAttachWeaponMuzzleSuppressorLargeC, ItemAttachWeaponMuzzleSuppressorMediumC, ItemAttachWeaponMuzzleSuppressorSmallC, ItemAttachWeaponMuzzleSuppressorSniperRifleC, ItemAttachWeaponStockArCompositeC, ItemAttachWeaponStockShotgunBulletLoopsC, ItemAttachWeaponStockSniperRifleBulletLoopsC, ItemAttachWeaponStockSniperRifleCheekPadC, ItemAttachWeaponStockUziC, ItemAttachWeaponUpperAcog01_C, ItemAttachWeaponUpperAimpointC, ItemAttachWeaponUpperCqbssC, ItemAttachWeaponUpperDotSight01_C, ItemAttachWeaponUpperHolosightC, ItemBackB01_StartParachutePackC, ItemBackC02_Lv3C, ItemBackE01_Lv1C, ItemBackE02_Lv1C, ItemBackF01_Lv2C, ItemBackF02_Lv2C, ItemBoostEnergyDrinkC, ItemBoostPainKillerC, ItemGhillie01_C, ItemHeadE01_Lv1C, ItemHeadE02_Lv1C, ItemHeadF01_Lv2C, ItemHeadF02_Lv2C, ItemHeadG01_Lv3C, ItemHealBandageC, ItemHealFirstAidC, ItemHealMedKitC, ItemJerryCanC, ItemWeaponAk47C, ItemWeaponAugC, ItemWeaponAwmC, ItemWeaponBerreta686C, ItemWeaponCowbarC, ItemWeaponCrossbowC, ItemWeaponDp28C, ItemWeaponFlashBangC, ItemWeaponG18C, ItemWeaponGrenadeC, ItemWeaponGrozaC, ItemWeaponHk416C, ItemWeaponKar98KC, ItemWeaponM16A4C, ItemWeaponM1911C, ItemWeaponM24C, ItemWeaponM9C, ItemWeaponMacheteC, ItemWeaponMini14C, ItemWeaponMolotovC, ItemWeaponNagantM1895C, ItemWeaponPanC, ItemWeaponSaiga12C, ItemWeaponScarLC, ItemWeaponSickleC, ItemWeaponSksC, ItemWeaponSmokeBombC, ItemWeaponThompsonC, ItemWeaponUmpC, ItemWeaponUziC, ItemWeaponVectorC, ItemWeaponVssC, ItemWeaponWinchesterC };

    public enum SubCategory { Backpack, Boost, Empty, Fuel, Handgun, Headgear, Heal, Jacket, Main, Melee, None, Throwable, Vest };

    public enum MapName { Empty, ErangelMain };

    public enum DamageCauserName { BattleRoyaleModeControllerDefC, BpMotorbike04_C, BpMotorbike04_SideCarC, BuffDecreaseBreathInApneaC, BuggyA02_C, BuggyA03_C, DaciaA01_V2C, DaciaA02_V2C, DaciaA03_V2C, PlayerFemaleAC, PlayerMaleAC, ProjGrenadeC, RedZoneBombC, UazA01_C, UazB01_C, UazC01_C, WeapAk47C, WeapBerreta686C, WeapDp28C, WeapG18C, WeapHk416C, WeapKar98KC, WeapM16A4C, WeapM1911C, WeapM9C, WeapMini14C, WeapNagantM1895C, WeapScarLC, WeapSksC, WeapThompsonC, WeapUmpC, WeapUziC, WeapVssC, WeapWinchesterC };

    public enum DamageReason { ArmShot, HeadShot, LegShot, NonSpecific, None, PelvisShot, TorsoShot };

    public enum DamageTypeCategory { DamageBlueZone, DamageDrown, DamageExplosionGrenade, DamageExplosionRedZone, DamageExplosionVehicle, DamageGroggy, DamageGun, DamageInstantFall, DamageMelee, DamageVehicleCrashHit, DamageVehicleHit, Empty };

    public enum ErrorMessage { Empty };

    public enum ItemPackageId { CarapackageRedBoxC };

    public enum T { LogCarePackageLand, LogCarePackageSpawn, LogGameStatePeriodic, LogItemAttach, LogItemDetach, LogItemDrop, LogItemEquip, LogItemPickup, LogItemUnequip, LogItemUse, LogMatchDefinition, LogMatchEnd, LogMatchStart, LogPlayerAttack, LogPlayerCreate, LogPlayerKill, LogPlayerLogin, LogPlayerLogout, LogPlayerPosition, LogPlayerTakeDamage, LogVehicleDestroy, LogVehicleLeave, LogVehicleRide };

    public enum VehicleId { AquaRailA01_C, BoatPg117C, BpMotorbike04_C, BpMotorbike04_SideCarC, BuggyA01_C, BuggyA02_C, BuggyA03_C, DaciaA01_V2C, DaciaA02_V2C, DaciaA03_V2C, DaciaA04_V2C, DummyTransportAircraftC, Empty, ParachutePlayerC, UazA01_C, UazB01_C, UazC01_C };

    public enum VehicleType { Empty, FloatingVehicle, Parachute, TransportAircraft, WheeledVehicle };

    public partial class ApiTelemetry
    {
        public static List<ApiTelemetry> FromJson(string json) => JsonConvert.DeserializeObject<List<ApiTelemetry>>(json, Converter.SettingsA);
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

    static class AccountIdExtensions
    {
        public static AccountId? ValueForString(string str)
        {
            switch (str)
            {
                case "account.0b092fd15222458b946c1aac8593c7c3": return AccountId.Account0B092Fd15222458B946C1Aac8593C7C3;
                case "account.0b119b4ede3b4cdfa28f0ad03b681b91": return AccountId.Account0B119B4Ede3B4Cdfa28F0Ad03B681B91;
                case "account.11a5431f58474ab0bb2b2d7c740657fe": return AccountId.Account11A5431F58474Ab0Bb2B2D7C740657Fe;
                case "account.132e9fe630be456085305e464bb3bc86": return AccountId.Account132E9Fe630Be456085305E464Bb3Bc86;
                case "account.150ee0bf7dd346ed8c746a471a67cd71": return AccountId.Account150Ee0Bf7Dd346Ed8C746A471A67Cd71;
                case "account.16969917319f47ca8098548ba3880df1": return AccountId.Account16969917319F47Ca8098548Ba3880Df1;
                case "account.1b569293579b4e2989675f021430d860": return AccountId.Account1B569293579B4E2989675F021430D860;
                case "account.1b7bd27dd3984abd941a93bbf0bd85df": return AccountId.Account1B7Bd27Dd3984Abd941A93Bbf0Bd85Df;
                case "account.22329f9527714578a6b82a122e589c68": return AccountId.Account22329F9527714578A6B82A122E589C68;
                case "account.27de6d60a51d46be8cdb375df154a289": return AccountId.Account27De6D60A51D46Be8Cdb375Df154A289;
                case "account.28f4781751be4d0c9902d4c73bf21e83": return AccountId.Account28F4781751Be4D0C9902D4C73Bf21E83;
                case "account.2c8cabf9e62b4a038766badadb28889e": return AccountId.Account2C8Cabf9E62B4A038766Badadb28889E;
                case "account.2ed87bbab8504b46af004289b15ca27e": return AccountId.Account2Ed87Bbab8504B46Af004289B15Ca27E;
                case "account.32afe13c28594a64b5801223571ad533": return AccountId.Account32Afe13C28594A64B5801223571Ad533;
                case "account.353e62c94ab34d168c01691be66cd789": return AccountId.Account353E62C94Ab34D168C01691Be66Cd789;
                case "account.3654e255b77b409e87b10dcb086ab00d": return AccountId.Account3654E255B77B409E87B10Dcb086Ab00D;
                case "account.3b072ab2d9654016911a3e96752460d8": return AccountId.Account3B072Ab2D9654016911A3E96752460D8;
                case "account.3bc891847dab44cda315df6cf4fd905c": return AccountId.Account3Bc891847Dab44Cda315Df6Cf4Fd905C;
                case "account.4719a36cbe12484aa05ff572bb77888c": return AccountId.Account4719A36Cbe12484Aa05Ff572Bb77888C;
                case "account.4761abf4f15d4f1aaa03084163aefa2c": return AccountId.Account4761Abf4F15D4F1Aaa03084163Aefa2C;
                case "account.482cb1173c3146b58b059a05428f27f5": return AccountId.Account482Cb1173C3146B58B059A05428F27F5;
                case "account.48f1d86cebab4c22bab4d25b9f9c0c4b": return AccountId.Account48F1D86Cebab4C22Bab4D25B9F9C0C4B;
                case "account.4ce5cb32fbb14f79a70d8bd52c31a1d3": return AccountId.Account4Ce5Cb32Fbb14F79A70D8Bd52C31A1D3;
                case "account.4ddc50466110494baf8ec3c3bb9001ea": return AccountId.Account4Ddc50466110494Baf8Ec3C3Bb9001Ea;
                case "account.5064f27c8eb84c478447d8d3870d9b8f": return AccountId.Account5064F27C8Eb84C478447D8D3870D9B8F;
                case "account.5eb38076836748d3af8553045795953c": return AccountId.Account5Eb38076836748D3Af8553045795953C;
                case "account.62e9ecb32f8e494d948b40875c928bfe": return AccountId.Account62E9Ecb32F8E494D948B40875C928Bfe;
                case "account.64bce2d894ee4559b7f40ca0e1bd11de": return AccountId.Account64Bce2D894Ee4559B7F40Ca0E1Bd11De;
                case "account.66906e0b46814abe95d9367008896035": return AccountId.Account66906E0B46814Abe95D9367008896035;
                case "account.6772d1daa3474b0d8b92944e457777b9": return AccountId.Account6772D1Daa3474B0D8B92944E457777B9;
                case "account.67ffc30d9eb14015ad428fd55aa36f3b": return AccountId.Account67Ffc30D9Eb14015Ad428Fd55Aa36F3B;
                case "account.680a34ffc7254c32aaa5634014e73e1d": return AccountId.Account680A34Ffc7254C32Aaa5634014E73E1D;
                case "account.68aa4249f6f3427190ccd5bbfeb0abbf": return AccountId.Account68Aa4249F6F3427190Ccd5Bbfeb0Abbf;
                case "account.6998fdafb41840eab0497c7fa097e4cb": return AccountId.Account6998Fdafb41840Eab0497C7Fa097E4Cb;
                case "account.69fc249d7c474c3e83346e0e668e75c6": return AccountId.Account69Fc249D7C474C3E83346E0E668E75C6;
                case "account.6c2f595d6b244c22bfa9d61dda3ad87b": return AccountId.Account6C2F595D6B244C22Bfa9D61Dda3Ad87B;
                case "account.6c59176537884d5ba7bc94830db5a8ed": return AccountId.Account6C59176537884D5Ba7Bc94830Db5A8Ed;
                case "account.7009b53728ce4fb582a2d6e58b9b28c5": return AccountId.Account7009B53728Ce4Fb582A2D6E58B9B28C5;
                case "account.7102d38856d74caebde58e13cec79030": return AccountId.Account7102D38856D74Caebde58E13Cec79030;
                case "account.73f1ad05fbed43f99496ffe87996d0b3": return AccountId.Account73F1Ad05Fbed43F99496Ffe87996D0B3;
                case "account.7720fb0476ac4145a807dcc8144db36c": return AccountId.Account7720Fb0476Ac4145A807Dcc8144Db36C;
                case "account.7b92d1776cb3430480c8c957bb76b787": return AccountId.Account7B92D1776Cb3430480C8C957Bb76B787;
                case "account.8045177c68e14f88a064c6e5c1f312c9": return AccountId.Account8045177C68E14F88A064C6E5C1F312C9;
                case "account.813d19c430cb4ae188bc1fdc574890d1": return AccountId.Account813D19C430Cb4Ae188Bc1Fdc574890D1;
                case "account.82f45de0130b424eb32dec7d75681c92": return AccountId.Account82F45De0130B424Eb32Dec7D75681C92;
                case "account.836ed8a0e5f849b38cb625552b110e1b": return AccountId.Account836Ed8A0E5F849B38Cb625552B110E1B;
                case "account.8530b2d91d8c4683b04daaad32787cc3": return AccountId.Account8530B2D91D8C4683B04Daaad32787Cc3;
                case "account.86b94e18432e4d5da4980b06c3f23be5": return AccountId.Account86B94E18432E4D5Da4980B06C3F23Be5;
                case "account.8b66d706dd97413bb33849e08bcd5254": return AccountId.Account8B66D706Dd97413Bb33849E08Bcd5254;
                case "account.8f92b1e58af746138c645e5156b87000": return AccountId.Account8F92B1E58Af746138C645E5156B87000;
                case "account.91eb8361c20f46d095d1ad98925693d5": return AccountId.Account91Eb8361C20F46D095D1Ad98925693D5;
                case "account.9353a4c32640470dab4bb81869969e43": return AccountId.Account9353A4C32640470Dab4Bb81869969E43;
                case "account.964a0ff0c8c94f0197361575f6eaff1b": return AccountId.Account964A0Ff0C8C94F0197361575F6Eaff1B;
                case "account.96cc435acfaf4137be3d44f80c26e108": return AccountId.Account96Cc435Acfaf4137Be3D44F80C26E108;
                case "account.976f6170b87841bab4beffd56e32b63d": return AccountId.Account976F6170B87841Bab4Beffd56E32B63D;
                case "account.9a5ebe0ac2d9449b82eba4e777057265": return AccountId.Account9A5Ebe0Ac2D9449B82Eba4E777057265;
                case "account.9a67e5fab95641ce81efabdd73a58b31": return AccountId.Account9A67E5Fab95641Ce81Efabdd73A58B31;
                case "account.9d06fecc0fb8448d82324d93083853c6": return AccountId.Account9D06Fecc0Fb8448D82324D93083853C6;
                case "account.a0c46033039f4ccfba47af39696ad277": return AccountId.AccountA0C46033039F4Ccfba47Af39696Ad277;
                case "account.a26525af2c0a410b986910d41d8e423c": return AccountId.AccountA26525Af2C0A410B986910D41D8E423C;
                case "account.a699648be5204bdab98e71cd46966919": return AccountId.AccountA699648Be5204Bdab98E71Cd46966919;
                case "account.a8d79a1e61964c0bae3e0f32b55ca258": return AccountId.AccountA8D79A1E61964C0Bae3E0F32B55Ca258;
                case "account.a977b90d637e490eaa186587abba6981": return AccountId.AccountA977B90D637E490Eaa186587Abba6981;
                case "account.abb338e6408345e5a6d86d77a3e462e8": return AccountId.AccountAbb338E6408345E5A6D86D77A3E462E8;
                case "account.aef791265d00449193fc19b6fd2bd7d3": return AccountId.AccountAef791265D00449193Fc19B6Fd2Bd7D3;
                case "account.af68aaf9f9dd4cbe9020ada151d58201": return AccountId.AccountAf68Aaf9F9Dd4Cbe9020Ada151D58201;
                case "account.b6635477cf6a4e8ba78893bb2de2e2d5": return AccountId.AccountB6635477Cf6A4E8Ba78893Bb2De2E2D5;
                case "account.b8672333ac774369b443533f9d7556fb": return AccountId.AccountB8672333Ac774369B443533F9D7556Fb;
                case "account.b92265ea75544dc4963effe31618478d": return AccountId.AccountB92265Ea75544Dc4963Effe31618478D;
                case "account.bdc84a3e3314447fa05c2d814c1236d3": return AccountId.AccountBdc84A3E3314447Fa05C2D814C1236D3;
                case "account.c0eab56bb90a4011805622abae2fc0a7": return AccountId.AccountC0Eab56Bb90A4011805622Abae2Fc0A7;
                case "account.c1f07355ecfc4a93814627f7e5a2df09": return AccountId.AccountC1F07355Ecfc4A93814627F7E5A2Df09;
                case "account.c4ddacbeef774269b19eb5085d8fd453": return AccountId.AccountC4Ddacbeef774269B19Eb5085D8Fd453;
                case "account.cbf0cd5595fa4e4bbe211350b300c5e5": return AccountId.AccountCbf0Cd5595Fa4E4Bbe211350B300C5E5;
                case "account.cc7511c415684908b6aa8cd756db0927": return AccountId.AccountCc7511C415684908B6Aa8Cd756Db0927;
                case "account.ce516c35d9b5452d80232d19e7b1b33b": return AccountId.AccountCe516C35D9B5452D80232D19E7B1B33B;
                case "account.cfd4d2acad654d4a93aebe91b41bf6ec": return AccountId.AccountCfd4D2Acad654D4A93Aebe91B41Bf6Ec;
                case "account.d34b6c1b93164b9ab899332f120d23f5": return AccountId.AccountD34B6C1B93164B9Ab899332F120D23F5;
                case "account.d4659ecdcedd4022af6c58b7c500f93a": return AccountId.AccountD4659Ecdcedd4022Af6C58B7C500F93A;
                case "account.d773c28d84354414a2b283de0588dc89": return AccountId.AccountD773C28D84354414A2B283De0588Dc89;
                case "account.d893f944a8da46ceab019a92c47747ab": return AccountId.AccountD893F944A8Da46Ceab019A92C47747Ab;
                case "account.d991b392d18c4de1966826ab9e5ddfd7": return AccountId.AccountD991B392D18C4De1966826Ab9E5Ddfd7;
                case "account.daf9b87684e046ce8b1201d0a715e932": return AccountId.AccountDaf9B87684E046Ce8B1201D0A715E932;
                case "account.db37da3cda79402b95d61956e3a48d5c": return AccountId.AccountDb37Da3Cda79402B95D61956E3A48D5C;
                case "account.dd9e11d047894c86a274a40f0342f057": return AccountId.AccountDd9E11D047894C86A274A40F0342F057;
                case "account.e0a9cb7fe3c84651a1645a5483299162": return AccountId.AccountE0A9Cb7Fe3C84651A1645A5483299162;
                case "account.e11e2926fc654af685a258dff3c73b08": return AccountId.AccountE11E2926Fc654Af685A258Dff3C73B08;
                case "account.e413c864dcd64112973d21c4a8b596fa": return AccountId.AccountE413C864Dcd64112973D21C4A8B596Fa;
                case "account.e471fc65651640f58d85181bea5c44d7": return AccountId.AccountE471Fc65651640F58D85181Bea5C44D7;
                case "account.e59e46b7dfe247ceb03468a1dab084ef": return AccountId.AccountE59E46B7Dfe247Ceb03468A1Dab084Ef;
                case "account.e948a2506af44429813dae2db32ed22c": return AccountId.AccountE948A2506Af44429813Dae2Db32Ed22C;
                case "account.eae2ab68e73d4814b8491109b6c1c6e2": return AccountId.AccountEae2Ab68E73D4814B8491109B6C1C6E2;
                case "account.ebe461aa07014186b98e6dd6da3a43fe": return AccountId.AccountEbe461Aa07014186B98E6Dd6Da3A43Fe;
                case "account.ee21877ff7ed443ebe9dfefa9feb8f12": return AccountId.AccountEe21877Ff7Ed443Ebe9Dfefa9Feb8F12;
                case "account.f0d08a9e5d2641948a58b6d5949891fb": return AccountId.AccountF0D08A9E5D2641948A58B6D5949891Fb;
                case "account.f1da1c8db6404c9db9ed96267bfbc243": return AccountId.AccountF1Da1C8Db6404C9Db9Ed96267Bfbc243;
                case "account.f632da4b63184f43932ecb813760499a": return AccountId.AccountF632Da4B63184F43932Ecb813760499A;
                case "account.f9bcf26a062545e6bcfb10cf3f7afe32": return AccountId.AccountF9Bcf26A062545E6Bcfb10Cf3F7Afe32;
                case "account.fc69dd36cfd54f19b7d7bc2ee171b002": return AccountId.AccountFc69Dd36Cfd54F19B7D7Bc2Ee171B002;
                case "account.ff90cd2d31014769b7b5dbfe11cdfd13": return AccountId.AccountFf90Cd2D31014769B7B5Dbfe11Cdfd13;
                case "": return AccountId.Empty;
                default: return null;
            }
        }

        public static AccountId ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }

        public static void WriteJson(this AccountId value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case AccountId.Account0B092Fd15222458B946C1Aac8593C7C3: serializer.Serialize(writer, "account.0b092fd15222458b946c1aac8593c7c3"); break;
                case AccountId.Account0B119B4Ede3B4Cdfa28F0Ad03B681B91: serializer.Serialize(writer, "account.0b119b4ede3b4cdfa28f0ad03b681b91"); break;
                case AccountId.Account11A5431F58474Ab0Bb2B2D7C740657Fe: serializer.Serialize(writer, "account.11a5431f58474ab0bb2b2d7c740657fe"); break;
                case AccountId.Account132E9Fe630Be456085305E464Bb3Bc86: serializer.Serialize(writer, "account.132e9fe630be456085305e464bb3bc86"); break;
                case AccountId.Account150Ee0Bf7Dd346Ed8C746A471A67Cd71: serializer.Serialize(writer, "account.150ee0bf7dd346ed8c746a471a67cd71"); break;
                case AccountId.Account16969917319F47Ca8098548Ba3880Df1: serializer.Serialize(writer, "account.16969917319f47ca8098548ba3880df1"); break;
                case AccountId.Account1B569293579B4E2989675F021430D860: serializer.Serialize(writer, "account.1b569293579b4e2989675f021430d860"); break;
                case AccountId.Account1B7Bd27Dd3984Abd941A93Bbf0Bd85Df: serializer.Serialize(writer, "account.1b7bd27dd3984abd941a93bbf0bd85df"); break;
                case AccountId.Account22329F9527714578A6B82A122E589C68: serializer.Serialize(writer, "account.22329f9527714578a6b82a122e589c68"); break;
                case AccountId.Account27De6D60A51D46Be8Cdb375Df154A289: serializer.Serialize(writer, "account.27de6d60a51d46be8cdb375df154a289"); break;
                case AccountId.Account28F4781751Be4D0C9902D4C73Bf21E83: serializer.Serialize(writer, "account.28f4781751be4d0c9902d4c73bf21e83"); break;
                case AccountId.Account2C8Cabf9E62B4A038766Badadb28889E: serializer.Serialize(writer, "account.2c8cabf9e62b4a038766badadb28889e"); break;
                case AccountId.Account2Ed87Bbab8504B46Af004289B15Ca27E: serializer.Serialize(writer, "account.2ed87bbab8504b46af004289b15ca27e"); break;
                case AccountId.Account32Afe13C28594A64B5801223571Ad533: serializer.Serialize(writer, "account.32afe13c28594a64b5801223571ad533"); break;
                case AccountId.Account353E62C94Ab34D168C01691Be66Cd789: serializer.Serialize(writer, "account.353e62c94ab34d168c01691be66cd789"); break;
                case AccountId.Account3654E255B77B409E87B10Dcb086Ab00D: serializer.Serialize(writer, "account.3654e255b77b409e87b10dcb086ab00d"); break;
                case AccountId.Account3B072Ab2D9654016911A3E96752460D8: serializer.Serialize(writer, "account.3b072ab2d9654016911a3e96752460d8"); break;
                case AccountId.Account3Bc891847Dab44Cda315Df6Cf4Fd905C: serializer.Serialize(writer, "account.3bc891847dab44cda315df6cf4fd905c"); break;
                case AccountId.Account4719A36Cbe12484Aa05Ff572Bb77888C: serializer.Serialize(writer, "account.4719a36cbe12484aa05ff572bb77888c"); break;
                case AccountId.Account4761Abf4F15D4F1Aaa03084163Aefa2C: serializer.Serialize(writer, "account.4761abf4f15d4f1aaa03084163aefa2c"); break;
                case AccountId.Account482Cb1173C3146B58B059A05428F27F5: serializer.Serialize(writer, "account.482cb1173c3146b58b059a05428f27f5"); break;
                case AccountId.Account48F1D86Cebab4C22Bab4D25B9F9C0C4B: serializer.Serialize(writer, "account.48f1d86cebab4c22bab4d25b9f9c0c4b"); break;
                case AccountId.Account4Ce5Cb32Fbb14F79A70D8Bd52C31A1D3: serializer.Serialize(writer, "account.4ce5cb32fbb14f79a70d8bd52c31a1d3"); break;
                case AccountId.Account4Ddc50466110494Baf8Ec3C3Bb9001Ea: serializer.Serialize(writer, "account.4ddc50466110494baf8ec3c3bb9001ea"); break;
                case AccountId.Account5064F27C8Eb84C478447D8D3870D9B8F: serializer.Serialize(writer, "account.5064f27c8eb84c478447d8d3870d9b8f"); break;
                case AccountId.Account5Eb38076836748D3Af8553045795953C: serializer.Serialize(writer, "account.5eb38076836748d3af8553045795953c"); break;
                case AccountId.Account62E9Ecb32F8E494D948B40875C928Bfe: serializer.Serialize(writer, "account.62e9ecb32f8e494d948b40875c928bfe"); break;
                case AccountId.Account64Bce2D894Ee4559B7F40Ca0E1Bd11De: serializer.Serialize(writer, "account.64bce2d894ee4559b7f40ca0e1bd11de"); break;
                case AccountId.Account66906E0B46814Abe95D9367008896035: serializer.Serialize(writer, "account.66906e0b46814abe95d9367008896035"); break;
                case AccountId.Account6772D1Daa3474B0D8B92944E457777B9: serializer.Serialize(writer, "account.6772d1daa3474b0d8b92944e457777b9"); break;
                case AccountId.Account67Ffc30D9Eb14015Ad428Fd55Aa36F3B: serializer.Serialize(writer, "account.67ffc30d9eb14015ad428fd55aa36f3b"); break;
                case AccountId.Account680A34Ffc7254C32Aaa5634014E73E1D: serializer.Serialize(writer, "account.680a34ffc7254c32aaa5634014e73e1d"); break;
                case AccountId.Account68Aa4249F6F3427190Ccd5Bbfeb0Abbf: serializer.Serialize(writer, "account.68aa4249f6f3427190ccd5bbfeb0abbf"); break;
                case AccountId.Account6998Fdafb41840Eab0497C7Fa097E4Cb: serializer.Serialize(writer, "account.6998fdafb41840eab0497c7fa097e4cb"); break;
                case AccountId.Account69Fc249D7C474C3E83346E0E668E75C6: serializer.Serialize(writer, "account.69fc249d7c474c3e83346e0e668e75c6"); break;
                case AccountId.Account6C2F595D6B244C22Bfa9D61Dda3Ad87B: serializer.Serialize(writer, "account.6c2f595d6b244c22bfa9d61dda3ad87b"); break;
                case AccountId.Account6C59176537884D5Ba7Bc94830Db5A8Ed: serializer.Serialize(writer, "account.6c59176537884d5ba7bc94830db5a8ed"); break;
                case AccountId.Account7009B53728Ce4Fb582A2D6E58B9B28C5: serializer.Serialize(writer, "account.7009b53728ce4fb582a2d6e58b9b28c5"); break;
                case AccountId.Account7102D38856D74Caebde58E13Cec79030: serializer.Serialize(writer, "account.7102d38856d74caebde58e13cec79030"); break;
                case AccountId.Account73F1Ad05Fbed43F99496Ffe87996D0B3: serializer.Serialize(writer, "account.73f1ad05fbed43f99496ffe87996d0b3"); break;
                case AccountId.Account7720Fb0476Ac4145A807Dcc8144Db36C: serializer.Serialize(writer, "account.7720fb0476ac4145a807dcc8144db36c"); break;
                case AccountId.Account7B92D1776Cb3430480C8C957Bb76B787: serializer.Serialize(writer, "account.7b92d1776cb3430480c8c957bb76b787"); break;
                case AccountId.Account8045177C68E14F88A064C6E5C1F312C9: serializer.Serialize(writer, "account.8045177c68e14f88a064c6e5c1f312c9"); break;
                case AccountId.Account813D19C430Cb4Ae188Bc1Fdc574890D1: serializer.Serialize(writer, "account.813d19c430cb4ae188bc1fdc574890d1"); break;
                case AccountId.Account82F45De0130B424Eb32Dec7D75681C92: serializer.Serialize(writer, "account.82f45de0130b424eb32dec7d75681c92"); break;
                case AccountId.Account836Ed8A0E5F849B38Cb625552B110E1B: serializer.Serialize(writer, "account.836ed8a0e5f849b38cb625552b110e1b"); break;
                case AccountId.Account8530B2D91D8C4683B04Daaad32787Cc3: serializer.Serialize(writer, "account.8530b2d91d8c4683b04daaad32787cc3"); break;
                case AccountId.Account86B94E18432E4D5Da4980B06C3F23Be5: serializer.Serialize(writer, "account.86b94e18432e4d5da4980b06c3f23be5"); break;
                case AccountId.Account8B66D706Dd97413Bb33849E08Bcd5254: serializer.Serialize(writer, "account.8b66d706dd97413bb33849e08bcd5254"); break;
                case AccountId.Account8F92B1E58Af746138C645E5156B87000: serializer.Serialize(writer, "account.8f92b1e58af746138c645e5156b87000"); break;
                case AccountId.Account91Eb8361C20F46D095D1Ad98925693D5: serializer.Serialize(writer, "account.91eb8361c20f46d095d1ad98925693d5"); break;
                case AccountId.Account9353A4C32640470Dab4Bb81869969E43: serializer.Serialize(writer, "account.9353a4c32640470dab4bb81869969e43"); break;
                case AccountId.Account964A0Ff0C8C94F0197361575F6Eaff1B: serializer.Serialize(writer, "account.964a0ff0c8c94f0197361575f6eaff1b"); break;
                case AccountId.Account96Cc435Acfaf4137Be3D44F80C26E108: serializer.Serialize(writer, "account.96cc435acfaf4137be3d44f80c26e108"); break;
                case AccountId.Account976F6170B87841Bab4Beffd56E32B63D: serializer.Serialize(writer, "account.976f6170b87841bab4beffd56e32b63d"); break;
                case AccountId.Account9A5Ebe0Ac2D9449B82Eba4E777057265: serializer.Serialize(writer, "account.9a5ebe0ac2d9449b82eba4e777057265"); break;
                case AccountId.Account9A67E5Fab95641Ce81Efabdd73A58B31: serializer.Serialize(writer, "account.9a67e5fab95641ce81efabdd73a58b31"); break;
                case AccountId.Account9D06Fecc0Fb8448D82324D93083853C6: serializer.Serialize(writer, "account.9d06fecc0fb8448d82324d93083853c6"); break;
                case AccountId.AccountA0C46033039F4Ccfba47Af39696Ad277: serializer.Serialize(writer, "account.a0c46033039f4ccfba47af39696ad277"); break;
                case AccountId.AccountA26525Af2C0A410B986910D41D8E423C: serializer.Serialize(writer, "account.a26525af2c0a410b986910d41d8e423c"); break;
                case AccountId.AccountA699648Be5204Bdab98E71Cd46966919: serializer.Serialize(writer, "account.a699648be5204bdab98e71cd46966919"); break;
                case AccountId.AccountA8D79A1E61964C0Bae3E0F32B55Ca258: serializer.Serialize(writer, "account.a8d79a1e61964c0bae3e0f32b55ca258"); break;
                case AccountId.AccountA977B90D637E490Eaa186587Abba6981: serializer.Serialize(writer, "account.a977b90d637e490eaa186587abba6981"); break;
                case AccountId.AccountAbb338E6408345E5A6D86D77A3E462E8: serializer.Serialize(writer, "account.abb338e6408345e5a6d86d77a3e462e8"); break;
                case AccountId.AccountAef791265D00449193Fc19B6Fd2Bd7D3: serializer.Serialize(writer, "account.aef791265d00449193fc19b6fd2bd7d3"); break;
                case AccountId.AccountAf68Aaf9F9Dd4Cbe9020Ada151D58201: serializer.Serialize(writer, "account.af68aaf9f9dd4cbe9020ada151d58201"); break;
                case AccountId.AccountB6635477Cf6A4E8Ba78893Bb2De2E2D5: serializer.Serialize(writer, "account.b6635477cf6a4e8ba78893bb2de2e2d5"); break;
                case AccountId.AccountB8672333Ac774369B443533F9D7556Fb: serializer.Serialize(writer, "account.b8672333ac774369b443533f9d7556fb"); break;
                case AccountId.AccountB92265Ea75544Dc4963Effe31618478D: serializer.Serialize(writer, "account.b92265ea75544dc4963effe31618478d"); break;
                case AccountId.AccountBdc84A3E3314447Fa05C2D814C1236D3: serializer.Serialize(writer, "account.bdc84a3e3314447fa05c2d814c1236d3"); break;
                case AccountId.AccountC0Eab56Bb90A4011805622Abae2Fc0A7: serializer.Serialize(writer, "account.c0eab56bb90a4011805622abae2fc0a7"); break;
                case AccountId.AccountC1F07355Ecfc4A93814627F7E5A2Df09: serializer.Serialize(writer, "account.c1f07355ecfc4a93814627f7e5a2df09"); break;
                case AccountId.AccountC4Ddacbeef774269B19Eb5085D8Fd453: serializer.Serialize(writer, "account.c4ddacbeef774269b19eb5085d8fd453"); break;
                case AccountId.AccountCbf0Cd5595Fa4E4Bbe211350B300C5E5: serializer.Serialize(writer, "account.cbf0cd5595fa4e4bbe211350b300c5e5"); break;
                case AccountId.AccountCc7511C415684908B6Aa8Cd756Db0927: serializer.Serialize(writer, "account.cc7511c415684908b6aa8cd756db0927"); break;
                case AccountId.AccountCe516C35D9B5452D80232D19E7B1B33B: serializer.Serialize(writer, "account.ce516c35d9b5452d80232d19e7b1b33b"); break;
                case AccountId.AccountCfd4D2Acad654D4A93Aebe91B41Bf6Ec: serializer.Serialize(writer, "account.cfd4d2acad654d4a93aebe91b41bf6ec"); break;
                case AccountId.AccountD34B6C1B93164B9Ab899332F120D23F5: serializer.Serialize(writer, "account.d34b6c1b93164b9ab899332f120d23f5"); break;
                case AccountId.AccountD4659Ecdcedd4022Af6C58B7C500F93A: serializer.Serialize(writer, "account.d4659ecdcedd4022af6c58b7c500f93a"); break;
                case AccountId.AccountD773C28D84354414A2B283De0588Dc89: serializer.Serialize(writer, "account.d773c28d84354414a2b283de0588dc89"); break;
                case AccountId.AccountD893F944A8Da46Ceab019A92C47747Ab: serializer.Serialize(writer, "account.d893f944a8da46ceab019a92c47747ab"); break;
                case AccountId.AccountD991B392D18C4De1966826Ab9E5Ddfd7: serializer.Serialize(writer, "account.d991b392d18c4de1966826ab9e5ddfd7"); break;
                case AccountId.AccountDaf9B87684E046Ce8B1201D0A715E932: serializer.Serialize(writer, "account.daf9b87684e046ce8b1201d0a715e932"); break;
                case AccountId.AccountDb37Da3Cda79402B95D61956E3A48D5C: serializer.Serialize(writer, "account.db37da3cda79402b95d61956e3a48d5c"); break;
                case AccountId.AccountDd9E11D047894C86A274A40F0342F057: serializer.Serialize(writer, "account.dd9e11d047894c86a274a40f0342f057"); break;
                case AccountId.AccountE0A9Cb7Fe3C84651A1645A5483299162: serializer.Serialize(writer, "account.e0a9cb7fe3c84651a1645a5483299162"); break;
                case AccountId.AccountE11E2926Fc654Af685A258Dff3C73B08: serializer.Serialize(writer, "account.e11e2926fc654af685a258dff3c73b08"); break;
                case AccountId.AccountE413C864Dcd64112973D21C4A8B596Fa: serializer.Serialize(writer, "account.e413c864dcd64112973d21c4a8b596fa"); break;
                case AccountId.AccountE471Fc65651640F58D85181Bea5C44D7: serializer.Serialize(writer, "account.e471fc65651640f58d85181bea5c44d7"); break;
                case AccountId.AccountE59E46B7Dfe247Ceb03468A1Dab084Ef: serializer.Serialize(writer, "account.e59e46b7dfe247ceb03468a1dab084ef"); break;
                case AccountId.AccountE948A2506Af44429813Dae2Db32Ed22C: serializer.Serialize(writer, "account.e948a2506af44429813dae2db32ed22c"); break;
                case AccountId.AccountEae2Ab68E73D4814B8491109B6C1C6E2: serializer.Serialize(writer, "account.eae2ab68e73d4814b8491109b6c1c6e2"); break;
                case AccountId.AccountEbe461Aa07014186B98E6Dd6Da3A43Fe: serializer.Serialize(writer, "account.ebe461aa07014186b98e6dd6da3a43fe"); break;
                case AccountId.AccountEe21877Ff7Ed443Ebe9Dfefa9Feb8F12: serializer.Serialize(writer, "account.ee21877ff7ed443ebe9dfefa9feb8f12"); break;
                case AccountId.AccountF0D08A9E5D2641948A58B6D5949891Fb: serializer.Serialize(writer, "account.f0d08a9e5d2641948a58b6d5949891fb"); break;
                case AccountId.AccountF1Da1C8Db6404C9Db9Ed96267Bfbc243: serializer.Serialize(writer, "account.f1da1c8db6404c9db9ed96267bfbc243"); break;
                case AccountId.AccountF632Da4B63184F43932Ecb813760499A: serializer.Serialize(writer, "account.f632da4b63184f43932ecb813760499a"); break;
                case AccountId.AccountF9Bcf26A062545E6Bcfb10Cf3F7Afe32: serializer.Serialize(writer, "account.f9bcf26a062545e6bcfb10cf3f7afe32"); break;
                case AccountId.AccountFc69Dd36Cfd54F19B7D7Bc2Ee171B002: serializer.Serialize(writer, "account.fc69dd36cfd54f19b7d7bc2ee171b002"); break;
                case AccountId.AccountFf90Cd2D31014769B7B5Dbfe11Cdfd13: serializer.Serialize(writer, "account.ff90cd2d31014769b7b5dbfe11cdfd13"); break;
                case AccountId.Empty: serializer.Serialize(writer, ""); break;
            }
        }
    }

    static class NameExtensions
    {
        public static Name? ValueForString(string str)
        {
            switch (str)
            {
                case "Altavista": return Name.Altavista;
                case "andreekou": return Name.Andreekou;
                case "Andrew226": return Name.Andrew226;
                case "Andrewk503": return Name.Andrewk503;
                case "Assassin1one7": return Name.Assassin1One7;
                case "Basil105": return Name.Basil105;
                case "BerserkerMatou": return Name.BerserkerMatou;
                case "Big_Baby": return Name.BigBaby;
                case "BigDustyDNelson": return Name.BigDustyDNelson;
                case "bigtittygoth": return Name.Bigtittygoth;
                case "Brendarrrr": return Name.Brendarrrr;
                case "bschroe": return Name.Bschroe;
                case "Bundy2": return Name.Bundy2;
                case "chuckspinello": return Name.Chuckspinello;
                case "CorporateProfit": return Name.CorporateProfit;
                case "Crunk-Zilla": return Name.CrunkZilla;
                case "Darkdoom00": return Name.Darkdoom00;
                case "Darkkountry": return Name.Darkkountry;
                case "DayGuyKnown": return Name.DayGuyKnown;
                case "DePee1644": return Name.DePee1644;
                case "Deathammers": return Name.Deathammers;
                case "Deathmufn": return Name.Deathmufn;
                case "DeciValentine": return Name.DeciValentine;
                case "DigBic96": return Name.DigBic96;
                case "DKChef": return Name.DkChef;
                case "Edsger_Djikstra": return Name.EdsgerDjikstra;
                case "": return Name.Empty;
                case "epickitten": return Name.Epickitten;
                case "Everwolf_Gaming": return Name.EverwolfGaming;
                case "FuLLBLeeD": return Name.FuLlbLeeD;
                case "G0dKill3r": return Name.G0DKill3R;
                case "GargaMike2112": return Name.GargaMike2112;
                case "GERARDO778": return Name.Gerardo778;
                case "Ghost4559": return Name.Ghost4559;
                case "goatlicker25": return Name.Goatlicker25;
                case "Gothik": return Name.Gothik;
                case "happy_404": return Name.Happy404;
                case "hashCrusher": return Name.HashCrusher;
                case "HeBro": return Name.HeBro;
                case "i_R_responsible": return Name.IRResponsible;
                case "Inadequis": return Name.Inadequis;
                case "ingrix": return Name.Ingrix;
                case "John-MC": return Name.JohnMc;
                case "Jondawg": return Name.Jondawg;
                case "Kaos204": return Name.Kaos204;
                case "KeysOnTheTable": return Name.KeysOnTheTable;
                case "Killamonjaro": return Name.Killamonjaro;
                case "kimjungun1": return Name.Kimjungun1;
                case "kittywompus": return Name.Kittywompus;
                case "LeDogeyDoge": return Name.LeDogeyDoge;
                case "Lunatica97": return Name.Lunatica97;
                case "MastaFu": return Name.MastaFu;
                case "MayaNormusbutt": return Name.MayaNormusbutt;
                case "McSquirtz": return Name.McSquirtz;
                case "monkeybyte": return Name.Monkeybyte;
                case "NBKCoco": return Name.NbkCoco;
                case "NBKJuice": return Name.NbkJuice;
                case "nerfqx": return Name.Nerfqx;
                case "NoComp": return Name.NoComp;
                case "Nostradamuru": return Name.Nostradamuru;
                case "nrg1337": return Name.Nrg1337;
                case "OfficerHopps": return Name.OfficerHopps;
                case "Old-Man-Hatter": return Name.OldManHatter;
                case "Orion5814": return Name.Orion5814;
                case "PDEslayer": return Name.PdEslayer;
                case "phishaddict": return Name.Phishaddict;
                case "PreeminentPeace": return Name.PreeminentPeace;
                case "Ptb334": return Name.Ptb334;
                case "qRnbw": return Name.QRnbw;
                case "Raethiance": return Name.Raethiance;
                case "Raven253": return Name.Raven253;
                case "ReclusiveSleet7": return Name.ReclusiveSleet7;
                case "Rez_u": return Name.RezU;
                case "Rinthaugritu": return Name.Rinthaugritu;
                case "Rlin06": return Name.Rlin06;
                case "saltyDAN486": return Name.SaltyDan486;
                case "SawzeBawze": return Name.SawzeBawze;
                case "scotched_": return Name.Scotched;
                case "ShadyTactics": return Name.ShadyTactics;
                case "ShartLobster": return Name.ShartLobster;
                case "Shrimply_Amazing": return Name.ShrimplyAmazing;
                case "smalbert": return Name.Smalbert;
                case "Spyder707": return Name.Spyder707;
                case "StaceeTiny": return Name.StaceeTiny;
                case "Sterkcide": return Name.Sterkcide;
                case "1shoop2sheep": return Name.The1Shoop2Sheep;
                case "2gtravis": return Name.The2Gtravis;
                case "ThePeaceKepper": return Name.ThePeaceKepper;
                case "TsundereAsukaBum": return Name.TsundereAsukaBum;
                case "turd-_-ferguson": return Name.TurdFerguson;
                case "Vasaras1987": return Name.Vasaras1987;
                case "Vathas1": return Name.Vathas1;
                case "vele1759": return Name.Vele1759;
                case "vele1766": return Name.Vele1766;
                case "vex_ed": return Name.VexEd;
                case "WazzuXL": return Name.WazzuXl;
                case "Wolfoftwilight": return Name.Wolfoftwilight;
                case "xcuseM3": return Name.XcuseM3;
                case "yearwargrayson": return Name.Yearwargrayson;
                case "yrotsym": return Name.Yrotsym;
                case "ZoatTheGoat": return Name.ZoatTheGoat;
                default: return null;
            }
        }

        public static Name ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }

        public static void WriteJson(this Name value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case Name.Altavista: serializer.Serialize(writer, "Altavista"); break;
                case Name.Andreekou: serializer.Serialize(writer, "andreekou"); break;
                case Name.Andrew226: serializer.Serialize(writer, "Andrew226"); break;
                case Name.Andrewk503: serializer.Serialize(writer, "Andrewk503"); break;
                case Name.Assassin1One7: serializer.Serialize(writer, "Assassin1one7"); break;
                case Name.Basil105: serializer.Serialize(writer, "Basil105"); break;
                case Name.BerserkerMatou: serializer.Serialize(writer, "BerserkerMatou"); break;
                case Name.BigBaby: serializer.Serialize(writer, "Big_Baby"); break;
                case Name.BigDustyDNelson: serializer.Serialize(writer, "BigDustyDNelson"); break;
                case Name.Bigtittygoth: serializer.Serialize(writer, "bigtittygoth"); break;
                case Name.Brendarrrr: serializer.Serialize(writer, "Brendarrrr"); break;
                case Name.Bschroe: serializer.Serialize(writer, "bschroe"); break;
                case Name.Bundy2: serializer.Serialize(writer, "Bundy2"); break;
                case Name.Chuckspinello: serializer.Serialize(writer, "chuckspinello"); break;
                case Name.CorporateProfit: serializer.Serialize(writer, "CorporateProfit"); break;
                case Name.CrunkZilla: serializer.Serialize(writer, "Crunk-Zilla"); break;
                case Name.Darkdoom00: serializer.Serialize(writer, "Darkdoom00"); break;
                case Name.Darkkountry: serializer.Serialize(writer, "Darkkountry"); break;
                case Name.DayGuyKnown: serializer.Serialize(writer, "DayGuyKnown"); break;
                case Name.DePee1644: serializer.Serialize(writer, "DePee1644"); break;
                case Name.Deathammers: serializer.Serialize(writer, "Deathammers"); break;
                case Name.Deathmufn: serializer.Serialize(writer, "Deathmufn"); break;
                case Name.DeciValentine: serializer.Serialize(writer, "DeciValentine"); break;
                case Name.DigBic96: serializer.Serialize(writer, "DigBic96"); break;
                case Name.DkChef: serializer.Serialize(writer, "DKChef"); break;
                case Name.EdsgerDjikstra: serializer.Serialize(writer, "Edsger_Djikstra"); break;
                case Name.Empty: serializer.Serialize(writer, ""); break;
                case Name.Epickitten: serializer.Serialize(writer, "epickitten"); break;
                case Name.EverwolfGaming: serializer.Serialize(writer, "Everwolf_Gaming"); break;
                case Name.FuLlbLeeD: serializer.Serialize(writer, "FuLLBLeeD"); break;
                case Name.G0DKill3R: serializer.Serialize(writer, "G0dKill3r"); break;
                case Name.GargaMike2112: serializer.Serialize(writer, "GargaMike2112"); break;
                case Name.Gerardo778: serializer.Serialize(writer, "GERARDO778"); break;
                case Name.Ghost4559: serializer.Serialize(writer, "Ghost4559"); break;
                case Name.Goatlicker25: serializer.Serialize(writer, "goatlicker25"); break;
                case Name.Gothik: serializer.Serialize(writer, "Gothik"); break;
                case Name.Happy404: serializer.Serialize(writer, "happy_404"); break;
                case Name.HashCrusher: serializer.Serialize(writer, "hashCrusher"); break;
                case Name.HeBro: serializer.Serialize(writer, "HeBro"); break;
                case Name.IRResponsible: serializer.Serialize(writer, "i_R_responsible"); break;
                case Name.Inadequis: serializer.Serialize(writer, "Inadequis"); break;
                case Name.Ingrix: serializer.Serialize(writer, "ingrix"); break;
                case Name.JohnMc: serializer.Serialize(writer, "John-MC"); break;
                case Name.Jondawg: serializer.Serialize(writer, "Jondawg"); break;
                case Name.Kaos204: serializer.Serialize(writer, "Kaos204"); break;
                case Name.KeysOnTheTable: serializer.Serialize(writer, "KeysOnTheTable"); break;
                case Name.Killamonjaro: serializer.Serialize(writer, "Killamonjaro"); break;
                case Name.Kimjungun1: serializer.Serialize(writer, "kimjungun1"); break;
                case Name.Kittywompus: serializer.Serialize(writer, "kittywompus"); break;
                case Name.LeDogeyDoge: serializer.Serialize(writer, "LeDogeyDoge"); break;
                case Name.Lunatica97: serializer.Serialize(writer, "Lunatica97"); break;
                case Name.MastaFu: serializer.Serialize(writer, "MastaFu"); break;
                case Name.MayaNormusbutt: serializer.Serialize(writer, "MayaNormusbutt"); break;
                case Name.McSquirtz: serializer.Serialize(writer, "McSquirtz"); break;
                case Name.Monkeybyte: serializer.Serialize(writer, "monkeybyte"); break;
                case Name.NbkCoco: serializer.Serialize(writer, "NBKCoco"); break;
                case Name.NbkJuice: serializer.Serialize(writer, "NBKJuice"); break;
                case Name.Nerfqx: serializer.Serialize(writer, "nerfqx"); break;
                case Name.NoComp: serializer.Serialize(writer, "NoComp"); break;
                case Name.Nostradamuru: serializer.Serialize(writer, "Nostradamuru"); break;
                case Name.Nrg1337: serializer.Serialize(writer, "nrg1337"); break;
                case Name.OfficerHopps: serializer.Serialize(writer, "OfficerHopps"); break;
                case Name.OldManHatter: serializer.Serialize(writer, "Old-Man-Hatter"); break;
                case Name.Orion5814: serializer.Serialize(writer, "Orion5814"); break;
                case Name.PdEslayer: serializer.Serialize(writer, "PDEslayer"); break;
                case Name.Phishaddict: serializer.Serialize(writer, "phishaddict"); break;
                case Name.PreeminentPeace: serializer.Serialize(writer, "PreeminentPeace"); break;
                case Name.Ptb334: serializer.Serialize(writer, "Ptb334"); break;
                case Name.QRnbw: serializer.Serialize(writer, "qRnbw"); break;
                case Name.Raethiance: serializer.Serialize(writer, "Raethiance"); break;
                case Name.Raven253: serializer.Serialize(writer, "Raven253"); break;
                case Name.ReclusiveSleet7: serializer.Serialize(writer, "ReclusiveSleet7"); break;
                case Name.RezU: serializer.Serialize(writer, "Rez_u"); break;
                case Name.Rinthaugritu: serializer.Serialize(writer, "Rinthaugritu"); break;
                case Name.Rlin06: serializer.Serialize(writer, "Rlin06"); break;
                case Name.SaltyDan486: serializer.Serialize(writer, "saltyDAN486"); break;
                case Name.SawzeBawze: serializer.Serialize(writer, "SawzeBawze"); break;
                case Name.Scotched: serializer.Serialize(writer, "scotched_"); break;
                case Name.ShadyTactics: serializer.Serialize(writer, "ShadyTactics"); break;
                case Name.ShartLobster: serializer.Serialize(writer, "ShartLobster"); break;
                case Name.ShrimplyAmazing: serializer.Serialize(writer, "Shrimply_Amazing"); break;
                case Name.Smalbert: serializer.Serialize(writer, "smalbert"); break;
                case Name.Spyder707: serializer.Serialize(writer, "Spyder707"); break;
                case Name.StaceeTiny: serializer.Serialize(writer, "StaceeTiny"); break;
                case Name.Sterkcide: serializer.Serialize(writer, "Sterkcide"); break;
                case Name.The1Shoop2Sheep: serializer.Serialize(writer, "1shoop2sheep"); break;
                case Name.The2Gtravis: serializer.Serialize(writer, "2gtravis"); break;
                case Name.ThePeaceKepper: serializer.Serialize(writer, "ThePeaceKepper"); break;
                case Name.TsundereAsukaBum: serializer.Serialize(writer, "TsundereAsukaBum"); break;
                case Name.TurdFerguson: serializer.Serialize(writer, "turd-_-ferguson"); break;
                case Name.Vasaras1987: serializer.Serialize(writer, "Vasaras1987"); break;
                case Name.Vathas1: serializer.Serialize(writer, "Vathas1"); break;
                case Name.Vele1759: serializer.Serialize(writer, "vele1759"); break;
                case Name.Vele1766: serializer.Serialize(writer, "vele1766"); break;
                case Name.VexEd: serializer.Serialize(writer, "vex_ed"); break;
                case Name.WazzuXl: serializer.Serialize(writer, "WazzuXL"); break;
                case Name.Wolfoftwilight: serializer.Serialize(writer, "Wolfoftwilight"); break;
                case Name.XcuseM3: serializer.Serialize(writer, "xcuseM3"); break;
                case Name.Yearwargrayson: serializer.Serialize(writer, "yearwargrayson"); break;
                case Name.Yrotsym: serializer.Serialize(writer, "yrotsym"); break;
                case Name.ZoatTheGoat: serializer.Serialize(writer, "ZoatTheGoat"); break;
            }
        }
    }

    static class AttachedItemExtensions
    {
        public static AttachedItem? ValueForString(string str)
        {
            switch (str)
            {
                case "Item_Attach_Weapon_Lower_AngledForeGrip_C": return AttachedItem.ItemAttachWeaponLowerAngledForeGripC;
                case "Item_Attach_Weapon_Lower_Foregrip_C": return AttachedItem.ItemAttachWeaponLowerForegripC;
                case "Item_Attach_Weapon_Magazine_Extended_Large_C": return AttachedItem.ItemAttachWeaponMagazineExtendedLargeC;
                case "Item_Attach_Weapon_Magazine_Extended_Medium_C": return AttachedItem.ItemAttachWeaponMagazineExtendedMediumC;
                case "Item_Attach_Weapon_Magazine_ExtendedQuickDraw_Large_C": return AttachedItem.ItemAttachWeaponMagazineExtendedQuickDrawLargeC;
                case "Item_Attach_Weapon_Magazine_ExtendedQuickDraw_Medium_C": return AttachedItem.ItemAttachWeaponMagazineExtendedQuickDrawMediumC;
                case "Item_Attach_Weapon_Magazine_ExtendedQuickDraw_Small_C": return AttachedItem.ItemAttachWeaponMagazineExtendedQuickDrawSmallC;
                case "Item_Attach_Weapon_Magazine_ExtendedQuickDraw_SniperRifle_C": return AttachedItem.ItemAttachWeaponMagazineExtendedQuickDrawSniperRifleC;
                case "Item_Attach_Weapon_Magazine_Extended_Small_C": return AttachedItem.ItemAttachWeaponMagazineExtendedSmallC;
                case "Item_Attach_Weapon_Magazine_Extended_SniperRifle_C": return AttachedItem.ItemAttachWeaponMagazineExtendedSniperRifleC;
                case "Item_Attach_Weapon_Magazine_QuickDraw_Large_C": return AttachedItem.ItemAttachWeaponMagazineQuickDrawLargeC;
                case "Item_Attach_Weapon_Magazine_QuickDraw_Medium_C": return AttachedItem.ItemAttachWeaponMagazineQuickDrawMediumC;
                case "Item_Attach_Weapon_Magazine_QuickDraw_Small_C": return AttachedItem.ItemAttachWeaponMagazineQuickDrawSmallC;
                case "Item_Attach_Weapon_Magazine_QuickDraw_SniperRifle_C": return AttachedItem.ItemAttachWeaponMagazineQuickDrawSniperRifleC;
                case "Item_Attach_Weapon_Muzzle_Choke_C": return AttachedItem.ItemAttachWeaponMuzzleChokeC;
                case "Item_Attach_Weapon_Muzzle_Compensator_Large_C": return AttachedItem.ItemAttachWeaponMuzzleCompensatorLargeC;
                case "Item_Attach_Weapon_Muzzle_Compensator_Medium_C": return AttachedItem.ItemAttachWeaponMuzzleCompensatorMediumC;
                case "Item_Attach_Weapon_Muzzle_Compensator_SniperRifle_C": return AttachedItem.ItemAttachWeaponMuzzleCompensatorSniperRifleC;
                case "Item_Attach_Weapon_Muzzle_FlashHider_Large_C": return AttachedItem.ItemAttachWeaponMuzzleFlashHiderLargeC;
                case "Item_Attach_Weapon_Muzzle_FlashHider_Medium_C": return AttachedItem.ItemAttachWeaponMuzzleFlashHiderMediumC;
                case "Item_Attach_Weapon_Muzzle_FlashHider_SniperRifle_C": return AttachedItem.ItemAttachWeaponMuzzleFlashHiderSniperRifleC;
                case "Item_Attach_Weapon_Muzzle_Suppressor_Large_C": return AttachedItem.ItemAttachWeaponMuzzleSuppressorLargeC;
                case "Item_Attach_Weapon_Muzzle_Suppressor_Medium_C": return AttachedItem.ItemAttachWeaponMuzzleSuppressorMediumC;
                case "Item_Attach_Weapon_Muzzle_Suppressor_Small_C": return AttachedItem.ItemAttachWeaponMuzzleSuppressorSmallC;
                case "Item_Attach_Weapon_Muzzle_Suppressor_SniperRifle_C": return AttachedItem.ItemAttachWeaponMuzzleSuppressorSniperRifleC;
                case "Item_Attach_Weapon_Stock_AR_Composite_C": return AttachedItem.ItemAttachWeaponStockArCompositeC;
                case "Item_Attach_Weapon_Stock_Shotgun_BulletLoops_C": return AttachedItem.ItemAttachWeaponStockShotgunBulletLoopsC;
                case "Item_Attach_Weapon_Stock_SniperRifle_BulletLoops_C": return AttachedItem.ItemAttachWeaponStockSniperRifleBulletLoopsC;
                case "Item_Attach_Weapon_Stock_SniperRifle_CheekPad_C": return AttachedItem.ItemAttachWeaponStockSniperRifleCheekPadC;
                case "Item_Attach_Weapon_Stock_UZI_C": return AttachedItem.ItemAttachWeaponStockUziC;
                case "Item_Attach_Weapon_Upper_ACOG_01_C": return AttachedItem.ItemAttachWeaponUpperAcog01_C;
                case "Item_Attach_Weapon_Upper_Aimpoint_C": return AttachedItem.ItemAttachWeaponUpperAimpointC;
                case "Item_Attach_Weapon_Upper_CQBSS_C": return AttachedItem.ItemAttachWeaponUpperCqbssC;
                case "Item_Attach_Weapon_Upper_DotSight_01_C": return AttachedItem.ItemAttachWeaponUpperDotSight01_C;
                case "Item_Attach_Weapon_Upper_Holosight_C": return AttachedItem.ItemAttachWeaponUpperHolosightC;
                default: return null;
            }
        }

        public static AttachedItem ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }

        public static void WriteJson(this AttachedItem value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case AttachedItem.ItemAttachWeaponLowerAngledForeGripC: serializer.Serialize(writer, "Item_Attach_Weapon_Lower_AngledForeGrip_C"); break;
                case AttachedItem.ItemAttachWeaponLowerForegripC: serializer.Serialize(writer, "Item_Attach_Weapon_Lower_Foregrip_C"); break;
                case AttachedItem.ItemAttachWeaponMagazineExtendedLargeC: serializer.Serialize(writer, "Item_Attach_Weapon_Magazine_Extended_Large_C"); break;
                case AttachedItem.ItemAttachWeaponMagazineExtendedMediumC: serializer.Serialize(writer, "Item_Attach_Weapon_Magazine_Extended_Medium_C"); break;
                case AttachedItem.ItemAttachWeaponMagazineExtendedQuickDrawLargeC: serializer.Serialize(writer, "Item_Attach_Weapon_Magazine_ExtendedQuickDraw_Large_C"); break;
                case AttachedItem.ItemAttachWeaponMagazineExtendedQuickDrawMediumC: serializer.Serialize(writer, "Item_Attach_Weapon_Magazine_ExtendedQuickDraw_Medium_C"); break;
                case AttachedItem.ItemAttachWeaponMagazineExtendedQuickDrawSmallC: serializer.Serialize(writer, "Item_Attach_Weapon_Magazine_ExtendedQuickDraw_Small_C"); break;
                case AttachedItem.ItemAttachWeaponMagazineExtendedQuickDrawSniperRifleC: serializer.Serialize(writer, "Item_Attach_Weapon_Magazine_ExtendedQuickDraw_SniperRifle_C"); break;
                case AttachedItem.ItemAttachWeaponMagazineExtendedSmallC: serializer.Serialize(writer, "Item_Attach_Weapon_Magazine_Extended_Small_C"); break;
                case AttachedItem.ItemAttachWeaponMagazineExtendedSniperRifleC: serializer.Serialize(writer, "Item_Attach_Weapon_Magazine_Extended_SniperRifle_C"); break;
                case AttachedItem.ItemAttachWeaponMagazineQuickDrawLargeC: serializer.Serialize(writer, "Item_Attach_Weapon_Magazine_QuickDraw_Large_C"); break;
                case AttachedItem.ItemAttachWeaponMagazineQuickDrawMediumC: serializer.Serialize(writer, "Item_Attach_Weapon_Magazine_QuickDraw_Medium_C"); break;
                case AttachedItem.ItemAttachWeaponMagazineQuickDrawSmallC: serializer.Serialize(writer, "Item_Attach_Weapon_Magazine_QuickDraw_Small_C"); break;
                case AttachedItem.ItemAttachWeaponMagazineQuickDrawSniperRifleC: serializer.Serialize(writer, "Item_Attach_Weapon_Magazine_QuickDraw_SniperRifle_C"); break;
                case AttachedItem.ItemAttachWeaponMuzzleChokeC: serializer.Serialize(writer, "Item_Attach_Weapon_Muzzle_Choke_C"); break;
                case AttachedItem.ItemAttachWeaponMuzzleCompensatorLargeC: serializer.Serialize(writer, "Item_Attach_Weapon_Muzzle_Compensator_Large_C"); break;
                case AttachedItem.ItemAttachWeaponMuzzleCompensatorMediumC: serializer.Serialize(writer, "Item_Attach_Weapon_Muzzle_Compensator_Medium_C"); break;
                case AttachedItem.ItemAttachWeaponMuzzleCompensatorSniperRifleC: serializer.Serialize(writer, "Item_Attach_Weapon_Muzzle_Compensator_SniperRifle_C"); break;
                case AttachedItem.ItemAttachWeaponMuzzleFlashHiderLargeC: serializer.Serialize(writer, "Item_Attach_Weapon_Muzzle_FlashHider_Large_C"); break;
                case AttachedItem.ItemAttachWeaponMuzzleFlashHiderMediumC: serializer.Serialize(writer, "Item_Attach_Weapon_Muzzle_FlashHider_Medium_C"); break;
                case AttachedItem.ItemAttachWeaponMuzzleFlashHiderSniperRifleC: serializer.Serialize(writer, "Item_Attach_Weapon_Muzzle_FlashHider_SniperRifle_C"); break;
                case AttachedItem.ItemAttachWeaponMuzzleSuppressorLargeC: serializer.Serialize(writer, "Item_Attach_Weapon_Muzzle_Suppressor_Large_C"); break;
                case AttachedItem.ItemAttachWeaponMuzzleSuppressorMediumC: serializer.Serialize(writer, "Item_Attach_Weapon_Muzzle_Suppressor_Medium_C"); break;
                case AttachedItem.ItemAttachWeaponMuzzleSuppressorSmallC: serializer.Serialize(writer, "Item_Attach_Weapon_Muzzle_Suppressor_Small_C"); break;
                case AttachedItem.ItemAttachWeaponMuzzleSuppressorSniperRifleC: serializer.Serialize(writer, "Item_Attach_Weapon_Muzzle_Suppressor_SniperRifle_C"); break;
                case AttachedItem.ItemAttachWeaponStockArCompositeC: serializer.Serialize(writer, "Item_Attach_Weapon_Stock_AR_Composite_C"); break;
                case AttachedItem.ItemAttachWeaponStockShotgunBulletLoopsC: serializer.Serialize(writer, "Item_Attach_Weapon_Stock_Shotgun_BulletLoops_C"); break;
                case AttachedItem.ItemAttachWeaponStockSniperRifleBulletLoopsC: serializer.Serialize(writer, "Item_Attach_Weapon_Stock_SniperRifle_BulletLoops_C"); break;
                case AttachedItem.ItemAttachWeaponStockSniperRifleCheekPadC: serializer.Serialize(writer, "Item_Attach_Weapon_Stock_SniperRifle_CheekPad_C"); break;
                case AttachedItem.ItemAttachWeaponStockUziC: serializer.Serialize(writer, "Item_Attach_Weapon_Stock_UZI_C"); break;
                case AttachedItem.ItemAttachWeaponUpperAcog01_C: serializer.Serialize(writer, "Item_Attach_Weapon_Upper_ACOG_01_C"); break;
                case AttachedItem.ItemAttachWeaponUpperAimpointC: serializer.Serialize(writer, "Item_Attach_Weapon_Upper_Aimpoint_C"); break;
                case AttachedItem.ItemAttachWeaponUpperCqbssC: serializer.Serialize(writer, "Item_Attach_Weapon_Upper_CQBSS_C"); break;
                case AttachedItem.ItemAttachWeaponUpperDotSight01_C: serializer.Serialize(writer, "Item_Attach_Weapon_Upper_DotSight_01_C"); break;
                case AttachedItem.ItemAttachWeaponUpperHolosightC: serializer.Serialize(writer, "Item_Attach_Weapon_Upper_Holosight_C"); break;
            }
        }
    }

    static class CategoryExtensions
    {
        public static Category? ValueForString(string str)
        {
            switch (str)
            {
                case "Ammunition": return Category.Ammunition;
                case "Attachment": return Category.Attachment;
                case "": return Category.Empty;
                case "Equipment": return Category.Equipment;
                case "Use": return Category.Use;
                case "Weapon": return Category.Weapon;
                default: return null;
            }
        }

        public static Category ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }

        public static void WriteJson(this Category value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case Category.Ammunition: serializer.Serialize(writer, "Ammunition"); break;
                case Category.Attachment: serializer.Serialize(writer, "Attachment"); break;
                case Category.Empty: serializer.Serialize(writer, ""); break;
                case Category.Equipment: serializer.Serialize(writer, "Equipment"); break;
                case Category.Use: serializer.Serialize(writer, "Use"); break;
                case Category.Weapon: serializer.Serialize(writer, "Weapon"); break;
            }
        }
    }

    static class ItemIdExtensions
    {
        public static ItemId? ValueForString(string str)
        {
            switch (str)
            {
                case "": return ItemId.Empty;
                case "Item_Ammo_12Guage_C": return ItemId.ItemAmmo12GuageC;
                case "Item_Ammo_300Magnum_C": return ItemId.ItemAmmo300MagnumC;
                case "Item_Ammo_45ACP_C": return ItemId.ItemAmmo45AcpC;
                case "Item_Ammo_556mm_C": return ItemId.ItemAmmo556MmC;
                case "Item_Ammo_762mm_C": return ItemId.ItemAmmo762MmC;
                case "Item_Ammo_9mm_C": return ItemId.ItemAmmo9MmC;
                case "Item_Ammo_Bolt_C": return ItemId.ItemAmmoBoltC;
                case "Item_Armor_C_01_Lv3_C": return ItemId.ItemArmorC01_Lv3C;
                case "Item_Armor_D_01_Lv2_C": return ItemId.ItemArmorD01_Lv2C;
                case "Item_Armor_E_01_Lv1_C": return ItemId.ItemArmorE01_Lv1C;
                case "Item_Attach_Weapon_Lower_AngledForeGrip_C": return ItemId.ItemAttachWeaponLowerAngledForeGripC;
                case "Item_Attach_Weapon_Lower_Foregrip_C": return ItemId.ItemAttachWeaponLowerForegripC;
                case "Item_Attach_Weapon_Lower_QuickDraw_Large_Crossbow_C": return ItemId.ItemAttachWeaponLowerQuickDrawLargeCrossbowC;
                case "Item_Attach_Weapon_Magazine_Extended_Large_C": return ItemId.ItemAttachWeaponMagazineExtendedLargeC;
                case "Item_Attach_Weapon_Magazine_Extended_Medium_C": return ItemId.ItemAttachWeaponMagazineExtendedMediumC;
                case "Item_Attach_Weapon_Magazine_ExtendedQuickDraw_Large_C": return ItemId.ItemAttachWeaponMagazineExtendedQuickDrawLargeC;
                case "Item_Attach_Weapon_Magazine_ExtendedQuickDraw_Medium_C": return ItemId.ItemAttachWeaponMagazineExtendedQuickDrawMediumC;
                case "Item_Attach_Weapon_Magazine_ExtendedQuickDraw_Small_C": return ItemId.ItemAttachWeaponMagazineExtendedQuickDrawSmallC;
                case "Item_Attach_Weapon_Magazine_ExtendedQuickDraw_SniperRifle_C": return ItemId.ItemAttachWeaponMagazineExtendedQuickDrawSniperRifleC;
                case "Item_Attach_Weapon_Magazine_Extended_Small_C": return ItemId.ItemAttachWeaponMagazineExtendedSmallC;
                case "Item_Attach_Weapon_Magazine_Extended_SniperRifle_C": return ItemId.ItemAttachWeaponMagazineExtendedSniperRifleC;
                case "Item_Attach_Weapon_Magazine_QuickDraw_Large_C": return ItemId.ItemAttachWeaponMagazineQuickDrawLargeC;
                case "Item_Attach_Weapon_Magazine_QuickDraw_Medium_C": return ItemId.ItemAttachWeaponMagazineQuickDrawMediumC;
                case "Item_Attach_Weapon_Magazine_QuickDraw_Small_C": return ItemId.ItemAttachWeaponMagazineQuickDrawSmallC;
                case "Item_Attach_Weapon_Magazine_QuickDraw_SniperRifle_C": return ItemId.ItemAttachWeaponMagazineQuickDrawSniperRifleC;
                case "Item_Attach_Weapon_Muzzle_Choke_C": return ItemId.ItemAttachWeaponMuzzleChokeC;
                case "Item_Attach_Weapon_Muzzle_Compensator_Large_C": return ItemId.ItemAttachWeaponMuzzleCompensatorLargeC;
                case "Item_Attach_Weapon_Muzzle_Compensator_Medium_C": return ItemId.ItemAttachWeaponMuzzleCompensatorMediumC;
                case "Item_Attach_Weapon_Muzzle_Compensator_SniperRifle_C": return ItemId.ItemAttachWeaponMuzzleCompensatorSniperRifleC;
                case "Item_Attach_Weapon_Muzzle_FlashHider_Large_C": return ItemId.ItemAttachWeaponMuzzleFlashHiderLargeC;
                case "Item_Attach_Weapon_Muzzle_FlashHider_Medium_C": return ItemId.ItemAttachWeaponMuzzleFlashHiderMediumC;
                case "Item_Attach_Weapon_Muzzle_FlashHider_SniperRifle_C": return ItemId.ItemAttachWeaponMuzzleFlashHiderSniperRifleC;
                case "Item_Attach_Weapon_Muzzle_Suppressor_Large_C": return ItemId.ItemAttachWeaponMuzzleSuppressorLargeC;
                case "Item_Attach_Weapon_Muzzle_Suppressor_Medium_C": return ItemId.ItemAttachWeaponMuzzleSuppressorMediumC;
                case "Item_Attach_Weapon_Muzzle_Suppressor_Small_C": return ItemId.ItemAttachWeaponMuzzleSuppressorSmallC;
                case "Item_Attach_Weapon_Muzzle_Suppressor_SniperRifle_C": return ItemId.ItemAttachWeaponMuzzleSuppressorSniperRifleC;
                case "Item_Attach_Weapon_Stock_AR_Composite_C": return ItemId.ItemAttachWeaponStockArCompositeC;
                case "Item_Attach_Weapon_Stock_Shotgun_BulletLoops_C": return ItemId.ItemAttachWeaponStockShotgunBulletLoopsC;
                case "Item_Attach_Weapon_Stock_SniperRifle_BulletLoops_C": return ItemId.ItemAttachWeaponStockSniperRifleBulletLoopsC;
                case "Item_Attach_Weapon_Stock_SniperRifle_CheekPad_C": return ItemId.ItemAttachWeaponStockSniperRifleCheekPadC;
                case "Item_Attach_Weapon_Stock_UZI_C": return ItemId.ItemAttachWeaponStockUziC;
                case "Item_Attach_Weapon_Upper_ACOG_01_C": return ItemId.ItemAttachWeaponUpperAcog01_C;
                case "Item_Attach_Weapon_Upper_Aimpoint_C": return ItemId.ItemAttachWeaponUpperAimpointC;
                case "Item_Attach_Weapon_Upper_CQBSS_C": return ItemId.ItemAttachWeaponUpperCqbssC;
                case "Item_Attach_Weapon_Upper_DotSight_01_C": return ItemId.ItemAttachWeaponUpperDotSight01_C;
                case "Item_Attach_Weapon_Upper_Holosight_C": return ItemId.ItemAttachWeaponUpperHolosightC;
                case "Item_Back_B_01_StartParachutePack_C": return ItemId.ItemBackB01_StartParachutePackC;
                case "Item_Back_C_02_Lv3_C": return ItemId.ItemBackC02_Lv3C;
                case "Item_Back_E_01_Lv1_C": return ItemId.ItemBackE01_Lv1C;
                case "Item_Back_E_02_Lv1_C": return ItemId.ItemBackE02_Lv1C;
                case "Item_Back_F_01_Lv2_C": return ItemId.ItemBackF01_Lv2C;
                case "Item_Back_F_02_Lv2_C": return ItemId.ItemBackF02_Lv2C;
                case "Item_Boost_EnergyDrink_C": return ItemId.ItemBoostEnergyDrinkC;
                case "Item_Boost_PainKiller_C": return ItemId.ItemBoostPainKillerC;
                case "Item_Ghillie_01_C": return ItemId.ItemGhillie01_C;
                case "Item_Head_E_01_Lv1_C": return ItemId.ItemHeadE01_Lv1C;
                case "Item_Head_E_02_Lv1_C": return ItemId.ItemHeadE02_Lv1C;
                case "Item_Head_F_01_Lv2_C": return ItemId.ItemHeadF01_Lv2C;
                case "Item_Head_F_02_Lv2_C": return ItemId.ItemHeadF02_Lv2C;
                case "Item_Head_G_01_Lv3_C": return ItemId.ItemHeadG01_Lv3C;
                case "Item_Heal_Bandage_C": return ItemId.ItemHealBandageC;
                case "Item_Heal_FirstAid_C": return ItemId.ItemHealFirstAidC;
                case "Item_Heal_MedKit_C": return ItemId.ItemHealMedKitC;
                case "Item_JerryCan_C": return ItemId.ItemJerryCanC;
                case "Item_Weapon_AK47_C": return ItemId.ItemWeaponAk47C;
                case "Item_Weapon_AUG_C": return ItemId.ItemWeaponAugC;
                case "Item_Weapon_AWM_C": return ItemId.ItemWeaponAwmC;
                case "Item_Weapon_Berreta686_C": return ItemId.ItemWeaponBerreta686C;
                case "Item_Weapon_Cowbar_C": return ItemId.ItemWeaponCowbarC;
                case "Item_Weapon_Crossbow_C": return ItemId.ItemWeaponCrossbowC;
                case "Item_Weapon_DP28_C": return ItemId.ItemWeaponDp28C;
                case "Item_Weapon_FlashBang_C": return ItemId.ItemWeaponFlashBangC;
                case "Item_Weapon_G18_C": return ItemId.ItemWeaponG18C;
                case "Item_Weapon_Grenade_C": return ItemId.ItemWeaponGrenadeC;
                case "Item_Weapon_Groza_C": return ItemId.ItemWeaponGrozaC;
                case "Item_Weapon_HK416_C": return ItemId.ItemWeaponHk416C;
                case "Item_Weapon_Kar98k_C": return ItemId.ItemWeaponKar98KC;
                case "Item_Weapon_M16A4_C": return ItemId.ItemWeaponM16A4C;
                case "Item_Weapon_M1911_C": return ItemId.ItemWeaponM1911C;
                case "Item_Weapon_M24_C": return ItemId.ItemWeaponM24C;
                case "Item_Weapon_M9_C": return ItemId.ItemWeaponM9C;
                case "Item_Weapon_Machete_C": return ItemId.ItemWeaponMacheteC;
                case "Item_Weapon_Mini14_C": return ItemId.ItemWeaponMini14C;
                case "Item_Weapon_Molotov_C": return ItemId.ItemWeaponMolotovC;
                case "Item_Weapon_NagantM1895_C": return ItemId.ItemWeaponNagantM1895C;
                case "Item_Weapon_Pan_C": return ItemId.ItemWeaponPanC;
                case "Item_Weapon_Saiga12_C": return ItemId.ItemWeaponSaiga12C;
                case "Item_Weapon_SCAR-L_C": return ItemId.ItemWeaponScarLC;
                case "Item_Weapon_Sickle_C": return ItemId.ItemWeaponSickleC;
                case "Item_Weapon_SKS_C": return ItemId.ItemWeaponSksC;
                case "Item_Weapon_SmokeBomb_C": return ItemId.ItemWeaponSmokeBombC;
                case "Item_Weapon_Thompson_C": return ItemId.ItemWeaponThompsonC;
                case "Item_Weapon_UMP_C": return ItemId.ItemWeaponUmpC;
                case "Item_Weapon_UZI_C": return ItemId.ItemWeaponUziC;
                case "Item_Weapon_Vector_C": return ItemId.ItemWeaponVectorC;
                case "Item_Weapon_VSS_C": return ItemId.ItemWeaponVssC;
                case "Item_Weapon_Winchester_C": return ItemId.ItemWeaponWinchesterC;
                default: return null;
            }
        }

        public static ItemId ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }

        public static void WriteJson(this ItemId value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case ItemId.Empty: serializer.Serialize(writer, ""); break;
                case ItemId.ItemAmmo12GuageC: serializer.Serialize(writer, "Item_Ammo_12Guage_C"); break;
                case ItemId.ItemAmmo300MagnumC: serializer.Serialize(writer, "Item_Ammo_300Magnum_C"); break;
                case ItemId.ItemAmmo45AcpC: serializer.Serialize(writer, "Item_Ammo_45ACP_C"); break;
                case ItemId.ItemAmmo556MmC: serializer.Serialize(writer, "Item_Ammo_556mm_C"); break;
                case ItemId.ItemAmmo762MmC: serializer.Serialize(writer, "Item_Ammo_762mm_C"); break;
                case ItemId.ItemAmmo9MmC: serializer.Serialize(writer, "Item_Ammo_9mm_C"); break;
                case ItemId.ItemAmmoBoltC: serializer.Serialize(writer, "Item_Ammo_Bolt_C"); break;
                case ItemId.ItemArmorC01_Lv3C: serializer.Serialize(writer, "Item_Armor_C_01_Lv3_C"); break;
                case ItemId.ItemArmorD01_Lv2C: serializer.Serialize(writer, "Item_Armor_D_01_Lv2_C"); break;
                case ItemId.ItemArmorE01_Lv1C: serializer.Serialize(writer, "Item_Armor_E_01_Lv1_C"); break;
                case ItemId.ItemAttachWeaponLowerAngledForeGripC: serializer.Serialize(writer, "Item_Attach_Weapon_Lower_AngledForeGrip_C"); break;
                case ItemId.ItemAttachWeaponLowerForegripC: serializer.Serialize(writer, "Item_Attach_Weapon_Lower_Foregrip_C"); break;
                case ItemId.ItemAttachWeaponLowerQuickDrawLargeCrossbowC: serializer.Serialize(writer, "Item_Attach_Weapon_Lower_QuickDraw_Large_Crossbow_C"); break;
                case ItemId.ItemAttachWeaponMagazineExtendedLargeC: serializer.Serialize(writer, "Item_Attach_Weapon_Magazine_Extended_Large_C"); break;
                case ItemId.ItemAttachWeaponMagazineExtendedMediumC: serializer.Serialize(writer, "Item_Attach_Weapon_Magazine_Extended_Medium_C"); break;
                case ItemId.ItemAttachWeaponMagazineExtendedQuickDrawLargeC: serializer.Serialize(writer, "Item_Attach_Weapon_Magazine_ExtendedQuickDraw_Large_C"); break;
                case ItemId.ItemAttachWeaponMagazineExtendedQuickDrawMediumC: serializer.Serialize(writer, "Item_Attach_Weapon_Magazine_ExtendedQuickDraw_Medium_C"); break;
                case ItemId.ItemAttachWeaponMagazineExtendedQuickDrawSmallC: serializer.Serialize(writer, "Item_Attach_Weapon_Magazine_ExtendedQuickDraw_Small_C"); break;
                case ItemId.ItemAttachWeaponMagazineExtendedQuickDrawSniperRifleC: serializer.Serialize(writer, "Item_Attach_Weapon_Magazine_ExtendedQuickDraw_SniperRifle_C"); break;
                case ItemId.ItemAttachWeaponMagazineExtendedSmallC: serializer.Serialize(writer, "Item_Attach_Weapon_Magazine_Extended_Small_C"); break;
                case ItemId.ItemAttachWeaponMagazineExtendedSniperRifleC: serializer.Serialize(writer, "Item_Attach_Weapon_Magazine_Extended_SniperRifle_C"); break;
                case ItemId.ItemAttachWeaponMagazineQuickDrawLargeC: serializer.Serialize(writer, "Item_Attach_Weapon_Magazine_QuickDraw_Large_C"); break;
                case ItemId.ItemAttachWeaponMagazineQuickDrawMediumC: serializer.Serialize(writer, "Item_Attach_Weapon_Magazine_QuickDraw_Medium_C"); break;
                case ItemId.ItemAttachWeaponMagazineQuickDrawSmallC: serializer.Serialize(writer, "Item_Attach_Weapon_Magazine_QuickDraw_Small_C"); break;
                case ItemId.ItemAttachWeaponMagazineQuickDrawSniperRifleC: serializer.Serialize(writer, "Item_Attach_Weapon_Magazine_QuickDraw_SniperRifle_C"); break;
                case ItemId.ItemAttachWeaponMuzzleChokeC: serializer.Serialize(writer, "Item_Attach_Weapon_Muzzle_Choke_C"); break;
                case ItemId.ItemAttachWeaponMuzzleCompensatorLargeC: serializer.Serialize(writer, "Item_Attach_Weapon_Muzzle_Compensator_Large_C"); break;
                case ItemId.ItemAttachWeaponMuzzleCompensatorMediumC: serializer.Serialize(writer, "Item_Attach_Weapon_Muzzle_Compensator_Medium_C"); break;
                case ItemId.ItemAttachWeaponMuzzleCompensatorSniperRifleC: serializer.Serialize(writer, "Item_Attach_Weapon_Muzzle_Compensator_SniperRifle_C"); break;
                case ItemId.ItemAttachWeaponMuzzleFlashHiderLargeC: serializer.Serialize(writer, "Item_Attach_Weapon_Muzzle_FlashHider_Large_C"); break;
                case ItemId.ItemAttachWeaponMuzzleFlashHiderMediumC: serializer.Serialize(writer, "Item_Attach_Weapon_Muzzle_FlashHider_Medium_C"); break;
                case ItemId.ItemAttachWeaponMuzzleFlashHiderSniperRifleC: serializer.Serialize(writer, "Item_Attach_Weapon_Muzzle_FlashHider_SniperRifle_C"); break;
                case ItemId.ItemAttachWeaponMuzzleSuppressorLargeC: serializer.Serialize(writer, "Item_Attach_Weapon_Muzzle_Suppressor_Large_C"); break;
                case ItemId.ItemAttachWeaponMuzzleSuppressorMediumC: serializer.Serialize(writer, "Item_Attach_Weapon_Muzzle_Suppressor_Medium_C"); break;
                case ItemId.ItemAttachWeaponMuzzleSuppressorSmallC: serializer.Serialize(writer, "Item_Attach_Weapon_Muzzle_Suppressor_Small_C"); break;
                case ItemId.ItemAttachWeaponMuzzleSuppressorSniperRifleC: serializer.Serialize(writer, "Item_Attach_Weapon_Muzzle_Suppressor_SniperRifle_C"); break;
                case ItemId.ItemAttachWeaponStockArCompositeC: serializer.Serialize(writer, "Item_Attach_Weapon_Stock_AR_Composite_C"); break;
                case ItemId.ItemAttachWeaponStockShotgunBulletLoopsC: serializer.Serialize(writer, "Item_Attach_Weapon_Stock_Shotgun_BulletLoops_C"); break;
                case ItemId.ItemAttachWeaponStockSniperRifleBulletLoopsC: serializer.Serialize(writer, "Item_Attach_Weapon_Stock_SniperRifle_BulletLoops_C"); break;
                case ItemId.ItemAttachWeaponStockSniperRifleCheekPadC: serializer.Serialize(writer, "Item_Attach_Weapon_Stock_SniperRifle_CheekPad_C"); break;
                case ItemId.ItemAttachWeaponStockUziC: serializer.Serialize(writer, "Item_Attach_Weapon_Stock_UZI_C"); break;
                case ItemId.ItemAttachWeaponUpperAcog01_C: serializer.Serialize(writer, "Item_Attach_Weapon_Upper_ACOG_01_C"); break;
                case ItemId.ItemAttachWeaponUpperAimpointC: serializer.Serialize(writer, "Item_Attach_Weapon_Upper_Aimpoint_C"); break;
                case ItemId.ItemAttachWeaponUpperCqbssC: serializer.Serialize(writer, "Item_Attach_Weapon_Upper_CQBSS_C"); break;
                case ItemId.ItemAttachWeaponUpperDotSight01_C: serializer.Serialize(writer, "Item_Attach_Weapon_Upper_DotSight_01_C"); break;
                case ItemId.ItemAttachWeaponUpperHolosightC: serializer.Serialize(writer, "Item_Attach_Weapon_Upper_Holosight_C"); break;
                case ItemId.ItemBackB01_StartParachutePackC: serializer.Serialize(writer, "Item_Back_B_01_StartParachutePack_C"); break;
                case ItemId.ItemBackC02_Lv3C: serializer.Serialize(writer, "Item_Back_C_02_Lv3_C"); break;
                case ItemId.ItemBackE01_Lv1C: serializer.Serialize(writer, "Item_Back_E_01_Lv1_C"); break;
                case ItemId.ItemBackE02_Lv1C: serializer.Serialize(writer, "Item_Back_E_02_Lv1_C"); break;
                case ItemId.ItemBackF01_Lv2C: serializer.Serialize(writer, "Item_Back_F_01_Lv2_C"); break;
                case ItemId.ItemBackF02_Lv2C: serializer.Serialize(writer, "Item_Back_F_02_Lv2_C"); break;
                case ItemId.ItemBoostEnergyDrinkC: serializer.Serialize(writer, "Item_Boost_EnergyDrink_C"); break;
                case ItemId.ItemBoostPainKillerC: serializer.Serialize(writer, "Item_Boost_PainKiller_C"); break;
                case ItemId.ItemGhillie01_C: serializer.Serialize(writer, "Item_Ghillie_01_C"); break;
                case ItemId.ItemHeadE01_Lv1C: serializer.Serialize(writer, "Item_Head_E_01_Lv1_C"); break;
                case ItemId.ItemHeadE02_Lv1C: serializer.Serialize(writer, "Item_Head_E_02_Lv1_C"); break;
                case ItemId.ItemHeadF01_Lv2C: serializer.Serialize(writer, "Item_Head_F_01_Lv2_C"); break;
                case ItemId.ItemHeadF02_Lv2C: serializer.Serialize(writer, "Item_Head_F_02_Lv2_C"); break;
                case ItemId.ItemHeadG01_Lv3C: serializer.Serialize(writer, "Item_Head_G_01_Lv3_C"); break;
                case ItemId.ItemHealBandageC: serializer.Serialize(writer, "Item_Heal_Bandage_C"); break;
                case ItemId.ItemHealFirstAidC: serializer.Serialize(writer, "Item_Heal_FirstAid_C"); break;
                case ItemId.ItemHealMedKitC: serializer.Serialize(writer, "Item_Heal_MedKit_C"); break;
                case ItemId.ItemJerryCanC: serializer.Serialize(writer, "Item_JerryCan_C"); break;
                case ItemId.ItemWeaponAk47C: serializer.Serialize(writer, "Item_Weapon_AK47_C"); break;
                case ItemId.ItemWeaponAugC: serializer.Serialize(writer, "Item_Weapon_AUG_C"); break;
                case ItemId.ItemWeaponAwmC: serializer.Serialize(writer, "Item_Weapon_AWM_C"); break;
                case ItemId.ItemWeaponBerreta686C: serializer.Serialize(writer, "Item_Weapon_Berreta686_C"); break;
                case ItemId.ItemWeaponCowbarC: serializer.Serialize(writer, "Item_Weapon_Cowbar_C"); break;
                case ItemId.ItemWeaponCrossbowC: serializer.Serialize(writer, "Item_Weapon_Crossbow_C"); break;
                case ItemId.ItemWeaponDp28C: serializer.Serialize(writer, "Item_Weapon_DP28_C"); break;
                case ItemId.ItemWeaponFlashBangC: serializer.Serialize(writer, "Item_Weapon_FlashBang_C"); break;
                case ItemId.ItemWeaponG18C: serializer.Serialize(writer, "Item_Weapon_G18_C"); break;
                case ItemId.ItemWeaponGrenadeC: serializer.Serialize(writer, "Item_Weapon_Grenade_C"); break;
                case ItemId.ItemWeaponGrozaC: serializer.Serialize(writer, "Item_Weapon_Groza_C"); break;
                case ItemId.ItemWeaponHk416C: serializer.Serialize(writer, "Item_Weapon_HK416_C"); break;
                case ItemId.ItemWeaponKar98KC: serializer.Serialize(writer, "Item_Weapon_Kar98k_C"); break;
                case ItemId.ItemWeaponM16A4C: serializer.Serialize(writer, "Item_Weapon_M16A4_C"); break;
                case ItemId.ItemWeaponM1911C: serializer.Serialize(writer, "Item_Weapon_M1911_C"); break;
                case ItemId.ItemWeaponM24C: serializer.Serialize(writer, "Item_Weapon_M24_C"); break;
                case ItemId.ItemWeaponM9C: serializer.Serialize(writer, "Item_Weapon_M9_C"); break;
                case ItemId.ItemWeaponMacheteC: serializer.Serialize(writer, "Item_Weapon_Machete_C"); break;
                case ItemId.ItemWeaponMini14C: serializer.Serialize(writer, "Item_Weapon_Mini14_C"); break;
                case ItemId.ItemWeaponMolotovC: serializer.Serialize(writer, "Item_Weapon_Molotov_C"); break;
                case ItemId.ItemWeaponNagantM1895C: serializer.Serialize(writer, "Item_Weapon_NagantM1895_C"); break;
                case ItemId.ItemWeaponPanC: serializer.Serialize(writer, "Item_Weapon_Pan_C"); break;
                case ItemId.ItemWeaponSaiga12C: serializer.Serialize(writer, "Item_Weapon_Saiga12_C"); break;
                case ItemId.ItemWeaponScarLC: serializer.Serialize(writer, "Item_Weapon_SCAR-L_C"); break;
                case ItemId.ItemWeaponSickleC: serializer.Serialize(writer, "Item_Weapon_Sickle_C"); break;
                case ItemId.ItemWeaponSksC: serializer.Serialize(writer, "Item_Weapon_SKS_C"); break;
                case ItemId.ItemWeaponSmokeBombC: serializer.Serialize(writer, "Item_Weapon_SmokeBomb_C"); break;
                case ItemId.ItemWeaponThompsonC: serializer.Serialize(writer, "Item_Weapon_Thompson_C"); break;
                case ItemId.ItemWeaponUmpC: serializer.Serialize(writer, "Item_Weapon_UMP_C"); break;
                case ItemId.ItemWeaponUziC: serializer.Serialize(writer, "Item_Weapon_UZI_C"); break;
                case ItemId.ItemWeaponVectorC: serializer.Serialize(writer, "Item_Weapon_Vector_C"); break;
                case ItemId.ItemWeaponVssC: serializer.Serialize(writer, "Item_Weapon_VSS_C"); break;
                case ItemId.ItemWeaponWinchesterC: serializer.Serialize(writer, "Item_Weapon_Winchester_C"); break;
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
                case "Jacket": return SubCategory.Jacket;
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
                case SubCategory.Jacket: serializer.Serialize(writer, "Jacket"); break;
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
                case "": return MapName.Empty;
                case "Erangel_Main": return MapName.ErangelMain;
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
                case MapName.Empty: serializer.Serialize(writer, ""); break;
                case MapName.ErangelMain: serializer.Serialize(writer, "Erangel_Main"); break;
            }
        }
    }

    static class DamageCauserNameExtensions
    {
        public static DamageCauserName? ValueForString(string str)
        {
            switch (str)
            {
                case "BattleRoyaleModeController_Def_C": return DamageCauserName.BattleRoyaleModeControllerDefC;
                case "BP_Motorbike_04_C": return DamageCauserName.BpMotorbike04_C;
                case "BP_Motorbike_04_SideCar_C": return DamageCauserName.BpMotorbike04_SideCarC;
                case "Buff_DecreaseBreathInApnea_C": return DamageCauserName.BuffDecreaseBreathInApneaC;
                case "Buggy_A_02_C": return DamageCauserName.BuggyA02_C;
                case "Buggy_A_03_C": return DamageCauserName.BuggyA03_C;
                case "Dacia_A_01_v2_C": return DamageCauserName.DaciaA01_V2C;
                case "Dacia_A_02_v2_C": return DamageCauserName.DaciaA02_V2C;
                case "Dacia_A_03_v2_C": return DamageCauserName.DaciaA03_V2C;
                case "PlayerFemale_A_C": return DamageCauserName.PlayerFemaleAC;
                case "PlayerMale_A_C": return DamageCauserName.PlayerMaleAC;
                case "ProjGrenade_C": return DamageCauserName.ProjGrenadeC;
                case "RedZoneBomb_C": return DamageCauserName.RedZoneBombC;
                case "Uaz_A_01_C": return DamageCauserName.UazA01_C;
                case "Uaz_B_01_C": return DamageCauserName.UazB01_C;
                case "Uaz_C_01_C": return DamageCauserName.UazC01_C;
                case "WeapAK47_C": return DamageCauserName.WeapAk47C;
                case "WeapBerreta686_C": return DamageCauserName.WeapBerreta686C;
                case "WeapDP28_C": return DamageCauserName.WeapDp28C;
                case "WeapG18_C": return DamageCauserName.WeapG18C;
                case "WeapHK416_C": return DamageCauserName.WeapHk416C;
                case "WeapKar98k_C": return DamageCauserName.WeapKar98KC;
                case "WeapM16A4_C": return DamageCauserName.WeapM16A4C;
                case "WeapM1911_C": return DamageCauserName.WeapM1911C;
                case "WeapM9_C": return DamageCauserName.WeapM9C;
                case "WeapMini14_C": return DamageCauserName.WeapMini14C;
                case "WeapNagantM1895_C": return DamageCauserName.WeapNagantM1895C;
                case "WeapSCAR-L_C": return DamageCauserName.WeapScarLC;
                case "WeapSKS_C": return DamageCauserName.WeapSksC;
                case "WeapThompson_C": return DamageCauserName.WeapThompsonC;
                case "WeapUMP_C": return DamageCauserName.WeapUmpC;
                case "WeapUZI_C": return DamageCauserName.WeapUziC;
                case "WeapVSS_C": return DamageCauserName.WeapVssC;
                case "WeapWinchester_C": return DamageCauserName.WeapWinchesterC;
                default: return null;
            }
        }

        public static DamageCauserName ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }

        public static void WriteJson(this DamageCauserName value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case DamageCauserName.BattleRoyaleModeControllerDefC: serializer.Serialize(writer, "BattleRoyaleModeController_Def_C"); break;
                case DamageCauserName.BpMotorbike04_C: serializer.Serialize(writer, "BP_Motorbike_04_C"); break;
                case DamageCauserName.BpMotorbike04_SideCarC: serializer.Serialize(writer, "BP_Motorbike_04_SideCar_C"); break;
                case DamageCauserName.BuffDecreaseBreathInApneaC: serializer.Serialize(writer, "Buff_DecreaseBreathInApnea_C"); break;
                case DamageCauserName.BuggyA02_C: serializer.Serialize(writer, "Buggy_A_02_C"); break;
                case DamageCauserName.BuggyA03_C: serializer.Serialize(writer, "Buggy_A_03_C"); break;
                case DamageCauserName.DaciaA01_V2C: serializer.Serialize(writer, "Dacia_A_01_v2_C"); break;
                case DamageCauserName.DaciaA02_V2C: serializer.Serialize(writer, "Dacia_A_02_v2_C"); break;
                case DamageCauserName.DaciaA03_V2C: serializer.Serialize(writer, "Dacia_A_03_v2_C"); break;
                case DamageCauserName.PlayerFemaleAC: serializer.Serialize(writer, "PlayerFemale_A_C"); break;
                case DamageCauserName.PlayerMaleAC: serializer.Serialize(writer, "PlayerMale_A_C"); break;
                case DamageCauserName.ProjGrenadeC: serializer.Serialize(writer, "ProjGrenade_C"); break;
                case DamageCauserName.RedZoneBombC: serializer.Serialize(writer, "RedZoneBomb_C"); break;
                case DamageCauserName.UazA01_C: serializer.Serialize(writer, "Uaz_A_01_C"); break;
                case DamageCauserName.UazB01_C: serializer.Serialize(writer, "Uaz_B_01_C"); break;
                case DamageCauserName.UazC01_C: serializer.Serialize(writer, "Uaz_C_01_C"); break;
                case DamageCauserName.WeapAk47C: serializer.Serialize(writer, "WeapAK47_C"); break;
                case DamageCauserName.WeapBerreta686C: serializer.Serialize(writer, "WeapBerreta686_C"); break;
                case DamageCauserName.WeapDp28C: serializer.Serialize(writer, "WeapDP28_C"); break;
                case DamageCauserName.WeapG18C: serializer.Serialize(writer, "WeapG18_C"); break;
                case DamageCauserName.WeapHk416C: serializer.Serialize(writer, "WeapHK416_C"); break;
                case DamageCauserName.WeapKar98KC: serializer.Serialize(writer, "WeapKar98k_C"); break;
                case DamageCauserName.WeapM16A4C: serializer.Serialize(writer, "WeapM16A4_C"); break;
                case DamageCauserName.WeapM1911C: serializer.Serialize(writer, "WeapM1911_C"); break;
                case DamageCauserName.WeapM9C: serializer.Serialize(writer, "WeapM9_C"); break;
                case DamageCauserName.WeapMini14C: serializer.Serialize(writer, "WeapMini14_C"); break;
                case DamageCauserName.WeapNagantM1895C: serializer.Serialize(writer, "WeapNagantM1895_C"); break;
                case DamageCauserName.WeapScarLC: serializer.Serialize(writer, "WeapSCAR-L_C"); break;
                case DamageCauserName.WeapSksC: serializer.Serialize(writer, "WeapSKS_C"); break;
                case DamageCauserName.WeapThompsonC: serializer.Serialize(writer, "WeapThompson_C"); break;
                case DamageCauserName.WeapUmpC: serializer.Serialize(writer, "WeapUMP_C"); break;
                case DamageCauserName.WeapUziC: serializer.Serialize(writer, "WeapUZI_C"); break;
                case DamageCauserName.WeapVssC: serializer.Serialize(writer, "WeapVSS_C"); break;
                case DamageCauserName.WeapWinchesterC: serializer.Serialize(writer, "WeapWinchester_C"); break;
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
                case DamageTypeCategory.DamageVehicleCrashHit: serializer.Serialize(writer, "Damage_VehicleCrashHit"); break;
                case DamageTypeCategory.DamageVehicleHit: serializer.Serialize(writer, "Damage_VehicleHit"); break;
                case DamageTypeCategory.Empty: serializer.Serialize(writer, ""); break;
            }
        }
    }

    static class ErrorMessageExtensions
    {
        public static ErrorMessage? ValueForString(string str)
        {
            switch (str)
            {
                case "": return ErrorMessage.Empty;
                default: return null;
            }
        }

        public static ErrorMessage ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }

        public static void WriteJson(this ErrorMessage value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case ErrorMessage.Empty: serializer.Serialize(writer, ""); break;
            }
        }
    }

    static class ItemPackageIdExtensions
    {
        public static ItemPackageId? ValueForString(string str)
        {
            switch (str)
            {
                case "Carapackage_RedBox_C": return ItemPackageId.CarapackageRedBoxC;
                default: return null;
            }
        }

        public static ItemPackageId ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }

        public static void WriteJson(this ItemPackageId value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case ItemPackageId.CarapackageRedBoxC: serializer.Serialize(writer, "Carapackage_RedBox_C"); break;
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
                case "Boat_PG117_C": return VehicleId.BoatPg117C;
                case "BP_Motorbike_04_C": return VehicleId.BpMotorbike04_C;
                case "BP_Motorbike_04_SideCar_C": return VehicleId.BpMotorbike04_SideCarC;
                case "Buggy_A_01_C": return VehicleId.BuggyA01_C;
                case "Buggy_A_02_C": return VehicleId.BuggyA02_C;
                case "Buggy_A_03_C": return VehicleId.BuggyA03_C;
                case "Dacia_A_01_v2_C": return VehicleId.DaciaA01_V2C;
                case "Dacia_A_02_v2_C": return VehicleId.DaciaA02_V2C;
                case "Dacia_A_03_v2_C": return VehicleId.DaciaA03_V2C;
                case "Dacia_A_04_v2_C": return VehicleId.DaciaA04_V2C;
                case "DummyTransportAircraft_C": return VehicleId.DummyTransportAircraftC;
                case "": return VehicleId.Empty;
                case "ParachutePlayer_C": return VehicleId.ParachutePlayerC;
                case "Uaz_A_01_C": return VehicleId.UazA01_C;
                case "Uaz_B_01_C": return VehicleId.UazB01_C;
                case "Uaz_C_01_C": return VehicleId.UazC01_C;
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
                case VehicleId.BoatPg117C: serializer.Serialize(writer, "Boat_PG117_C"); break;
                case VehicleId.BpMotorbike04_C: serializer.Serialize(writer, "BP_Motorbike_04_C"); break;
                case VehicleId.BpMotorbike04_SideCarC: serializer.Serialize(writer, "BP_Motorbike_04_SideCar_C"); break;
                case VehicleId.BuggyA01_C: serializer.Serialize(writer, "Buggy_A_01_C"); break;
                case VehicleId.BuggyA02_C: serializer.Serialize(writer, "Buggy_A_02_C"); break;
                case VehicleId.BuggyA03_C: serializer.Serialize(writer, "Buggy_A_03_C"); break;
                case VehicleId.DaciaA01_V2C: serializer.Serialize(writer, "Dacia_A_01_v2_C"); break;
                case VehicleId.DaciaA02_V2C: serializer.Serialize(writer, "Dacia_A_02_v2_C"); break;
                case VehicleId.DaciaA03_V2C: serializer.Serialize(writer, "Dacia_A_03_v2_C"); break;
                case VehicleId.DaciaA04_V2C: serializer.Serialize(writer, "Dacia_A_04_v2_C"); break;
                case VehicleId.DummyTransportAircraftC: serializer.Serialize(writer, "DummyTransportAircraft_C"); break;
                case VehicleId.Empty: serializer.Serialize(writer, ""); break;
                case VehicleId.ParachutePlayerC: serializer.Serialize(writer, "ParachutePlayer_C"); break;
                case VehicleId.UazA01_C: serializer.Serialize(writer, "Uaz_A_01_C"); break;
                case VehicleId.UazB01_C: serializer.Serialize(writer, "Uaz_B_01_C"); break;
                case VehicleId.UazC01_C: serializer.Serialize(writer, "Uaz_C_01_C"); break;
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

        public static void WriteJson(this VehicleType value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case VehicleType.Empty: serializer.Serialize(writer, ""); break;
                case VehicleType.FloatingVehicle: serializer.Serialize(writer, "FloatingVehicle"); break;
                case VehicleType.Parachute: serializer.Serialize(writer, "Parachute"); break;
                case VehicleType.TransportAircraft: serializer.Serialize(writer, "TransportAircraft"); break;
                case VehicleType.WheeledVehicle: serializer.Serialize(writer, "WheeledVehicle"); break;
            }
        }
    }

    public static class Serialize
    {
        public static string ToJson(this List<ApiTelemetry> self) => JsonConvert.SerializeObject(self, Converter.SettingsB);
    }

    internal class Converter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(AttackType) || t == typeof(AccountId) || t == typeof(Name) || t == typeof(AttachedItem) || t == typeof(Category) || t == typeof(ItemId) || t == typeof(SubCategory) || t == typeof(MapName) || t == typeof(DamageCauserName) || t == typeof(DamageReason) || t == typeof(DamageTypeCategory) || t == typeof(ErrorMessage) || t == typeof(ItemPackageId) || t == typeof(T) || t == typeof(VehicleId) || t == typeof(VehicleType) || t == typeof(AttackType?) || t == typeof(AccountId?) || t == typeof(Name?) || t == typeof(AttachedItem?) || t == typeof(Category?) || t == typeof(ItemId?) || t == typeof(SubCategory?) || t == typeof(MapName?) || t == typeof(DamageCauserName?) || t == typeof(DamageReason?) || t == typeof(DamageTypeCategory?) || t == typeof(ErrorMessage?) || t == typeof(ItemPackageId?) || t == typeof(T?) || t == typeof(VehicleId?) || t == typeof(VehicleType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (t == typeof(AttackType))
                return AttackTypeExtensions.ReadJson(reader, serializer);
            if (t == typeof(AccountId))
                return AccountIdExtensions.ReadJson(reader, serializer);
            if (t == typeof(Name))
                return NameExtensions.ReadJson(reader, serializer);
            if (t == typeof(AttachedItem))
                return AttachedItemExtensions.ReadJson(reader, serializer);
            if (t == typeof(Category))
                return CategoryExtensions.ReadJson(reader, serializer);
            if (t == typeof(ItemId))
                return ItemIdExtensions.ReadJson(reader, serializer);
            if (t == typeof(SubCategory))
                return SubCategoryExtensions.ReadJson(reader, serializer);
            if (t == typeof(MapName))
                return MapNameExtensions.ReadJson(reader, serializer);
            if (t == typeof(DamageCauserName))
                return DamageCauserNameExtensions.ReadJson(reader, serializer);
            if (t == typeof(DamageReason))
                return DamageReasonExtensions.ReadJson(reader, serializer);
            if (t == typeof(DamageTypeCategory))
                return DamageTypeCategoryExtensions.ReadJson(reader, serializer);
            if (t == typeof(ErrorMessage))
                return ErrorMessageExtensions.ReadJson(reader, serializer);
            if (t == typeof(ItemPackageId))
                return ItemPackageIdExtensions.ReadJson(reader, serializer);
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
            if (t == typeof(AccountId?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return AccountIdExtensions.ReadJson(reader, serializer);
            }
            if (t == typeof(Name?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return NameExtensions.ReadJson(reader, serializer);
            }
            if (t == typeof(AttachedItem?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return AttachedItemExtensions.ReadJson(reader, serializer);
            }
            if (t == typeof(Category?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return CategoryExtensions.ReadJson(reader, serializer);
            }
            if (t == typeof(ItemId?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return ItemIdExtensions.ReadJson(reader, serializer);
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
            if (t == typeof(DamageCauserName?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return DamageCauserNameExtensions.ReadJson(reader, serializer);
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
            if (t == typeof(ErrorMessage?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return ErrorMessageExtensions.ReadJson(reader, serializer);
            }
            if (t == typeof(ItemPackageId?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return ItemPackageIdExtensions.ReadJson(reader, serializer);
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
            var t = value.GetType();
            if (t == typeof(AttackType))
            {
                ((AttackType)value).WriteJson(writer, serializer);
                return;
            }
            if (t == typeof(AccountId))
            {
                ((AccountId)value).WriteJson(writer, serializer);
                return;
            }
            if (t == typeof(Name))
            {
                ((Name)value).WriteJson(writer, serializer);
                return;
            }
            if (t == typeof(AttachedItem))
            {
                ((AttachedItem)value).WriteJson(writer, serializer);
                return;
            }
            if (t == typeof(Category))
            {
                ((Category)value).WriteJson(writer, serializer);
                return;
            }
            if (t == typeof(ItemId))
            {
                ((ItemId)value).WriteJson(writer, serializer);
                return;
            }
            if (t == typeof(SubCategory))
            {
                ((SubCategory)value).WriteJson(writer, serializer);
                return;
            }
            if (t == typeof(MapName))
            {
                ((MapName)value).WriteJson(writer, serializer);
                return;
            }
            if (t == typeof(DamageCauserName))
            {
                ((DamageCauserName)value).WriteJson(writer, serializer);
                return;
            }
            if (t == typeof(DamageReason))
            {
                ((DamageReason)value).WriteJson(writer, serializer);
                return;
            }
            if (t == typeof(DamageTypeCategory))
            {
                ((DamageTypeCategory)value).WriteJson(writer, serializer);
                return;
            }
            if (t == typeof(ErrorMessage))
            {
                ((ErrorMessage)value).WriteJson(writer, serializer);
                return;
            }
            if (t == typeof(ItemPackageId))
            {
                ((ItemPackageId)value).WriteJson(writer, serializer);
                return;
            }
            if (t == typeof(T))
            {
                ((T)value).WriteJson(writer, serializer);
                return;
            }
            if (t == typeof(VehicleId))
            {
                ((VehicleId)value).WriteJson(writer, serializer);
                return;
            }
            if (t == typeof(VehicleType))
            {
                ((VehicleType)value).WriteJson(writer, serializer);
                return;
            }
            throw new Exception("Unknown type");
        }

        public static readonly JsonSerializerSettings SettingsA = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new Converter(),
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
        public static readonly JsonSerializerSettings SettingsB = new JsonSerializerSettings
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
