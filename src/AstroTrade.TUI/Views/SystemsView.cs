using Terminal.Gui.ViewBase;
using Terminal.Gui.Views;

namespace AstroTrade.TUI.Views;

public class SystemsView : BaseScreenView
{
    public override string Title => "Systems";

    public SystemsView()
    {
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
                    new MenuItemv2("_Explore Waypoints", "", () => HandleMenuAction("explore")),
                    new MenuItemv2("_Jump Gates", "", () => HandleMenuAction("jump")),
                    new MenuItemv2("_View Map", "", () => HandleMenuAction("map")),
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
            "explore" => "Waypoint exploration not implemented yet",
            "jump" => "Jump gate navigation not implemented yet",
            "map" => "System map not implemented yet",
            "back" => "Back navigation not implemented yet",
            _ => $"Unknown action: {action}",
        };

        MessageBox.Query("Systems", message, "OK");
    }
}
