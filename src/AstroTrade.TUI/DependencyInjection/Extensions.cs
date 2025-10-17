using System.Linq;
using AstroTrade.Core.Abstractions;
using AstroTrade.Core.Features.Contracts;
using AstroTrade.Core.Features.Dashboard;
using AstroTrade.Core.Features.Markets;
using AstroTrade.Core.Features.Shell;
using AstroTrade.Core.Features.Ships;
using AstroTrade.Core.Features.Systems;
using AstroTrade.Core.Security;
using AstroTrade.Core.Services;
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

        var config = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.File(
                formatter: new MessageTemplateTextFormatter(outputTemplate),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs", "app-.log"),
                restrictedToMinimumLevel: LogEventLevel.Debug,
                shared: true,
                rollingInterval: RollingInterval.Day
            )
            .Enrich.WithProperty("ApplicationName", "AstroTrade")
            .Enrich.With<SourceClassEnricher>();

        // Enable console logging in Development
        var environment =
            Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT")
            ?? Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
            ?? "Production";

        if (environment == "Development")
        {
            config.WriteTo.Console(
                outputTemplate: outputTemplate,
                theme: AnsiConsoleTheme.Sixteen,
                restrictedToMinimumLevel: LogEventLevel.Information
            );
        }

        builder.AddSerilog(config.CreateLogger());
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
                AppConstants.DataDirectory,
                sp.GetRequiredService<ILogger<FileTokenRepository>>()
            ))
            .AddSingleton<ICurrentAgentService, CurrentAgentService>()
            .AddSingleton<
                AstroTrade.Core.Abstractions.ICorrelationContext,
                AstroTrade.Core.Services.CorrelationContext
            >()
            .AddMediator(options => options.Assemblies = [typeof(Core.AssemblyMarker).Assembly]);

        services.AddKiotaClientServices();
        services.AddTUIViews();

        // Emit startup-level logs (configuration loaded, service registration summary)
        // We build a short-lived ServiceProvider here to obtain an ILoggerFactory that
        // is already configured by the previous AddLogging call. This is intentional
        // for early startup observability.
        using (var sp = services.BuildServiceProvider())
        {
            var loggerFactory = sp.GetRequiredService<ILoggerFactory>();
            var logger = loggerFactory.CreateLogger("Startup");
            var env =
                Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT")
                ?? Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
                ?? "Production";

            StartupLog.ApplicationStarting(logger, env);

            var providerCount = (configuration as IConfigurationRoot)?.Providers?.Count() ?? 1;
            StartupLog.ConfigurationLoaded(logger, providerCount);

            StartupLog.ServiceRegistrationSummary(logger, services.Count);
        }
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
