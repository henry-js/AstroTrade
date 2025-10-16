using AstroTrade.Core.Abstractions;
using AstroTrade.Core.Features.Contracts;
using AstroTrade.Core.Features.Ships;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mediator;
using SpaceTraders.Api.Models;

namespace AstroTrade.Core.Features.Dashboard;

public partial class DashboardViewModel(
    IMediator mediator,
    ICurrentAgentService currentAgentService
) : ObservableObject
{
    private readonly IMediator _mediator = mediator;
    private readonly ICurrentAgentService _currentAgentService = currentAgentService;

    public event EventHandler<NavigationEventArgs>? NavigationRequested;

    [ObservableProperty]
    private List<Contract>? _contracts;

    [ObservableProperty]
    private List<Ship>? _fleetShips;

    [ObservableProperty]
    private string? _errorMessage;

    public async Task InitializeAsync()
    {
        try
        {
            // Check if we have a current agent
            if (string.IsNullOrEmpty(_currentAgentService.CurrentAgentSymbol))
            {
                ErrorMessage = "No agent selected. Please register or select an agent.";
                Contracts = null;
                FleetShips = null;
                return;
            }

            Contracts = await _mediator.Send(new GetContractsQuery());
            FleetShips = await _mediator.Send(new GetShipsQuery());
            ErrorMessage = null;
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }
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
