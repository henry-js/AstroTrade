using AstroTrade.Domain.SpaceTraders.Models;
using AstroTrade.Services;
using SpaceTraders.Api;

namespace AstroTrade.Application.Services;

public class SpaceTradersService : ISpaceTradersService
{
    private readonly SpaceTradersClient client;

    public SpaceTradersService(SpaceTradersClient client)
    {
        this.client = client;
    }
    public async Task<RegisterAgentResponse> RegisterSpaceTrader(string faction, string symbol, string email)
    {
        RegisterAgentRequest requestBody = new()
        {
            Faction = faction,
            Symbol = symbol,
            Email = email,
        };
        try
        {
            var response = await client.GetAsGetResponseAsync();
            Console.WriteLine(response);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }

        var response2 = await client.Register.PostAsRegisterPostResponseAsync(new SpaceTraders.Api.Register.RegisterPostRequestBody { Faction = SpaceTraders.Api.Models.FactionSymbol.COSMIC, Symbol = symbol, Email = "jh@example.com" });
        return new RegisterAgentResponse();
        // return response;
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
