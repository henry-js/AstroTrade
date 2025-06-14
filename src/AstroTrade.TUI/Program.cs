#if DEBUG
#else
using AstroTrade;
using Velopack;

VelopackApp.Build().Run();

SetupHelper.EnsureUserConfigFileExists();
SetupHelper.EnsureCurrentApplicationDirectoryIsInPath();
#endif

using AstroTrade.TUI.Views;

using Microsoft.Extensions.DependencyInjection;

using Terminal.Gui.App;

var configuration = Extensions.CreateConfiguration();
var services = new ServiceCollection();
services.AddLogging(Extensions.ConfigureSerilog);
services.AddProjectServices(configuration);

var provider = services.BuildServiceProvider();
Application.Init();
Application.Run(provider.GetRequiredService<ShellView>());
Application.Top?.Dispose();
Application.Shutdown();

// var app = ConsoleApp.Create()
//     .ConfigureLogging(builder => builder.ConfigureSerilog())
//     .ConfigureServices(services =>
//     {
//         var configuration = Extensions.CreateConfiguration();
//         services.AddProjectServices(configuration);
//     });

// app.Add<MyCommands>();

// app.UseFilter<ExceptionFilter>();

// await app.RunAsync(args);