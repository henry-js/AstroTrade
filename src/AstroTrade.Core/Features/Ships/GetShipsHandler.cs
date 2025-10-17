using AstroTrade.Core.Abstractions;
using AstroTrade.Core.Logging;
using Mediator;
using Microsoft.Extensions.Logging;
using SpaceTraders.Api;
using SpaceTraders.Api.Models;

namespace AstroTrade.Core.Features.Ships;

public class GetShipsHandler(
    ApiClient apiClient,
    ILogger<GetShipsHandler> logger,
    ICorrelationContext correlationContext
) : IQueryHandler<GetShipsQuery, List<Ship>>
{
    private readonly ApiClient _apiClient = apiClient;
    private readonly ILogger<GetShipsHandler> _logger = logger;
    private readonly ICorrelationContext _correlationContext = correlationContext;

    public async ValueTask<List<Ship>> Handle(
        GetShipsQuery query,
        CancellationToken cancellationToken
    )
    {
        using var scope = _correlationContext.BeginScope();
        var correlationId = _correlationContext.CurrentId;

        FeatureLog.FeatureStarted(_logger, "GetShips", correlationId);
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();

        try
        {
            var response = await _apiClient.My.Ships.GetAsShipsGetResponseAsync(
                cancellationToken: cancellationToken
            );

            var result = response?.Data ?? new List<Ship>();
            FeatureLog.FeatureCompleted(
                _logger,
                "GetShips",
                correlationId,
                stopwatch.ElapsedMilliseconds
            );
            return result;
        }
        catch (Exception ex)
        {
            FeatureLog.FeatureFailed(_logger, "GetShips", correlationId, ex.Message, ex);
            throw;
        }
    }
}
