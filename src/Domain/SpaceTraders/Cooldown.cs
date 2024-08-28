namespace AstroTrade.Domain.SpaceTraders;

public class Cooldown
{
    public string ShipSymbol { get; set; }

    public long TotalSeconds { get; set; }

    public long RemainingSeconds { get; set; }

    public DateTimeOffset Expiration { get; set; }
}
