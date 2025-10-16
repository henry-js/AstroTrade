using Microsoft.Extensions.Logging;

namespace AstroTrade.Infrastructure.Logging;

internal static partial class RepositoryLog
{
    [LoggerMessage(
        EventId = 1110,
        Level = LogLevel.Debug,
        Message = "Repository query executed: {QueryName}"
    )]
    public static partial void QueryExecuted(ILogger logger, string queryName);

    [LoggerMessage(
        EventId = 1111,
        Level = LogLevel.Information,
        Message = "Repository cache {CacheStatus} for {Key}"
    )]
    public static partial void CacheStatus(ILogger logger, string cacheStatus, string key);

    [LoggerMessage(
        EventId = 1112,
        Level = LogLevel.Warning,
        Message = "Entity {EntityType} not found for id {Id}"
    )]
    public static partial void EntityNotFound(ILogger logger, string entityType, string id);
}
