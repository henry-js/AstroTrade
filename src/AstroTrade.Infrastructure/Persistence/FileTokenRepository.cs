using AstroTrade.Core.Abstractions;

namespace AstroTrade.Infrastructure.Persistence;

public class FileTokenRepository : ITokenRepository
{
    private readonly string _dataDirectory;

    public FileTokenRepository(string dataDirectory)
    {
        _dataDirectory = dataDirectory;
    }

    public async Task<string?> GetTokenAsync(string agentSymbol)
    {
        var tokenPath = GetTokenPath(agentSymbol);
        if (!File.Exists(tokenPath))
        {
            return null;
        }

        return await File.ReadAllTextAsync(tokenPath);
    }

    public async Task SaveTokenAsync(string token, string agentSymbol)
    {
        var tokenPath = GetTokenPath(agentSymbol);

        // Ensure the directory exists.
        var directory = Path.GetDirectoryName(tokenPath);
        if (directory != null)
        {
            Directory.CreateDirectory(directory);
        }

        await File.WriteAllTextAsync(tokenPath, token);
    }

    public async Task<string[]> GetAvailableAgentSymbolsAsync()
    {
        var agentsDir = Path.Combine(_dataDirectory, "agents");
        if (!Directory.Exists(agentsDir))
        {
            return Array.Empty<string>();
        }
        var tokenFiles = Directory.GetFiles(agentsDir, "*_authtoken.txt");
        var agentSymbols = new List<string>();

        foreach (var file in tokenFiles)
        {
            var fileName = Path.GetFileNameWithoutExtension(file);
            if (fileName.EndsWith("_authtoken"))
            {
                var agentSymbol = fileName[..^10]; // Remove "_authtoken" suffix
                // Unsanitize the symbol (convert underscores back to original invalid chars if needed)
                // For now, just return as-is since we sanitized during save
                agentSymbols.Add(agentSymbol);
            }
        }
        return await Task.FromResult(agentSymbols.ToArray());
    }

    private string GetTokenPath(string agentSymbol)
    {
        // Sanitize agent symbol for filename (remove invalid characters)
        var sanitizedSymbol = string.Join("_", agentSymbol.Split(Path.GetInvalidFileNameChars()));
        var dir = Path.Combine(_dataDirectory, "agents");
        Directory.CreateDirectory(dir);

        return Path.Combine(dir, $"{sanitizedSymbol}_authtoken.txt");
    }
}
