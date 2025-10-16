using Microsoft.Extensions.Logging;

namespace AstroTrade.Infrastructure.Logging;

internal static partial class HttpClientLog
{
    [LoggerMessage(
        EventId = 1101,
        Level = LogLevel.Information,
        Message = "HTTP {Method} {Uri} started"
    )]
    public static partial void RequestStarted(ILogger logger, string method, string uri);

    [LoggerMessage(
        EventId = 1102,
        Level = LogLevel.Information,
        Message = "HTTP {Method} {Uri} responded {StatusCode} in {ElapsedMs}ms"
    )]
    public static partial void ResponseReceived(
        ILogger logger,
        string method,
        string uri,
        int statusCode,
        long elapsedMs
    );

    [LoggerMessage(
        EventId = 1103,
        Level = LogLevel.Warning,
        Message = "HTTP {Method} {Uri} failed: {Reason}"
    )]
    public static partial void RequestFailed(
        ILogger logger,
        string method,
        string uri,
        string reason,
        Exception? exception = null
    );
}
