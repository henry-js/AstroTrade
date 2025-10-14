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
    private readonly ContractsListView _contractsListView;
    private readonly FleetOverviewView _fleetOverviewView;

    public override string Title => "Dashboard";

    public DashboardView(DashboardViewModel viewModel, INavigationManager navigationManager)
    {
        ViewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        _navigationManager =
            navigationManager ?? throw new ArgumentNullException(nameof(navigationManager));

        viewModel.NavigationRequested += OnNavigationRequested;

        _contractsListView = new ContractsListView();
        _contractsListView.ContractSelected += OnContractSelected;

        _fleetOverviewView = new FleetOverviewView();
        _fleetOverviewView.ShipSelected += OnShipSelected;

        InitializeLayout();
    }

    public override async void OnActivated()
    {
        base.OnActivated();
        await ((DashboardViewModel)ViewModel!).InitializeAsync();
        var vm = (DashboardViewModel)ViewModel!;
        _contractsListView.UpdateContracts(vm.Contracts ?? new List<Contract>());
        _fleetOverviewView.UpdateShips(vm.FleetShips ?? new List<Ship>());
        if (!string.IsNullOrEmpty(vm.ErrorMessage))
        {
            MessageBox.ErrorQuery("Error", vm.ErrorMessage, "OK");
        }
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

        contractsFrame.Add(_contractsListView);
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

        fleetFrame.Add(_fleetOverviewView);
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

    private void OnContractSelected(object? sender, Contract? contract)
    {
        _navigationManager.NavigateTo<ContractsView>();
    }

    private void OnShipSelected(object? sender, Ship? ship)
    {
        _navigationManager.NavigateTo<ShipsView>();
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
