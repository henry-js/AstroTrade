using AstroTrade.TUI;
using AstroTrade.TUI.Commands;
using AstroTrade.TUI.DependencyInjection;
using AstroTrade.TUI.Filters;
using AstroTrade.TUI.Views;
using ConsoleAppFramework;
using DotNetPathUtils;
using Microsoft.Extensions.DependencyInjection;
using Terminal.Gui.App;
using Velopack;

if (OperatingSystem.IsWindows())
{
    var appDirectory = Path.GetDirectoryName(AppContext.BaseDirectory)!;
    var pathHelper = new PathEnvironmentHelper(new PathUtilsOptions() { PrefixWithPeriod = false });
    VelopackApp
        .Build()
        .OnAfterInstallFastCallback(v => pathHelper.EnsureDirectoryIsInPath(appDirectory))
        .OnBeforeUninstallFastCallback(v => pathHelper.RemoveDirectoryFromPath(appDirectory!))
        .Run();
}

AppInitializer.Initialize();

var services = new ServiceCollection();

services.AddProjectServices();

var provider = services.BuildServiceProvider();
Application.Init();
Application.Run(provider.GetRequiredService<ShellView>());
Application.Top?.Dispose();
Application.Shutdown();

ConsoleApp.ServiceProvider = provider;

var app = ConsoleApp.Create();

app.Add<MyCommands>();

app.UseFilter<ExceptionFilter>();

await app.RunAsync(args);
