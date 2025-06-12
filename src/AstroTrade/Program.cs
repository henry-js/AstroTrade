using AstroTrade.Core.Abstractions;
using AstroTrade.Infrastructure.Persistence;

using Microsoft.Extensions.DependencyInjection;

using SpaceTraders.Api;
#if DEBUG
#else
using AstroTrade;
using Velopack;

VelopackApp.Build().Run();

SetupHelper.EnsureUserConfigFileExists();
SetupHelper.EnsureCurrentApplicationDirectoryIsInPath();
#endif

// MyServiceProvider sp = new();

// ConsoleApp.ServiceProvider = sp;

var configuration = MyServiceProvider.CreateConfiguration();
var app = ConsoleApp.Create()
    .ConfigureLogging(MyServiceProvider.ConfigureSerilog)
    .ConfigureServices(services =>
    {
        var accountToken = configuration["SpaceTraders:AccountToken"];
        services
            .AddSingleton(configuration)
            .Configure<CliConfig>(configuration.GetSection(nameof(CliConfig)))
            .AddSingleton<IService, ServiceImplementation>()
            .AddSingleton<MyCommands>()
            .AddSingleton<ITokenRepository, FileTokenRepository>()
            .AddMediator(options =>
            {
                options.Assemblies = [typeof(AstroTrade.Core.AssemblyMarker).Assembly];
            })
            .AddKiotaHandlers()
            .AddHttpClient<ApiClientFactory>((sp, client) => { })
            .AttachKiotaHandlers()
            .Services
            .AddTransient(sp => sp.GetRequiredService<ApiClientFactory>().GetClient(accountToken));
    }

    );
app.Add<MyCommands>();

app.UseFilter<ExceptionFilter>();

await app.RunAsync(args);

Console.ReadLine();