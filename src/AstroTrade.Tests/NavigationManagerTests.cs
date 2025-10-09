using AstroTrade.TUI.Navigation;
using Microsoft.Extensions.DependencyInjection;
using Terminal.Gui.Views;

namespace AstroTrade.Tests;

public class NavigationManagerTests
{
    private IServiceProvider _serviceProvider = null!;
    private NavigationManager _navigationManager = null!;

    [Before(HookType.Test)]
    public void Setup()
    {
        var services = new ServiceCollection();
        services.AddSingleton<TestScreen>();
        services.AddSingleton<AnotherTestScreen>();
        _serviceProvider = services.BuildServiceProvider();
        _navigationManager = new NavigationManager(_serviceProvider);
    }

    [Test]
    public async Task NavigateTo_ValidScreenType_SetsCurrentScreenAndRaisesEvent()
    {
        // Arrange
        var screen = _serviceProvider.GetRequiredService<TestScreen>();

        var eventRaised = false;
        IScreenView? previousScreen = null;
        IScreenView? newScreen = null;

        _navigationManager.ScreenChanged += (sender, args) =>
        {
            eventRaised = true;
            previousScreen = args.PreviousScreen;
            newScreen = args.NewScreen;
        };

        // Act
        _navigationManager.NavigateTo<TestScreen>();

        // Assert
        await Assert.That(_navigationManager.CurrentScreen).IsSameReferenceAs(screen);
        await Assert.That(eventRaised).IsTrue();
        await Assert.That(previousScreen).IsNull();
        await Assert.That(newScreen).IsSameReferenceAs(screen);
        await Assert.That(screen.WasActivated).IsTrue();
    }

    [Test]
    public async Task NavigateTo_SameScreenType_ReturnsCachedInstance()
    {
        // Arrange
        var screen = _serviceProvider.GetRequiredService<TestScreen>();

        // Act
        _navigationManager.NavigateTo<TestScreen>();
        _navigationManager.NavigateTo<TestScreen>();

        // Assert
        await Assert.That(_navigationManager.CurrentScreen).IsSameReferenceAs(screen);
    }

    [Test]
    public async Task NavigateTo_InvalidScreenType_ThrowsArgumentException()
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() => _navigationManager.NavigateTo(typeof(string)));
    }

    [Test]
    public async Task NavigateTo_CallsOnDeactivatedOnPreviousScreen()
    {
        // Arrange
        var firstScreen = _serviceProvider.GetRequiredService<TestScreen>();
        var secondScreen = _serviceProvider.GetRequiredService<AnotherTestScreen>();

        // Act
        _navigationManager.NavigateTo<TestScreen>();
        _navigationManager.NavigateTo<AnotherTestScreen>();

        // Assert
        await Assert.That(firstScreen.WasDeactivated).IsTrue();
        await Assert.That(secondScreen.WasActivated).IsTrue();
    }
}

// Test screen classes for testing
public class TestScreen : IScreenView
{
    public string Title => "Test Screen";

    public IEnumerable<MenuBarItemv2> GetMenuItems() => Array.Empty<MenuBarItemv2>();

    public void HandleMenuAction(string action) { }

    public bool WasActivated { get; private set; }
    public bool WasDeactivated { get; private set; }

    public void OnActivated() { WasActivated = true; }

    public void OnDeactivated() { WasDeactivated = true; }
}

public class AnotherTestScreen : IScreenView
{
    public string Title => "Another Test Screen";

    public IEnumerable<MenuBarItemv2> GetMenuItems() => Array.Empty<MenuBarItemv2>();

    public void HandleMenuAction(string action) { }

    public bool WasActivated { get; private set; }
    public bool WasDeactivated { get; private set; }

    public void OnActivated() { WasActivated = true; }

    public void OnDeactivated() { WasDeactivated = true; }
}
