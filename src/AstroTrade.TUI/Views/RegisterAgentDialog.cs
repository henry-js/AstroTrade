using System.Collections.ObjectModel;
using AstroTrade.Core.Features.Shell;
using Terminal.Gui;
using Terminal.Gui.Input;
using Terminal.Gui.ViewBase;
using Terminal.Gui.Views;

namespace AstroTrade.TUI.Views;

public class RegisterAgentDialog : Dialog
{
    public string? AgentName { get; private set; }
    public string? SelectedFaction { get; private set; }

    public readonly TextField NameField;
    public readonly ComboBox FactionCombo;

    public RegisterAgentDialog()
    {
        Title = "Register New Agent";
        Width = 60;
        Height = 12;

        // Agent Name Label and Field
        var nameLabel = new Label
        {
            Text = "Agent Name:",
            X = 1,
            Y = 1,
            Width = 15,
        };
        Add(nameLabel);

        NameField = new TextField
        {
            Text = "",
            X = Pos.Right(nameLabel) + 1,
            Y = 1,
            Width = Dim.Fill(2),
        };
        Add(NameField);

        // Faction Label and ComboBox
        var factionLabel = new Label
        {
            Text = "Faction:",
            X = 1,
            Y = 3,
            Width = 15,
        };
        Add(factionLabel);

        FactionCombo = new ComboBox
        {
            X = Pos.Right(factionLabel) + 1,
            Y = 3,
            Width = Dim.Fill(2),
            Height = 4,
        };
        FactionCombo.SetSource<string>(
            new ObservableCollection<string> { "COSMIC", "VOID", "GALACTIC", "QUANTUM", "DOMINION" }
        );
        FactionCombo.SelectedItem = 0; // Default to COSMIC
        Add(FactionCombo);

        // Buttons
        var okButton = new Button
        {
            Text = "OK",
            X = Pos.Center() - 10,
            Y = Pos.AnchorEnd(1),
            IsDefault = true,
        };
        AddButton(okButton);

        okButton.Accepting += AcceptOk;
        var cancelButton = new Button
        {
            Text = "Cancel",
            X = Pos.Center() + 2,
            Y = Pos.AnchorEnd(1),
        };
        AddButton(cancelButton);
        cancelButton.Accepting += (s, e) =>
        {
            e.Handled = true;
            Canceled = true;
            RequestStop();
        };
    }

    private void AcceptOk(object? sender, CommandEventArgs e)
    {
        e.Handled = true;
        Canceled = false;
        RequestStop();
    }
}
