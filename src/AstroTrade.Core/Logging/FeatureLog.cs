using Microsoft.Extensions.Logging;

namespace AstroTrade.Core.Logging;

internal static partial class FeatureLog
{
    [LoggerMessage(
        EventId = 1020,
        Level = LogLevel.Information,
        Message = "Feature {FeatureName} started (correlation: {CorrelationId})"
    )]
    public static partial void FeatureStarted(
        ILogger logger,
        string featureName,
        string correlationId
    );

    [LoggerMessage(
        EventId = 1021,
        Level = LogLevel.Information,
        Message = "Feature {FeatureName} completed (correlation: {CorrelationId}) in {ElapsedMs}ms"
    )]
    public static partial void FeatureCompleted(
        ILogger logger,
        string featureName,
        string correlationId,
        long elapsedMs
    );

    [LoggerMessage(
        EventId = 1022,
        Level = LogLevel.Error,
        Message = "Feature {FeatureName} failed (correlation: {CorrelationId}): {Reason}"
    )]
    public static partial void FeatureFailed(
        ILogger logger,
        string featureName,
        string correlationId,
        string reason,
        Exception? exception = null
    );
}
