# Unit Testing Guidelines for AstroTrade

## Overview

This document establishes the definitive standards and idioms for writing unit tests in the AstroTrade project. All tests must adhere strictly to these guidelines to ensure consistency, maintainability, and quality. The reference implementation in `src/AstroTrade.Tests/Features/Dashboard/DashboardTests.cs` serves as the canonical example—**deviate at your own risk**.

## General Principles

- **Framework**: Use TUnit for test execution.
- **Mocking**: Use NSubstitute for dependency mocking.
- **Assertions**: Use AwesomeAssertions for fluent, readable assertions.
- **Async**: All test methods must be `public async Task` (no synchronous tests).
- **Isolation**: Tests must be independent; no shared state between tests.
- **Naming**: Follow `{Method}_{Scenario}_{ExpectedResult}` convention (e.g., `InitializeAsync_ValidQueries_SetsContractsAndShips`).
- **Structure**: Use Arrange-Act-Assert (AAA) pattern with comments where clarity is needed.

## Test Structure and Syntax

- **Test Class**: `[TestFixture] public class {FeatureName}Tests`.
  - Add using directives at top of test class:
    - `using TUnit.Core;`
    - `using NSubstitute;`
    - `using AwesomeAssertions;`
    - `using AstroTrade.Core.Features.{FeatureName};`
- **Nested Classes**: Group tests by component (e.g., `public class {ComponentName}Tests`).
- **Setup**: Use `[BeforeEach] public async Task Setup()` for initializing mocks and test subjects.
- **Test Methods**: `[Test] public async Task {DescriptiveName}()`.
- **Imports**: Include `using TUnit.Core;`, `using NSubstitute;`, `using AwesomeAssertions;`, and feature-specific usings.
- **Reference**: See `DashboardTests.cs` for exact syntax (e.g., nested classes, setup methods, test naming).

## Mocking with NSubstitute

- Create mocks: `var mock = Substitute.For<IInterface>();`.
- Configure returns: `mock.Method(Arg.Any<Param>()).Returns(expectedValue);`.
- Verify calls: `mock.Received().Method(Arg.Any<Param>());` or `mock.DidNotReceive().Method();`.
- Exceptions: `mock.Method().Throws(new Exception("message"));`.
- **Idiom**: Mock all dependencies in setup; avoid over-mocking.

## Assertions with AwesomeAssertions

- Equality: `result.Should().Be(expected);`.
- Collections: `list.Should().BeEquivalentTo(expectedList);`.
- Exceptions: `await Assert.ThrowsAsync<Exception>(() => method());`.
- Events: `monitor.Should().RaisePropertyChangeFor(vm => vm.Property);`.
- Nulls: `value.Should().BeNull();` or `value.Should().NotBeNull();`.
- **Idiom**: Prefer fluent assertions over classic Assert; chain for readability.

## Quality Assurance

- **Code Reviews**: Require peer reviews for test PRs using the checklist in `TEST_QUALITY_CHECKLIST.md`.
- **CI/CD Checks**: Automate validation of test syntax (e.g., async methods, naming conventions) in pipelines.
- **Linting**: Use Roslyn analyzers or EditorConfig to enforce idioms at build time.
- **Templates**: Provide code snippets for consistent test structure.
- **Quality Metrics**: Track separately (e.g., mutation testing scores in AGENTS.md), not tied to test writing.
- Run tests: `dotnet run .build/targets.cs test`.
- Build: `dotnet build AstroTrade.Tests/AstroTrade.Tests.csproj` before running.
- Documentation: Update AGENTS.md with test summaries post-implementation.

## Examples

Refer to `src/AstroTrade.Tests/Features/Dashboard/DashboardTests.cs` for complete examples:

- ViewModel testing (initialization, commands, events).
- Error handling and mocking patterns.
- Async task structures.

## Enforcement

- **Mandatory**: All new tests must match the style in `DashboardTests.cs`.
- **Review**: Pull requests with tests deviating from these guidelines will be rejected.
- **Updates**: If standards evolve, update this document and the reference file accordingly.

This guide is static and applies project-wide. For feature-specific implementation steps, refer to `UNIT_TESTING_IMPLEMENTATION_PLAN.md`.
