using AstroTrade.Application;

namespace DesktopUI.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {
        
    }
    private readonly ISpaceTradersApiService service;
    public MainWindowViewModel(ISpaceTradersApiService service)
    {
        this.service = service;
    }
#pragma warning disable CA1822 // Mark members as static
    public string Greeting => "Welcome to Avalonia!";
#pragma warning restore CA1822 // Mark members as static
}
