using AstroTrade.Core.Abstractions;
using AstroTrade.Core.Services;
using AstroTrade.Core.Features.Contracts;
using AstroTrade.Core.Features.Dashboard;
using AstroTrade.Core.Features.Markets;
using AstroTrade.Core.Features.Shell;
using AstroTrade.Core.Features.Ships;
using AstroTrade.Core.Features.Systems;
using AstroTrade.Core.Security;
using AstroTrade.Infrastructure.Persistence;
using AstroTrade.TUI.Commands;
using AstroTrade.TUI.Configuration;
using AstroTrade.TUI.Logging;
using AstroTrade.TUI.Navigation;
using AstroTrade.TUI.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Microsoft.Kiota.Serialization.Json;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Display;
using Serilog.Sinks.SystemConsole.Themes;
using SpaceTraders.Api;

namespace AstroTrade.TUI.DependencyInjection;

public static class Extensions
{
    public static IConfiguration CreateConfiguration()
    {
        var configBuilder = new ConfigurationBuilder()
            .AddJsonFile("config.json", optional: false, reloadOnChange: true)
            .AddUserSecrets(typeof(Program).Assembly);

        return configBuilder.Build();
    }

    public static void ConfigureSerilog(this ILoggingBuilder builder)
    {
        const string outputTemplate =
            "[{Timestamp:HH:mm:ss} {Level:u3}] ({SourceClass}) {Message:lj}{NewLine}{Exception}";
        builder.AddSerilog(
            new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File(
                    formatter: new MessageTemplateTextFormatter(outputTemplate),
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs", "app-.log"),
                    restrictedToMinimumLevel: LogEventLevel.Debug,
                    shared: true,
                    rollingInterval: RollingInterval.Day
                )
                .Enrich.WithProperty("ApplicationName", "<APP NAME>")
                .Enrich.With<SourceClassEnricher>()
                // .WriteTo.Console(
                //     outputTemplate: outputTemplate,
                //     theme: AnsiConsoleTheme.Sixteen,
                //     restrictedToMinimumLevel: LogEventLevel.Information
                // )
                .CreateLogger()
        );
    }

    public static void AddProjectServices(this IServiceCollection services)
    {
        var configuration = CreateConfiguration();
        services
            .AddSingleton(configuration)
            .AddLogging(ConfigureSerilog)
            .Configure<SpaceTradersConfiguration>(
                configuration.GetSection(nameof(SpaceTradersConfiguration))
            )
            .AddSingleton<MyCommands>()
            .AddSingleton<ITokenRepository>(sp => new FileTokenRepository(
                AppConstants.DataDirectory
            ))
            .AddSingleton<ICurrentAgentService, CurrentAgentService>()
            .AddMediator(options => options.Assemblies = [typeof(Core.AssemblyMarker).Assembly]);

        services.AddKiotaClientServices();
        services.AddTUIViews();
    }

    private static void AddTUIViews(this IServiceCollection services)
    {
        services.AddSingleton<INavigationManager, NavigationManager>();
        services.AddTransient<ShellView>();
        services.AddTransient<ShellViewModel>();
        services.AddTransient<DashboardView>();
        services.AddTransient<DashboardViewModel>();
        services.AddTransient<ShipsView>();
        services.AddTransient<ShipsViewModel>();
        services.AddTransient<MarketsView>();
        services.AddTransient<MarketsViewModel>();
        services.AddTransient<ContractsView>();
        services.AddTransient<ContractsViewModel>();
        services.AddTransient<SystemsView>();
        services.AddTransient<SystemsViewModel>();
        services.AddTransient<ContractsListView>();
        services.AddTransient<FleetOverviewView>();
    }

    private static void AddKiotaClientServices(this IServiceCollection services)
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
