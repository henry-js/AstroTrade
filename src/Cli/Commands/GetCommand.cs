namespace AstroTrade.Cli.Commands;

public class GetCommand : Command
{
    public GetCommand() : base("get", "query SpaceTraders for info")
    {
        AddOptions(this);
    }

    private void AddOptions(Command command)
    {
        var entityArgument = new Argument<SpaceTradersEntity>("ENTITY", "Type of entity to query for");
        command.AddArgument(entityArgument);
    }

    new public class Handler : ICommandHandler
    {
        public int Invoke(InvocationContext context) => InvokeAsync(context).Result;

        public async Task<int> InvokeAsync(InvocationContext context)
        {
            throw new NotImplementedException();
        }
    }
}

internal enum SpaceTradersEntity
{
    me, ships, contracts, factions, system
}
