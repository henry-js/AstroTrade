using AstroTrade.Core.Abstractions;
using AstroTrade.Core.Features.Dashboard;
using AstroTrade.TUI.Navigation;
using Terminal.Gui.ViewBase;
using Terminal.Gui.Views;

namespace AstroTrade.TUI.Views;

public class DashboardView : BaseScreenView
{
    private readonly INavigationManager _navigationManager;

    public override string Title => "Dashboard";

    public DashboardView(DashboardViewModel viewModel, INavigationManager navigationManager)
    {
        ViewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        _navigationManager =
            navigationManager ?? throw new ArgumentNullException(nameof(navigationManager));

        viewModel.NavigationRequested += OnNavigationRequested;

        // Initialize dashboard layout
        var label = new Label()
        {
            Text = "Dashboard Screen - Coming Soon",
            X = Pos.Center(),
            Y = Pos.Center(),
        };
        Add(label);
    }

    private void OnNavigationRequested(object? sender, NavigationEventArgs e)
    {
        switch (e.Target)
        {
            case "ships":
                _navigationManager.NavigateTo<ShipsView>();
                break;
            case "markets":
                _navigationManager.NavigateTo<MarketsView>();
                break;
            case "contracts":
                _navigationManager.NavigateTo<ContractsView>();
                break;
            case "systems":
                _navigationManager.NavigateTo<SystemsView>();
                break;
        }
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
