using AstroTrade.Core.Abstractions;
using AstroTrade.Core.Features.Contracts;
using AstroTrade.TUI.Navigation;
using Terminal.Gui.ViewBase;
using Terminal.Gui.Views;

namespace AstroTrade.TUI.Views;

public class ContractsView : BaseScreenView
{
    private readonly INavigationManager _navigationManager;

    public override string Title => "Contracts";

    public ContractsView(ContractsViewModel viewModel, INavigationManager navigationManager)
    {
        ViewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        _navigationManager = navigationManager ?? throw new ArgumentNullException(nameof(navigationManager));

        viewModel.NavigationRequested += OnNavigationRequested;

        // Initialize contracts layout
        var label = new Label()
        {
            Text = "Contract Management - Coming Soon",
            X = Pos.Center(),
            Y = Pos.Center(),
        };
        Add(label);
    }

    private void OnNavigationRequested(object? sender, NavigationEventArgs e)
    {
        switch (e.Target)
        {
            case "dashboard":
                _navigationManager.NavigateTo<DashboardView>();
                break;
        }
    }

    public override IEnumerable<MenuBarItemv2> GetMenuItems()
    {
        return new List<MenuBarItemv2>
        {
            new(
                "_Contracts",
                [
                    new MenuItemv2(
                        "_Accept Contract",
                        "",
                        () => (ViewModel as ContractsViewModel)?.AcceptContractCommand.Execute(null)
                    ),
                    new MenuItemv2(
                        "_Deliver Goods",
                        "",
                        () => (ViewModel as ContractsViewModel)?.DeliverGoodsCommand.Execute(null)
                    ),
                    new MenuItemv2(
                        "_Fulfill Contract",
                        "",
                        () =>
                            (ViewModel as ContractsViewModel)?.FulfillContractCommand.Execute(null)
                    ),
                    new MenuItemv2(
                        "_Back to Dashboard",
                        "",
                        () =>
                            (ViewModel as ContractsViewModel)?.NavigateToDashboardCommand.Execute(
                                null
                            )
                    ),
                ]
            ),
        };
    }
}
