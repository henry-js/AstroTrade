using System.Collections;
using System.Collections.ObjectModel;
using AstroTrade.Core.Features.Shell;
using AstroTrade.TUI.Navigation;
using Terminal.Gui;
using Terminal.Gui.App;
using Terminal.Gui.Input;
using Terminal.Gui.ViewBase;
using Terminal.Gui.Views;

namespace AstroTrade.TUI.Views;

public partial class ShellView
{
    private readonly INavigationManager _navigationManager = default!;
    private readonly AgentBar? _agentBar;

    public ShellViewModel ViewModel { get; } = default!;

    public ShellView(ShellViewModel viewModel, INavigationManager navigationManager)
    {
        _navigationManager =
            navigationManager ?? throw new ArgumentNullException(nameof(navigationManager));

        InitializeComponent();

        ViewModel = viewModel;
        Title = "AstroTrade";

        _navigationManager.ScreenChanged += OnScreenChanged;

        _navigationManager.NavigateTo<DashboardView>();

        _agentBar = new AgentBar(ViewModel)
        {
            Y = 1,
            Width = Dim.Fill(),
            Height = 1,
        };
        headerFrame.Add(_agentBar);

        // Configure StatusBar
        // statusBar.Add(new StatusItem(Key.Q.WithCtrl, "~Ctrl+Q~ Quit", () => Application.RequestStop()));
        // statusBar.Add(new StatusItem(Key.Empty, "API: Online", null));
        // statusBar.Add(new StatusItem(Key.Empty, $"Time: {DateTime.UtcNow:HH:mm:ss}", null));
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
                ShowRegisterAgentDialog();
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

    private void ShowRegisterAgentDialog()
    {
        var dialog = new RegisterAgentDialog();
        Application.Run(dialog);

        if (!dialog.Canceled)
        {
            var name = dialog.NameField.Text?.ToString();
            var faction = dialog.FactionCombo.Text?.ToString();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(faction))
            {
                // For now, skip validation
                return;
            }

            var parameters = new RegisterAgentParameters { Name = name, Faction = faction };
            ViewModel.RegisterAgentCommand.Execute(parameters);
        }
    }
}
