namespace AstroTrade.Core.Models;

public class DomainAgent
{
    public string Symbol { get; }
    public long Credits { get; private set; }
    public string? Headquarters { get; }
    public int ShipCount { get; private set; }
    public string? StartingFaction { get; }
    public List<DomainShip> Ships { get; }

    public DomainAgent(
        string symbol,
        long credits,
        string? headquarters,
        int shipCount,
        string? startingFaction,
        List<DomainShip> ships
    )
    {
        Symbol = symbol;
        Credits = credits;
        Headquarters = headquarters;
        ShipCount = shipCount;
        StartingFaction = startingFaction;
        Ships = ships;
    }

    public bool CanAfford(long cost) => Credits >= cost;

    public void DeductCredits(long amount) => Credits -= amount;

    public void AddCredits(long amount) => Credits += amount;

    public bool HasShips() => ShipCount > 0;

    public void AddShip(DomainShip ship) => Ships.Add(ship);
}
