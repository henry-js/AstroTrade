using AstroTrade.Core.Features.Dashboard;
using Terminal.Gui.ViewBase;
using Terminal.Gui.Views;

namespace AstroTrade.TUI.Views;

public class DashboardView : BaseScreenView
{
    public override string Title => "Dashboard";

    public DashboardView(DashboardViewModel viewModel)
    {
        ViewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));

        // Initialize dashboard layout
        var label = new Label()
        {
            Text = "Dashboard Screen - Coming Soon",
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
                "_Game",
                [
                    new MenuItemv2(
                        "_Ships",
                        "",
                        () =>
                            (ViewModel as DashboardViewModel)?.NavigateToShipsCommand.Execute(null)
                    ),
                    new MenuItemv2(
                        "_Markets",
                        "",
                        () =>
                            (ViewModel as DashboardViewModel)?.NavigateToMarketsCommand.Execute(
                                null
                            )
                    ),
                    new MenuItemv2(
                        "_Contracts",
                        "",
                        () =>
                            (ViewModel as DashboardViewModel)?.NavigateToContractsCommand.Execute(
                                null
                            )
                    ),
                    new MenuItemv2(
                        "_Systems",
                        "",
                        () =>
                            (ViewModel as DashboardViewModel)?.NavigateToSystemsCommand.Execute(
                                null
                            )
                    ),
                ]
            ),
        };
    }
}
