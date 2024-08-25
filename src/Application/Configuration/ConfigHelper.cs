using System.Runtime.InteropServices;
using System.Text.Json;

namespace AstroTrade.Application.Configuration;

public static class ConfigHelper
{
    private static readonly string ConfigFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".config", "astrotrade");
    private const string ConfigFile = "config.json";
    public static readonly string ConfigFilePath = Path.Combine(ConfigFolderPath, ConfigFile);

    public static void AddCliToPath()
    {
        const string variable = "Path";

        var value = Environment.GetEnvironmentVariable(variable, EnvironmentVariableTarget.User)
            ?? throw new Exception($"Environment variable could not be found, {variable}");

        string name = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), AppDomain.CurrentDomain.FriendlyName, "current");

        if (value.Contains(name, StringComparison.OrdinalIgnoreCase))
        {
            string separator = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? ";" : ":";
            value += $"{name}{separator}";

            Environment.SetEnvironmentVariable(variable, value, EnvironmentVariableTarget.User);
        }
    }

    public static void CreateConfigFile()
    {
        if (!Directory.Exists(ConfigFolderPath)) Directory.CreateDirectory(ConfigFolderPath);

        if (!File.Exists(ConfigFilePath))
        {
            JsonSerializerOptions options = new() { WriteIndented = true };
            File.WriteAllText(ConfigFilePath, JsonSerializer.Serialize(new AstroTradeOptions(), options));
        }
    }
}
