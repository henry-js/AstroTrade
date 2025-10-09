using SpaceTraders.Api.Models;

namespace AstroTrade.Core.Mappers;

public static class ShipMapper
{
    public static Models.DomainShip ToDomain(this Ship apiShip) =>
        new(
            apiShip.Registration?.Name
                ?? throw new ArgumentNullException(nameof(apiShip.Registration)),
            apiShip.Registration?.Role?.ToString() ?? "UNKNOWN",
            apiShip.Nav?.Status?.ToString() ?? "UNKNOWN",
            apiShip.Nav?.WaypointSymbol ?? ""
        );
}
