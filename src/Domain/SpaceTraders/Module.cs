namespace AstroTrade.Domain.SpaceTraders;

public class Module
{
    public string Symbol { get; set; }

    public long Capacity { get; set; }

    public long Range { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public Requirements Requirements { get; set; }
}
