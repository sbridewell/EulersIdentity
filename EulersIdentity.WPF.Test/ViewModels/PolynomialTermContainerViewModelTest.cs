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

        /// <summary>
        /// Tests that PolynomialTerm and PolynomialTermRepresentation are updated correctly
        /// when xValue in MainViewModel is updated.
        /// </summary>
        [Fact]
        public void PolynomialTermAndRepresentation_ShouldUpdateWhenXValueChanges()
        {
            // Arrange
            var mainViewModel = new MainViewModel();
            var containerViewModel = new PolynomialTermContainerViewModel
            {
                PolynomialTerm = new PolynomialTermViewModel
                {
                    Coefficient = "3",
                    Exponent = "2",
                },
            };

            // Act
            mainViewModel.XValue = 4.0; // Update xValue in MainViewModel
            containerViewModel.XValue = mainViewModel.XValue.ToString();

            // Assert
            containerViewModel.PolynomialTerm.Coefficient.Should().Be("3");
            containerViewModel.PolynomialTerm.Exponent.Should().Be("2");
            containerViewModel.PolynomialTermRepresentation.Should().Be("3x^2");
            containerViewModel.TermValue.Should().BeApproximately(48.0, 0.0001); // 3 * 4^2 = 48
        }
    }
}