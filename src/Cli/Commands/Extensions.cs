using AstroTrade.Domain.SpaceTraders;
using Microsoft.Extensions.Hosting;
using System.CommandLine.Hosting;
using System.CommandLine.Parsing;
using System.Reflection;
using System.Windows.Input;

namespace AstroTrade.Cli.Commands;

static class Extensions
{
    public static Command AddBranch(this Command command, Func<Command> value)
    {
        command.AddCommand(value.Invoke());
        return command;
    }

    public static IHostBuilder RegisterCommandHandlers(this IHostBuilder builder)
    {
        var commands = typeof(Extensions).Assembly.GetTypes()
        .Where(t => t.DeclaringType != null && typeof(ICommandHandler).IsAssignableFrom(t) && t.DeclaringType.BaseType == typeof(Command));

        foreach (var command in commands)
        {
            builder.UseCommandHandler(command.DeclaringType, command);
        }

        return builder;
    }
}
