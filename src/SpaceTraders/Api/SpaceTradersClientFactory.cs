using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Authentication.Azure;
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
        _authenticationProvider = new CustomAuthenticationProvider(accessToken, ["/register"]);
        return new(new HttpClientRequestAdapter(_authenticationProvider, httpClient: _httpClient));
    }
}

public class CustomAuthenticationProvider : IAuthenticationProvider
{
    private readonly string accessToken;
    private readonly IEnumerable<string> excludeEndpoints;

    public CustomAuthenticationProvider(string accessToken, IEnumerable<string> excludeEndpoints)
    {
        this.accessToken = accessToken;
        this.excludeEndpoints = new HashSet<string>(excludeEndpoints);
    }

    public Task AuthenticateRequestAsync(RequestInformation request, Dictionary<string, object>? additionalAuthenticationContext = null, CancellationToken cancellationToken = default)
    {
        // string registerEndpoint = "https://api.spacetraders.io/v2";
        if (request.URI.AbsolutePath == "/v2/register")
        {

        }
        else
        {
            request.Headers.Add("Authorization", $"Bearer {accessToken}");
        }

        return Task.CompletedTask;
    }
}
