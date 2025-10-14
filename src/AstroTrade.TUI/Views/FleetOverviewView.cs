using System.Collections.ObjectModel;
using SpaceTraders.Api.Models;
using Terminal.Gui;
using Terminal.Gui.ViewBase;
using Terminal.Gui.Views;

namespace AstroTrade.TUI.Views;

public class FleetOverviewView : View
{
    public event EventHandler<Ship>? ShipSelected;

    private readonly ListView _listView;

    public FleetOverviewView()
    {
        Height = Dim.Fill();
        Width = Dim.Fill();

        _listView = new ListView
        {
            X = 0,
            Y = 0,
            Width = Dim.Fill(),
            Height = Dim.Fill(),
        };

        _listView.SetSource(new ObservableCollection<string>());
        _listView.OpenSelectedItem += OnShipSelected;

        Add(_listView);
    }

    public void UpdateShips(List<Ship> ships)
    {
        _listView.SetSource(CreateShipItems(ships));
    }

    private ObservableCollection<string> CreateShipItems(List<Ship> ships)
    {
        var items = ships
            .Select(ship =>
                $"{ship.Symbol} - {ship.Nav?.Route?.Destination?.Symbol ?? "Unknown"} - {ship.Nav?.Status?.ToString() ?? "Unknown"} - Cargo: {ship.Cargo?.Units ?? 0}/{ship.Cargo?.Capacity ?? 0}"
            )
            .ToList();
        return new ObservableCollection<string>(items);
    }

    private void OnShipSelected(object? sender, ListViewItemEventArgs args)
    {
        // TODO: Pass actual ship
        ShipSelected?.Invoke(this, null!);
    }
}
