namespace AstroTrade.Configuration;

public class SpaceTradersConfiguration
{
    public string? AccountToken { get; set; }
}

[JsonSourceGenerationOptions(
    WriteIndented = true,
    AllowTrailingCommas = true,
    UseStringEnumConverter = true,
    PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase,
    PropertyNameCaseInsensitive = true
)]
[JsonSerializable(typeof(SpaceTradersConfiguration))]
public partial class SpaceTradersConfigurationContext : JsonSerializerContext;