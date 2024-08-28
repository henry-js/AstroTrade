namespace AstroTrade.Domain.SpaceTraders;

public class Deliver
{
    public string TradeSymbol { get; set; }

    public string DestinationSymbol { get; set; }

    public long UnitsRequired { get; set; }

    public long UnitsFulfilled { get; set; }
}
