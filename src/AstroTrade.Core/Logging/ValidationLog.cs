using Microsoft.Extensions.Logging;

namespace AstroTrade.Core.Logging;

internal static partial class ValidationLog
{
    [LoggerMessage(
        EventId = 1010,
        Level = LogLevel.Warning,
        Message = "Validation failed: {Rule} on {Target}: {Details}"
    )]
    public static partial void RuleFailed(
        ILogger logger,
        string rule,
        string target,
        string details
    );

    [LoggerMessage(
        EventId = 1011,
        Level = LogLevel.Debug,
        Message = "Validation succeeded: {Rule} on {Target}"
    )]
    public static partial void RuleSucceeded(ILogger logger, string rule, string target);

    [LoggerMessage(
        EventId = 1012,
        Level = LogLevel.Warning,
        Message = "Model state invalid for {Target}: {ErrorCount} errors"
    )]
    public static partial void ModelStateInvalid(ILogger logger, string target, int errorCount);
}
