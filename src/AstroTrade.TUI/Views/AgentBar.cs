// using System.ComponentModel;
// using AstroTrade.Core.Features.Shell;
// using Terminal.Gui.App;
// using Terminal.Gui.ViewBase;
// using Terminal.Gui.Views;

// namespace AstroTrade.TUI.Views;

// /// <summary>
// /// A specialized Bar that displays the agent's core status information horizontally.
// /// It binds to a ShellViewModel to receive live updates.
// /// </summary>
// public class AgentBar : Bar
// {
//     private readonly ShellViewModel _viewModel;

//     // We hold references to the individual UI components to update them.
//     private readonly Shortcut _agentSymbolShortcut;
//     private readonly Shortcut _creditsShortcut;
//     private readonly Shortcut _shipCountShortcut;
//     private readonly Shortcut _hqShortcut;

//     /// <summary>
//     /// Creates a new instance of the AgentBar.
//     /// </summary>
//     /// <param name="viewModel">The ViewModel that will provide the data.</param>
//     public AgentBar(ShellViewModel viewModel)
//         : base()
//     {
//         _viewModel = viewModel;

//         // Ensure the bar lays out its items horizontally.
//         this.Orientation = Orientation.Horizontal;

//         // --- Create the UI components ---

//         _agentSymbolShortcut = new Shortcut { Title = "AGENT" };
//         _creditsShortcut = new Shortcut { Title = "CREDITS" };
//         _shipCountShortcut = new Shortcut { Title = "SHIPS" };
//         _hqShortcut = new Shortcut { Title = "HQ" };

//         var separator = new Label() { Y = 0, Text = " | " };
//         var separator2 = new Label() { Y = 0, Text = " | " };
//         var separator3 = new Label() { Y = 0, Text = " | " };

//         // Add all the shortcuts and separators to the Bar.
//         // The Bar's internal layout logic will arrange them.
//         this.Add(
//             _agentSymbolShortcut,
//             separator,
//             _creditsShortcut,
//             separator2,
//             _shipCountShortcut,
//             separator3,
//             _hqShortcut
//         );

//         // --- Set up data binding ---
//         // Subscribe to the ViewModel's PropertyChanged event.
//         _viewModel.PropertyChanged += OnViewModelPropertyChanged;

//         // Set the initial values from the ViewModel.
//         UpdateView();
//     }

//     /// <summary>
//     /// This method is called whenever a property on the ViewModel changes.
//     /// </summary>
//     private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
//     {
//         // UI updates must be run on the main UI thread.
//         // Application.MainLoop.Invoke ensures this.
//         Application.Invoke(UpdateView);
//     }

//     /// <summary>
//     /// Reads the current values from the ViewModel and updates the UI components.
//     /// </summary>
//     private void UpdateView()
//     {
//         // The `Text` property of a Shortcut is what displays the main value.
//         _agentSymbolShortcut.Text = _viewModel.AgentSymbol ?? "N/A";
//         _creditsShortcut.Text = _viewModel.Credits.ToString() ?? "0";
//         _shipCountShortcut.Text = _viewModel.ShipCount ?? "0";
//         _hqShortcut.Text = _viewModel.Headquarters ?? "N/A";
//     }

//     // It's good practice to unsubscribe from events when the view is disposed.
//     protected override void Dispose(bool disposing)
//     {
//         _viewModel.PropertyChanged -= OnViewModelPropertyChanged;
//         base.Dispose(disposing);
//     }
// }
