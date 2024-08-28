using AstroTrade.Domain;
using AstroTrade.Domain.SpaceTraders;

namespace AstroTrade.Application;

public interface ISpaceTradersApiService
{
    Task<Result<SpaceTradersStatus>> GetSpaceTradersStatus();
    Task<Result<RegistrationResponse>> RegisterSpaceTrader(RegistrationRequest request);
}
