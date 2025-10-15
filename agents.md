# AstroTrade Agent Guidelines

## Build/Test Commands

- **Build**: `dotnet run .build/targets.cs build`
- **Test all**: `dotnet run .build/targets.cs test`
- **Test single**: `dotnet test --filter "FullyQualifiedName~TestClass.TestMethod"`
- **Restore**: `dotnet run .build/targets.cs restore`

## Code Style (.NET 10.0, Nullable enabled)

- **Namespaces**: File-scoped preferred
- **Naming**: PascalCase (classes/methods/properties), camelCase (locals/params), _camelCase (private fields)
- **Formatting**: 4 spaces, CRLF, expression-bodied members, pattern matching, null propagation
- **Imports**: Outside namespace, system first, separate groups
- **Error Handling**: Specific exceptions, Serilog logging, await in try-catch
- **Architecture**: CQRS (Mediator), MVVM (CommunityToolkit.Mvvm), DI containers, Repository pattern
- **Testing**: TUnit framework, [Arguments]/[MethodDataSource] for data-driven tests

## Project Resources (.ai directory)

- **.ai/checklists/**: Test quality checklist for code reviews
- **.ai/designs/**: Detailed TUI screen designs and layouts
- **.ai/guidelines/**: Comprehensive unit testing guidelines and standards
- **.ai/plans/**: Implementation plans for features (dashboard, subcomponents, etc.)
