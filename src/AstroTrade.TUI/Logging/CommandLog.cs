using Microsoft.Extensions.Logging;

namespace AstroTrade.TUI.Logging;

internal static partial class CommandLog
{
    [LoggerMessage(
        EventId = 1210,
        Level = LogLevel.Information,
        Message = "Executing command {CommandName} (user: {User})"
    )]
    public static partial void CommandExecuting(
        ILogger logger,
        string commandName,
        string? user = null
    );

    [LoggerMessage(
        EventId = 1211,
        Level = LogLevel.Information,
        Message = "Command {CommandName} completed in {ElapsedMs}ms"
    )]
    public static partial void CommandCompleted(ILogger logger, string commandName, long elapsedMs);

    [LoggerMessage(
        EventId = 1212,
        Level = LogLevel.Error,
        Message = "Command {CommandName} failed: {Reason}"
    )]
    public static partial void CommandFailed(
        ILogger logger,
        string commandName,
        string reason,
        Exception? exception = null
    );
}
