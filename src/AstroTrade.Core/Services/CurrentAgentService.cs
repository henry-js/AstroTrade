using AstroTrade.Core.Abstractions;

namespace AstroTrade.Core.Services;

public class CurrentAgentService : ICurrentAgentService
{
    private readonly ITokenRepository _tokenRepository;

    public CurrentAgentService(ITokenRepository tokenRepository)
    {
        _tokenRepository = tokenRepository;
    }

    public string? CurrentAgentSymbol { get; set; }

    public async Task SetCurrentAgentAsync(string symbol)
    {
        CurrentAgentSymbol = symbol;
    }

    public async Task<string[]> GetAvailableAgentSymbolsAsync()
    {
        return await _tokenRepository.GetAvailableAgentSymbolsAsync();
    }
}
