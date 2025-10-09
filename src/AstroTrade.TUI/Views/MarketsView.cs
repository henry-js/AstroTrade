using Terminal.Gui.ViewBase;
using Terminal.Gui.Views;

namespace AstroTrade.TUI.Views;

public class MarketsView : BaseScreenView
{
    public override string Title => "Markets";

    public MarketsView()
    {
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
                    new MenuItemv2("_Buy Goods", "", () => HandleMenuAction("buy")),
                    new MenuItemv2("_Sell Goods", "", () => HandleMenuAction("sell")),
                    new MenuItemv2("_View Prices", "", () => HandleMenuAction("prices")),
                    new MenuItemv2("_Back to Dashboard", "", () => HandleMenuAction("back")),
                ]
            ),
        };
    }

    public override void HandleMenuAction(string action)
    {
        // For now, just show a message - will be replaced with actual functionality
        var message = action switch
        {
            "buy" => "Buy goods not implemented yet",
            "sell" => "Sell goods not implemented yet",
            "prices" => "Price view not implemented yet",
            "back" => "Back navigation not implemented yet",
            _ => $"Unknown action: {action}",
        };

        MessageBox.Query("Markets", message, "OK");
    }
}
