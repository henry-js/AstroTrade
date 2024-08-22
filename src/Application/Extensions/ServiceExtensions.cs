using AstroTrade.Application.Services;
using AstroTrade.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SpaceTraders.Api;

namespace Application.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddSpaceTradersApi(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddKiotaHandlers();
        services.AddHttpClient<SpaceTradersClientFactory>((sp, client) =>
        {
            client.BaseAddress = new Uri("https://api.spacetraders.io/v2");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
        }).AttachKiotaHandlers();

        services.AddTransient(sp =>
            sp.GetRequiredService<SpaceTradersClientFactory>().GetClient(configuration["SpaceTraders:AccessToken"]));

        // services.AddSingleton(sp => new FlurlClientCache()
        // .Add(nameof(SpaceTradersApi), SpaceTradersApi.BaseUrl, builder => builder
        //     .WithHeaders(new
        //     {
        //         Content_Type = "application/json",
        //         Accept = "application/json"
        //     }))
        // );

        services.AddSingleton<ISpaceTradersService, SpaceTradersService>();

        return services;
    }
}
