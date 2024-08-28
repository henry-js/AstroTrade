namespace AstroTrade.Domain.SpaceTraders;

public class Agent
{
    public string AccountId { get; set; }

    public string Symbol { get; set; }

    public string Headquarters { get; set; }

    public long Credits { get; set; }

    public string StartingFaction { get; set; }

    public long ShipCount { get; set; }
}
