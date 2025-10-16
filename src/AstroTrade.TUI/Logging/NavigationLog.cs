using Microsoft.Extensions.Logging;

namespace AstroTrade.TUI.Logging;

internal static partial class NavigationLog
{
    [LoggerMessage(
        EventId = 1201,
        Level = LogLevel.Debug,
        Message = "Navigating from {From} to {To} with params {Params}"
    )]
    public static partial void NavigateStart(
        ILogger logger,
        string from,
        string to,
        string? @params = null
    );

    [LoggerMessage(
        EventId = 1202,
        Level = LogLevel.Information,
        Message = "Navigation to {To} completed in {ElapsedMs}ms"
    )]
    public static partial void NavigateComplete(ILogger logger, string to, long elapsedMs);

    [LoggerMessage(
        EventId = 1203,
        Level = LogLevel.Warning,
        Message = "Navigation error from {From} to {To}: {Reason}"
    )]
    public static partial void NavigateError(
        ILogger logger,
        string from,
        string to,
        string reason,
        Exception? exception = null
    );
}
