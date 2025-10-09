namespace AstroTrade.Core.Models;

public class DomainShip
{
    public string Symbol { get; }
    public string RegistrationRole { get; }
    public string NavStatus { get; }
    public string NavWaypointSymbol { get; }

    public DomainShip(
        string symbol,
        string registrationRole,
        string navStatus,
        string navWaypointSymbol
    )
    {
        Symbol = symbol;
        RegistrationRole = registrationRole;
        NavStatus = navStatus;
        NavWaypointSymbol = navWaypointSymbol;
    }

    public bool IsDocked() => NavStatus == "DOCKED";

    public bool IsInTransit() => NavStatus == "IN_TRANSIT";
}
