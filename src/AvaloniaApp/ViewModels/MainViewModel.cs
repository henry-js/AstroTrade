using AstroTrade.Application.Services;
using Microsoft.Extensions.Logging;
using SpaceTraders.Api;

namespace AvaloniaApp.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private readonly ILogger<MainViewModel> logger;
    private readonly SpaceTradersService service;

    public MainViewModel(ILogger<MainViewModel> logger, SpaceTradersService service)
    {
        this.logger = logger;
        this.service = service;
        logger.LogInformation("Hello From the logger");
    }
#pragma warning disable CA1822 // Mark members as static
    public string Greeting => "Welcome to Avalonia!";
#pragma warning restore CA1822 // Mark members as static
}
