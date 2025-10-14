# AstroTrade Agent Guidelines

## Build/Lint/Test Commands

### Build Commands

- **Full build**: `dotnet run .build/targets.cs build`
- **Restore dependencies**: `dotnet run .build/targets.cs restore`

### Test Commands

- **Run all tests**: `dotnet run .build/targets.cs test`
- **Run tests with coverage**: `dotnet run .build/targets.cs test` (coverage enabled by default)

### Alternative Scripts

- **PowerShell**: `./build.ps1 <target>` (e.g., `./build.ps1 test`)
- **Bash**: `./build.sh <target>` (e.g., `./build.sh build`)

## Code Style Guidelines

### General

- **Target Framework**: .NET 10.0
- **Nullable Reference Types**: Enabled
- **Implicit Usings**: Enabled
- **File-scoped Namespaces**: Preferred
- **Indentation**: 4 spaces
- **Line Endings**: CRLF

### Naming Conventions

- **Classes/Interfaces/Enums**: PascalCase
- **Methods/Properties/Events**: PascalCase
- **Local Variables/Parameters**: camelCase
- **Private Fields**: _camelCase
- **Constants**: PascalCase
- **Type Parameters**: TPrefix (e.g., `TValue`)

### Code Structure

- **Expression-bodied Members**: Use for accessors, properties, and lambdas where appropriate
- **Pattern Matching**: Preferred over `as` with null checks and `is` with cast checks
- **Collection Expressions**: Use when types loosely match
- **Null Propagation**: Preferred
- **Object Initializers**: Preferred
- **Auto Properties**: Preferred

### Imports and Organization

- **System Directives First**: Enabled
- **Separate Import Groups**: Enabled
- **Using Directive Placement**: Outside namespace

### Error Handling

- **Exception Handling**: Use try-catch blocks with specific exception types
- **Async Error Handling**: Use `await` in try-catch blocks
- **Logging**: Use Serilog for structured logging

### Architecture Patterns

- **CQRS**: Use Mediator for command/query separation
- **MVVM**: Use CommunityToolkit.Mvvm for view models
- **Dependency Injection**: Register services in DI containers
- **Repository Pattern**: Use for data access abstraction

### Testing

- **Framework**: TUnit with Microsoft.Testing.Platform
- **Test Organization**: Group related tests in classes
- **Data-driven Tests**: Use `[Arguments]`, `[MethodDataSource]`, or `[DataGenerator]`
- **Async Tests**: Use `async Task` for asynchronous test methods
- **Quality Tracking**: Monitor mutation testing scores and test robustness metrics separately from coverage; update this section with quarterly summaries
