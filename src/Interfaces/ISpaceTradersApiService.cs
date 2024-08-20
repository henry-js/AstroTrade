
using AstroTrade.Domain.SpaceTraders.Models;

namespace AstroTrade.Services;

public interface ISpaceTradersService
{
    public Task<RegisterAgentResponse> RegisterSpaceTrader(string faction, string symbol, string email);
}
