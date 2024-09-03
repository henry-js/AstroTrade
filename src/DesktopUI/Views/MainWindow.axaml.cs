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
        //this.SizeToContent = SizeToContent.WidthAndHeight;
    }
}