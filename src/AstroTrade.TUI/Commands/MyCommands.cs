using System.Text.Json;
using AstroTrade.Core.Features.Agents.Register;
using AstroTrade.TUI.Configuration;
using ConsoleAppFramework;
using Mediator;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AstroTrade.TUI.Commands;

public class MyCommands(
    [FromServices] ILogger<MyCommands> logger,
    IOptions<SpaceTradersConfiguration> options,
    IMediator mediator,
    IConfiguration configuration
)
{
    private readonly SpaceTradersConfiguration config = options.Value;
    private readonly IMediator _mediator = mediator;
    private readonly IConfiguration _configuration = configuration;

    [Command("config")]
    public async Task Config()
    {
        var command = new RegisterAgentCommand(
            "TESTABC",
            "aegis",
            _configuration["SpaceTraders:AccountToken"] ?? throw new Exception()
        );
        var newAgent = await _mediator.Send(command);
        var opts = options;
        logger.LogInformation("Displaying IOptions wrapped config");

        var text = JsonSerializer.Serialize(
            config,
            typeof(SpaceTradersConfiguration),
            SpaceTradersConfigurationContext.Default
        );

        Console.WriteLine(text);
    }
}
