using AstroTrade.Domain;
using AstroTrade.Domain.SpaceTraders;

namespace AstroTrade.Application;

public interface ISpaceTradersService
{
    Task<Result<SpaceTradersStatus>> GetSpaceTradersStatus();
    Task<Result<RegisterAgentResponse>> RegisterSpaceTrader(string faction, string symbol, string email);
}
