using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Authentication;

namespace AstroTrade.Core.Security;

public class AccountAuthenticationProvider : IAuthenticationProvider
{
    private readonly string _accountToken;

    public AccountAuthenticationProvider(string accountToken)
    {
        _accountToken = accountToken;
    }

    public Task AuthenticateRequestAsync(
        RequestInformation request,
        Dictionary<string, object>? additionalAuthenticationContext = null,
        CancellationToken cancellationToken = default
    )
    {
        request.Headers.Add("Authorization", $"Bearer {_accountToken}");
        return Task.CompletedTask;
    }
}
