using AstroTrade.Core.Abstractions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SpaceTraders.Api.Models;

namespace AstroTrade.Core.Features.Dashboard;

public partial class DashboardViewModel : ObservableObject
{
    public event EventHandler<NavigationEventArgs>? NavigationRequested;

    [ObservableProperty]
    private List<Contract>? _contracts;

    [ObservableProperty]
    private List<Ship>? _fleetShips;

    public DashboardViewModel()
    {
        // Initialize with empty lists to avoid null references
        Contracts = new List<Contract>();
        FleetShips = new List<Ship>();
    }

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

    [RelayCommand]
    private void FulfillContract()
    {
        // TODO: Implement contract fulfillment logic
        // For now, just navigate to contracts screen
        NavigateToContracts();
    }
}
