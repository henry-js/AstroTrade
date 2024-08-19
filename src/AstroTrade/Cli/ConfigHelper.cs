using System.Runtime.InteropServices;

namespace AstroTrade.Cli;

internal static class ConfigHelper
{
    internal static void AddCliToPath()
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

    internal static void CreateConfigFile()
    {
        throw new NotImplementedException();
    }
}
