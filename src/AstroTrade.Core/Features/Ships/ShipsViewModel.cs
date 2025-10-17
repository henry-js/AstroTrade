using AstroTrade.Core.Abstractions;
using AstroTrade.Core.Logging;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;

namespace AstroTrade.Core.Features.Ships;

public partial class ShipsViewModel(
    ILogger<ShipsViewModel> logger,
    ICorrelationContext correlationContext) : ObservableObject
{
    private readonly ILogger<ShipsViewModel> _logger = logger;
    private readonly ICorrelationContext _correlationContext = correlationContext;

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
