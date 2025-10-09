using AstroTrade.Core.Abstractions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AstroTrade.Core.Features.Markets;

public partial class MarketsViewModel : ObservableObject
{
    private readonly INavigationService _navigationService;

    public MarketsViewModel(INavigationService navigationService)
    {
        _navigationService =
            navigationService ?? throw new ArgumentNullException(nameof(navigationService));
    }

    [RelayCommand]
    private void NavigateToDashboard()
    {
        _navigationService.NavigateToDashboard();
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
