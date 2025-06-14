using AstroTrade.Core.Features.Shell;

using Terminal.Gui.Input;
using Terminal.Gui.ViewBase;
using Terminal.Gui.Views;

using YourApp.Views;

namespace AstroTrade.TUI.Views;

public partial class ShellView
{

    public ShellViewModel ViewModel { get; }

    public ShellView(ShellViewModel viewModel) : base()
    {
        InitializeComponent();

        ViewModel = viewModel;
        Title = "AstroTrade";
        var headerVal = new HeaderLabel()
        {
            NameText = "AGENT",
            ValueText = "TEST"
        };
        // headerVal.Border.Thickness = new Terminal.Gui.Drawing.Thickness(1);
        headerVal.Y = 1;
        headerVal.Width = Dim.Auto();
        headerVal.Height = Dim.Auto();
        headerFrame.Add(headerVal);
        // headerFrame.Border.Thickness = new(1, 0, 1, 0);

        // headerFrame.Add(agentSymbolLabel);
    }
}
