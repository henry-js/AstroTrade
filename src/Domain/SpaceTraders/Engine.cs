namespace AstroTrade.Domain.SpaceTraders;

public class Engine
{
    public string Symbol { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public long Condition { get; set; }

    public long Integrity { get; set; }

    public long? Speed { get; set; }

    public Requirements Requirements { get; set; }

    public long? PowerOutput { get; set; }
}
