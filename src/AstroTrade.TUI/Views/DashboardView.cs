using AstroTrade.TUI.Navigation;
using Terminal.Gui.ViewBase;
using Terminal.Gui.Views;

namespace AstroTrade.TUI.Views;

public class DashboardView : BaseScreenView
{
    public override string Title => "Dashboard";

    public DashboardView()
    {
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
                    new MenuItemv2("_Ships", "", () => HandleMenuAction("ships")),
                    new MenuItemv2("_Markets", "", () => HandleMenuAction("markets")),
                    new MenuItemv2("_Contracts", "", () => HandleMenuAction("contracts")),
                    new MenuItemv2("_Systems", "", () => HandleMenuAction("systems")),
                ]
            ),
        };
    }

    public override void HandleMenuAction(string action)
    {
        // For now, just show a message - will be replaced with actual navigation
        var message = action switch
        {
            "ships" => "Ships screen not implemented yet",
            "markets" => "Markets screen not implemented yet",
            "contracts" => "Contracts screen not implemented yet",
            "systems" => "Systems screen not implemented yet",
            _ => $"Unknown action: {action}",
        };

        MessageBox.Query("Navigation", message, "OK");
    }
}
