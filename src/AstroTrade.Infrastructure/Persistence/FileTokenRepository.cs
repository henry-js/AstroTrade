using AstroTrade.Core.Abstractions;

namespace AstroTrade.Infrastructure.Persistence;

public class FileTokenRepository : ITokenRepository
{
    private readonly string _tokenPath;

    public FileTokenRepository(string dataDirectory)
    {
        _tokenPath = Path.Combine(dataDirectory, "authtoken.txt");
    }

    public async Task<string?> GetTokenAsync()
    {
        if (!File.Exists(_tokenPath))
        {
            return null;
        }

        return await File.ReadAllTextAsync(_tokenPath);
    }

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
