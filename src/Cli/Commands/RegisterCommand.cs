using System.CommandLine;
using System.CommandLine.Invocation;
using AstroTrade.Domain;
using AstroTrade.Services;
using Microsoft.Extensions.Logging;

namespace AstroTrade.Cli.Commands;

public class RegisterCommand : Command
{
    public RegisterCommand() : base("register", "Authenticate with SpaceTraders API")
    {
        AddOptions(this);
    }

    private void AddOptions(Command command)
    {
        var quantityOption = new Option<int>(
            aliases: ["-q", "--quantity"]
        );
        command.AddOption(quantityOption);

        var factionArgument = new Argument<string>("FACTION", "The symbol of the faction");
        command.AddArgument(factionArgument);
        var symbolArgument = new Argument<string>("SYMBOL", "Your desired agent symbol");
        command.AddArgument(symbolArgument);
        var emailArgument = new Argument<string>("EMAIL", "Your email address, used if you reserved your call sign between resets");
        command.AddArgument(emailArgument);
    }

    new public class Handler(ISpaceTradersService service, ILogger<RegisterCommand> logger)
    : ICommandHandler
    {
        public string Faction { get; set; }
        public string Symbol { get; set; }
        public string Email { get; set; }
        private readonly ISpaceTradersService service = service;
        private readonly ILogger<RegisterCommand> logger = logger;

        public int Quantity { get; set; }
        public int Invoke(InvocationContext context)
        {
            return InvokeAsync(context).Result;
        }

        public async Task<int> InvokeAsync(InvocationContext context)
        {
            var result = service.RegisterSpaceTrader(Faction, Symbol, Email);
            return 0;
        }
    }
}
