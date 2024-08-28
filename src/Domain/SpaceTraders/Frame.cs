namespace AstroTrade.Domain.SpaceTraders;

public class Frame
{
    public string Symbol { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public long Condition { get; set; }

    public long Integrity { get; set; }

    public long ModuleSlots { get; set; }

    public long MountingPoints { get; set; }

    public long FuelCapacity { get; set; }

    public Requirements Requirements { get; set; }
}
