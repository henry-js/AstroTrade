
using AstroTrade.Domain.SpaceTraders;
using FluentResults;

namespace AstroTrade.Services;

public interface ISpaceTradersService
{
    Task<Result<SpaceTradersStatus>> GetSpaceTradersStatus();
    Task<RegisterAgentResponse> RegisterSpaceTrader(string faction, string symbol, string email);
}
