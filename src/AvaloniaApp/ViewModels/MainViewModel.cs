using AstroTrade.Application.Services;
using AstroTrade.Services;
using Microsoft.Extensions.Logging;

namespace AstroTrade.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private readonly ILogger<MainViewModel> logger;
    private readonly ISpaceTradersService service;

    public MainViewModel(ILogger<MainViewModel> logger, ISpaceTradersService service)
    {
        this.logger = logger;
        this.service = service;
        logger.LogInformation("Hello From the logger");
    }
#pragma warning disable CA1822 // Mark members as static
    public string Greeting => "Welcome to Avalonia!";
#pragma warning restore CA1822 // Mark members as static
}
