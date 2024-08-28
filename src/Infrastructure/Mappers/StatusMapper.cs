using AstroTrade.Domain.SpaceTraders;
using Riok.Mapperly.Abstractions;
using SpaceTraders.Api;
using SpaceTraders.Api.Register;

namespace AstroTrade.Infrastructure.Mappers;

[Mapper]
internal static partial class StatusMapper
{
    [MapperIgnoreSource(nameof(GetResponse.AdditionalData))]
    public static partial SpaceTradersStatus ToSpaceTradersStatus(this GetResponse getResponse);
}

[Mapper]
internal static partial class RegistrationResponseMapper
{
    [MapperIgnoreSource(nameof(RegisterPostResponse_data.AdditionalData))]
    public static partial RegistrationResponse ToRegistrationResponse(this RegisterPostResponse_data registerPostResponse);
}
