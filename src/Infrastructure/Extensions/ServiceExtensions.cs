using AstroTrade.Application;
using AstroTrade.Infrastructure.Configuration;
using AstroTrade.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SpaceTraders.Api;

namespace AstroTrade.Infrastructure.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddSpaceTraders(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddKiotaHandlers();
        services.AddHttpClient<SpaceTradersClientFactory>((sp, client) =>
        {
            client.BaseAddress = new Uri("https://api.spacetraders.io/v2");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
        }).AttachKiotaHandlers();

        services.AddTransient(sp =>
            sp.GetRequiredService<SpaceTradersClientFactory>().GetClient(configuration["SpaceTraders:AccessToken"]));

        services.AddTransient<ISpaceTradersService, SpaceTradersService>();

        return services;
    }

    public static IConfigurationBuilder AddSpaceTradersConfiguration(this IConfigurationBuilder builder)
    {
        ConfigHelper.CreateConfigFile();
        builder.AddJsonFile(ConfigHelper.ConfigFilePath, false);
        return builder;
    }
}
