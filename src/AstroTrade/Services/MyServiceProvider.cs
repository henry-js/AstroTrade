using Serilog.Templates;

namespace AstroTrade.Services;

public static class MyServiceProvider
{
    public static IConfiguration CreateConfiguration()
        => new ConfigurationBuilder()
            .AddJsonFile("./config.json", false)
            .Build();

    public static void ConfigureSerilog(ILoggingBuilder builder)
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

    // private static IConfigureOptions<CliConfig> BindCliConfig(IConfiguration configuration)
    //     => IOptionsModule
    //         .Configure<CliConfig>(config => configuration.Bind("Config", config));
}
