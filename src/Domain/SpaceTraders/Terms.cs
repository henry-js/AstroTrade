namespace AstroTrade.Domain.SpaceTraders;

public class Terms
{
    public DateTimeOffset Deadline { get; set; }

    public Payment Payment { get; set; }

    public Deliver[] Deliver { get; set; }
}
