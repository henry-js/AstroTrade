using System;
using Microsoft.Extensions.Logging;

namespace AstroTrade.TUI.Logging;

/// <summary>
/// Source-generated logging helpers for application startup and DI registration.
/// Event IDs: 1600-1699
/// </summary>
internal static partial class StartupLog
{
    [LoggerMessage(
        EventId = 1601,
        Level = LogLevel.Information,
        Message = "Starting AstroTrade (env={Environment})"
    )]
    public static partial void ApplicationStarting(ILogger logger, string environment);

    [LoggerMessage(
        EventId = 1602,
        Level = LogLevel.Debug,
        Message = "Loaded configuration from {SourceCount} sources"
    )]
    public static partial void ConfigurationLoaded(ILogger logger, int sourceCount);

    [LoggerMessage(
        EventId = 1603,
        Level = LogLevel.Debug,
        Message = "Service registration count: {ServiceCount}"
    )]
    public static partial void ServiceRegistrationSummary(ILogger logger, int serviceCount);
}
