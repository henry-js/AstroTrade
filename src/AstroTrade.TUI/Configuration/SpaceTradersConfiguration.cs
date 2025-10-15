using System.Text.Json.Serialization;

namespace AstroTrade.TUI.Configuration;

public class SpaceTradersConfiguration
{
    public string? AccountToken { get; set; }
    public string? LastAgentSymbol { get; set; }
}

[JsonSourceGenerationOptions(
    WriteIndented = true,
    AllowTrailingCommas = true,
    UseStringEnumConverter = true,
    PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase,
    PropertyNameCaseInsensitive = true
)]
[JsonSerializable(typeof(SpaceTradersConfiguration))]
public partial class SpaceTradersConfigurationContext : JsonSerializerContext { }
