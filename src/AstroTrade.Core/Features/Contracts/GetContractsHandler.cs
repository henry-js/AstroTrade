using Mediator;
using SpaceTraders.Api;
using SpaceTraders.Api.Models;

namespace AstroTrade.Core.Features.Contracts;

public class GetContractsHandler(ApiClient apiClient)
    : IQueryHandler<GetContractsQuery, List<Contract>>
{
    private readonly ApiClient _apiClient = apiClient;

    public async ValueTask<List<Contract>> Handle(
        GetContractsQuery query,
        CancellationToken cancellationToken
    )
    {
        var response = await _apiClient.My.Contracts.GetAsContractsGetResponseAsync(
            cancellationToken: cancellationToken
        );
        return response?.Data ?? new List<Contract>();
    }
}
