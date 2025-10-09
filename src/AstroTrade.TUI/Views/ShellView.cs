using System.Collections;
using AstroTrade.Core.Features.Shell;
using AstroTrade.TUI.Navigation;
using Terminal.Gui.App;
using Terminal.Gui.Input;
using Terminal.Gui.ViewBase;
using Terminal.Gui.Views;
using YourApp.Views;

namespace AstroTrade.TUI.Views;

public partial class ShellView
{
    private readonly INavigationManager _navigationManager;

    public ShellViewModel ViewModel { get; }

    public ShellView() { }

    public ShellView(ShellViewModel viewModel, INavigationManager navigationManager)
    {
        _navigationManager =
            navigationManager ?? throw new ArgumentNullException(nameof(navigationManager));

        InitializeComponent();

        ViewModel = viewModel;
        Title = "AstroTrade";

        // Subscribe to navigation changes
        _navigationManager.ScreenChanged += OnScreenChanged;

        // Navigate to default screen
        _navigationManager.NavigateTo<DashboardView>();

        var headerVal = new HeaderLabel() { NameText = "AGENT", ValueText = "TEST" };
        // headerVal.Border.Thickness = new Terminal.Gui.Drawing.Thickness(1);
        headerVal.Y = 1;
        headerVal.Width = Dim.Auto();
        headerVal.Height = Dim.Auto();
        headerFrame.Add(headerVal);
        // headerFrame.Border.Thickness = new(1, 0, 1, 0);

        // headerFrame.Add(agentSymbolLabel);
    }

    private void OnScreenChanged(object? sender, ScreenChangedEventArgs e)
    {
        // Clear mainFrame
        mainFrame.RemoveAll();

        // Add new screen if exists
        if (e.NewScreen is View screenView)
        {
            screenView.Width = Dim.Fill();
            screenView.Height = Dim.Fill();
            mainFrame.Add(screenView);
        }

        // Update menu
        UpdateMenuBar(e.NewScreen?.GetMenuItems() ?? []);

        // Refresh layout
        Application.LayoutAndDraw();
    }

    private void UpdateMenuBar(IEnumerable<MenuBarItemv2> screenMenus)
    {
        var defaultItems = ShellMenuItems.ToList();

        if (screenMenus.Any())
        {
            defaultItems.AddRange(screenMenus);
        }
        menuBar = new(defaultItems);
    }

    private static IEnumerable<MenuBarItemv2> ShellMenuItems =>
        [
            new(
                "_File",
                [
                    new MenuItemv2()
                    {
                        Title = "_Quit",
                        HelpText = "Quit UI Catalog",
                        Key = Application.QuitKey,
                        // By not specifying TargetView the Key Binding will be Application-level
                        Command = Command.Quit,
                    },
                ]
            ),
        ];
}
