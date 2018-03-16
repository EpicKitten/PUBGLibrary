namespace PUBGLibrary.API
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Phraser
    {
        [JsonProperty("data")]
        public List<Datum> Data { get; set; }

        [JsonProperty("included")]
        public List<Included> Included { get; set; }

        [JsonProperty("links")]
        public PhraserLinks Links { get; set; }

        [JsonProperty("meta")]
        public PhraserMeta Meta { get; set; }
    }

    public partial class Datum
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("attributes")]
        public DatumAttributes Attributes { get; set; }

        [JsonProperty("relationships")]
        public DatumRelationships Relationships { get; set; }

        [JsonProperty("links")]
        public DatumLinks Links { get; set; }
    }

    public partial class DatumAttributes
    {
        [JsonProperty("createdAt")]
        public System.DateTimeOffset? CreatedAt { get; set; }

        [JsonProperty("duration")]
        public long? Duration { get; set; }

        [JsonProperty("gameMode")]
        public string GameMode { get; set; }

        [JsonProperty("patchVersion")]
        public string PatchVersion { get; set; }

        [JsonProperty("shardId")]
        public string ShardId { get; set; }

        [JsonProperty("stats")]
        public PhraserMeta Stats { get; set; }

        [JsonProperty("tags")]
        public object Tags { get; set; }

        [JsonProperty("titleId")]
        public string TitleId { get; set; }
    }

    public partial class PhraserMeta
    {
    }

    public partial class DatumLinks
    {
        [JsonProperty("schema")]
        public Schema? Schema { get; set; }

        [JsonProperty("self")]
        public string Self { get; set; }
    }

    public partial class DatumRelationships
    {
        [JsonProperty("assets")]
        public Assets Assets { get; set; }

        [JsonProperty("rosters")]
        public Assets Rosters { get; set; }

        [JsonProperty("rounds")]
        public Assets Rounds { get; set; }

        [JsonProperty("spectators")]
        public Assets Spectators { get; set; }
    }

    public partial class Assets
    {
        [JsonProperty("data")]
        public List<Dat> Data { get; set; }
    }

    public partial class Dat
    {
        [JsonProperty("type")]
        public DatumType? Type { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public partial class Included
    {
        [JsonProperty("type")]
        public DatumType? Type { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("attributes")]
        public IncludedAttributes Attributes { get; set; }

        [JsonProperty("relationships")]
        public IncludedRelationships Relationships { get; set; }

        [JsonProperty("links")]
        public DatumLinks Links { get; set; }
    }

    public partial class IncludedAttributes
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("patchVersion")]
        public Schema? PatchVersion { get; set; }

        [JsonProperty("shardId")]
        public ShardId? ShardId { get; set; }

        [JsonProperty("stats")]
        public APIPlayer Stats { get; set; }

        [JsonProperty("titleId")]
        public TitleId? TitleId { get; set; }

        [JsonProperty("actor")]
        public Schema? Actor { get; set; }

        [JsonProperty("won")]
        public Won? Won { get; set; }

        [JsonProperty("URL")]
        public string Url { get; set; }

        [JsonProperty("createdAt")]
        public System.DateTimeOffset? CreatedAt { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public partial class APIPlayer
    {
        [JsonProperty("DBNOs")]
        public long? DbnOs { get; set; }

        [JsonProperty("assists")]
        public long? Assists { get; set; }

        [JsonProperty("boosts")]
        public long? Boosts { get; set; }

        [JsonProperty("damageDealt")]
        public double? DamageDealt { get; set; }

        [JsonProperty("deathType")]
        public DeathType? DeathType { get; set; }

        [JsonProperty("headshotKills")]
        public long? HeadshotKills { get; set; }

        [JsonProperty("heals")]
        public long? Heals { get; set; }

        [JsonProperty("killPlace")]
        public long? KillPlace { get; set; }

        [JsonProperty("killPointsDelta")]
        public long? KillPointsDelta { get; set; }

        [JsonProperty("killStreaks")]
        public long? KillStreaks { get; set; }

        [JsonProperty("kills")]
        public long? Kills { get; set; }

        [JsonProperty("lastKillPoints")]
        public long? LastKillPoints { get; set; }

        [JsonProperty("lastWinPoints")]
        public long? LastWinPoints { get; set; }

        [JsonProperty("longestKill")]
        public double? LongestKill { get; set; }

        [JsonProperty("mostDamage")]
        public long? MostDamage { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("playerId")]
        public string PlayerId { get; set; }

        [JsonProperty("revives")]
        public long? Revives { get; set; }

        [JsonProperty("rideDistance")]
        public double? RideDistance { get; set; }

        [JsonProperty("roadKills")]
        public long? RoadKills { get; set; }

        [JsonProperty("teamKills")]
        public long? TeamKills { get; set; }

        [JsonProperty("timeSurvived")]
        public double? TimeSurvived { get; set; }

        [JsonProperty("vehicleDestroys")]
        public long? VehicleDestroys { get; set; }

        [JsonProperty("walkDistance")]
        public double? WalkDistance { get; set; }

        [JsonProperty("weaponsAcquired")]
        public long? WeaponsAcquired { get; set; }

        [JsonProperty("winPlace")]
        public long? WinPlace { get; set; }

        [JsonProperty("winPointsDelta")]
        public long? WinPointsDelta { get; set; }

        [JsonProperty("rank")]
        public long? Rank { get; set; }

        [JsonProperty("teamId")]
        public int? TeamId { get; set; }
    }

    public partial class IncludedRelationships
    {
        [JsonProperty("assets")]
        public Assets Assets { get; set; }

        [JsonProperty("player")]
        public Player Player { get; set; }

        [JsonProperty("participants")]
        public Assets Participants { get; set; }

        [JsonProperty("team")]
        public Assets Team { get; set; }
    }

    public partial class Player
    {
        [JsonProperty("data")]
        public Dat Data { get; set; }
    }

    public partial class PhraserLinks
    {
        [JsonProperty("next")]
        public string Next { get; set; }

        [JsonProperty("self")]
        public string Self { get; set; }
    }

    public enum Schema { Empty };

    public enum DatumType { Asset, Participant, Player, Roster };

    public enum ShardId { PcNa };

    public enum DeathType { Alive, Byplayer, Suicide };

    public enum TitleId { BlueholePubg };

    public enum Won { False, True };

    public partial class Phraser
    {
        public static Phraser FromJson(string json) => JsonConvert.DeserializeObject<Phraser>(json, PUBGLibrary.API.Converter.Settings);
    }

    static class SchemaExtensions
    {
        public static Schema? ValueForString(string str)
        {
            switch (str)
            {
                case "": return Schema.Empty;
                default: return null;
            }
        }

        public static Schema ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }

        public static void WriteJson(this Schema value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case Schema.Empty: serializer.Serialize(writer, ""); break;
            }
        }
    }

    static class DatumTypeExtensions
    {
        public static DatumType? ValueForString(string str)
        {
            switch (str)
            {
                case "asset": return DatumType.Asset;
                case "participant": return DatumType.Participant;
                case "player": return DatumType.Player;
                case "roster": return DatumType.Roster;
                default: return null;
            }
        }

        public static DatumType ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }

        public static void WriteJson(this DatumType value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case DatumType.Asset: serializer.Serialize(writer, "asset"); break;
                case DatumType.Participant: serializer.Serialize(writer, "participant"); break;
                case DatumType.Player: serializer.Serialize(writer, "player"); break;
                case DatumType.Roster: serializer.Serialize(writer, "roster"); break;
            }
        }
    }

    static class ShardIdExtensions
    {
        public static ShardId? ValueForString(string str)
        {
            switch (str)
            {
                case "pc-na": return ShardId.PcNa;
                default: return null;
            }
        }

        public static ShardId ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }

        public static void WriteJson(this ShardId value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case ShardId.PcNa: serializer.Serialize(writer, "pc-na"); break;
            }
        }
    }

    static class DeathTypeExtensions
    {
        public static DeathType? ValueForString(string str)
        {
            switch (str)
            {
                case "alive": return DeathType.Alive;
                case "byplayer": return DeathType.Byplayer;
                case "suicide": return DeathType.Suicide;
                default: return null;
            }
        }

        public static DeathType ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }

        public static void WriteJson(this DeathType value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case DeathType.Alive: serializer.Serialize(writer, "alive"); break;
                case DeathType.Byplayer: serializer.Serialize(writer, "byplayer"); break;
                case DeathType.Suicide: serializer.Serialize(writer, "suicide"); break;
            }
        }
    }

    static class TitleIdExtensions
    {
        public static TitleId? ValueForString(string str)
        {
            switch (str)
            {
                case "bluehole-pubg": return TitleId.BlueholePubg;
                default: return null;
            }
        }

        public static TitleId ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }

        public static void WriteJson(this TitleId value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case TitleId.BlueholePubg: serializer.Serialize(writer, "bluehole-pubg"); break;
            }
        }
    }

    static class WonExtensions
    {
        public static Won? ValueForString(string str)
        {
            switch (str)
            {
                case "false": return Won.False;
                case "true": return Won.True;
                default: return null;
            }
        }

        public static Won ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            var str = serializer.Deserialize<string>(reader);
            var maybeValue = ValueForString(str);
            if (maybeValue.HasValue) return maybeValue.Value;
            throw new Exception("Unknown enum case " + str);
        }

        public static void WriteJson(this Won value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case Won.False: serializer.Serialize(writer, "false"); break;
                case Won.True: serializer.Serialize(writer, "true"); break;
            }
        }
    }

    public static class Serialize
    {
        public static string ToJson(this Phraser self) => JsonConvert.SerializeObject(self, PUBGLibrary.API.Converter.Settings);
    }

    internal class Converter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Schema) || t == typeof(DatumType) || t == typeof(ShardId) || t == typeof(DeathType) || t == typeof(TitleId) || t == typeof(Won) || t == typeof(Schema?) || t == typeof(DatumType?) || t == typeof(ShardId?) || t == typeof(DeathType?) || t == typeof(TitleId?) || t == typeof(Won?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (t == typeof(Schema))
                return SchemaExtensions.ReadJson(reader, serializer);
            if (t == typeof(DatumType))
                return DatumTypeExtensions.ReadJson(reader, serializer);
            if (t == typeof(ShardId))
                return ShardIdExtensions.ReadJson(reader, serializer);
            if (t == typeof(DeathType))
                return DeathTypeExtensions.ReadJson(reader, serializer);
            if (t == typeof(TitleId))
                return TitleIdExtensions.ReadJson(reader, serializer);
            if (t == typeof(Won))
                return WonExtensions.ReadJson(reader, serializer);
            if (t == typeof(Schema?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return SchemaExtensions.ReadJson(reader, serializer);
            }
            if (t == typeof(DatumType?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return DatumTypeExtensions.ReadJson(reader, serializer);
            }
            if (t == typeof(ShardId?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return ShardIdExtensions.ReadJson(reader, serializer);
            }
            if (t == typeof(DeathType?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return DeathTypeExtensions.ReadJson(reader, serializer);
            }
            if (t == typeof(TitleId?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return TitleIdExtensions.ReadJson(reader, serializer);
            }
            if (t == typeof(Won?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return WonExtensions.ReadJson(reader, serializer);
            }
            throw new Exception("Unknown type");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var t = value.GetType();
            if (t == typeof(Schema))
            {
                ((Schema)value).WriteJson(writer, serializer);
                return;
            }
            if (t == typeof(DatumType))
            {
                ((DatumType)value).WriteJson(writer, serializer);
                return;
            }
            if (t == typeof(ShardId))
            {
                ((ShardId)value).WriteJson(writer, serializer);
                return;
            }
            if (t == typeof(DeathType))
            {
                ((DeathType)value).WriteJson(writer, serializer);
                return;
            }
            if (t == typeof(TitleId))
            {
                ((TitleId)value).WriteJson(writer, serializer);
                return;
            }
            if (t == typeof(Won))
            {
                ((Won)value).WriteJson(writer, serializer);
                return;
            }
            throw new Exception("Unknown type");
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
