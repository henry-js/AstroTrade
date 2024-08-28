﻿using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Hosting;
using System.CommandLine.Parsing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Spectre.Console;
using Velopack;
using AstroTrade.Cli.Commands;
using AstroTrade.Infrastructure.Configuration;
using AstroTrade.Infrastructure.Extensions;
using Cli.Commands;

var loggerConfiguration = new LoggerConfiguration()
    .MinimumLevel.Debug()
            .WriteTo.File(path: "logs/startup_.log",
            outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u}] {SourceContext}: {Message:lj}{NewLine}{Exception}",
            rollingInterval: RollingInterval.Day)
            .Enrich.WithProperty("Application Name", "AstroTrade");
Log.Logger = loggerConfiguration.CreateBootstrapLogger();

ConfigHelper.CreateConfigFile();
ConfigHelper.AddCliToPath();

VelopackApp.Build()
.WithFirstRun(v => { }).Run();

// services.AddScoped<BogusCommand>();

var rootCommand = new RootCommand("astrade");
var authBranch = new Command("auth", "Authenication commands");
rootCommand.AddCommand(authBranch);
authBranch.AddCommand(new RegisterCommand());
rootCommand.AddCommand(new StatusCommand());

// var getBranch = new Command("get", "get information from SpaceTraders");
rootCommand.AddCommand(new GetCommand());

var cmdLineBuilder = new CommandLineBuilder(rootCommand);
int result = 0;

var parser = cmdLineBuilder
    .UseHost(_ => Host.CreateDefaultBuilder(args), builder =>
    {
        builder.ConfigureAppConfiguration(builder => builder.AddSpaceTradersConfiguration());
        builder.ConfigureServices(ConfigureServices)
        .UseCommandHandler<RegisterCommand, RegisterCommand.Handler>()
        .UseCommandHandler<StatusCommand, StatusCommand.Handler>()
        .UseCommandHandler<GetCommand, GetCommand.Handler>()
        .UseConsoleLifetime();

        builder.UseSerilog((context, services, configuration) =>
        configuration.ReadFrom.Configuration(context.Configuration));
    })
    .UseDefaults()
    .UseExceptionHandler((ex, context) =>
    {
        AnsiConsole.WriteException(ex, ExceptionFormats.ShortenTypes | ExceptionFormats.NoStackTrace);
        Log.Fatal(ex, "Application terminated unexpectedly");
    }).Build();

static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
{
    services.AddSingleton(_ => AnsiConsole.Console);
    services.AddSingleton(TimeProvider.System);
    services.AddSpaceTraders(context.Configuration);
}
result = await parser.InvokeAsync(args);

#if DEBUG
Console.WriteLine();
Console.WriteLine("Press any key to exit.");
System.Console.ReadKey(intercept: true);
#endif

return result;
