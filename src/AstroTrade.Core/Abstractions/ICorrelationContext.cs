namespace AstroTrade.Core.Abstractions;

/// <summary>
/// Provides correlation ID context for request tracing across component boundaries.
/// </summary>
public interface ICorrelationContext
{
    /// <summary>
    /// Gets the current correlation ID for the execution context.
    /// </summary>
    string CurrentId { get; }

    /// <summary>
    /// Begins a new correlation scope with an optional ID.
    /// </summary>
    /// <param name="id">Optional correlation ID. If null, a new GUID will be generated.</param>
    /// <returns>A disposable scope that restores the previous correlation ID when disposed.</returns>
    IDisposable BeginScope(string? id = null);
}
