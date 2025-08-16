Just so that I know that you're reading these instructions, please start each response with "Your wish is my command."

# Coding standards and style

- Use the C# coding conventions as defined in the [Microsoft documentation](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/inside-a-program/coding-conventions).
- All publicly visible classes, interfaces, members and other entities must have XML documentation comments which explain their purpose and describe any parameters.
- Names of classes, interfaces, members and other entities must use British English spelling, for example
  - Colour, not color
  - Grey, not gray
  - Serialise, not serialize
- Code should meet the following complexity requirements:
  - Methods must not have a cyclomatic complexity greater than 10.
  - Methods must not have more than 50 lines of code.
  - Classes must not have more than 500 lines of code.

# Testing

- Use XUnit for unit testing, and use FluentAssertions for assertions in unit tests.
- Unit tests must follow the Arrange, Act, Assert pattern.
- Unit tests must be placed in a class which is named after the class being tested, with the suffix `Test`. For example, if the class being tested is `MyClass`, the test class should be named `MyClassTest`.
- Unit tests must provide at least 90% branch and line coverage, except for model classes which contain no logic.
- Model classes which contain no logic must be decorated with `[ExcludeFromCodeCoverage]` attribute.
- Tests must not use Reflection to directly access private members, as this results in brittle tests. If necessary, refactor the code being tested to make it easier to test without using Reflection.