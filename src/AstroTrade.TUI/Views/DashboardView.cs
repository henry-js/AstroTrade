using System.Collections.ObjectModel;
using AstroTrade.Core.Abstractions;
using AstroTrade.Core.Features.Dashboard;
using AstroTrade.TUI.Navigation;
using SpaceTraders.Api.Models;
using Terminal.Gui;
using Terminal.Gui.ViewBase;
using Terminal.Gui.Views;

namespace AstroTrade.TUI.Views;

public class DashboardView : BaseScreenView
{
    private readonly INavigationManager _navigationManager;

    public override string Title => "Dashboard";

    public DashboardView(DashboardViewModel viewModel, INavigationManager navigationManager)
    {
        ViewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        _navigationManager = navigationManager ?? throw new ArgumentNullException(nameof(navigationManager));

        viewModel.NavigationRequested += OnNavigationRequested;

        InitializeLayout();
    }

    private void InitializeLayout()
    {
        // Left Panel: Active Contracts
        var contractsFrame = new FrameView
        {
            Title = "Active Contracts",
            X = 0,
            Y = 0,
            Width = Dim.Percent(40),
            Height = Dim.Fill(3), // Leave space for buttons
        };

        var contractsList = new ListView
        {
            X = 0,
            Y = 0,
            Width = Dim.Fill(),
            Height = Dim.Fill(),
        };

        // Bind to ViewModel
        (ViewModel as DashboardViewModel)!.PropertyChanged += (s, e) =>
        {
            if (e.PropertyName == nameof(DashboardViewModel.Contracts))
            {
                UpdateContractsList(contractsList);
            }
        };

        contractsFrame.Add(contractsList);
        Add(contractsFrame);

        // Right Panel: Fleet Overview
        var fleetFrame = new FrameView
        {
            Title = "Fleet Overview",
            X = Pos.Right(contractsFrame),
            Y = 0,
            Width = Dim.Fill(),
            Height = Dim.Fill(3),
        };

        var fleetList = new ListView
        {
            X = 0,
            Y = 0,
            Width = Dim.Fill(),
            Height = Dim.Fill(),
        };

        // Bind to ViewModel
        (ViewModel as DashboardViewModel)!.PropertyChanged += (s, e) =>
        {
            if (e.PropertyName == nameof(DashboardViewModel.FleetShips))
            {
                UpdateFleetList(fleetList);
            }
        };

        fleetFrame.Add(fleetList);
        Add(fleetFrame);

        // Bottom Section: Action Buttons
        var navigateButton = new Button
        {
            Text = "Navigate Ship",
            X = 0,
            Y = Pos.AnchorEnd(1),
            Width = Dim.Percent(25),
        };

        var marketButton = new Button
        {
            Text = "View Market",
            X = Pos.Right(navigateButton),
            Y = Pos.AnchorEnd(1),
            Width = Dim.Percent(25),
        };

        var fulfillButton = new Button
        {
            Text = "Fulfill Contract",
            X = Pos.Right(marketButton),
            Y = Pos.AnchorEnd(1),
            Width = Dim.Percent(25),
        };

        Add(navigateButton, marketButton, fulfillButton);
    }

    private void UpdateContractsList(ListView list)
    {
        var vm = ViewModel as DashboardViewModel;
        if (vm?.Contracts == null)
            return;

        var items = vm
            .Contracts.Select(contract =>
                $"{contract.Id} - {contract.Type?.ToString() ?? "Unknown"} - ¢{contract.Terms?.Payment?.OnAccepted?.ToString("N0") ?? "0"} - {contract.Terms?.Deadline?.ToString("yyyy-MM-dd") ?? "-"}"
            )
            .ToList();
        list.SetSource(new ObservableCollection<string>(items));
    }

    private void UpdateFleetList(ListView list)
    {
        var vm = ViewModel as DashboardViewModel;
        if (vm?.FleetShips == null)
            return;

        var items = vm
            .FleetShips.Select(ship =>
                $"{ship.Symbol} - {ship.Nav?.Route?.Destination?.Symbol ?? "Unknown"} - {ship.Nav?.Status?.ToString() ?? "Unknown"} - Cargo: {ship.Cargo?.Units ?? 0}/{ship.Cargo?.Capacity ?? 0}"
            )
            .ToList();
        list.SetSource(new ObservableCollection<string>(items));
    }

    private void OnNavigationRequested(object? sender, NavigationEventArgs e)
    {
        switch (e.Target)
        {
            case "ships":
                _navigationManager.NavigateTo<ShipsView>();
                break;
            case "markets":
                _navigationManager.NavigateTo<MarketsView>();
                break;
            case "contracts":
                _navigationManager.NavigateTo<ContractsView>();
                break;
            case "systems":
                _navigationManager.NavigateTo<SystemsView>();
                break;
        }
    }

    public override IEnumerable<MenuBarItemv2> GetMenuItems()
    {
        return new List<MenuBarItemv2>
        {
            new(
                "_Game",
                [
                    new MenuItemv2(
                        "_Ships",
                        "",
                        () =>
                            (ViewModel as DashboardViewModel)?.NavigateToShipsCommand.Execute(null)
                    ),
                    new MenuItemv2(
                        "_Markets",
                        "",
                        () =>
                            (ViewModel as DashboardViewModel)?.NavigateToMarketsCommand.Execute(
                                null
                            )
                    ),
                    new MenuItemv2(
                        "_Contracts",
                        "",
                        () =>
                            (ViewModel as DashboardViewModel)?.NavigateToContractsCommand.Execute(
                                null
                            )
                    ),
                    new MenuItemv2(
                        "_Systems",
                        "",
                        () =>
                            (ViewModel as DashboardViewModel)?.NavigateToSystemsCommand.Execute(
                                null
                            )
                    ),
                ]
            ),
        };
    }
}
