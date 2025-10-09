using AstroTrade.TUI.Navigation;
using Terminal.Gui.ViewBase;
using Terminal.Gui.Views;

namespace AstroTrade.TUI.Views;

public abstract class BaseScreenView : View, IScreenView
{
    public abstract string Title { get; }

    public virtual object? ViewModel { get; protected set; }

    public virtual IEnumerable<MenuBarItemv2> GetMenuItems() => [];

    public virtual void HandleMenuAction(string action)
    {
        // Default: do nothing
    }

    public virtual void OnActivated()
    {
        // Default: focus this view
        SetFocus();
    }

    public virtual void OnDeactivated()
    {
        // Default: do nothing
    }
}
