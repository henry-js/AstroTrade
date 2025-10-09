using AstroTrade.Core.Abstractions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AstroTrade.Core.Features.Ships;

public partial class ShipsViewModel : ObservableObject
{
    public event EventHandler<NavigationEventArgs>? NavigationRequested;

    [RelayCommand]
    private void NavigateToDashboard()
    {
        NavigationRequested?.Invoke(this, new NavigationEventArgs("dashboard"));
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
