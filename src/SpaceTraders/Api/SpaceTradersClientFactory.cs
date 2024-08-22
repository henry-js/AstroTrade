using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;

namespace SpaceTraders.Api;

public class SpaceTradersClientFactory
{
    private IAuthenticationProvider _authenticationProvider;
    private readonly HttpClient _httpClient;

    public SpaceTradersClientFactory(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public SpaceTradersClient GetClient(string accessToken)
    {
        _authenticationProvider = new BaseBearerTokenAuthenticationProvider(new TokenProvider(accessToken));
        return new(new HttpClientRequestAdapter(_authenticationProvider, httpClient: _httpClient));
    }
}

internal class TokenProvider(string accessToken = "") : IAccessTokenProvider
{
    public AllowedHostsValidator AllowedHostsValidator { get; } = new AllowedHostsValidator();

    public Task<string> GetAuthorizationTokenAsync(Uri uri, Dictionary<string, object>? additionalAuthenticationContext = null, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(accessToken);
    }
}
