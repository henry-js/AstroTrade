#if DEBUG
#else
using AstroTrade;
using Velopack;

VelopackApp.Build().Run();

SetupHelper.EnsureUserConfigFileExists();
SetupHelper.EnsureCurrentApplicationDirectoryIsInPath();
#endif

var app = ConsoleApp.Create()
    .ConfigureLogging(builder => builder.ConfigureSerilog())
    .ConfigureServices(services =>
    {
        var configuration = Extensions.CreateConfiguration();
        services.AddProjectServices(configuration);
    });

app.Add<MyCommands>();

app.UseFilter<ExceptionFilter>();

await app.RunAsync(args);

Console.ReadLine();
