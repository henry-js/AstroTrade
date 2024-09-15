using AstroTrade.Application;
using AstroTrade.Domain;
using AstroTrade.Domain.Exceptions;
using AstroTrade.Domain.SpaceTraders;
using AstroTrade.Infrastructure.Mappers;
using Microsoft.Extensions.Logging;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Http.HttpClientLibrary.Middleware.Options;
using SpaceTraders.Api;
using SpaceTraders.Api.Register;

namespace AstroTrade.Infrastructure.Services;

public class SpaceTradersApiService : ISpaceTradersApiService
{
    private readonly SpaceTradersClient client;
    private readonly ILogger<SpaceTradersApiService> logger;

    public SpaceTradersApiService(SpaceTradersClient client, ILogger<SpaceTradersApiService> logger)
    {
        this.client = client;
        this.logger = logger;
    }

    public async Task<Result<SpaceTradersStatus>> GetSpaceTradersStatus()
    {
        logger.LogInformation("Fetching SpaceTraders status");
        try
        {
            var response = await client.GetAsGetResponseAsync(conf =>
            {
                conf.Options = [new RetryHandlerOption()
                {

                }];
            });
            return response.ToSpaceTradersStatus();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Encountered error");
            return ex;
        }
    }

    public async Task<Result<RegistrationResponse>> RegisterSpaceTrader(RegistrationRequest request)
    {
        logger.LogInformation("Registering new space trader");

        var body = new RegisterPostRequestBody
        {
            Faction = Enum.Parse<SpaceTraders.Api.Models.FactionSymbol>(request.Faction.ToString()),
            Symbol = request.Symbol,
            Email = request.Email
        };

        try
        {
            var response = await client.Register.PostAsRegisterPostResponseAsync(body);
            var data = response!.Data!.ToRegistrationResponse();
            logger.LogInformation("Created new agent, CallSign: {CallSign}", data.Agent.Symbol);
            return data;
        }
        catch (Exception ex) when (ex is ApiException apiException && apiException.ResponseStatusCode == 409)
        {
            var exception = new AgentAlreadyExistsException(apiException);
            logger.LogInformation(exception, "Encountered Error, {StatusCode}", apiException.ResponseStatusCode);

            return exception;
        }
    }
}
