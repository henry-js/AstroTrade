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
    private readonly INavigationManager _navigationManager = default!;
    private readonly HeaderLabel? _agentHeaderLabel;

    public ShellViewModel ViewModel { get; } = default!;

    public ShellView(ShellViewModel viewModel, INavigationManager navigationManager)
    {
        _navigationManager =
            navigationManager ?? throw new ArgumentNullException(nameof(navigationManager));

        InitializeComponent();

        ViewModel = viewModel;
        Title = "AstroTrade";

        // Subscribe to ViewModel changes for UI updates
        ViewModel.PropertyChanged += OnViewModelPropertyChanged;

        _navigationManager.ScreenChanged += OnScreenChanged;

        _navigationManager.NavigateTo<DashboardView>();

        _agentHeaderLabel = new HeaderLabel
        {
            NameText = "AGENT",
            ValueText = ViewModel.AgentSymbol ?? "Not Registered",
            Y = 1,
            Width = Dim.Auto(),
            Height = Dim.Auto(),
        };
        headerFrame.Add(_agentHeaderLabel);
    }

    private void OnViewModelPropertyChanged(
        object? sender,
        System.ComponentModel.PropertyChangedEventArgs e
    )
    {
        if (e.PropertyName == nameof(ShellViewModel.AgentSymbol) && _agentHeaderLabel != null)
        {
            _agentHeaderLabel.ValueText = ViewModel.AgentSymbol ?? "Not Registered";
            Application.LayoutAndDraw();
        }
    }

    private void OnScreenChanged(object? sender, ScreenChangedEventArgs e)
    {
        mainFrame.RemoveAll();

        if (e.NewScreen is View screenView)
        {
            screenView.Width = Dim.Fill();
            screenView.Height = Dim.Fill();
            mainFrame.Add(screenView);
        }

        UpdateMenuBar(e.NewScreen?.GetMenuItems() ?? []);

        Application.LayoutAndDraw();
    }

    private void UpdateMenuBar(IEnumerable<MenuBarItemv2> screenMenus)
    {
        var defaultItems = ShellMenuItems.ToList();

        if (screenMenus.Any())
        {
            defaultItems.AddRange(screenMenus);
        }
        menuBar.Menus = defaultItems.ToArray();
    }

    public MenuBarItemv2[] ShellMenuItems =>
        [
            new(
                "_File",
                [
                    new MenuItemv2()
                    {
                        Title = "_Quit",
                        HelpText = "Quit UI Catalog",
                        Key = Application.QuitKey,
                        Command = Command.Quit,
                    },
                ]
            ),
            new(
                "_Home",
                [
                    new MenuItemv2("_Home", "", () => HandleMenuAction("home")),
                    new MenuItemv2("_Register Agent", "", () => HandleMenuAction("register")),
                    new MenuItemv2("_Ships", "", () => HandleMenuAction("ships")),
                    new MenuItemv2("_Markets", "", () => HandleMenuAction("markets")),
                    new MenuItemv2("_Contracts", "", () => HandleMenuAction("contracts")),
                    new MenuItemv2("_Systems", "", () => HandleMenuAction("systems")),
                ]
            ),
        ];

    public void HandleMenuAction(string action)
    {
        switch (action)
        {
            case "home":
                _navigationManager.NavigateTo<DashboardView>();
                break;
            case "register":
                ViewModel.RegisterAgentCommand.Execute(null);
                break;
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
}
