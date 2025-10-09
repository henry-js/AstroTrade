using Terminal.Gui.Views;

namespace AstroTrade.TUI.Navigation;

public interface INavigationManager
{
    IScreenView? CurrentScreen { get; }
    event EventHandler<ScreenChangedEventArgs>? ScreenChanged;
    void NavigateTo<TScreen>()
        where TScreen : IScreenView;
    void NavigateTo(Type screenType);
}

public class ScreenChangedEventArgs : EventArgs
{
    public IScreenView? PreviousScreen { get; }
    public IScreenView? NewScreen { get; }

    public ScreenChangedEventArgs(IScreenView? previous, IScreenView? newScreen)
    {
        PreviousScreen = previous;
        NewScreen = newScreen;
    }
}

public interface IScreenView
{
    string Title { get; }
    object? ViewModel { get; }
    IEnumerable<MenuBarItemv2> GetMenuItems();
    void HandleMenuAction(string action);
    void OnActivated(); // Called when screen becomes active
    void OnDeactivated(); // Called when screen becomes inactive
}
