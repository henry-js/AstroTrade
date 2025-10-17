using AstroTrade.Core.Abstractions;
using AstroTrade.Core.Logging;
using Mediator;
using Microsoft.Extensions.Logging;
using SpaceTraders.Api;
using SpaceTraders.Api.Models;

namespace AstroTrade.Core.Features.Contracts;

public class GetContractsHandler(
    ApiClient apiClient,
    ILogger<GetContractsHandler> logger,
    ICorrelationContext correlationContext
) : IQueryHandler<GetContractsQuery, List<Contract>>
{
    private readonly ApiClient _apiClient = apiClient;
    private readonly ILogger<GetContractsHandler> _logger = logger;
    private readonly ICorrelationContext _correlationContext = correlationContext;

    public async ValueTask<List<Contract>> Handle(
        GetContractsQuery query,
        CancellationToken cancellationToken
    )
    {
        using var scope = _correlationContext.BeginScope();
        var correlationId = _correlationContext.CurrentId;

        FeatureLog.FeatureStarted(_logger, "GetContracts", correlationId);
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();

        try
        {
            var response = await _apiClient.My.Contracts.GetAsContractsGetResponseAsync(
                cancellationToken: cancellationToken
            );

            var result = response?.Data ?? new List<Contract>();
            FeatureLog.FeatureCompleted(
                _logger,
                "GetContracts",
                correlationId,
                stopwatch.ElapsedMilliseconds
            );
            return result;
        }
        catch (Exception ex)
        {
            FeatureLog.FeatureFailed(_logger, "GetContracts", correlationId, ex.Message, ex);
            throw;
        }
    }
}
