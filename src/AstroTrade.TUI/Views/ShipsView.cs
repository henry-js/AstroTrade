using AstroTrade.Core.Features.Ships;
using Terminal.Gui.ViewBase;
using Terminal.Gui.Views;

namespace AstroTrade.TUI.Views;

public class ShipsView : BaseScreenView
{
    public override string Title => "Ships";

    public ShipsView(ShipsViewModel viewModel)
    {
        ViewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));

        // Initialize ships layout
        var label = new Label()
        {
            Text = "Ships Management - Coming Soon",
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
                "_Fleet",
                [
                    new MenuItemv2(
                        "_Purchase Ship",
                        "",
                        () => (ViewModel as ShipsViewModel)?.PurchaseShipCommand.Execute(null)
                    ),
                    new MenuItemv2(
                        "_View Cargo",
                        "",
                        () => (ViewModel as ShipsViewModel)?.ViewCargoCommand.Execute(null)
                    ),
                    new MenuItemv2(
                        "_Navigate",
                        "",
                        () => (ViewModel as ShipsViewModel)?.NavigateShipCommand.Execute(null)
                    ),
                    new MenuItemv2(
                        "_Back to Dashboard",
                        "",
                        () =>
                            (ViewModel as ShipsViewModel)?.NavigateToDashboardCommand.Execute(null)
                    ),
                ]
            ),
        };
    }
}
