using AstroTrade.Core.Abstractions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AstroTrade.Core.Features.Contracts;

public partial class ContractsViewModel : ObservableObject
{
    private readonly INavigationService _navigationService;

    public ContractsViewModel(INavigationService navigationService)
    {
        _navigationService =
            navigationService ?? throw new ArgumentNullException(nameof(navigationService));
    }

    [RelayCommand]
    private void NavigateToDashboard()
    {
        _navigationService.NavigateToDashboard();
    }

    // Placeholder commands for future contract functionality
    [RelayCommand]
    private void AcceptContract()
    {
        // TODO: Implement contract acceptance logic
    }

    [RelayCommand]
    private void DeliverGoods()
    {
        // TODO: Implement goods delivery logic
    }

    [RelayCommand]
    private void FulfillContract()
    {
        // TODO: Implement contract fulfillment logic
    }
}
