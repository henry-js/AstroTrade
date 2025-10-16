using Microsoft.Extensions.Logging;

namespace AstroTrade.Infrastructure.Logging;

internal static partial class PersistenceLog
{
    [LoggerMessage(
        EventId = 1120,
        Level = LogLevel.Debug,
        Message = "Opened database connection for {Context}"
    )]
    public static partial void ConnectionOpened(ILogger logger, string context);

    [LoggerMessage(
        EventId = 1121,
        Level = LogLevel.Debug,
        Message = "Closed database connection for {Context}"
    )]
    public static partial void ConnectionClosed(ILogger logger, string context);

    [LoggerMessage(
        EventId = 1122,
        Level = LogLevel.Warning,
        Message = "Transient persistence error on {Operation}: {Reason}"
    )]
    public static partial void TransientError(
        ILogger logger,
        string operation,
        string reason,
        Exception? exception = null
    );
}
