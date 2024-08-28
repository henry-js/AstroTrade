namespace AstroTrade.Domain.SpaceTraders;

public class Faction
{
    public FactionSymbol Symbol { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string Headquarters { get; set; }

    public Trait[] Traits { get; set; }

    public bool IsRecruiting { get; set; }
}
