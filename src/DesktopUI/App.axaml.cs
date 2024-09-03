using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using DesktopUI.ViewModels;
using DesktopUI.Views;
using Microsoft.Extensions.DependencyInjection;
using AstroTrade.Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using CommunityToolkit.Mvvm.DependencyInjection;

namespace DesktopUI;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Line below is needed to remove Avalonia data validation.
            // Without this line you will get duplicate validations from both Avalonia and CT
            BindingPlugins.DataValidators.RemoveAt(0);

            var configuration = new ConfigurationBuilder()
                .AddSpaceTradersConfiguration()
                .Build() ;
            Ioc.Default.ConfigureServices(
                new ServiceCollection()
                .AddTransient<MainViewModel>()
                .AddSpaceTraders(configuration)
                .BuildServiceProvider());

            var vm = Ioc.Default.GetRequiredService<MainViewModel>();
            desktop.MainWindow = new MainWindow
            {
                DataContext = vm,
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}

