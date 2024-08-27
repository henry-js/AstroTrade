namespace AstroTrade.Domain.SpaceTraders;

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

public partial class RegisterAgentResponse
{
    [JsonPropertyName("data")]
    public Data Data { get; set; }
}

public class Data
{
    [JsonPropertyName("agent")]
    public Agent Agent { get; set; }

    [JsonPropertyName("contract")]
    public Contract Contract { get; set; }

    [JsonPropertyName("faction")]
    public Faction Faction { get; set; }

    [JsonPropertyName("ship")]
    public Ship Ship { get; set; }

    [JsonPropertyName("token")]
    public string Token { get; set; }
}

public class Agent
{
    [JsonPropertyName("accountId")]
    public string AccountId { get; set; }

    [JsonPropertyName("symbol")]
    public string Symbol { get; set; }

    [JsonPropertyName("headquarters")]
    public string Headquarters { get; set; }

    [JsonPropertyName("credits")]
    public long Credits { get; set; }

    [JsonPropertyName("startingFaction")]
    public string StartingFaction { get; set; }

    [JsonPropertyName("shipCount")]
    public long ShipCount { get; set; }
}

public class Contract
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("factionSymbol")]
    public string FactionSymbol { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("terms")]
    public Terms Terms { get; set; }

    [JsonPropertyName("accepted")]
    public bool Accepted { get; set; }

    [JsonPropertyName("fulfilled")]
    public bool Fulfilled { get; set; }

    [JsonPropertyName("expiration")]
    public DateTimeOffset Expiration { get; set; }

    [JsonPropertyName("deadlineToAccept")]
    public DateTimeOffset DeadlineToAccept { get; set; }
}

public class Terms
{
    [JsonPropertyName("deadline")]
    public DateTimeOffset Deadline { get; set; }

    [JsonPropertyName("payment")]
    public Payment Payment { get; set; }

    [JsonPropertyName("deliver")]
    public Deliver[] Deliver { get; set; }
}

public class Deliver
{
    [JsonPropertyName("tradeSymbol")]
    public string TradeSymbol { get; set; }

    [JsonPropertyName("destinationSymbol")]
    public string DestinationSymbol { get; set; }

    [JsonPropertyName("unitsRequired")]
    public long UnitsRequired { get; set; }

    [JsonPropertyName("unitsFulfilled")]
    public long UnitsFulfilled { get; set; }
}

public class Payment
{
    [JsonPropertyName("onAccepted")]
    public long OnAccepted { get; set; }

    [JsonPropertyName("onFulfilled")]
    public long OnFulfilled { get; set; }
}

public class Faction
{
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("headquarters")]
    public string Headquarters { get; set; }

    [JsonPropertyName("traits")]
    public Trait[] Traits { get; set; }

    [JsonPropertyName("isRecruiting")]
    public bool IsRecruiting { get; set; }
}

public class Trait
{
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("units")]
    public long? Units { get; set; }
}

public class Ship
{
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; }

    [JsonPropertyName("registration")]
    public Registration Registration { get; set; }

    [JsonPropertyName("nav")]
    public Nav Nav { get; set; }

    [JsonPropertyName("crew")]
    public Crew Crew { get; set; }

    [JsonPropertyName("frame")]
    public Frame Frame { get; set; }

    [JsonPropertyName("reactor")]
    public Engine Reactor { get; set; }

    [JsonPropertyName("engine")]
    public Engine Engine { get; set; }

    [JsonPropertyName("cooldown")]
    public Cooldown Cooldown { get; set; }

    [JsonPropertyName("modules")]
    public Module[] Modules { get; set; }

    [JsonPropertyName("mounts")]
    public Mount[] Mounts { get; set; }

    [JsonPropertyName("cargo")]
    public Cargo Cargo { get; set; }

    [JsonPropertyName("fuel")]
    public Fuel Fuel { get; set; }
}

public class Cargo
{
    [JsonPropertyName("capacity")]
    public long Capacity { get; set; }

    [JsonPropertyName("units")]
    public long Units { get; set; }

    [JsonPropertyName("inventory")]
    public Trait[] Inventory { get; set; }
}

public class Cooldown
{
    [JsonPropertyName("shipSymbol")]
    public string ShipSymbol { get; set; }

    [JsonPropertyName("totalSeconds")]
    public long TotalSeconds { get; set; }

    [JsonPropertyName("remainingSeconds")]
    public long RemainingSeconds { get; set; }

    [JsonPropertyName("expiration")]
    public DateTimeOffset Expiration { get; set; }
}

public class Crew
{
    [JsonPropertyName("current")]
    public long Current { get; set; }

    [JsonPropertyName("required")]
    public long CrewRequired { get; set; }

    [JsonPropertyName("capacity")]
    public long Capacity { get; set; }

    [JsonPropertyName("rotation")]
    public string Rotation { get; set; }

    [JsonPropertyName("morale")]
    public long Morale { get; set; }

    [JsonPropertyName("wages")]
    public long Wages { get; set; }
}

public class Engine
{
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("condition")]
    public long Condition { get; set; }

    [JsonPropertyName("integrity")]
    public long Integrity { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("speed")]
    public long? Speed { get; set; }

    [JsonPropertyName("requirements")]
    public Requirements Requirements { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("powerOutput")]
    public long? PowerOutput { get; set; }
}

public class Requirements
{
    [JsonPropertyName("power")]
    public long Power { get; set; }

    [JsonPropertyName("crew")]
    public long Crew { get; set; }

    [JsonPropertyName("slots")]
    public long Slots { get; set; }
}

public class Frame
{
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("condition")]
    public long Condition { get; set; }

    [JsonPropertyName("integrity")]
    public long Integrity { get; set; }

    [JsonPropertyName("moduleSlots")]
    public long ModuleSlots { get; set; }

    [JsonPropertyName("mountingPoints")]
    public long MountingPoints { get; set; }

    [JsonPropertyName("fuelCapacity")]
    public long FuelCapacity { get; set; }

    [JsonPropertyName("requirements")]
    public Requirements Requirements { get; set; }
}

public class Fuel
{
    [JsonPropertyName("current")]
    public long Current { get; set; }

    [JsonPropertyName("capacity")]
    public long Capacity { get; set; }

    [JsonPropertyName("consumed")]
    public Consumed Consumed { get; set; }
}

public class Consumed
{
    [JsonPropertyName("amount")]
    public long Amount { get; set; }

    [JsonPropertyName("timestamp")]
    public DateTimeOffset Timestamp { get; set; }
}

public class Module
{
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; }

    [JsonPropertyName("capacity")]
    public long Capacity { get; set; }

    [JsonPropertyName("range")]
    public long Range { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("requirements")]
    public Requirements Requirements { get; set; }
}

public class Mount
{
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("strength")]
    public long Strength { get; set; }

    [JsonPropertyName("deposits")]
    public string[] Deposits { get; set; }

    [JsonPropertyName("requirements")]
    public Requirements Requirements { get; set; }
}

public class Nav
{
    [JsonPropertyName("systemSymbol")]
    public string SystemSymbol { get; set; }

    [JsonPropertyName("waypointSymbol")]
    public string WaypointSymbol { get; set; }

    [JsonPropertyName("route")]
    public Route Route { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("flightMode")]
    public string FlightMode { get; set; }
}

public class Route
{
    [JsonPropertyName("destination")]
    public Destination Destination { get; set; }

    [JsonPropertyName("origin")]
    public Destination Origin { get; set; }

    [JsonPropertyName("departureTime")]
    public DateTimeOffset DepartureTime { get; set; }

    [JsonPropertyName("arrival")]
    public DateTimeOffset Arrival { get; set; }
}

public class Destination
{
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("systemSymbol")]
    public string SystemSymbol { get; set; }

    [JsonPropertyName("x")]
    public long X { get; set; }

    [JsonPropertyName("y")]
    public long Y { get; set; }
}

public class Registration
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("factionSymbol")]
    public string FactionSymbol { get; set; }

    [JsonPropertyName("role")]
    public string Role { get; set; }
}

public partial class RegisterAgentResponse
{
    public static RegisterAgentResponse FromJson(string json) => JsonSerializer.Deserialize<RegisterAgentResponse>(json, Converter.Settings);
}

public static class Serialize
{
    public static string ToJson(this RegisterAgentResponse self) => JsonSerializer.Serialize(self, Converter.Settings);
}

internal static class Converter
{
    public static readonly JsonSerializerOptions Settings = new(JsonSerializerDefaults.Web)
    {
        Converters =
            {
                new DateOnlyConverter(),
                new TimeOnlyConverter(),
            },
    };
}

public class DateOnlyConverter : JsonConverter<DateOnly>
{
    private readonly string serializationFormat;
    public DateOnlyConverter() : this(null) { }

    public DateOnlyConverter(string? serializationFormat)
    {
        this.serializationFormat = serializationFormat ?? "yyyy-MM-dd";
    }

    public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        return DateOnly.Parse(value!);
    }

    public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
        => writer.WriteStringValue(value.ToString(serializationFormat));
}
public class TimeOnlyConverter : JsonConverter<TimeOnly>
{
    private readonly string serializationFormat;

    public TimeOnlyConverter() : this(null) { }

    public TimeOnlyConverter(string? serializationFormat)
    {
        this.serializationFormat = serializationFormat ?? "HH:mm:ss.fff";
    }

    public override TimeOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        return TimeOnly.Parse(value!);
    }

    public override void Write(Utf8JsonWriter writer, TimeOnly value, JsonSerializerOptions options)
        => writer.WriteStringValue(value.ToString(serializationFormat));
}
