using AstroTrade.Application;
using AstroTrade.Domain.SpaceTraders;
using AstroTrade.Infrastructure.Configuration;

namespace AstroTrade.Cli.Commands;

public class RegisterCommand : Command
{
    public RegisterCommand() : base("register", "Authenticate with SpaceTraders API")
    {
        AddOptions(this);
    }

    private void AddOptions(Command command)
    {
        var factionArgument = new Argument<FactionSymbol>("FACTION", "The symbol of the faction");
        command.AddArgument(factionArgument);
        var symbolArgument = new Argument<string>("SYMBOL", "Your desired agent symbol");
        command.AddArgument(symbolArgument);
        var emailArgument = new Argument<string?>(
            name: "EMAIL",
            description: "Your email address, used if you reserved your call sign between resets",
            getDefaultValue: () => null);
        command.AddArgument(emailArgument);
    }

    new public class Handler(IAnsiConsole console, ISpaceTradersApiService service, ILogger<RegisterCommand> logger)
    : ICommandHandler
    {
        public FactionSymbol Faction { get; set; }
        public string Symbol { get; set; }
        public string? Email { get; set; }
        private readonly ISpaceTradersApiService service = service;
        private readonly ILogger<RegisterCommand> logger = logger;

        public int Quantity { get; set; }
        public int Invoke(InvocationContext context)
        {
            return InvokeAsync(context).Result;
        }

        public async Task<int> InvokeAsync(InvocationContext context)
        {
            RegistrationRequest request = new()
            {
                Symbol = Symbol,
                Faction = Faction,
                Email = string.Empty
            };

            var response = await service.RegisterSpaceTrader(request);

            if (response.IsFailure)
            {
                console.WriteException(response.Exception);
                return -1;
            }
            ConfigHelper.SaveAccessToken(response.Value.Token);
            console.WriteLine(JsonSerializer.Serialize(response.Value));
            return 0;
        }
    }
}
