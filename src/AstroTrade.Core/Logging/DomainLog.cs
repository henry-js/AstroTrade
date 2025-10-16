using Microsoft.Extensions.Logging;

namespace AstroTrade.Core.Logging;

/// <summary>
/// Source-generated logging helpers for domain-level events.
/// Event IDs: 1000-1099
/// </summary>
internal static partial class DomainLog
{
    [LoggerMessage(
        EventId = 1001,
        Level = LogLevel.Information,
        Message = "Created {EntityType} with id {EntityId}"
    )]
    public static partial void EntityCreated(ILogger logger, string entityType, string entityId);

    [LoggerMessage(
        EventId = 1002,
        Level = LogLevel.Information,
        Message = "Updated {EntityType} with id {EntityId}"
    )]
    public static partial void EntityUpdated(ILogger logger, string entityType, string entityId);

    [LoggerMessage(
        EventId = 1003,
        Level = LogLevel.Information,
        Message = "Deleted {EntityType} with id {EntityId}"
    )]
    public static partial void EntityDeleted(ILogger logger, string entityType, string entityId);

    [LoggerMessage(
        EventId = 1004,
        Level = LogLevel.Debug,
        Message = "Published domain event {EventName} for {EntityType} {EntityId}"
    )]
    public static partial void DomainEventPublished(
        ILogger logger,
        string eventName,
        string entityType,
        string entityId
    );

    [LoggerMessage(
        EventId = 1005,
        Level = LogLevel.Warning,
        Message = "Domain invariant violated on {EntityType} {EntityId}: {Reason}"
    )]
    public static partial void DomainInvariantViolated(
        ILogger logger,
        string entityType,
        string entityId,
        string reason,
        Exception? exception = null
    );
}
