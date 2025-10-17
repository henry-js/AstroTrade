using AstroTrade.Core.Abstractions;

namespace AstroTrade.Core.Services;

/// <summary>
/// Provides correlation ID context for request tracing across async operations.
/// Uses AsyncLocal to maintain correlation IDs across async boundaries.
/// </summary>
public class CorrelationContext : ICorrelationContext
{
    private readonly AsyncLocal<string> _currentId = new();

    /// <inheritdoc />
    public string CurrentId => _currentId.Value ??= Guid.NewGuid().ToString();

    /// <inheritdoc />
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

        public void Dispose()
        {
            _context._currentId.Value = _previousId!;
        }
    }
}
