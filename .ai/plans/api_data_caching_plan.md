# API Data Caching Plan

## Overview

Implement comprehensive API data caching with local SQLite storage to significantly reduce API calls, improve performance, and prevent rate limiting. This major feature will cache static game data permanently and dynamic data with appropriate TTLs.

## Current API Usage Analysis

Based on codebase analysis, these endpoints are called frequently and are candidates for caching:

- **Contracts**: `GetContractsQuery` - Called on dashboard load
- **Ships**: `GetShipsQuery` - Called on dashboard load
- **Systems/Waypoints**: `GetSystemQuery`, `GetWaypointsQuery` - Called for navigation
- **Markets**: `GetMarketQuery` - Called when viewing markets
- **Agent Info**: Rarely changes but fetched on dashboard load

## Cacheable Data Categories

### Static/Long-lived Data (Cache Forever)

- **System Information**: Star systems, waypoints, traits
- **Faction Data**: Faction details, headquarters
- **Shipyard/Market Static Info**: Available ships, trade goods (without prices)

### Dynamic Data (Cache with TTL)

- **Market Prices**: 5-15 minute TTL (game economy changes)
- **Ship Status/Location**: 1-2 minute TTL (real-time movement)
- **Contract Status**: 5 minute TTL (progress updates)
- **Agent Credits**: 30 second TTL (frequent trading)

### User-Action Invalidated

- **Agent Data**: Invalidate on registration/switch
- **Ship Inventory**: Invalidate after trade/extraction
- **Contract Progress**: Invalidate after delivery

## Architecture Options

### Option 1: SQLite Database (Recommended)

Leverage existing SQLite infrastructure from Directory.Build.props

```csharp
public class CachedMarketData
{
    public string WaypointSymbol { get; set; }
    public string TradeGood { get; set; }
    public int BuyPrice { get; set; }
    public int SellPrice { get; set; }
    public DateTime CachedAt { get; set; }
    public DateTime ExpiresAt { get; set; }
}
```

### Option 2: LiteDB (NoSQL Document DB)

File-based NoSQL, no server required. Good for complex nested objects.

### Option 3: JSON File Cache

Simple but limited for complex queries. Good for rapid prototyping.

## Cache Synchronization Strategy

### Cache-First with Fallback

```csharp
public async Task<List<Contract>> GetContractsAsync()
{
    // Try cache first
    var cached = await _cache.GetContractsAsync();
    if (cached != null && !IsExpired(cached))
        return cached;

    // Fallback to API
    var fresh = await _apiClient.GetContractsAsync();
    await _cache.StoreContractsAsync(fresh);
    return fresh;
}
```

### Background Refresh

Periodic background job to refresh volatile data, preventing cache misses during user actions.

### Write-Through Cache

When user performs actions (trade, move ship), immediately invalidate/update affected cache entries.

## Implementation Plan

### Phase 1: Infrastructure (High Priority)

- [ ] Choose database technology (SQLite recommended)
- [ ] Create `ICacheRepository` interface
- [ ] Implement cache repository with SQLite
- [ ] Add cache configuration (TTL settings)
- [ ] Create database migration/initialization logic

### Phase 2: Static Data Caching (Medium Priority)

- [ ] Cache system/waypoint data (never expires)
- [ ] Cache faction information
- [ ] Update queries to check cache first
- [ ] Add cache warming on startup

### Phase 3: Dynamic Data Caching (Medium Priority)

- [ ] Implement TTL-based caching for market data
- [ ] Cache ship locations with short TTL
- [ ] Add cache invalidation on user actions
- [ ] Implement background refresh for volatile data

### Phase 4: Cache Management UI (Low Priority)

- [ ] Add cache status to debug menu
- [ ] Manual cache refresh options
- [ ] Cache statistics (hit rate, size, storage used)
- [ ] Cache clearing functionality

## Performance Impact

### Expected Improvements

- **Dashboard Load**: 3 API calls → 0 API calls (after initial load)
- **Market Browsing**: 10+ API calls → 1-2 API calls
- **Navigation**: System data cached permanently
- **API Rate Limit**: 30 req/minute → 5-10 req/minute during normal use

### Storage Requirements

- **Static Data**: ~50MB (all systems, waypoints, factions)
- **Dynamic Data**: ~5MB (market prices, ship status)
- **Total**: ~55MB SQLite database

## Data Consistency Concerns

### Cache Invalidation Triggers

- **Time-based**: Market prices expire every 5 minutes
- **Action-based**: Ship movement invalidates location cache
- **Manual**: User can force refresh if needed

### Stale Data Risks

- **Market Prices**: Could show outdated prices (5 min max)
- **Ship Status**: Could show wrong location briefly
- **Mitigation**: Short TTLs + manual refresh options + visual indicators

## Testing Strategy

### Cache Testing

- [ ] Unit tests for cache hit/miss logic
- [ ] Integration tests with SQLite
- [ ] Performance tests comparing cached vs API calls
- [ ] Memory usage tests

### Data Consistency

- [ ] Tests for cache invalidation on user actions
- [ ] Tests for TTL expiration
- [ ] Manual testing with API response mocking
- [ ] Concurrent access tests

## Migration Strategy

### Backward Compatibility

- Cache is additive - existing code continues working
- API calls happen as fallback when cache misses
- Gradual rollout: enable caching per feature

### Data Migration

- Fresh cache on first run (populate from API)
- No existing user data to migrate
- Cache rebuilds automatically if corrupted

## Success Metrics

- **API Call Reduction**: 70-80% fewer API calls
- **UI Responsiveness**: Dashboard loads in <1 second vs 3-5 seconds
- **Rate Limit Safety**: Stay well under API limits
- **Offline Capability**: Basic functionality works without internet (future)

## Technical Implementation Details

### Database Schema

```sql
-- Static data tables
CREATE TABLE Systems (Symbol TEXT PRIMARY KEY, ...);
CREATE TABLE Waypoints (Symbol TEXT PRIMARY KEY, SystemSymbol TEXT, ...);
CREATE TABLE Factions (Symbol TEXT PRIMARY KEY, ...);

-- Dynamic data tables
CREATE TABLE MarketPrices (
    WaypointSymbol TEXT,
    TradeGood TEXT,
    BuyPrice INTEGER,
    SellPrice INTEGER,
    CachedAt DATETIME,
    ExpiresAt DATETIME,
    PRIMARY KEY (WaypointSymbol, TradeGood)
);

CREATE TABLE ShipLocations (
    ShipSymbol TEXT PRIMARY KEY,
    SystemSymbol TEXT,
    WaypointSymbol TEXT,
    CachedAt DATETIME,
    ExpiresAt DATETIME
);
```

### Cache Repository Interface

```csharp
public interface ICacheRepository
{
    Task<T?> GetAsync<T>(string key) where T : class;
    Task SetAsync<T>(string key, T value, TimeSpan? ttl = null) where T : class;
    Task RemoveAsync(string key);
    Task ClearExpiredAsync();
    Task<long> GetCacheSizeAsync();
}
```

### Query Handler Updates

```csharp
public class GetContractsQueryHandler : IQueryHandler<GetContractsQuery, List<Contract>>
{
    public async Task<List<Contract>> Handle(GetContractsQuery query, CancellationToken ct)
    {
        // Try cache first
        var cached = await _cache.GetAsync<List<Contract>>("contracts");
        if (cached != null && !IsExpired(cached))
            return cached;

        // API fallback
        var contracts = await _apiClient.My.Contracts.GetAsync(cancellationToken: ct);
        var domainContracts = contracts.Data.Select(c => c.ToDomain()).ToList();

        await _cache.SetAsync("contracts", domainContracts, TimeSpan.FromMinutes(5));
        return domainContracts;
    }
}
```

## Risks and Mitigations

### Performance Risks

- **Cache misses**: Could temporarily slow down if cache is cold
- **Memory usage**: SQLite database file growth
- **Mitigation**: Background warming, size limits, compression

### Data Consistency Risks

- **Stale data**: Users seeing outdated information
- **Race conditions**: Multiple processes updating cache
- **Mitigation**: Short TTLs, optimistic locking, conflict resolution

### Development Complexity

- **Added complexity**: More layers in data access
- **Testing difficulty**: Cache state management
- **Mitigation**: Comprehensive testing, gradual rollout, feature flags

## Future Enhancements

- **Offline mode**: Full functionality without internet connection
- **Cache synchronization**: Multi-device cache sharing
- **Advanced invalidation**: Event-driven cache updates
- **Cache analytics**: Usage patterns and optimization opportunities
