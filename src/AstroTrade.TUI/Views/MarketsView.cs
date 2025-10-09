using AstroTrade.Core.Features.Markets;
using Terminal.Gui.ViewBase;
using Terminal.Gui.Views;

namespace AstroTrade.TUI.Views;

public class MarketsView : BaseScreenView
{
    public override string Title => "Markets";

    public MarketsView(MarketsViewModel viewModel)
    {
        ViewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));

        // Initialize markets layout
        var label = new Label()
        {
            Text = "Market Trading - Coming Soon",
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
