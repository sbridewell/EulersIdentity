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

### 5. EulersIdentity.WPF.Test
- **Purpose**: Contains unit tests for the WPF application.
- **Testing Frameworks**: XUnit for testing and FluentAssertions for assertions.
- **Key Test Classes**:
  - `MainViewModelTest`: Tests the `MainViewModel` class.
  - `PolynomialTermControlTest`: Tests the `PolynomialTermControl` user control.

## Current State
- **Code Quality**: The solution adheres to Microsoft's C# coding conventions and includes XML documentation for all publicly visible entities.
- **Testing**:
  - Unit tests provide over 90% branch and line coverage.
  - Tests follow the Arrange-Act-Assert pattern.
- **Build**: The solution builds successfully
- **Debugging**:
  - Debug messages are logged in the `MainViewModel` and displayed in the `MainWindow` when enabled.
  - Debugging can be toggled on or off using the `DebugEnabled` property.

## Recent Updates
- Added a `TextBox` in the `MainWindow` to display debug messages.
- Introduced `DebugMessages` and `DebugEnabled` properties in the `MainViewModel`.
- Enhanced the `PolynomialTermControl` to bind directly to `MainViewModel` properties.
- Implemented data persistence across tabs in the WPF application.
- Resolved SA1101 warnings by prefixing local calls with `this`.
- Expanded unit tests for `RelayCommand` and `ViewModelBase` to ensure full coverage.
- Addressed CS8618 warnings by initializing non-nullable fields with default values.
- Updated `RelayCommand` to use nullable `Func<bool>?` for `canExecute` to resolve CS8625 warnings.
- Updated `SetProperty` in `ViewModelBase` to mark `propertyName` as nullable to resolve CS8625 warnings.

## Future Work
- Consolidate test framework references in the `EulersIdentity.WPF.Test` project to eliminate duplicate test methods in the test explorer.
- Extend the application to demonstrate more advanced polynomial and equation operations.
- Add support for parsing polynomials and equations from strings.
- Improve performance for large polynomials.
- Implement additional features in the `Polynomial` and `Equation` tabs.

## Licensing
This solution is released under the MIT license. See `LICENSE.txt` in the repository root for details.

