using AstroTrade.Core.Abstractions;
using AstroTrade.Core.Features.Contracts;
using AstroTrade.Core.Features.Dashboard;
using AstroTrade.Core.Features.Ships;
using Mediator;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using SpaceTraders.Api.Models;
using TUnit.Core;

public class DashboardViewModelTests
{
    private IMediator _mockMediator = null!;
    private ICurrentAgentService _mockCurrentAgentService = null!;
    private DashboardViewModel _viewModel = null!;

    [Before(Test)]
    public void Setup()
    {
        _mockMediator = Substitute.For<IMediator>();
        _mockCurrentAgentService = Substitute.For<ICurrentAgentService>();
        _viewModel = new DashboardViewModel(_mockMediator, _mockCurrentAgentService);
    }

    [Test]
    public async Task Constructor_ValidMediator_SetsMediator()
    {
        // Arrange & Act
        var viewModel = new DashboardViewModel(_mockMediator, _mockCurrentAgentService);

        // Assert
        await Assert.That(viewModel).IsNotNull();
    }

    [Test]
    public async Task InitializeAsync_ValidQueries_SetsContractsAndShips()
    {
        // Arrange
        _mockCurrentAgentService.CurrentAgentSymbol.Returns("TEST_AGENT");
        var contracts = new List<Contract> { new() { Id = "1" } };
        var ships = new List<Ship> { new() { Symbol = "SHIP1" } };
        _mockMediator.Send(Arg.Any<GetContractsQuery>()).Returns(contracts);
        _mockMediator.Send(Arg.Any<GetShipsQuery>()).Returns(ships);

        // Act
        await _viewModel.InitializeAsync();

        // Assert
        await Assert.That(_viewModel.Contracts).IsEquivalentTo(contracts);
        await Assert.That(_viewModel.FleetShips).IsEquivalentTo(ships);
        await Assert.That(_viewModel.ErrorMessage).IsNull();
    }

    [Test]
    public async Task InitializeAsync_QueryThrows_SetsErrorMessage()
    {
        // Arrange
        _mockCurrentAgentService.CurrentAgentSymbol.Returns("TEST_AGENT");
        _mockMediator.Send(Arg.Any<GetContractsQuery>()).Throws(new Exception("Test error"));

        // Act
        await _viewModel.InitializeAsync();

        // Assert
        await Assert.That(_viewModel.ErrorMessage).IsEqualTo("Test error");
        await Assert.That(_viewModel.Contracts).IsNull();
        await Assert.That(_viewModel.FleetShips).IsNull();
    }

    [Test]
    public async Task InitializeAsync_NoCurrentAgent_SetsErrorMessage()
    {
        // Arrange
        _mockCurrentAgentService.CurrentAgentSymbol.Returns((string?)null);

        // Act
        await _viewModel.InitializeAsync();

        // Assert
        await Assert
            .That(_viewModel.ErrorMessage)
            .IsEqualTo("No agent selected. Please register or select an agent.");
        await Assert.That(_viewModel.Contracts).IsNull();
        await Assert.That(_viewModel.FleetShips).IsNull();
    }

    [Test]
    public async Task NavigateToShips_Execute_RaisesNavigationRequested()
    {
        // Arrange
        NavigationEventArgs? raisedArgs = null;
        _viewModel.NavigationRequested += (sender, args) => raisedArgs = args;

        // Act
        _viewModel.NavigateToShipsCommand.Execute(null);

        // Assert
        await Assert.That(raisedArgs).IsNotNull();
        await Assert.That(raisedArgs!.Target).IsEqualTo("ships");
    }

    [Test]
    public async Task NavigateToMarkets_Execute_RaisesNavigationRequested()
    {
        // Arrange
        NavigationEventArgs? raisedArgs = null;
        _viewModel.NavigationRequested += (sender, args) => raisedArgs = args;

        // Act
        _viewModel.NavigateToMarketsCommand.Execute(null);

        // Assert
        await Assert.That(raisedArgs).IsNotNull();
        await Assert.That(raisedArgs!.Target).IsEqualTo("markets");
    }

    [Test]
    public async Task NavigateToContracts_Execute_RaisesNavigationRequested()
    {
        // Arrange
        NavigationEventArgs? raisedArgs = null;
        _viewModel.NavigationRequested += (sender, args) => raisedArgs = args;

        // Act
        _viewModel.NavigateToContractsCommand.Execute(null);

        // Assert
        await Assert.That(raisedArgs).IsNotNull();
        await Assert.That(raisedArgs!.Target).IsEqualTo("contracts");
    }

    [Test]
    public async Task NavigateToSystems_Execute_RaisesNavigationRequested()
    {
        // Arrange
        NavigationEventArgs? raisedArgs = null;
        _viewModel.NavigationRequested += (sender, args) => raisedArgs = args;

        // Act
        _viewModel.NavigateToSystemsCommand.Execute(null);

        // Assert
        await Assert.That(raisedArgs).IsNotNull();
        await Assert.That(raisedArgs!.Target).IsEqualTo("systems");
    }

    [Test]
    public async Task FulfillContract_Execute_NavigatesToContracts()
    {
        // Arrange
        NavigationEventArgs? raisedArgs = null;
        _viewModel.NavigationRequested += (sender, args) => raisedArgs = args;

        // Act
        _viewModel.FulfillContractCommand.Execute(null);

        // Assert
        await Assert.That(raisedArgs).IsNotNull();
        await Assert.That(raisedArgs!.Target).IsEqualTo("contracts");
    }
}
