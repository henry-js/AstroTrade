using Terminal.Gui.ViewBase;
using Terminal.Gui.Views;

namespace AstroTrade.TUI.Views;

public class ContractsView : BaseScreenView
{
    public override string Title => "Contracts";

    public ContractsView()
    {
        // Initialize contracts layout
        var label = new Label()
        {
            Text = "Contract Management - Coming Soon",
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
                "_Contracts",
                [
                    new MenuItemv2("_Accept Contract", "", () => HandleMenuAction("accept")),
                    new MenuItemv2("_Deliver Goods", "", () => HandleMenuAction("deliver")),
                    new MenuItemv2("_Fulfill Contract", "", () => HandleMenuAction("fulfill")),
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
            "accept" => "Accept contract not implemented yet",
            "deliver" => "Deliver goods not implemented yet",
            "fulfill" => "Fulfill contract not implemented yet",
            "back" => "Back navigation not implemented yet",
            _ => $"Unknown action: {action}",
        };

        MessageBox.Query("Contracts", message, "OK");
    }
}
