using AstroTrade.Services;
using Microsoft.Extensions.DependencyInjection;
using AstroTrade.Application.Services;
using Flurl.Http.Configuration;
using Flurl.Http;

namespace AstroTrade.Application;

public static class ServiceExtensions
{
    public static IServiceCollection AddSpaceTradersApi(this IServiceCollection services)
    {
        services.AddSingleton(sp => new FlurlClientCache()
        .Add(nameof(SpaceTradersApi), SpaceTradersApi.BaseUrl, builder => builder
            .WithHeaders(new
            {
                Content_Type = "application/json",
                Accept = "application/json"
            }))
        );

        services.AddSingleton<ISpaceTradersService, SpaceTradersService>();
        return services;
    }
}

internal static class SpaceTradersApi
{
    public const string BaseUrl = "https://api.spacetraders.io/v2";
}
