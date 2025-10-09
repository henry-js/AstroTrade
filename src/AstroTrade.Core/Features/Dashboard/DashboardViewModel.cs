using AstroTrade.Core.Abstractions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AstroTrade.Core.Features.Dashboard;

public partial class DashboardViewModel : ObservableObject
{
    private readonly INavigationService _navigationService;

    public DashboardViewModel(INavigationService navigationService)
    {
        _navigationService =
            navigationService ?? throw new ArgumentNullException(nameof(navigationService));
    }

    [RelayCommand]
    private void NavigateToShips()
    {
        _navigationService.NavigateToShips();
    }

    [RelayCommand]
    private void NavigateToMarkets()
    {
        _navigationService.NavigateToMarkets();
    }

    [RelayCommand]
    private void NavigateToContracts()
    {
        _navigationService.NavigateToContracts();
    }

    [RelayCommand]
    private void NavigateToSystems()
    {
        _navigationService.NavigateToSystems();
    }
}
