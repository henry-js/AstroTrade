using AstroTrade.Core.Abstractions;
using AstroTrade.Core.Features.Markets;
using AstroTrade.TUI.Navigation;
using Terminal.Gui.ViewBase;
using Terminal.Gui.Views;

namespace AstroTrade.TUI.Views;

public class MarketsView : BaseScreenView
{
    private readonly INavigationManager _navigationManager;

    public override string Title => "Markets";

    public MarketsView(MarketsViewModel viewModel, INavigationManager navigationManager)
    {
        ViewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        _navigationManager = navigationManager ?? throw new ArgumentNullException(nameof(navigationManager));

        viewModel.NavigationRequested += OnNavigationRequested;

        // Initialize markets layout
        var label = new Label()
        {
            Text = "Market Trading - Coming Soon",
            X = Pos.Center(),
            Y = Pos.Center(),
        };
        Add(label);
    }

    private void OnNavigationRequested(object? sender, NavigationEventArgs e)
    {
        switch (e.Target)
        {
            case "dashboard":
                _navigationManager.NavigateTo<DashboardView>();
                break;
        }
    }

    public override IEnumerable<MenuBarItemv2> GetMenuItems()
    {
        return new List<MenuBarItemv2>
        {
            new(
                "_Trade",
                [
                    new MenuItemv2(
                        "_Buy Goods",
                        "",
                        () => (ViewModel as MarketsViewModel)?.BuyGoodsCommand.Execute(null)
                    ),
                    new MenuItemv2(
                        "_Sell Goods",
                        "",
                        () => (ViewModel as MarketsViewModel)?.SellGoodsCommand.Execute(null)
                    ),
                    new MenuItemv2(
                        "_View Prices",
                        "",
                        () => (ViewModel as MarketsViewModel)?.ViewPricesCommand.Execute(null)
                    ),
                    new MenuItemv2(
                        "_Back to Dashboard",
                        "",
                        () =>
                            (ViewModel as MarketsViewModel)?.NavigateToDashboardCommand.Execute(
                                null
                            )
                    ),
                ]
            ),
        };
    }
}
