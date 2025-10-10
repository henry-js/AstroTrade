using System.ComponentModel;
using AstroTrade.Core.Features.Shell;
using Terminal.Gui;
using Terminal.Gui.ViewBase;
using Terminal.Gui.Views;

namespace AstroTrade.TUI.Views;

/// <summary>
/// A specialized View that displays the agent's core status information horizontally.
/// It binds to a ShellViewModel to receive live updates.
/// </summary>
public class AgentBar : View
{
    private readonly ShellViewModel _viewModel;

    // We hold references to the individual UI components to update them.
    private readonly Label _agentLabel;
    private readonly Label _creditsLabel;
    private readonly Label _shipsLabel;
    private readonly Label _hqLabel;
    private readonly Label _factionLabel;

    /// <summary>
    /// Creates a new instance of the AgentBar.
    /// </summary>
    /// <param name="viewModel">The ViewModel that will provide the data.</param>
    public AgentBar(ShellViewModel viewModel)
    {
        _viewModel = viewModel;

        Height = 1;

        // --- Create the UI components ---

        _agentLabel = new Label { Y = 0 };
        _creditsLabel = new Label { Y = 0 };
        _shipsLabel = new Label { Y = 0 };
        _hqLabel = new Label { Y = 0 };
        _factionLabel = new Label { Y = 0 };

        // Add all labels to the View.
        Add(_agentLabel, _creditsLabel, _shipsLabel, _hqLabel, _factionLabel);

        // --- Set up data binding ---
        // Subscribe to the ViewModel's PropertyChanged event.
        _viewModel.PropertyChanged += OnViewModelPropertyChanged;

        // Set the initial values from the ViewModel.
        UpdateView();
    }

    /// <summary>
    /// This method is called whenever a property on the ViewModel changes.
    /// </summary>
    private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        UpdateView();
    }

    /// <summary>
    /// Reads the current values from the ViewModel and updates the UI components.
    /// </summary>
    private void UpdateView()
    {
        _agentLabel.Text = $"Agent: {_viewModel.AgentSymbol ?? "Not Registered"}";
        _creditsLabel.Text = $"   Credits: ¢{_viewModel.Credits?.ToString("N0") ?? "0"}";
        _shipsLabel.Text = $"   Ships: {_viewModel.ShipCount ?? "0"}";
        _hqLabel.Text = $"   HQ: {_viewModel.Headquarters ?? "N/A"}";
        _factionLabel.Text = $"   Faction: {_viewModel.Faction ?? "N/A"}";

        // Layout the labels horizontally
        _agentLabel.X = 0;
        _creditsLabel.X = Pos.Right(_agentLabel);
        _shipsLabel.X = Pos.Right(_creditsLabel);
        _hqLabel.X = Pos.Right(_shipsLabel);
        _factionLabel.X = Pos.Right(_hqLabel);
    }

    // It's good practice to unsubscribe from events when the view is disposed.
    protected override void Dispose(bool disposing)
    {
        _viewModel.PropertyChanged -= OnViewModelPropertyChanged;
        base.Dispose(disposing);
    }
}
