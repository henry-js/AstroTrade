namespace AstroTrade.Cli.Commands;

static class Extensions
{
    public static Command AddBranch(this Command command, Func<Command> value)
    {
        command.AddCommand(value.Invoke());
        return command;
    }
}
