# Implementation Plan: Dashboard Data Population with Pure CQRS

## Overview

Implement data loading for dashboard subcomponents (contracts list and fleet overview) using Pure CQRS architecture. DashboardViewModel will send queries via Mediator to populate agent-specific contracts and ships data from the SpaceTraders API.

## Architecture

- **Queries**: GetContractsQuery, GetShipsQuery
- **Handlers**: GetContractsHandler, GetShipsHandler (use ApiClient for API calls)
- **Mappers**: ContractMapper, ShipMapper (API models to domain/UI models)
- **ViewModel**: DashboardViewModel injects IMediator, adds InitializeAsync to send queries
- **View**: DashboardView calls InitializeAsync on activation, binds to updated observables

## Detailed Steps

- [x] **Create Query Classes (High Priority)**
  - [x] **Location**: `src/AstroTrade.Core/Features/Contracts/GetContractsQuery.cs` and `src/AstroTrade.Core/Features/Ships/GetShipsQuery.cs`
  - [x] **Details**:
    - [x] Define query classes implementing `IQuery<TResponse>` from Mediator
    - [x] GetContractsQuery: No parameters (fetches agent's contracts)
    - [x] GetShipsQuery: No parameters (fetches agent's ships)
    - [x] Response types: `List<Contract>` and `List<Ship>` (from SpaceTraders.Api.Models)

- [x] **Implement Query Handlers (High Priority)**
  - [x] **Location**: `src/AstroTrade.Core/Features/Contracts/GetContractsHandler.cs` and `src/AstroTrade.Core/Features/Ships/GetShipsHandler.cs`
  - [x] **Details**:
    - [x] Implement `IQueryHandler<GetContractsQuery, List<Contract>>` and similar for ships
    - [x] Inject `ApiClient` in constructor
    - [x] In Handle method: Call appropriate API endpoints (e.g., `await _apiClient.My.Contracts.GetAsync()`)
    - [x] Return fetched data directly (mappers handled separately if needed)

- [x] **Add Data Mappers (Medium Priority)**
  - [x] **Location**: `src/AstroTrade.Core/Mappers/ContractMapper.cs` and `src/AstroTrade.Core/Mappers/ShipMapper.cs`
  - [x] **Details**:
    - [x] Static methods to convert API models to domain/UI models if needed
    - [x] For now, API models may suffice; add if UI requires different structure
    - [x] Example: `public static DomainContract Map(Contract apiContract)`

- [x] **Update DashboardViewModel (High Priority)**
  - [x] **Location**: `src/AstroTrade.Core/Features/Dashboard/DashboardViewModel.cs`
  - [x] **Details**:
    - [x] Inject `IMediator` in constructor
    - [x] Add `public async Task InitializeAsync()` method
    - [x] In InitializeAsync: Send queries via `_mediator.Send(new GetContractsQuery())` and `GetShipsQuery()`
    - [x] Set Contracts and FleetShips properties with results
    - [x] Add error handling: Try-catch, set error message if fails

- [x] **Update DashboardView (Medium Priority)**
  - [x] **Location**: `src/AstroTrade.TUI/Views/DashboardView.cs`
  - [x] **Details**:
    - [x] Override `OnActivated()` to call `await (ViewModel as DashboardViewModel)?.InitializeAsync()`
    - [x] Add loading indicators (e.g., disable buttons during load)
    - [x] Handle errors: Bind to ViewModel error property, show message dialog if present

- [x] **Register in DI (Low Priority)**
  - [x] **Location**: Already handled via Mediator assemblies in `src/AstroTrade.TUI/DependencyInjection/Extensions.cs`
  - [x] **Details**: No changes needed; Mediator auto-discovers handlers in Core assembly

- [x] **Verify Integration (High Priority)**
  - [x] **Details**:
    - [x] Run `dotnet run .build/targets.cs build` and `dotnet run .build/targets.cs test`
    - [x] Test in TUI: Navigate to dashboard, verify lists populate with real API data
    - [x] Handle auth issues: Ensure token is loaded from config or registration

## Dependencies

- Steps 1-2 are independent
- Step 3 can be done in parallel
- Step 4 depends on 1-2
- Step 5 depends on 4
- Steps 6-7 depend on previous

## Success Criteria

- Dashboard loads contracts and ships on navigation
- Data updates UI without blocking
- Errors are handled gracefully
- Code follows MVVM/DI patterns
