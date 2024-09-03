using AstroTrade.Application;

namespace AstroTrade.Cli.Commands;

public class StartCommand : Command
{
    public StartCommand() : base("start", "Start SpaceTraders Menu System")
    {
        AddOptions(this);
    }

    private void AddOptions(StartCommand startCommand)
    {
    }

    new public class Handler(IAnsiConsole console, ISpaceTradersApiService service, ILogger<StartCommand> logger)
    : ICommandHandler
    {
        public int Invoke(InvocationContext context) => InvokeAsync(context).Result;

        public Task<int> InvokeAsync(InvocationContext context)
        {
            throw new NotImplementedException();
        }
    }
}
