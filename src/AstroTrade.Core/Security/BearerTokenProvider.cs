using AstroTrade.Core.Abstractions;
using Microsoft.Kiota.Abstractions.Authentication;

namespace AstroTrade.Core.Security;

public sealed class BearerTokenProvider : IAccessTokenProvider
{
    private readonly ITokenRepository _tokenRepository;
    private readonly ICurrentAgentService _currentAgentService;

    public BearerTokenProvider(
        ITokenRepository tokenRepository,
        ICurrentAgentService currentAgentService
    )
    {
        _tokenRepository = tokenRepository;
        _currentAgentService = currentAgentService;
    }

    public async Task<string> GetAuthorizationTokenAsync(
        Uri uri,
        Dictionary<string, object>? additionalAuthenticationContext = null,
        CancellationToken cancellationToken = default
    )
    {
        // Here is the logic from your CustomAuthenticationProvider.
        // If the request is for registration, we don't provide a token.
        if (uri.AbsolutePath.EndsWith("/register"))
        {
            return string.Empty; // Return no token
        }

        // For all other endpoints, fetch the token from storage using the current agent symbol.
        var agentSymbol = _currentAgentService.CurrentAgentSymbol;
        if (string.IsNullOrEmpty(agentSymbol))
        {
            return string.Empty;
        }

        return await _tokenRepository.GetTokenAsync(agentSymbol) ?? string.Empty;
    }

    public AllowedHostsValidator AllowedHostsValidator { get; } = new();
}
