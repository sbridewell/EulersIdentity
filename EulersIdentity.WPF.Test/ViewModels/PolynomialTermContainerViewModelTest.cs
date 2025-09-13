// <copyright file="PolynomialTermContainerViewModelTest.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace Sde.EulersIdentity.WPF.Test.ViewModels
{
    using FluentAssertions;
    using Sde.EulersIdentity.WPF.ViewModels;

    /// <summary>
    /// Unit tests for the <see cref="PolynomialTermContainerViewModel"/> class.
    /// </summary>
    public class PolynomialTermContainerViewModelTest
    {
        /// <summary>
        /// Tests that the TermValue is calculated correctly for valid inputs.
        /// </summary>
        [Fact]
        public void CalculateTermValue_ShouldReturnCorrectResultForValidInputs()
        {
            // Arrange
            var viewModel = new PolynomialTermContainerViewModel
            {
                PolynomialTerm = new PolynomialTermViewModel
                {
                    Coefficient = "2.5",
                    Exponent = "3",
                },
                XValue = "1.5",
            };

            // Act
            var termValue = viewModel.TermValue;

            // Assert
            termValue.Should().BeApproximately(8.4375, 0.0001);
        }

        /// <summary>
        /// Tests that the TermValue is NaN for invalid inputs.
        /// </summary>
        [Fact]
        public void CalculateTermValue_ShouldReturnNaNForInvalidInputs()
        {
            // Arrange
            var viewModel = new PolynomialTermContainerViewModel
            {
                PolynomialTerm = new PolynomialTermViewModel
                {
                    Coefficient = "invalid",
                    Exponent = "3",
                },
                XValue = "1.5",
            };

            // Act
            var termValue = viewModel.TermValue;

            // Assert
            termValue.Should().Be(double.NaN);
        }
    }
}