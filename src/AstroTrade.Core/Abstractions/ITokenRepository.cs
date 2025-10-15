namespace AstroTrade.Core.Abstractions;

public interface ITokenRepository
{
    Task SaveTokenAsync(string token, string agentSymbol);
    Task<string?> GetTokenAsync(string agentSymbol);
    Task<string[]> GetAvailableAgentSymbolsAsync();
}

public interface ICurrentAgentService
{
    string? CurrentAgentSymbol { get; set; }
    Task SetCurrentAgentAsync(string symbol);
    Task<string[]> GetAvailableAgentSymbolsAsync();
}
