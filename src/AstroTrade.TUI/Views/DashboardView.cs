using AstroTrade.TUI.Navigation;
using Terminal.Gui.ViewBase;
using Terminal.Gui.Views;

namespace AstroTrade.TUI.Views;

public class DashboardView : BaseScreenView
{
    private readonly INavigationManager _navigationManager;

    public override string Title => "Dashboard";

    public DashboardView(INavigationManager navigationManager)
    {
        _navigationManager =
            navigationManager ?? throw new ArgumentNullException(nameof(navigationManager));

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
        return new List<MenuBarItemv2> { new($"_{Title}") };
    }
}
