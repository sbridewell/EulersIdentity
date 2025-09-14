# Project Summary - Euler's Identity

## Overview
Euler's Identity is a mathematical expression that combines several fundamental constants and operations. This solution provides a .NET 8 implementation for working with polynomials and equations, including operations such as addition, subtraction, multiplication, and division of polynomial terms.

## Projects

### 1. EulersIdentity.ConsoleApp
- **Purpose**: A console application that serves as the entry point for the solution.
- **Main File**: `Program.cs`
- **Functionality**: Outputs a welcome message and demonstrates Euler's Identity.

### 2. EulersIdentity
- **Purpose**: Contains the core library for polynomial and equation operations.
- **Key Classes**:
  - `Polynomial`: Represents a polynomial and supports operations like addition, subtraction, multiplication, and division.
  - `Equation`: Represents a mathematical equation with polynomial expressions on both sides.
  - `PolynomialTerm`: Represents a single term in a polynomial.
- **Key Interfaces**:
  - `IPolynomial`: Defines the contract for polynomial operations.
  - `IEquation`: Defines the contract for equation operations.

### 3. EulersIdentity.Test
- **Purpose**: Contains unit tests for the core library.
- **Testing Frameworks**: XUnit for testing and FluentAssertions for assertions.
- **Key Test Classes**:
  - `PolynomialTest`: Tests the `Polynomial` class, including its `ToString` method and arithmetic operations.
  - `EquationTest`: Tests the `Equation` class.
  - `PolynomialTermTest`: Tests the `PolynomialTerm` class.

### 4. EulersIdentity.WPF
- **Purpose**: A WPF application to demonstrate the functionality of the `PolynomialTerm`, `Polynomial`, and `Equation` classes.
- **Key Features**:
  - A `TabControl` with three tabs: `PolynomialTerm`, `Polynomial`, and `Equation`.
  - The `PolynomialTerm` tab allows users to create and evaluate polynomial terms.
  - Debugging functionality to log property changes in the `MainViewModel`.
  - Data persistence across tabs.
- **Key Classes**:
  - `MainViewModel`: The main ViewModel for the application, managing tab states and debug messages.
  - `PolynomialTermControl`: A user control for creating and evaluating polynomial terms.
  - `PolynomialTermContainerViewModel`: Handles the logic for displaying and updating polynomial terms and their results.
  - `FloatingPointInputBehaviour`: Restricts `TextBox` input to valid floating-point numbers.
  - `ValidationBehaviour`: Provides an attached property to apply validation rules to a `TextBox`.

### 5. EulersIdentity.WPF.Test
- **Purpose**: Contains unit tests for the WPF application.
- **Testing Frameworks**: XUnit for testing and FluentAssertions for assertions.
- **Key Test Classes**:
  - `MainViewModelTest`: Tests the `MainViewModel` class.
  - `PolynomialTermControlTest`: Tests the `PolynomialTermControl` user control.
  - `PolynomialTermContainerViewModelTest`: Tests the `PolynomialTermContainerViewModel` class, including its `PolynomialTermAndResult` property and `OnPolynomialTermPropertyChanged` method.
  - `FloatingPointInputBehaviourTest`: Tests the `FloatingPointInputBehaviour` class.
  - `ValidationBehaviourTest`: Tests the `ValidationBehaviour` class.

### 6. EulersIdentity.WPF.UI.Test
- **Purpose**: Contains UI tests for the WPF application.
- **Testing Frameworks**: LightBDD for behaviour-driven development and FluentAssertions for assertions.
- **Key Test Classes**:
  - `MainWindowTest`: Tests the `MainWindow` class.
  - `PolynomialTermTabTest`: Tests the `PolynomialTerm` tab functionality, including updates to `PolynomialTermAndResultTextBlock` when the user edits the coefficient, exponent, or value of `x`.

## Current State
- **Code Quality**: The solution adheres to Microsoft's C# coding conventions and includes XML documentation for all publicly visible entities.
- **Testing**:
  - Unit tests provide over 90% branch and line coverage.
  - Tests follow the Arrange-Act-Assert pattern.
- **Build**: The solution builds successfully without any warnings or errors.
- **Debugging**:
  - Debug messages are logged in the `MainViewModel` and displayed in the `MainWindow` when enabled.
  - Debugging can be toggled on or off using the `DebugEnabled` property.
- **Bugs**:
  - There is an outstanding bug in the `PolynomialTermControl` where the `XValueTextBox` control is not correctly validating or displaying user input, causing related UI tests to fail.

## Recent Updates
- Renamed `StringToSanitisedStringConverter` to `StringToSanitisedDoubleStringConverter` and updated all references.
- Added a `TextBlock` to `PolynomialTermContainer.xaml` to display the formatted polynomial term and its result.
- Expanded `PolynomialTermContainerViewModelTest` to provide full coverage of the `OnPolynomialTermPropertyChanged` method.
- Added UI tests to `PolynomialTermTabTest` to verify updates to `PolynomialTermAndResultTextBlock` when the user edits the coefficient, exponent, or value of `x`.
- Implemented `GetTextBlockValue` in `UITestBase` to support retrieving `TextBlock` values in UI tests.
- Enhanced `PolynomialTermAndResult` to handle edge cases, such as negative `x` values with non-integer exponents, returning `NaN` as expected.

## Future Work
- Consolidate test framework references in the `EulersIdentity.WPF.Test` project to eliminate duplicate test methods in the test explorer.
- Extend the application to demonstrate more advanced polynomial and equation operations.
- Add support for parsing polynomials and equations from strings.
- Improve performance for large polynomials.
- Implement additional features in the `Polynomial` and `Equation` tabs.
- Fix the `XValueTextBox` validation and display issue in the `PolynomialTermControl`.

## Licensing
This solution is released under the MIT license. See `LICENSE.txt` in the repository root for details.

