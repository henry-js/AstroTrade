namespace AstroTrade.Domain.SpaceTraders;

public class Registration
{
    public string Name { get; set; }

    public string FactionSymbol { get; set; }

    public string Role { get; set; }
}

public record RegistrationRequest
{
    public FactionSymbol Faction { get; set; }
    public string Symbol { get; set; }
    public string? Email { get; set; }
}
