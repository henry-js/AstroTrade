using SpaceTraders.Api.Models;

namespace AstroTrade.Core.Mappers;

public static class AgentMapper
{
    public static Models.DomainAgent ToDomain(this Agent apiAgent) =>
        new(
            apiAgent.Symbol ?? throw new ArgumentNullException(nameof(apiAgent)),
            apiAgent.Credits ?? 0,
            apiAgent.Headquarters,
            apiAgent.ShipCount ?? 0,
            apiAgent.StartingFaction,
            new List<Models.DomainShip>()
        );
}
