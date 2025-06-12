namespace AstroTrade.Core.Abstractions;

public interface ITokenRepository
{
    Task SaveTokenAsync(string token);
    Task<string?> GetTokenAsync();
}
