// using System.CommandLine;
// using System.CommandLine.Invocation;

// namespace AstroTrade.Cli.Commands;

// public class AuthCommand : Command
// {
//     public AuthCommand() : base("auth", "Authenticate with SpaceTraders API")
//     {
//         AddOptions(this);
//     }

//     private void AddOptions(Command command)
//     {
//         var quantityOption = new Option<int>(
//             aliases: ["-q", "--quantity"]
//         );
//         command.AddOption(quantityOption);
//     }

//     new public class Handler()
//     : ICommandHandler
//     {
//         public int Quantity { get; set; }
//         public int Invoke(InvocationContext context)
//         {
//             return InvokeAsync(context).Result;
//         }

//         public async Task<int> InvokeAsync(InvocationContext context)
//         {
//             return 0;
//         }
//     }
// }
