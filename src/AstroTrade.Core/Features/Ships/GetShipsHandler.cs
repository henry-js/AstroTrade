using Mediator;
using SpaceTraders.Api;
using SpaceTraders.Api.Models;

namespace AstroTrade.Core.Features.Ships;

public class GetShipsHandler(ApiClient apiClient) : IQueryHandler<GetShipsQuery, List<Ship>>
{
    private readonly ApiClient _apiClient = apiClient;

    public async ValueTask<List<Ship>> Handle(
        GetShipsQuery query,
        CancellationToken cancellationToken
    )
    {
        var response = await _apiClient.My.Ships.GetAsShipsGetResponseAsync(
            cancellationToken: cancellationToken
        );
        return response?.Data ?? new List<Ship>();
    }
}
