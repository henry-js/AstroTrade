using System.Text.Json;
using AstroTrade.Core.Abstractions;
using AstroTrade.Core.Mappers;
using AstroTrade.Core.Models;
using AstroTrade.Core.Security;
using Mediator;
using Microsoft.Kiota.Http.HttpClientLibrary;
using SpaceTraders.Api;
using SpaceTraders.Api.Models;
using SpaceTraders.Api.Register;

namespace AstroTrade.Core.Features.Agents.Register;

public sealed class RegisterAgentHandler : ICommandHandler<RegisterAgentCommand, DomainAgent>
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ITokenRepository _tokenRepository;

    public RegisterAgentHandler(
        IHttpClientFactory httpClientFactory,
        ITokenRepository tokenRepository
    )
    {
        _httpClientFactory = httpClientFactory;
        _tokenRepository = tokenRepository;
    }

    public async ValueTask<DomainAgent> Handle(
        RegisterAgentCommand command,
        CancellationToken cancellationToken
    )
    {
        var registrationAuthProvider = new AccountAuthenticationProvider(command.AccountToken);
        var httpClient = _httpClientFactory.CreateClient("RegistrationClient");

        var registrationAdapter = new HttpClientRequestAdapter(
            registrationAuthProvider,
            httpClient: httpClient
        );
        var registrationClient = new ApiClient(registrationAdapter);

        var requestBody = new RegisterPostRequestBody
        {
            Symbol = command.Symbol,
            Faction = Enum.Parse<FactionSymbol>(command.Faction, true),
        };

        try
        {
            var response =
                await registrationClient.Register.PostAsRegisterPostResponseAsync(
                    requestBody,
                    cancellationToken: cancellationToken
                ) ?? throw new InvalidOperationException("API response data was null");

            if (response.Data?.Token is not string token)
            {
                throw new InvalidOperationException("Token was null");
            }
            if (response.Data?.Agent is not Agent apiAgent)
            {
                throw new InvalidOperationException("Agent was null");
            }

            await _tokenRepository.SaveTokenAsync(token);

            return apiAgent.ToDomain();
        }
        catch (Register409Error ex)
        {
            Console.WriteLine(JsonSerializer.Serialize(ex.Data));
            throw;
        }
    }
}
