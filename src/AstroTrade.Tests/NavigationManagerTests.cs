using AstroTrade.TUI.Navigation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using NSubstitute;
using Terminal.Gui.Views;

namespace AstroTrade.Tests;

public class NavigationManagerTests
{
    private IServiceProvider _serviceProvider = null!;
    private NavigationManager _navigationManager = null!;

    [Before(HookType.Test)]
    public void Setup()
    {
        // var services = new ServiceCollection();
        // services.AddSingleton<IScreenView, TestScreen>();
        // services.AddSingleton<IScreenView, AnotherTestScreen>();
        _serviceProvider = Substitute.For<IServiceProvider>();
        _navigationManager = new NavigationManager(_serviceProvider);
    }

    [Test]
    public async Task NavigateTo_ValidScreenType_SetsCurrentScreenAndRaisesEvent()
    {
        // Arrange
        var mockScreen = Substitute.For<IScreenView>();
        mockScreen.Title.Returns("Test Screen");
        mockScreen.GetMenuItems().Returns([]);
        _serviceProvider.GetRequiredService(typeof(TestScreen)).Returns(mockScreen);

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
        await Assert.That(_navigationManager.CurrentScreen).IsSameReferenceAs(mockScreen);
        await Assert.That(eventRaised).IsTrue();
        await Assert.That(previousScreen).IsNull();
        await Assert.That(newScreen).IsSameReferenceAs(mockScreen);
        mockScreen.Received(1).OnActivated();
    }

    [Test]
    public async Task NavigateTo_SameScreenType_ReturnsCachedInstance()
    {
        // Arrange
        var mockScreen = Substitute.For<IScreenView>();
        _serviceProvider.GetRequiredService(typeof(TestScreen)).Returns(mockScreen);

        // Act
        _navigationManager.NavigateTo<TestScreen>();
        _navigationManager.NavigateTo<TestScreen>();

        // Assert
        await Assert.That(_navigationManager.CurrentScreen).IsSameReferenceAs(mockScreen);
        _serviceProvider.Received(1).GetRequiredService(typeof(TestScreen));
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
        var firstScreen = Substitute.For<IScreenView>();
        var secondScreen = Substitute.For<IScreenView>();

        _serviceProvider.GetRequiredService(typeof(TestScreen)).Returns(firstScreen);
        _serviceProvider.GetRequiredService(typeof(AnotherTestScreen)).Returns(secondScreen);

        // Act
        _navigationManager.NavigateTo<TestScreen>();
        _navigationManager.NavigateTo<AnotherTestScreen>();

        // Assert
        firstScreen.Received(1).OnDeactivated();
        secondScreen.Received(1).OnActivated();
    }
}

// Test screen classes for testing
public class TestScreen : IScreenView
{
    public string Title => "Test Screen";

    public IEnumerable<MenuBarItemv2> GetMenuItems() => Array.Empty<MenuBarItemv2>();

    public void HandleMenuAction(string action) { }

    public void OnActivated() { }

    public void OnDeactivated() { }
}

public class AnotherTestScreen : IScreenView
{
    public string Title => "Another Test Screen";

    public IEnumerable<MenuBarItemv2> GetMenuItems() => Array.Empty<MenuBarItemv2>();

    public void HandleMenuAction(string action) { }

    public void OnActivated() { }

    public void OnDeactivated() { }
}
