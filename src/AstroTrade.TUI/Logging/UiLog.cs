using Microsoft.Extensions.Logging;

namespace AstroTrade.TUI.Logging;

internal static partial class UiLog
{
    [LoggerMessage(
        EventId = 1220,
        Level = LogLevel.Debug,
        Message = "Rendering component {ComponentName} took {ElapsedMs}ms"
    )]
    public static partial void ComponentRendered(
        ILogger logger,
        string componentName,
        long elapsedMs
    );

    [LoggerMessage(
        EventId = 1221,
        Level = LogLevel.Warning,
        Message = "UI component {ComponentName} encountered an issue: {Reason}"
    )]
    public static partial void ComponentIssue(
        ILogger logger,
        string componentName,
        string reason,
        Exception? exception = null
    );

    [LoggerMessage(
        EventId = 1222,
        Level = LogLevel.Debug,
        Message = "Configuration loaded for TUI: {ConfigName}"
    )]
    public static partial void ConfigurationLoaded(ILogger logger, string configName);
}
