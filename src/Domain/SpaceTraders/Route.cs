namespace AstroTrade.Domain.SpaceTraders;

public class Route
{
    public Destination Destination { get; set; }

    public Destination Origin { get; set; }

    public DateTimeOffset DepartureTime { get; set; }

    public DateTimeOffset Arrival { get; set; }
}
