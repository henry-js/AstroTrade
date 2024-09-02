using AstroTrade.Application;

namespace AstroTrade.Cli.Commands;

internal class StatusCommand : Command
{
    public StatusCommand()
        : base("status", "Get status of space traders API")
    {

    }

    new public class Handler(IAnsiConsole console, ISpaceTradersApiService service, ILogger<StatusCommand> logger)
        : ICommandHandler
    {
        public int Invoke(InvocationContext context) => InvokeAsync(context).Result;

        public async Task<int> InvokeAsync(InvocationContext context)
        {
            var response = await service.GetSpaceTradersStatus();
            if (response.IsFailure)
            {
                console.MarkupLine(response.Exception.Message);
                return -1;
            }

            var status = response.Value;
            // Create the layout
            var layout = new Layout("Root")
                .SplitColumns(
                    new Layout("Left"),
                    new Layout("Right")
                        .SplitRows(
                            new Layout("Top"),
                            new Layout("Bottom")));

            // Update the left column
            layout["Left"].Update(
                new Panel(
                    Align.Center(
                        new Markup($"[blue]{status.Description}[/]"),
                        VerticalAlignment.Middle))
                    .Expand());

            var statsGrid = new Grid();
            statsGrid.AddRow(nameof(status.Stats.Agents), status.Stats.Agents.ToString());
            statsGrid.AddRow(nameof(status.Stats.Ships), status.Stats.Ships.ToString());
            statsGrid.AddRow(nameof(status.Stats.Systems), status.Stats.Systems.ToString());
            statsGrid.AddRow(nameof(status.Stats.Waypoints), status.Stats.Waypoints.ToString());
            layout["Right"]["Top"].Update(new Panel(
                Align.Center(
                    statsGrid
                )
            )
            { Header = new PanelHeader(nameof(status.Stats)) });

            // Render the layout
            console.Write(layout);

            return 0;
        }
    }
}
