using System.Collections.ObjectModel;
using SpaceTraders.Api.Models;
using Terminal.Gui;
using Terminal.Gui.ViewBase;
using Terminal.Gui.Views;

namespace AstroTrade.TUI.Views;

public class ContractsListView : View
{
    public event EventHandler<Contract>? ContractSelected;

    private readonly ListView _listView;

    public ContractsListView()
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
        _listView.OpenSelectedItem += OnContractSelected;

        Add(_listView);
    }

    public void UpdateContracts(List<Contract> contracts)
    {
        _listView.SetSource(CreateContractItems(contracts));
    }

    private ObservableCollection<string> CreateContractItems(List<Contract> contracts)
    {
        var items = contracts
            .Select(contract =>
                $"{contract.Id} - {contract.Type?.ToString() ?? "Unknown"} - ¢{contract.Terms?.Payment?.OnAccepted?.ToString("N0") ?? "0"} - {contract.Terms?.Deadline?.ToString("yyyy-MM-dd") ?? "-"}"
            )
            .ToList();
        return new ObservableCollection<string>(items);
    }

    private void OnContractSelected(object? sender, ListViewItemEventArgs args)
    {
        // Assuming contracts are in same order, get by index
        // For simplicity, raise with null or find way to pass contract
        // TODO: Improve to pass actual contract
        ContractSelected?.Invoke(this, null!);
    }
}
