namespace AstroTrade.Domain.SpaceTraders;

public class Mount
{
    public string Symbol { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public long Strength { get; set; }

    public string[] Deposits { get; set; }

    public Requirements Requirements { get; set; }
}
