# AstroTrade TUI Screen Designs

## Overview

This document outlines the proposed screen designs for the AstroTrade Terminal User Interface (TUI) application, built using `Terminal.Gui` and the SpaceTraders API.

## Navigation and Controls

### Menu-based Navigation

- **Implementation**: Extend the existing `MenuBar` in `ShellView` with a "Game" menu containing:
  - Dashboard
  - Ships
  - Markets
  - Contracts
  - Systems
- **Functionality**: Each menu item switches the content of the `mainFrame` to the corresponding view.
- **Alternative**: A `TabView` within the `mainFrame` could be used for tabbed navigation.

### Keyboard Shortcuts

- **Global Hotkeys**: Use the `MenuBar` for global navigation shortcuts (e.g., `Alt+G` then `S` for the Ships screen). These should be consistent across the application.
- **Contextual Hotkeys**: Use function keys (F1, F2, etc.) and other simple keys (`Enter`) for actions specific to the current view. These actions should be clearly labeled at the bottom of the screen.

## Core UI Elements

### Log Area

- **Location**: The existing `logFrame` in `ShellView`.
- **Implementation**: A `TextView` with scrollable content.
- **Content**: A timestamped event log including:
  - Ship movements and status changes
  - Trade executions
  - Contract updates
  - API responses and errors
  - System notifications
- **Styling**: Use `ColorScheme` to color-code messages (e.g., success=green, error=red, info=blue) for readability.

### Status Bar

- **Location**: A dedicated `StatusBar` at the bottom of the main window.
- **Content**: Display persistent, global information:
  - API Connection Status (Online/Offline)
  - Current Game Time (UTC)
  - Essential global shortcuts (`Ctrl+Q` to Quit).

## Screen Designs

### 1. Dashboard Screen

**Purpose**: Main overview screen showing agent status, active contracts, and fleet summary.

**Layout**: 3-panel layout in `mainFrame`.

- **Top Section**: Enhanced `AgentBar` displaying:
  - Agent Symbol, Credits, Ship Count, Headquarters, Faction.
- **Left Panel**: Active contracts list (`TableView`).
  - Columns: Status, Type, Reward, Deadline.
  - **Styling**: Status column should be color-coded for at-a-glance understanding.
- **Right Panel**: Fleet overview (`ListView` or custom view).
  - Shows ship name, location, status, and a `ProgressBar` for cargo utilization.
- **Bottom Section**: Quick action buttons (`Navigate Ship`, `View Market`, `Fulfill Contract`).

┌───────────────────────────────────────────────────────────────────────────────────────────────┐
│ File  Game  Options  Help                                                                     │
├───────────────────────────────────────────────────────────────────────────────────────────────┤
│ Agent: COBOLD-1   Credits: ¢1,250,450   Ships: 4   HQ: X1-DF55-A1   Faction: COSMIC           │
├───────────────────────────────────────────────────────────────────────────────--──────────────┤
│ ┌─ Active Contracts (3) ───────────────┐ ┌─ Fleet Overview (4 Ships) ───────--───┐            │
│ │ Status    Type          Reward    Dlvr │ │ > STAR-JUMPER   XE-01   Docked      │            │
│ │>IN_PROG   PROCUREMENT   150,240   1/2  │ │   Cargo: [░░░░░░░░░░] 0/60          │            │
│ │ ACCEPTED  TRANSPORT     85,000    -    │ │                                     │            │
│ │ ACCEPTED  PROCUREMENT   210,000   -    │ │   VOID-DRIFTER  XE-01   In Orbit    │            │
│ │                                        │ │   Cargo: [██████░░░░] 30/60 IRON ORE│            │
│ │                                        │ │                                     │            │
│ │                                        │ │   ORE-HOUND     XE-02   In Transit  │            │
│ │                                        │ │   Arrival: 2m 15s                   │            │
│ │                                        │ │                                     │            │
│ │                                        │ │   RUST-BUCKET   XE-01   Docked      │            │
│ │                                        │ │   Cargo: [██████████] 60/60 COPPER  │            │
│ └────────────────────────────────────────┘ └─────────────────────────────────────┘            │
│                                                                                               │
│              [ Navigate Ship (F1) ] [ View Market (F2) ] [ Fulfill Contract (F3) ]            │
├───────────────────────────────────────────────────────────────────────────────────────────────┤
│ 10:32:15 [INFO] Application started.                                                          │
│ 10:32:18 [SUCCESS] Fetched agent data for COBOLD-1.                                           │
│>                                                                                              │
└───────────────────────────────────────────────────────────────────────────────────────────────┘

### 2. Ships Management Screen

**Purpose**: Detailed ship management and control interface.

**Layout**: Split view.

- **Top Panel**: Filter and search bar.
  - Filter by status (docked, in-transit, etc.), location, and ship type.
- **Left Panel**: Ships list (`TableView`).
  - Columns: Name, Type, Location, Status, Cargo (current/max).
  - **Styling**: The Status column should be color-coded (e.g., blue for in-transit, green for docked).
- **Right Panel**: Selected ship details.
  - Cargo inventory (expandable list).
  - Installed modules and mounts.
  - Fuel level (`ProgressBar`).
  - Current cooldown status (`ProgressBar` showing time remaining).
- **Bottom Panel**: Action buttons (`Navigate`, `Extract`, `Refuel`, etc.).

┌───────────────────────────────────────────────────────────────────────────────────────────────┐
│ File  Game  Options  Help                                                                     │
├───────────────────────────────────────────────────────────────────────────────────────────────┤
│ Agent: COBOLD-1   Credits: ¢1,250,450   Ships: 4   HQ: X1-DF55-A1   Faction: COSMIC           │
├───────────────────────────────────────────────────────────────────────────────────────────────┤
│ Filter: [ Docked              ] Search: [ STAR-JUMPER        ]                                │
├───────────────────────────────────────────────────────────────────────────────────────────────┤
│ ┌─ Ships (4) ─────────────────────────┐ ┌─ STAR-JUMPER (SHIP_MINING_DRONE) ────-──┐           │
│ │ Name            Location  Status    │ │ Cargo (0/60):                           │           │
│ │ > STAR-JUMPER   XE-01     Docked    │ │   <Empty>                               │           │
│ │   VOID-DRIFTER  XE-01     In Orbit  │ │                                         │           │
│ │   ORE-HOUND     XE-02     In Transit│ │ Cooldown: [Ready]                       │           │
│ │   RUST-BUCKET   XE-01     Docked    │ │ Fuel: [██████████] 100/100              │           │
│ │                                     │ │                                         │           │
│ │                                     │ │ Mounts:                                 │           │
│ │                                     │ │ - MOUNT_MINING_LASER_II                 │           │
│ │                                     │ │ - MOUNT_SURVEYOR_I                      │           │
│ │                                     │ │                                         │           │
│ └─────────────────────────────────────┘ └─────────────────────────────────────────┘           │
│                                                                                               │
│ [ Navigate (F1) ] [ Jettison Cargo (F2) ] [ Extract (F3) ] [ Refuel (F4) ] [ Sell Ship ]      │
├───────────────────────────────────────────────────────────────────────────────────────────────┤
│ 10:34:02 [INFO] Navigated to Ships screen.                                                    │
│>                                                                                              │
└───────────────────────────────────────────────────────────────────────────────────────────────┘

### 3. Markets Screen

**Purpose**: View market prices and execute trades.

**Layout**: 3-panel layout.

- **Top Section**: System/waypoint selector.
  - Current system and waypoint, with jump navigation controls.
- **Left Panel**: Goods table (`TableView`).
  - Columns: Good Name, Buy Price, Sell Price, Available Quantity, Supply Level.
  - **Styling**: Buy prices colored green, sell prices colored red to prevent errors. Consider a text-based **sparkline** (`[▂▅▃▇]`) for price history if API data is available.
- **Right Panel**: Ship cargo view and trade calculator.
  - Current cargo, available credits, and trade volume calculator.
- **Bottom Panel**: Trade controls (Buy/Sell amount inputs, confirm buttons).

┌───────────────────────────────────────────────────────────────────────────────────────────────┐
│ File  Game  Options  Help                                                                     │
├───────────────────────────────────────────────────────────────────────────────────────────────┤
│ Agent: COBOLD-1   Credits: ¢1,250,450   Ships: 4   HQ: X1-DF55-A1   Faction: COSMIC           │
├───────────────────────────────────────────────────────────────────────────────────────────────┤
│ System: X1-DF55   Waypoint: X1-DF55-A1 (ORBITAL_STATION)   [ Jump... ]                        │
├───────────────────────────────────────────────────────────────────────────────────────────────┤
│ ┌─ Market Goods ───────────────────────┐ ┌─ RUST-BUCKET Cargo (60/60) ──────--─────┐          │
│ │ Good Name       Buy     Sell   Supply│ │   COPPER ORE      x60                   │          │
│ │   IRON ORE      12      8      HIGH  │ │                                         │          │
│ │ > COPPER ORE    18      14     HIGH  │ │ Your Credits: ¢1,250,450                │          │
│ │   ALUMINUM ORE  25      19     MEDIUM│ │                                         │          │
│ │   SILICON       -       35     LOW   │ │ --- Trade Calculator ---                │          │
│ │   HYDROCARBON   -       42     LOW   │ │ Action:  [ Sell          ]              │          │
│ │                                      │ │ Amount:  [ 60            ] (Max: 60)    │          │
│ │                                      │ │ Price/Unit: ¢14                         │          │
│ │                                      │ │ Total:       ¢840                       │          │
│ └──────────────────────────────────────┘ └─────────────────────────────────────────┘          │
│                                                                                               │
│                                           [ Confirm Trade (Enter) ]                           │
├───────────────────────────────────────────────────────────────────────────────────────────────┤
│ 10:35:11 [SUCCESS] Sold 60 units of COPPER ORE for ¢840.                                      │
│>                                                                                              │
└───────────────────────────────────────────────────────────────────────────────────────────────┘

### 4. Contracts Screen

**Purpose**: View and manage SpaceTraders contracts.

**Layout**: Master-detail view.

- **Left Panel**: Contracts list (`TableView`).
  - Columns: Contract ID, Type, Status, Reward, Deadline.
  - **Styling**: Status column color-coded (e.g., yellow for accepted, green for fulfilled).
- **Right Panel**: Details for the selected contract.
  - Terms and conditions.
  - Deliverables progress shown with a `ProgressBar` (e.g., `[███░░░] 30/100`).
  - Required goods with quantities.
- **Bottom Panel**: Contract action buttons (`Accept`, `Deliver Goods`, `Fulfill`).

┌───────────────────────────────────────────────────────────────────────────────────────────────┐
│ File  Game  Options  Help                                                                     │
├───────────────────────────────────────────────────────────────────────────────────────────────┤
│ Agent: COBOLD-1   Credits: ¢1,250,450   Ships: 4   HQ: X1-DF55-A1   Faction: COSMIC           │
├───────────────────────────────────────────────────────────────────────────────────────────────┤
│ ┌─ Available Contracts (3) ────────────┐ ┌─ Contract Details (cln-a4f8-1) ──────----──┐       │
│ │ ID          Type          Status      │ │ Faction: United Colonies                  │       │
│ │ > cln-a4f8-1  PROCUREMENT   IN_PROGRESS │ │ Type: PROCUREMENT                       │       │
│ │   cln-b9c2-2  TRANSPORT     ACCEPTED    │ │ Reward: ¢150,240 on completion          │       │
│ │   cln-d1e5-3  PROCUREMENT   ACCEPTED    │ │ Deadline: 2025-10-12 14:30 UTC          │       │
│ │                                       │ │                                           │       │
│ │                                       │ │ Terms:                                    │       │
│ │                                       │ │ Deliver 100 units of IRON ORE to          │       │
│ │                                       │ │ waypoint X1-DF55-C3.                      │       │
│ │                                       │ │                                           │       │
│ │                                       │ │ Progress: [█████░░░░░] 50/100             │       │
│ └───────────────────────────────────────┘ └───────────────────────────────────────────┘       │
│                                                                                               │
│                                      [ Deliver Goods... ] [ Fulfill Contract ]                │
├───────────────────────────────────────────────────────────────────────────────────────────────┤
│ 10:36:20 [INFO] Accepted contract cln-b9c2-2.                                                 │
│>                                                                                              │
└───────────────────────────────────────────────────────────────────────────────────────────────┘

### 5. Systems Exploration Screen

**Purpose**: Explore star systems, waypoints, and plan navigation.

**Layout**: 3-panel layout.

- **Left Panel**: Systems tree/hierarchy (`TreeView`).
  - Systems sorted by distance, expandable to show waypoints.
- **Center Panel**: Waypoints list for the selected system (`TableView`).
  - Columns: Symbol, Type, Traits, Has Market, Has Shipyard.
- **Right Panel**: Details for the selected waypoint.
  - Traits and properties (e.g., `MARKETPLACE`, `SHIPYARD`).
  - Market prices and shipyard inventory (if available), with buttons to navigate to those screens.
  - Jump gate connections.
- **Bottom Panel**: Exploration action buttons (`Chart`, `Create Survey`, `Jump`).

┌───────────────────────────────────────────────────────────────────────────────────────────────┐
│ File  Game  Options  Help                                                                     │
├───────────────────────────────────────────────────────────────────────────────────────────────┤
│ Agent: COBOLD-1   Credits: ¢1,250,450   Ships: 4   HQ: X1-DF55-A1   Faction: COSMIC           │
├───────────────────────────────────────────────────────────────────────────────────────────────┤
│ ┌─ Systems ──────────┐ ┌ Waypoints in X1-DF55 ────────────┐ ┌ Details: X1-DF55-A1 ──────────┐ │
│ │ > X1-DF55 (0 ly)  │ │ > X1-DF55-A1   ORBITAL_STATION │ │ Symbol: X1-DF55-A1               │ │
│ │   ├─ X1-DF55-A1    │ │   X1-DF55-B2   GAS_GIANT     │ │ Type: ORBITAL_STATION             │ │
│ │   ├─ X1-DF55-B2    │ │   X1-DF55-C3   ASTEROID_FIELD│ │ Traits:                           │ │
│ │   └─ X1-DF55-C3    │ │                              │ │ - MARKETPLACE                     │ │
│ │   X2-GT88 (15 ly) │ │                              │ │ - SHIPYARD                         │ │
│ │   X3-ZB12 (22 ly) │ │                              │ │ - VIBRANT_AURORAS                  │ │
│ │                   │ │                              │ │                                    │ │
│ │                   │ │                              │ │ Services:                          │ │
│ │                   │ │                              │ │ - Market Access [View]             │ │
│ │                   │ │                              │ │ - Shipyard Access [View]           │ │
│ └───────────────────┘ └────────────────────────────────┘ └──────────────────────────────────┘ │
│                                                                                               │
│                                      [ Chart Waypoint ] [ Scan Waypoints ]                    │
├───────────────────────────────────────────────────────────────────────────────────────────────┤
│ 10:38:00 [INFO] Scanned 3 waypoints in system X1-DF55.                                        │
│>                                                                                              │
└───────────────────────────────────────────────────────────────────────────────────────────────┘

## Technical Implementation Notes

- **View Architecture**: Each screen will be a separate `View` or `Window` class with a corresponding `ViewModel` following the MVVM pattern.
- **Dedicated API Service**: A singleton service class will encapsulate all Kiota-generated client interactions. This service will handle API calls, error handling, rate limiting, and caching, providing a clean interface to the ViewModels.
- **Global State Manager**: A shared service will manage global state (e.g., agent credits, ship count) and notify subscribers (like the `AgentBar`) of changes via events.
- **Modal Dialogs for Actions**: Complex actions (e.g., navigating a ship, delivering goods) will be handled in modal `Dialogs`. This keeps the main views focused and uncluttered.
- **Data Binding**: Use ViewModel `PropertyChanged` events to update the UI.
- **Layout**: Use responsive layout controls like `Dim.Fill()` and `Pos.AnchorEnd()` for a flexible UI.
- **Styling**:
  - Utilize shared components like `HeaderLabel` and `AgentBar` for consistency.
  - Implement custom `ColorScheme` objects to apply strategic colouring to controls and text as outlined in the screen designs.

## Future Enhancements

- **Real-time Updates**: Integrate WebSocket or signal listeners for real-time game state updates without constant polling.
- **Advanced Keybindings**: Allow for user-configurable keyboard shortcuts.
- **Custom Themes**: Implement a system for users to select different color schemes for the entire application.
