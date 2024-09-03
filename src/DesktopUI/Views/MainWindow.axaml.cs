using AstroTrade.Infrastructure.Services;
using Avalonia.Controls;
using DesktopUI.ViewModels;

namespace DesktopUI.Views;

public partial class MainWindow : Window
{

    public MainWindow()
    {
        if (Design.IsDesignMode)
        {
            Design.SetDataContext(this, new MainViewModel(new SpaceTradersApiService(null, null)));
        }    
        InitializeComponent();
        MinWidth = 400;
        MinHeight = 200;
    }
}