using AstroTrade.Application;
using Avalonia.Controls;

namespace DesktopUI.Views;

public partial class MainWindow : Window
{

    public MainWindow()
    {
        InitializeComponent();
        MaxWidth = 800;
        MaxHeight = 400;
        MinWidth = 400;
        MinHeight = 200;
    }
}