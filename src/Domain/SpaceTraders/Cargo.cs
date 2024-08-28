namespace AstroTrade.Domain.SpaceTraders;

public class Cargo
{
    public long Capacity { get; set; }

    public long Units { get; set; }

    public Trait[] Inventory { get; set; } = [];
}
