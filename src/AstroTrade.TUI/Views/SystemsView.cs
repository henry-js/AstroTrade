using AstroTrade.Core.Features.Systems;
using Terminal.Gui.ViewBase;
using Terminal.Gui.Views;

namespace AstroTrade.TUI.Views;

public class SystemsView : BaseScreenView
{
    public override string Title => "Systems";

    public SystemsView(SystemsViewModel viewModel)
    {
        ViewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));

        // Initialize systems layout
        var label = new Label()
        {
            Text = "System Exploration - Coming Soon",
            X = Pos.Center(),
            Y = Pos.Center(),
        };
        Add(label);
    }

    public override IEnumerable<MenuBarItemv2> GetMenuItems()
    {
        return new List<MenuBarItemv2>
        {
            new(
                "_Systems",
                [
                    new MenuItemv2(
                        "_Explore Waypoints",
                        "",
                        () => (ViewModel as SystemsViewModel)?.ExploreWaypointsCommand.Execute(null)
                    ),
                    new MenuItemv2(
                        "_Jump Gates",
                        "",
                        () => (ViewModel as SystemsViewModel)?.JumpGatesCommand.Execute(null)
                    ),
                    new MenuItemv2(
                        "_View Map",
                        "",
                        () => (ViewModel as SystemsViewModel)?.ViewMapCommand.Execute(null)
                    ),
                    new MenuItemv2(
                        "_Back to Dashboard",
                        "",
                        () =>
                            (ViewModel as SystemsViewModel)?.NavigateToDashboardCommand.Execute(
                                null
                            )
                    ),
                ]
            ),
        };
    }
}
