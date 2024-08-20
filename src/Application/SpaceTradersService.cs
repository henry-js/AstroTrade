using AstroTrade.Domain.SpaceTraders.Models;
using AstroTrade.Services;
using Flurl.Http;
using Flurl.Http.Configuration;

namespace AstroTrade.Application.Services;

public class SpaceTradersService : ISpaceTradersService
{
    private readonly IFlurlClient _client;

    public SpaceTradersService(IOptionsManager options, IFlurlClientCache clients)
    {
        _client = clients.Get(nameof(SpaceTradersApi));
    }
    public async Task<RegisterAgentResponse> RegisterSpaceTrader(string faction, string symbol, string email)
    {
        RegisterAgentRequest requestBody = new()
        {
            Faction = faction,
            Symbol = symbol,
            Email = email,
        };

        var response = await _client.Request("register")
            .PostJsonAsync(requestBody)
            .ReceiveJson<RegisterAgentResponse>();

        return response;
    }
}

public interface IOptionsManager
{

    void Save(object Value);
}

internal class RegisterAgentRequest
{
    public string Faction { get; internal set; }
    public string Symbol { get; internal set; }
    public string Email { get; internal set; }
}
