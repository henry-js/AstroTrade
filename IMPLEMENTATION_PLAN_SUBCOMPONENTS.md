# Implementation Plan: Extract Dashboard Subcomponents

## Overview

Extract the contracts list and fleet overview from embedded `FrameView` + `ListView` in `DashboardView` into separate reusable `View` components. Pass data (`List<Contract>`/`List<Ship>`) directly in constructors for simplicity—no child ViewModels needed. Parent `DashboardViewModel` loads data and passes it; subcomponents handle display and raise selection events to parent.

## Architecture

- **ContractsListView**: Takes `List<Contract>` in constructor, displays in ListView, raises `ContractSelected` event
- **FleetOverviewView**: Takes `List<Ship>` in constructor, displays in ListView, raises `ShipSelected` event
- **DashboardViewModel**: Loads data in `InitializeAsync`, passes to sub-views
- **DashboardView**: Instantiates sub-views with data, handles events for navigation

## Detailed Steps

- [x] **Create ContractsListView**
  - [x] **Location**: `src/AstroTrade.TUI/Views/ContractsListView.cs`
  - [x] **Details**:
    - [x] Inherits `View`
    - [x] Constructor takes `List<Contract> contracts` (modified to default + UpdateContracts)
    - [x] Creates `ListView` with columns (ID, Type, Payment, Deadline)
    - [x] Binds to passed list
    - [x] Handles selection, raises `ContractSelected` event with selected contract

- [x] **Create FleetOverviewView**
  - [x] **Location**: `src/AstroTrade.TUI/Views/FleetOverviewView.cs`
  - [x] **Details**:
    - [x] Inherits `View`
    - [x] Constructor takes `List<Ship> ships` (modified to default + UpdateShips)
    - [x] Creates `ListView` with columns (Symbol, Location, Status, Cargo)
    - [x] Binds to passed list
    - [x] Handles selection, raises `ShipSelected` event with selected ship

- [x] **Update DashboardViewModel**
  - [x] **Location**: `src/AstroTrade.Core/Features/Dashboard/DashboardViewModel.cs`
  - [x] **Details**:
    - [x] Keep `InitializeAsync` loading `Contracts` and `FleetShips`
    - [x] No changes needed beyond data loading

- [x] **Update DashboardView**
  - [x] **Location**: `src/AstroTrade.TUI/Views/DashboardView.cs`
  - [x] **Details**:
    - [x] Replace embedded `FrameView` + `ListView` with `ContractsListView` and `FleetOverviewView`
    - [x] In `InitializeLayout`, instantiate with `((DashboardViewModel)ViewModel).Contracts` and `FleetShips`
    - [x] Subscribe to sub-view events, handle for navigation (e.g., select contract → navigate to contracts)

- [x] **Register New Views in DI**
  - [x] **Location**: `src/AstroTrade.TUI/DependencyInjection/Extensions.cs`
  - [x] **Details**: Add transients for `ContractsListView` and `FleetOverviewView`

- [x] **Verify Integration**
  - [x] **Details**:
    - [x] Build and test
    - [x] Ensure subcomponents display data and handle selection
    - [x] Check reusability (can instantiate elsewhere with data)

## Dependencies

- Steps 1-2 are independent
- Step 3 depends on existing data loading
- Step 4 depends on 1-2
- Steps 5-6 depend on previous

## Success Criteria

- Subcomponents are modular and reusable
- Data flows from parent VM to sub-views via constructors
- Selection events trigger parent navigation
- Code remains simple, no unnecessary VMs
