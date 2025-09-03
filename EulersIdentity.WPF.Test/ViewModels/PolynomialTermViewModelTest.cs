// <copyright file="PolynomialTermViewModelTest.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace Sde.EulersIdentity.WPF.Test.ViewModels
{
    using FluentAssertions;
    using Sde.EulersIdentity.WPF.ViewModels;

    /// <summary>
    /// Unit tests for the <see cref="PolynomialTermViewModel"/> class.
    /// </summary>
    public class PolynomialTermViewModelTest
    {
        /// <summary>
        /// Tests that the EvaluateCommand updates the Result property with the correct value for valid inputs.
        /// </summary>
        [Fact]
        public void EvaluateCommand_ShouldUpdateResultForValidInputs()
        {
            // Arrange
            var viewModel = new PolynomialTermViewModel
            {
                Coefficient = "2.5",
                Exponent = "3",
                XValue = "1.5",
            };

            // Act
            viewModel.EvaluateCommand.Execute(null);

            // Assert
            viewModel.Result.Should().Be("8.4375");
        }

        /// <summary>
        /// Tests that the EvaluateCommand updates the Result property with an error message for invalid coefficient.
        /// </summary>
        [Fact]
        public void EvaluateCommand_ShouldHandleInvalidCoefficient()
        {
            // Arrange
            var viewModel = new PolynomialTermViewModel
            {
                Coefficient = "invalid",
                Exponent = "3",
                XValue = "1.5",
            };

            // Act
            viewModel.EvaluateCommand.Execute(null);

            // Assert
            viewModel.Result.Should().StartWith("Error:");
        }

        /// <summary>
        /// Tests that the EvaluateCommand updates the Result property with an error message for invalid exponent.
        /// </summary>
        [Fact]
        public void EvaluateCommand_ShouldHandleInvalidExponent()
        {
            // Arrange
            var viewModel = new PolynomialTermViewModel
            {
                Coefficient = "2.5",
                Exponent = "invalid",
                XValue = "1.5",
            };

            // Act
            viewModel.EvaluateCommand.Execute(null);

            // Assert
            viewModel.Result.Should().StartWith("Error:");
        }

        /// <summary>
        /// Tests that the EvaluateCommand updates the Result property with an error message for invalid x value.
        /// </summary>
        [Fact]
        public void EvaluateCommand_ShouldHandleInvalidXValue()
        {
            // Arrange
            var viewModel = new PolynomialTermViewModel
            {
                Coefficient = "2.5",
                Exponent = "3",
                XValue = "invalid",
            };

            // Act
            viewModel.EvaluateCommand.Execute(null);

            // Assert
            viewModel.Result.Should().StartWith("Error:");
        }

        /// <summary>
        /// Tests that the CanEvaluate method returns true for valid inputs.
        /// </summary>
        [Fact]
        public void CanEvaluate_ShouldReturnTrueForValidInputs()
        {
            // Arrange
            var viewModel = new PolynomialTermViewModel
            {
                Coefficient = "2.5",
                Exponent = "3",
                XValue = "1.5",
            };

            // Act
            var canEvaluate = viewModel.EvaluateCommand.CanExecute(null);

            // Assert
            canEvaluate.Should().BeTrue();
        }

        /// <summary>
        /// Tests that the CanEvaluate method returns false for invalid inputs.
        /// </summary>
        [Fact]
        public void CanEvaluate_ShouldReturnFalseForInvalidInputs()
        {
            // Arrange
            var viewModel = new PolynomialTermViewModel
            {
                Coefficient = string.Empty,
                Exponent = "3",
                XValue = "1.5",
            };

            // Act
            var canEvaluate = viewModel.EvaluateCommand.CanExecute(null);

            // Assert
            canEvaluate.Should().BeFalse();
        }
    }
}