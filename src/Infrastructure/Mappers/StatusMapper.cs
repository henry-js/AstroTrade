using AstroTrade.Domain.SpaceTraders;
using Riok.Mapperly.Abstractions;
using SpaceTraders.Api;

namespace AstroTrade.Infrastructure.Mappers;

[Mapper]
internal static partial class StatusMapper
{
    [MapperIgnoreSource(nameof(GetResponse.AdditionalData))]
    public static partial SpaceTradersStatus ToSpaceTradersStatus(this GetResponse getResponse);
}
