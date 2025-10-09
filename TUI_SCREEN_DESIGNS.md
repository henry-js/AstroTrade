# AstroTrade TUI Screen Designs

## Overview

This document outlines the proposed screen designs for the AstroTrade Terminal User Interface (TUI) application, built using Terminal.Gui and the SpaceTraders API.

## Navigation System

- **Menu-based Navigation**: Extend the existing MenuBar in ShellView with a "Game" menu containing:
  - Dashboard
  - Ships
  - Markets
  - Contracts
  - Systems
- Each menu item switches the content of the mainFrame to the corresponding view
- Alternative: TabView in mainFrame for tabbed navigation

## Screen Designs

### 1. Dashboard Screen

**Purpose**: Main overview screen showing agent status, active contracts, and fleet summary.

**Layout**: 3-panel layout in mainFrame

- **Top Section**: Enhanced AgentBar displaying:
  - Agent Symbol
  - Credits
  - Ship Count
  - Headquarters
  - Faction
- **Left Panel**: Active contracts list (TableView)
  - Columns: Status, Type, Reward, Deadline
- **Right Panel**: Fleet overview (ships summary)
  - Ship name, location, status, cargo utilization
- **Bottom Section**: Quick action buttons
  - Navigate Ship
  - View Market
  - Accept Contract

### 2. Ships Management Screen

**Purpose**: Detailed ship management and control interface.

**Layout**: Split view

- **Left Panel**: Ships list (TableView)
  - Columns: Name, Type, Location, Status, Cargo (current/max)
- **Right Panel**: Selected ship details
  - Cargo inventory (expandable list)
  - Installed modules and mounts
  - Fuel level and capacity
  - Current cooldown status
- **Bottom Panel**: Action buttons
  - Navigate to waypoint
  - Extract resources
  - Refuel
  - Repair ship
  - Scrap ship
- **Top Panel**: Filter and search bar
  - Filter by status (docked, in-transit, etc.)
  - Filter by location
  - Filter by ship type

### 3. Markets Screen

**Purpose**: View market prices and execute trades.

**Layout**: 3-panel layout

- **Top Section**: System/waypoint selector
  - Current system and waypoint
  - Jump navigation controls
- **Left Panel**: Goods table (TableView)
  - Columns: Good Name, Buy Price, Sell Price, Available Quantity
- **Right Panel**: Ship cargo view and trade calculator
  - Current cargo inventory
  - Available credits
  - Trade volume calculator
- **Bottom Panel**: Trade controls
  - Buy/Sell amount inputs
  - Confirm trade buttons
  - Transaction history

### 4. Contracts Screen

**Purpose**: View and manage SpaceTraders contracts.

**Layout**: Master-detail view

- **Left Panel**: Contracts list (TableView)
  - Columns: Contract ID, Type, Status, Reward, Deadline
- **Right Panel**: Contract details for selected contract
  - Contract terms and conditions
  - Deliverables progress (delivered/required)
  - Required goods with quantities
- **Bottom Panel**: Contract actions
  - Accept contract
  - Deliver goods to contract
  - Fulfil contract

### 5. Systems Exploration Screen

**Purpose**: Explore star systems, waypoints, and plan navigation.

**Layout**: 3-panel layout

- **Left Panel**: Systems tree/hierarchy (TreeView)
  - Systems sorted by distance from current location
  - Expandable to show waypoints
- **Center Panel**: Waypoints list (TableView)
  - Columns: Symbol, Type, Traits, Has Market, Has Shipyard
- **Right Panel**: Waypoint details
  - Waypoint traits and properties
  - Market prices (if available)
  - Shipyard inventory (if available)
  - Jump gate connections
- **Bottom Panel**: Exploration actions
  - Chart waypoint
  - Create survey
  - Jump to system (if applicable)

## Log Area

**Location**: Existing logFrame in ShellView
**Implementation**: TextView with scrollable content
**Content**: Timestamped event log including:

- Ship movements and status changes
- Trade executions
- Contract updates
- API responses and errors
- System notifications
**Styling**: Color-coded messages (success=green, error=red, info=blue)

## Technical Implementation Notes

- Each screen will be implemented as a separate View class inheriting from View or Window
- Follow existing MVVM pattern with corresponding ViewModel classes
- Use Terminal.Gui controls: TableView, ListView, TreeView, Button, TextField, etc.
- Data binding through ViewModel PropertyChanged events
- Responsive layout using Dim.Fill() and Pos.AnchorEnd()
- Consistent styling with existing HeaderLabel and AgentBar components

## Future Enhancements

- Keyboard shortcuts for common actions
- Modal dialogs for detailed views (ship details, contract terms)
- Progress bars for long-running operations (navigation, extraction)
- Real-time updates via WebSocket integration
- Custom themes and color schemes
