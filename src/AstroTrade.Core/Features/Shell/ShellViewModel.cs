// File: AstroTrade.Core/Features/Shell/ShellViewModel.cs
using AstroTrade.Core.Features.Agents.Register;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mediator;
using Microsoft.Extensions.Configuration;

namespace AstroTrade.Core.Features.Shell;

// `ObservableObject` provides the implementation for INotifyPropertyChanged.
public partial class ShellViewModel(IMediator mediator, IConfiguration configuration)
    : ObservableObject
{
    private readonly IMediator _mediator = mediator;
    private readonly IConfiguration _configuration = configuration;

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
    private string? _faction;

    [ObservableProperty]
    private string? _statusMessage;

    // This is the most important property. It will hold the ViewModel
    // for whatever page is currently being displayed (e.g., ShipListViewModel).
    [ObservableProperty]
    private ObservableObject? _currentPage;

    public int? Credits { get; set; }

    [RelayCommand]
    private async Task RegisterAgentAsync(RegisterAgentParameters parameters)
    {
        try
        {
            var command = new RegisterAgentCommand(
                parameters.Name,
                parameters.Faction,
                _configuration["SpaceTradersConfiguration:AccountToken"]
                    ?? throw new Exception("AccountToken not found")
            );
            var agent = await _mediator.Send(command);

            // Update properties
            AgentSymbol = agent.Symbol;
            AgentCredits = agent.Credits.ToString();
            ShipCount = agent.ShipCount.ToString();
            Headquarters = agent.Headquarters;
            Faction = agent.StartingFaction;
            Credits = (int)agent.Credits;
            StatusMessage = "Agent registered successfully";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Registration failed: {ex.Message}";
        }
    }
}
