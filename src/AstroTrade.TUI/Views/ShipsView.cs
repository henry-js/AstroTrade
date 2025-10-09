using Terminal.Gui.ViewBase;
using Terminal.Gui.Views;

namespace AstroTrade.TUI.Views;

public class ShipsView : BaseScreenView
{
    public override string Title => "Ships";

    public ShipsView()
    {
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
                    new MenuItemv2("_Purchase Ship", "", () => HandleMenuAction("purchase")),
                    new MenuItemv2("_View Cargo", "", () => HandleMenuAction("cargo")),
                    new MenuItemv2("_Navigate", "", () => HandleMenuAction("navigate")),
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
            "purchase" => "Ship purchase not implemented yet",
            "cargo" => "Cargo view not implemented yet",
            "navigate" => "Navigation not implemented yet",
            "back" => "Back navigation not implemented yet",
            _ => $"Unknown action: {action}",
        };

        MessageBox.Query("Ships", message, "OK");
    }
}
