# Test Quality Checklist

Use this checklist during code reviews for unit test PRs to ensure adherence to UNIT_TESTING_GUIDELINES.md and high-quality test design.

## Syntax and Structure

- [ ] All test methods are `public async Task` (no synchronous tests).
- [ ] Naming follows `{Method}_{Scenario}_{ExpectedResult}` convention.
- [ ] Tests use Arrange-Act-Assert structure with comments if needed.
- [ ] Nested classes group tests by component appropriately.
- [ ] `[BeforeEach]` setup initializes mocks and test subjects correctly.

## Mocking and Dependencies

- [ ] NSubstitute used for all mocks (`Substitute.For<T>()`).
- [ ] All dependencies mocked; no real implementations in unit tests.
- [ ] Mock configurations are realistic and cover scenarios.
- [ ] Verifications use `Received()` or `DidNotReceive()` appropriately.

## Assertions and Coverage

- [ ] AwesomeAssertions used for fluent assertions (e.g., `.Should().Be()`).
- [ ] Tests cover happy paths, error conditions, and edge cases.
- [ ] All public APIs have at least one test with meaningful scenarios.
- [ ] No superficial tests added just to increase metrics.

## Quality and Best Practices

- [ ] Tests are independent and isolated (no shared state).
- [ ] Async operations tested properly (e.g., cancellation tokens).
- [ ] Error handling tested (exceptions, invalid inputs).
- [ ] Code follows the style in `DashboardTests.cs` exactly.

## Review Process

- [ ] PR includes links to guidelines and reference examples.
- [ ] CI/CD passes without syntax errors.
- [ ] Reviewer confirms no deviations from standards.

If any item is unchecked, request revisions before merging.
