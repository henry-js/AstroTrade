// File: AstroTrade.Core/Features/Shell/ShellViewModel.cs
using CommunityToolkit.Mvvm.ComponentModel;

namespace AstroTrade.Core.Features.Shell;

// `ObservableObject` provides the implementation for INotifyPropertyChanged.
public partial class ShellViewModel : ObservableObject
{
    // `[ObservableProperty]` generates the property and the OnPropertyChanged call.
    [ObservableProperty]
    private string? _agentSymbol;

    [ObservableProperty]
    private string? _agentCredits;

    [ObservableProperty]
    private string? _shipCount;

    [ObservableProperty]
    private string? _headquarters;

    [ObservableProperty]
    private string? _statusMessage;

    // This is the most important property. It will hold the ViewModel
    // for whatever page is currently being displayed (e.g., ShipListViewModel).
    [ObservableProperty]
    private ObservableObject? _currentPage;

    public int? Credits { get; set; }
}
