using AstroTrade.Core.Abstractions;

using Mediator;

using SpaceTraders.Api;
using SpaceTraders.Api.Models;
using SpaceTraders.Api.Register;

namespace AstroTrade.Core.Features.Agents.Register;

public sealed record RegisterAgentCommand(string Symbol, string Faction) : ICommand<Agent>;

public sealed class RegisterAgentHandler : ICommandHandler<RegisterAgentCommand, Agent>
{
    private readonly ApiClient _apiClient;
    private readonly ITokenRepository _tokenRepository;

    public RegisterAgentHandler(ApiClient apiClient, ITokenRepository tokenRepository)
    {
        _apiClient = apiClient;
        _tokenRepository = tokenRepository;
    }

    public async ValueTask<Agent> Handle(RegisterAgentCommand command, CancellationToken cancellationToken)
    {
        var requestBody = new RegisterPostRequestBody
        {
            Symbol = command.Symbol,
            Faction = Enum.Parse<FactionSymbol>(command.Faction, true)
        };

        var response = await _apiClient.Register.PostAsRegisterPostResponseAsync(requestBody, cancellationToken: cancellationToken)
            ?? throw new InvalidOperationException("API response data was null");

        await _tokenRepository.SaveTokenAsync(response.Data.Token);

        return response.Data.Agent;
    }
}