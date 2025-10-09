namespace AstroTrade.Core.Abstractions;

public interface INavigationService
{
    void NavigateToShips();
    void NavigateToMarkets();
    void NavigateToContracts();
    void NavigateToSystems();
    void NavigateToDashboard();
}
