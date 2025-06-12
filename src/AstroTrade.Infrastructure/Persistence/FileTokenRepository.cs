using AstroTrade.Core.Abstractions;

namespace AstroTrade.Infrastructure.Persistence;

public class FileTokenRepository : ITokenRepository
{
    public Task<string?> GetTokenAsync()
    {
        throw new NotImplementedException();
    }

    private readonly string _tokenPath = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        "AstroTrade",
        "authtoken.txt");

    public Task SaveTokenAsync(string token)
    {
        // Ensure the directory exists.
        var directory = Path.GetDirectoryName(_tokenPath);
        if (directory != null)
        {
            Directory.CreateDirectory(directory);
        }

        return File.WriteAllTextAsync(_tokenPath, token);
    }
}
