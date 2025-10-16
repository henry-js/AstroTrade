## AstroTrade — Source-generated logging plan

Last updated: 2025-10-16

This document describes a pragmatic, layered plan to introduce source-generated, high-quality structured logging across the AstroTrade solution using Microsoft.Extensions.Logging's LoggerMessage pattern (source generators). It lists per-layer responsibilities, reserved event id ranges, suggested message templates, file locations, acceptance criteria, and verification steps.

Goals

- Provide consistent, low-allocation logging via LoggerMessage source generation.
- Organize logs into strongly-typed static classes per logical area (Domain, Infrastructure, TUI, Persistence, Security, Startup).
- Reserve event id ranges to make it easy to search and filter logs.
-
- Provide clear message templates and typed parameters so logs are queryable and useful in production.

Event ID allocation

- 1000-1099 — Core (domain, validation, features)
- 1100-1199 — Infrastructure (HTTP clients, repositories, persistence helpers)
- 1200-1299 — TUI (navigation, commands, UI components)
- 1300-1399 — Reserved (previously SpaceTraders.Api, excluded as Kiota-generated)
- 1400-1499 — Persistence/DbContext (EF lifecycle, queries, transactions)
- 1500-1599 — Security (auth, token refresh, permission failures)
- 1600-1699 — Startup/host/DI and configuration loading

High-level implementation steps

1. Create a `Logging` folder for each project (see per-layer list below). Place static partial logger classes that use `LoggerMessage.Define`/`[LoggerMessage]` attributes so the compiler generates efficient helpers.
2. Add well-typed methods (parameters typed to the values you want in logs). Prefer scalar types (string, int, Guid, TimeSpan) and avoid large object-to-string calls in templates.
3. Reserve and document event id ranges to avoid collisions.
4. Add unit tests for a few critical messages per layer to assert the correct message template and parameters are used (using a TestLogger provider or capturing provider).
5. Run a full build and fix any generator compile errors. Replace existing ad-hoc Log(...) usages with generated calls gradually.

Per-layer detailed plan

Core (src/AstroTrade.Core/) — event IDs 1000-1099

- Folder: `src/AstroTrade.Core/Logging/`
- Files to add:
  - `DomainLog.cs` — entity lifecycle events (created/updated/deleted), domain events triggered, invariants checked.
  - `ValidationLog.cs` — validation success/failure, rule names, failing members.
  - `FeatureLog.cs` — high-level feature start/completion/failure (useful for tracing use-cases end-to-end).

Suggested messages (examples):

- DomainLog.EntityCreated(logger, entityType, entityId) — "Created {EntityType} with id {EntityId}" (1001)
-
- DomainLog.EntityUpdateFailed(logger, entityType, entityId, reason, ex) — "Failed updating {EntityType} {EntityId}: {Reason}" (1002)
- ValidationLog.RuleFailed(logger, ruleName, target, details) — "Validation failed: {Rule} on {Target}: {Details}" (1010)

Infrastructure (src/AstroTrade.Infrastructure/) — event IDs 1100-1199

- Folder: `src/AstroTrade.Infrastructure/Logging/`
- Files to add:
  - `HttpClientLog.cs` — outgoing HTTP observability (request start, response status, time, errors).
  - `RepositoryLog.cs` — repository operations (query issued, cache hit/miss, not found).
  - `PersistenceLog.cs` — general persistence helpers, connection open/close, transient errors.

Suggested messages (examples):

- HttpClientLog.RequestSent(logger, method, uri) — "HTTP {Method} {Uri} started" (1101)
- HttpClientLog.ResponseReceived(logger, method, uri, statusCode, duration) — "HTTP {Method} {Uri} responded {StatusCode} in {Elapsed}ms" (1102)
- RepositoryLog.EntityNotFound(logger, entityType, id) — "{EntityType} not found: {Id}" (1110)

TUI (src/AstroTrade.TUI/) — event IDs 1200-1299

- Folder: `src/AstroTrade.TUI/Logging/`
- Files to add:
  - `NavigationLog.cs` — screen/view navigation, parameters passed, navigation errors.
  - `CommandLog.cs` — user commands execution start/completion/failure.
  - `UiLog.cs` — component-level errors, configuration loads for the TUI, view rendering failures.

Suggested messages (examples):

- NavigationLog.NavigateStart(logger, from, to) — "Navigating from {From} to {To}" (1201)
- CommandLog.CommandFailed(logger, commandName, reason, ex) — "Command {Command} failed: {Reason}" (1202)

Persistence / DbContext (src/AstroTrade.Infrastructure/Persistence/) — event IDs 1400-1499

- Folder: `src/AstroTrade.Infrastructure/Persistence/Logging/`
- Files to add:
  - `DbContextLog.cs` — DbContext lifecycle (created/disposed), transaction begin/commit/rollback.
  - `MigrationLog.cs` — migration start/completed, applied migrations list.

Suggested messages (examples):

- DbContextLog.QueryExecuted(logger, sql, elapsedMs) — "EF Query executed in {Elapsed}ms: {SqlHash}" (1401)
- MigrationLog.MigrationApplied(logger, migrationName) — "Applied migration {MigrationName}" (1402)

Security (src/AstroTrade.Core/Security/) — event IDs 1500-1599

- Folder: `src/AstroTrade.Core/Security/Logging/`
- Files: `SecurityLog.cs`

Suggested messages (examples):

- SecurityLog.AuthenticationSucceeded(logger, userId) — "Authentication succeeded for agent {AgentId}" (1501)
- SecurityLog.AuthenticationFailed(logger, userIdOrRequestId, reason) — "Authentication failed: {Reason}" (1502)
- SecurityLog.PermissionDenied(logger, agentId, action, resource) — "Permission denied for {AgentId} on {Resource} ({Action})" (1503)

Startup / Host / DI (src/AstroTrade.TUI/DependencyInjection and Program.cs) — event IDs 1600-1699

- File(s): integrate into existing `DependencyInjection/Extensions.cs` or add `StartupLog.cs` in `src/AstroTrade.TUI/Logging/`

Suggested startup messages:

- StartupLog.ApplicationStarting(logger, environment) — "Starting AstroTrade (env={Environment})" (1601)
- StartupLog.ConfigurationLoaded(logger, sourceCount) — "Loaded configuration from {SourceCount} sources" (1602)
- StartupLog.ServiceRegistered(logger, serviceType, lifetime) — "Registered service {ServiceType} ({Lifetime})" (1603)
- StartupLog.ApplicationStopping(logger, uptime, reason) — "Stopping AstroTrade after {Uptime}: {Reason}" (1604)

Implementation notes and coding examples

- Use the `[LoggerMessage]` attribute for concise declarations. Example pattern the generated methods will follow:

```csharp
[LoggerMessage(EventId = 1001, Level = LogLevel.Information,
    Message = "Created {EntityType} with id {EntityId}")]
public static partial void EntityCreated(ILogger logger, string entityType, Guid entityId);
```

- Keep message templates stable (don't embed transient/stack traces). Pass exceptions in the generated call (last parameter) when appropriate.
- Prefer to capture short string snippets of large payloads (e.g., response body snippet) rather than whole payloads.

Migration strategy for existing logs

- Add the generated logger classes first without changing call sites. Add temporary adapter extension methods that map existing calls to the generated helpers.
- Gradually replace ad-hoc calls like `logger.LogInformation("... {0} ...", x)` with the generated helpers in feature-focused commits.

Unit testing and verification

- Add a small set of unit tests using a capturing `ILoggerProvider` to assert that critical events are produced with expected template keys and values.
- Tests should cover:
  - Happy path feature start/completion logged (Core FeatureLog)
  - HttpClient response error logged (Infrastructure)
  - DbContext slow query logged (Persistence)

Quality gates & build steps

- Run a full build after adding logging classes to trigger source generation and catch compile errors introduced by the new partial methods.

Recommended commands (PowerShell):

```powershell
dotnet restore
dotnet build ./AstroTrade.slnx --no-restore
dotnet test ./src/AstroTrade.Tests/AstroTrade.Tests.csproj --no-build
```

Notes on code style and conventions

- Place logging classes in a `Logging` folder inside each project to keep them discoverable.
- Stick to the repository's naming and formatting conventions (PascalCase types/methods, file-scoped namespaces where used).
- Document event id choices at the top of each logger file in a comment header.

Acceptance criteria

- A `Logging` folder exists in each targeted project with at least one `*.cs` logger class defined.
- The solution builds cleanly (source generators produce code and no generator-related errors remain).
- A short test or smoke-run demonstrates one generated log call producing an entry via console or test-capturing provider.

Next steps (recommended order)

1. ✅ COMPLETED: Add the `Core` logging classes (1000-1099). This gives domain observability and is low risk.
2. ✅ COMPLETED: Add `Startup` logging in `AstroTrade.TUI` (1600-1699) to get host-level messages on start/stop and DI registration.
3. ✅ COMPLETED: Add Infrastructure and Persistence logging (1100-1199, 1400-1499).
4. Add Security logs (1500-1599).
5. Build, fix generator issues, and run tests. Replace inline logs gradually.

## Logging Enhancement Plan (Post-Implementation)

Based on review of the implemented logging system, the following enhancements address gaps in usage, configuration, and tracing capabilities.

### Enhancement 1: Expand Logging Usage Across Codebase

**Objective**: Increase logging coverage from current ~5 files to comprehensive observability across all major components.

**Current Usage Analysis**:

- ✅ Startup/DI (Extensions.cs)
- ✅ Repository operations (FileTokenRepository.cs)
- ✅ UI exceptions (ExceptionFilter.cs)
- ✅ Feature operations (ShellViewModel.cs)
- ✅ Configuration loading (MyCommands.cs)

**Missing Coverage Areas**:

#### Phase 1A: Core Query Handlers (High Priority)

- **GetContractsQueryHandler.cs**: Add FeatureLog calls for query start/completion
- **GetShipsQueryHandler.cs**: Add FeatureLog calls for query start/completion
- **GetMarketsQueryHandler.cs**: Add FeatureLog calls for query start/completion
- **GetSystemsQueryHandler.cs**: Add FeatureLog calls for query start/completion

**Implementation Pattern**:

```csharp
public async Task<List<Contract>> Handle(GetContractsQuery query, CancellationToken ct)
{
    var correlationId = Guid.NewGuid().ToString();
    FeatureLog.FeatureStarted(_logger, "GetContracts", correlationId);
    var stopwatch = Stopwatch.StartNew();

    try
    {
        // existing logic
        var result = await _apiClient.My.Contracts.GetAsync(cancellationToken: ct);

        FeatureLog.FeatureCompleted(_logger, "GetContracts", correlationId, stopwatch.ElapsedMilliseconds);
        return result.Data.Select(c => c.ToDomain()).ToList();
    }
    catch (Exception ex)
    {
        FeatureLog.FeatureFailed(_logger, "GetContracts", correlationId, ex.Message, ex);
        throw;
    }
}
```

#### Phase 1B: ViewModel Operations (Medium Priority)

- **DashboardViewModel.InitializeAsync()**: Add FeatureLog for dashboard loading
- **ShipsViewModel**: Add NavigationLog for ship operations
- **MarketsViewModel**: Add FeatureLog for market data fetching
- **ContractsViewModel**: Add FeatureLog for contract operations

#### Phase 1C: API Client Operations (Medium Priority)

- **ApiClient usage**: Add HttpClientLog calls in request adapter or client wrapper
- **Token refresh**: Add SecurityLog calls in BearerTokenProvider

#### Phase 1D: Navigation Events (Low Priority)

- **NavigationManager**: Add NavigationLog calls for view transitions
- **View activation**: Add NavigationLog in base view classes

**Success Metrics**:

- 80% of query handlers have logging
- All ViewModels have initialization logging
- API calls are logged at HttpClient level

### Enhancement 3: Enable Console Logging for Development

**Objective**: Improve development experience by enabling console output while maintaining file logging for production.

**Current Configuration** (Extensions.cs lines 59-63):

```csharp
// .WriteTo.Console(
//     outputTemplate: outputTemplate,
//     theme: AnsiConsoleTheme.Sixteen,
//     restrictedToMinimumLevel: LogEventLevel.Information
// )
```

**Proposed Changes**:

#### Option A: Environment-Based Configuration (Recommended)

```csharp
public static void ConfigureSerilog(this ILoggingBuilder builder)
{
    const string outputTemplate = "[{Timestamp:HH:mm:ss} {Level:u3}] ({SourceClass}) {Message:lj}{NewLine}{Exception}";

    var config = new LoggerConfiguration()
        .MinimumLevel.Debug()
        .WriteTo.File(
            formatter: new MessageTemplateTextFormatter(outputTemplate),
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs", "app-.log"),
            restrictedToMinimumLevel: LogEventLevel.Debug,
            shared: true,
            rollingInterval: RollingInterval.Day
        )
        .Enrich.WithProperty("ApplicationName", "AstroTrade")
        .Enrich.With<SourceClassEnricher>();

    // Enable console logging in Development
    var environment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT")
                     ?? Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
                     ?? "Production";

    if (environment == "Development")
    {
        config.WriteTo.Console(
            outputTemplate: outputTemplate,
            theme: AnsiConsoleTheme.Sixteen,
            restrictedToMinimumLevel: LogEventLevel.Information
        );
    }

    builder.AddSerilog(config.CreateLogger());
}
```

**Benefits**:

- Development: Real-time console feedback
- Production: Clean file-only logging
- No performance impact in production

### Enhancement 4: Implement Correlation IDs for Better Tracing

**Objective**: Enable end-to-end request tracing across async operations and component boundaries.

**Current State**: FeatureLog has correlation ID parameters but they're not being used consistently.

**Implementation Plan**:

#### Phase 4A: Correlation ID Infrastructure (High Priority)

Create a correlation context service:

**ICorrelationContext.cs**:

```csharp
public interface ICorrelationContext
{
    string CurrentId { get; }
    IDisposable BeginScope(string? id = null);
}
```

**CorrelationContext.cs**:

```csharp
public class CorrelationContext : ICorrelationContext
{
    private readonly AsyncLocal<string> _currentId = new();

    public string CurrentId => _currentId.Value ??= Guid.NewGuid().ToString();

    public IDisposable BeginScope(string? id = null)
    {
        var previousId = _currentId.Value;
        _currentId.Value = id ?? Guid.NewGuid().ToString();
        return new CorrelationScope(this, previousId);
    }

    private class CorrelationScope : IDisposable
    {
        private readonly CorrelationContext _context;
        private readonly string? _previousId;

        public CorrelationScope(CorrelationContext context, string? previousId)
        {
            _context = context;
            _previousId = previousId;
        }

        public void Dispose() => _context._currentId.Value = _previousId;
    }
}
```

Register in DI:

```csharp
services.AddSingleton<ICorrelationContext, CorrelationContext>();
```

#### Phase 4B: Update FeatureLog Usage (Medium Priority)

Modify existing and new FeatureLog calls to use correlation context:

```csharp
public async Task<List<Contract>> Handle(GetContractsQuery query, CancellationToken ct)
{
    using var scope = _correlationContext.BeginScope();
    var correlationId = _correlationContext.CurrentId;

    FeatureLog.FeatureStarted(_logger, "GetContracts", correlationId);
    var stopwatch = Stopwatch.StartNew();

    try
    {
        // If this calls other handlers, they inherit the correlation ID
        var result = await _apiClient.My.Contracts.GetAsync(cancellationToken: ct);

        FeatureLog.FeatureCompleted(_logger, "GetContracts", correlationId, stopwatch.ElapsedMilliseconds);
        return result.Data.Select(c => c.ToDomain()).ToList();
    }
    catch (Exception ex)
    {
        FeatureLog.FeatureFailed(_logger, "GetContracts", correlationId, ex.Message, ex);
        throw;
    }
}
```

#### Phase 4C: Navigation Correlation (Low Priority)

Link navigation events to feature operations:

```csharp
public async Task NavigateToAsync<TView>(NavigationParameters? parameters = null)
{
    var correlationId = _correlationContext.CurrentId;
    NavigationLog.NavigateStart(_logger, CurrentView?.GetType().Name, typeof(TView).Name,
                               parameters?.ToString(), correlationId);

    // navigation logic

    NavigationLog.NavigateComplete(_logger, typeof(TView).Name, elapsedMs, correlationId);
}
```

**Benefits**:

- Trace requests across component boundaries
- Debug complex async flows
- Correlate logs from different layers
- Support distributed tracing if needed later

### Enhancement Implementation Timeline

**Week 1**: Enhancements 1A + 3 (Query handlers + Console logging)
**Week 2**: Enhancements 1B + 4A (ViewModels + Correlation infrastructure)
**Week 3**: Enhancements 1C + 4B (API logging + Correlation usage)
**Week 4**: Enhancements 1D + 4C (Navigation + Final correlation integration)

**Testing**: Add integration tests to verify correlation IDs flow correctly across components.

This enhancement plan provides systematic expansion of logging capabilities while maintaining the high-quality foundation already established.

Appendix — mapping to todo list

- Task IDs referenced in the workspace todo list are the same logical steps used above. Start with `Core` and `Startup` as described in the Next steps.

---

Last updated: 2025-10-16 (Enhanced with post-implementation expansion plan)
