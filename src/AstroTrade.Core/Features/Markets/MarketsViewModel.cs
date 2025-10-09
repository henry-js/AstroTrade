using AstroTrade.Core.Abstractions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AstroTrade.Core.Features.Markets;

public partial class MarketsViewModel : ObservableObject
{
    public event EventHandler<NavigationEventArgs>? NavigationRequested;

    [RelayCommand]
    private void NavigateToDashboard()
    {
        NavigationRequested?.Invoke(this, new NavigationEventArgs("dashboard"));
    }

    // Placeholder commands for future market functionality
    [RelayCommand]
    private void BuyGoods()
    {
        // TODO: Implement goods purchase logic
    }

    [RelayCommand]
    private void SellGoods()
    {
        // TODO: Implement goods selling logic
    }

    [RelayCommand]
    private void ViewPrices()
    {
        // TODO: Implement price viewing logic
    }
}
