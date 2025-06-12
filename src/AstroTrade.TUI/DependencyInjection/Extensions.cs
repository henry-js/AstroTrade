using AstroTrade.Core.Abstractions;
using AstroTrade.Core.Security;
using AstroTrade.Infrastructure.Persistence;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Microsoft.Kiota.Serialization.Json;

using Serilog.Templates;

using SpaceTraders.Api;

namespace AstroTrade.TUI.DependencyInjection;

public static class Extensions
{
    public static IConfiguration CreateConfiguration()
        => new ConfigurationBuilder()
            .AddJsonFile("./config.json", false)
            .Build();

    public static void ConfigureSerilog(this ILoggingBuilder builder)
    {
        builder.AddSerilog(
                   new LoggerConfiguration()
                           .WriteTo.File(
                               formatter: new ExpressionTemplate(
                                   "[{@t:HH:mm:ss} {@l:u3}] {@m}\n{@x}"),
                                   Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs", "app-.log"),
                               shared: true,
                               rollingInterval: RollingInterval.Day)
                           .Enrich.WithProperty("Application Name", "<APP NAME>")
                       .WriteTo.Console(theme: AnsiConsoleTheme.Sixteen)
                       .CreateLogger());
    }

    public static void AddProjectServices(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddSingleton(configuration)
            .Configure<SpaceTradersConfiguration>(configuration.GetSection(nameof(SpaceTradersConfiguration)))
            .AddSingleton<MyCommands>()
            .AddSingleton<ITokenRepository, FileTokenRepository>()
            .AddMediator(options => options.Assemblies = [typeof(Core.AssemblyMarker).Assembly]);

        services.AddKiotaClientServices();
    }

    public static void AddKiotaClientServices(this IServiceCollection services)
    {
        ApiClientBuilder.RegisterDefaultSerializer<JsonSerializationWriterFactory>();
        ApiClientBuilder.RegisterDefaultDeserializer<JsonParseNodeFactory>();

        services
            .AddSingleton<IAccessTokenProvider, BearerTokenProvider>()
            .AddSingleton<IAuthenticationProvider, BaseBearerTokenAuthenticationProvider>()
            .AddHttpClient()
            .AddSingleton<IRequestAdapter>(sp =>
            {
                var authProvider = sp.GetRequiredService<IAuthenticationProvider>();
                var httpClientFactory = sp.GetRequiredService<IHttpClientFactory>();
                var httpClient = httpClientFactory.CreateClient("SpaceTradersApiClient");

                return new HttpClientRequestAdapter(authProvider, httpClient: httpClient);
            });
        services.AddTransient<ApiClient>();
    }
}
