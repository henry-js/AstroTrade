using AstroTrade.Services;
using Microsoft.Extensions.Logging;
using System.CommandLine;
using System.CommandLine.Invocation;

namespace AstroTrade.Cli.Commands;

internal class StatusCommand : Command
{
    public StatusCommand()
        : base("status", "Get status of space traders API")
    {

    }

    new public class Handler(ISpaceTradersService service, ILogger<StatusCommand> logger)
        : ICommandHandler
    {
        public int Invoke(InvocationContext context) => InvokeAsync(context).Result;

        public async Task<int> InvokeAsync(InvocationContext context)
        {
            var response = await service.GetSpaceTradersStatus();
            return 0;
        }
    }
}
