using Avalonia.Controls;
using FluentAvalonia.UI.Windowing;

namespace AstroTrade.Views;
public partial class MainWindow : AppWindow
{
    public MainWindow()
    {
        InitializeComponent();

        TitleBar.ExtendsContentIntoTitleBar = true;
        TitleBar.TitleBarHitTestType = TitleBarHitTestType.Complex;
    }
}