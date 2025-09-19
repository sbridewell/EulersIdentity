# Project Summary - Euler's Identity

## Overview
Euler's Identity is a mathematical expression that combines several fundamental constants and operations. This solution provides a .NET 8 implementation for working with polynomials and equations, including operations such as addition, subtraction, multiplication, and division of polynomial terms.

## Projects

### EulersIdentity
- **Purpose**: Contains the core library for polynomial and equation operations.
- **Key Classes**:
  - `Polynomial`: Represents a polynomial and supports operations like addition, subtraction, multiplication, and division.
  - `Equation`: Represents a mathematical equation with polynomial expressions on both sides.
  - `PolynomialTerm`: Represents a single term in a polynomial.
- **Key Interfaces**:
  - `IPolynomial`: Defines the contract for polynomial operations.
  - `IEquation`: Defines the contract for equation operations.
- **Issues**:
  - Currently none

### EulersIdentity.Test
- **Purpose**: Contains unit tests for the core library.
- **Testing Frameworks**: XUnit for testing and FluentAssertions for assertions.
- **Key Test Classes**:
  - `PolynomialTest`: Tests the `Polynomial` class, including its `ToString` method, arithmetic operations, and constructor.
  - `EquationTest`: Tests the `Equation` class.
  - `PolynomialTermTest`: Tests the `PolynomialTerm` class.
- **Issues**:
  - Currently none

### EulersIdentity.WPF (not currently being progressed)
- **Purpose**: A WPF application to demonstrate the functionality of the `PolynomialTerm`, `Polynomial`, and `Equation` classes.
- **Key Features**:
  - A `TabControl` with three tabs: `PolynomialTerm`, `Polynomial`, and `Equation`.
  - The `PolynomialTerm` tab allows users to create and evaluate polynomial terms.
  - Debugging functionality to log property changes in the `MainViewModel`.
  - Data persistence across tabs.
- **Key Classes**:
  - `MainViewModel`: The main ViewModel for the application, managing tab states and debug messages.
  - `PolynomialTermControl`: A user control for creating and evaluating polynomial terms.
  - `PolynomialContainer`: A user control for managing and displaying polynomial-related data or functionality.
  - `PolynomialContainerViewModel`: Handles the logic for evaluating polynomials and managing the `PolynomialControlViewModel`.
  - `PolynomialControlViewModel`: Manages the state of the `PolynomialControl` user control, including adding, removing, and evaluating polynomial terms.
  - `FloatingPointInputBehaviour`: Restricts `TextBox` input to valid floating-point numbers.
  - `ValidationBehaviour`: Provides an attached property to apply validation rules to a `TextBox`.
- **Issues**:
  - I don't have enough knowledge of MVVM and databinding best practices to implement this correctly.

### EulersIdentity.WPF.Test (not currently being progressed)
- **Purpose**: Contains unit tests for the WPF application.
- **Testing Frameworks**: XUnit for testing and FluentAssertions for assertions.
- **Key Test Classes**:
  - `MainViewModelTest`: Tests the `MainViewModel` class.
  - `PolynomialTermControlTest`: Tests the `PolynomialTermControl` user control.
  - `PolynomialContainerViewModelTest`: Tests the `PolynomialContainerViewModel` class, including its `EvaluateCommand` and property updates.
  - `PolynomialControlViewModelTest`: Tests the `PolynomialControlViewModel` class, including its `ToPolynomial`, `AddTermCommand`, and `CanRemoveTerm` methods.
  - `FloatingPointInputBehaviourTest`: Tests the `FloatingPointInputBehaviour` class.
  - `ValidationBehaviourTest`: Tests the `ValidationBehaviour` class.

### EulersIdentity.WPF.UI.Test (not currently being progressed)
- **Purpose**: Contains UI tests for the WPF application.
- **Testing Frameworks**: LightBDD for behaviour-driven development and FluentAssertions for assertions.
- **Key Test Classes**:
  - `MainWindowTest`: Tests the `MainWindow` class.
  - `PolynomialTermTabTest`: Tests the `PolynomialTerm` tab functionality, including updates to `PolynomialTermAndResultTextBlock` when the user edits the coefficient, exponent, or value of `x`.
- **Issues**:
  - Tests occasionally throw a COMException `Error HRESULT E_FAIL has been returned from a call to a COM component`. Cause not yet known.

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
  - The "Add Term" button in the `PolynomialControl` user control is disabled due to the `CanAddTerm` method not being invoked. This issue is under investigation.
  - There is an outstanding bug in the `PolynomialTermControl` where the `XValueTextBox` control is not correctly validating or displaying user input, causing related UI tests to fail.

## Recent Updates
- Added dynamic raising of `CanExecuteChanged` for `AddTermCommand` and `EvaluateCommand` in `PolynomialControlViewModel` when the `Terms` collection changes.
- Verified the `RelayCommand` implementation for correctness.
- Added unit tests for `PolynomialControlViewModel` to cover `AddTermCommand` and `CanAddTerm` logic.
- Enhanced `PolynomialTermAndResult` to handle edge cases, such as negative `x` values with non-integer exponents, returning `NaN` as expected.

## Future Work
- Consolidate test framework references in the `EulersIdentity.WPF.Test` project to eliminate duplicate test methods in the test explorer.
- Extend the application to demonstrate more advanced polynomial and equation operations.
- Add support for parsing polynomials and equations from strings.
- Improve performance for large polynomials.
- Implement additional features in the `Polynomial` and `Equation` tabs.
- Fix the `XValueTextBox` validation and display issue in the `PolynomialTermControl`.
- Resolve the issue with the "Add Term" button in the `PolynomialControl` user control.

## Licensing
This solution is released under the MIT license. See `LICENSE.txt` in the repository root for details.

