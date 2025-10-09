using AstroTrade.Core.Abstractions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AstroTrade.Core.Features.Ships;

public partial class ShipsViewModel : ObservableObject
{
    private readonly INavigationService _navigationService;

    public ShipsViewModel(INavigationService navigationService)
    {
        _navigationService =
            navigationService ?? throw new ArgumentNullException(nameof(navigationService));
    }

    [RelayCommand]
    private void NavigateToDashboard()
    {
        _navigationService.NavigateToDashboard();
    }

    // Placeholder commands for future ship functionality
    [RelayCommand]
    private void PurchaseShip()
    {
        // TODO: Implement ship purchase logic
    }

    [RelayCommand]
    private void ViewCargo()
    {
        // TODO: Implement cargo view logic
    }

    [RelayCommand]
    private void NavigateShip()
    {
        // TODO: Implement ship navigation logic
    }
}
