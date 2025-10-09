using AstroTrade.Core.Features.Contracts;
using Terminal.Gui.ViewBase;
using Terminal.Gui.Views;

namespace AstroTrade.TUI.Views;

public class ContractsView : BaseScreenView
{
    public override string Title => "Contracts";

    public ContractsView(ContractsViewModel viewModel)
    {
        ViewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));

        // Initialize contracts layout
        var label = new Label()
        {
            Text = "Contract Management - Coming Soon",
            X = Pos.Center(),
            Y = Pos.Center(),
        };
        Add(label);
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
