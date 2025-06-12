using System.Threading.Tasks;

using AstroTrade.Core.Features.Agents.Register;

using Mediator;

namespace AstroTrade.Commands;

public class MyCommands([FromServices] ILogger<MyCommands> logger, IService service, IOptions<CliConfig> options, IMediator mediator)
{
    private readonly CliConfig config = options.Value;
    private readonly IMediator _mediator = mediator;

    /// <summary>Display message.</summary>
    /// <param name="msg">Message to show.</param>
    public void Echo(string msg)
    {
        logger.LogInformation("Hello from logger");
        service.DoSomething();
        Console.WriteLine(msg);
    }

    /// <summary>Sum parameters.</summary>
    /// <param name="x">left value.</param>
    /// <param name="y">right value.</param>
    public void Sum(int x, int y) => Console.WriteLine(x + y);

    [Command("config")]
    public async Task Config()
    {
        var command = new RegisterAgentCommand("TEST123", "aegis");
        var newAgent = await _mediator.Send(command);
        var opts = options;
        logger.LogInformation("Displaying IOptions wrapped config");

        var text = JsonSerializer.Serialize(config, typeof(CliConfig), CliConfigContext.Default);

        Console.WriteLine(text);
    }
}