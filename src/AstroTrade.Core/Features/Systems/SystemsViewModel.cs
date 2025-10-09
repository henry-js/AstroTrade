using AstroTrade.Core.Abstractions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AstroTrade.Core.Features.Systems;

public partial class SystemsViewModel : ObservableObject
{
    private readonly INavigationService _navigationService;

    public SystemsViewModel(INavigationService navigationService)
    {
        _navigationService =
            navigationService ?? throw new ArgumentNullException(nameof(navigationService));
    }

    [RelayCommand]
    private void NavigateToDashboard()
    {
        _navigationService.NavigateToDashboard();
    }

    // Placeholder commands for future systems functionality
    [RelayCommand]
    private void ExploreWaypoints()
    {
        // TODO: Implement waypoint exploration logic
    }

    [RelayCommand]
    private void JumpGates()
    {
        // TODO: Implement jump gate navigation logic
    }

    [RelayCommand]
    private void ViewMap()
    {
        // TODO: Implement system map viewing logic
    }
}
