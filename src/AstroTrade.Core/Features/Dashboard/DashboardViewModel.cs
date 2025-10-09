using AstroTrade.Core.Abstractions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AstroTrade.Core.Features.Dashboard;

public partial class DashboardViewModel : ObservableObject
{
    public event EventHandler<NavigationEventArgs>? NavigationRequested;

    [RelayCommand]
    private void NavigateToShips()
    {
        NavigationRequested?.Invoke(this, new NavigationEventArgs("ships"));
    }

    [RelayCommand]
    private void NavigateToMarkets()
    {
        NavigationRequested?.Invoke(this, new NavigationEventArgs("markets"));
    }

    [RelayCommand]
    private void NavigateToContracts()
    {
        NavigationRequested?.Invoke(this, new NavigationEventArgs("contracts"));
    }

    [RelayCommand]
    private void NavigateToSystems()
    {
        NavigationRequested?.Invoke(this, new NavigationEventArgs("systems"));
    }
}
