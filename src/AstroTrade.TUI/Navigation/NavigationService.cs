using AstroTrade.Core.Abstractions;
using AstroTrade.TUI.Views;

namespace AstroTrade.TUI.Navigation;

public class NavigationService : INavigationService
{
    private readonly INavigationManager _navigationManager;

    public NavigationService(INavigationManager navigationManager)
    {
        _navigationManager =
            navigationManager ?? throw new ArgumentNullException(nameof(navigationManager));
    }

    public void NavigateToShips()
    {
        _navigationManager.NavigateTo<ShipsView>();
    }

    public void NavigateToMarkets()
    {
        _navigationManager.NavigateTo<MarketsView>();
    }

    public void NavigateToContracts()
    {
        _navigationManager.NavigateTo<ContractsView>();
    }

    public void NavigateToSystems()
    {
        _navigationManager.NavigateTo<SystemsView>();
    }

    public void NavigateToDashboard()
    {
        _navigationManager.NavigateTo<DashboardView>();
    }
}
