namespace AstroTrade.Domain.SpaceTraders;

public class Ship
{
    public string Symbol { get; set; }

    public Registration Registration { get; set; }

    public Nav Nav { get; set; }

    public Crew Crew { get; set; }

    public Frame Frame { get; set; }

    public Engine Reactor { get; set; }

    public Engine Engine { get; set; }

    public Cooldown Cooldown { get; set; }

    public Module[] Modules { get; set; }

    public Mount[] Mounts { get; set; }

    public Cargo Cargo { get; set; }

    public Fuel Fuel { get; set; }
}
