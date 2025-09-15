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
        // Existing test methods...

        /// <summary>
        /// Tests that <see cref="PolynomialTermViewModel.ToPolynomialTerm"/> correctly converts valid coefficient and exponent values.
        /// </summary>
        [Fact]
        public void ToPolynomialTerm_ShouldConvertValidValues()
        {
            // Arrange
            var viewModel = new PolynomialTermViewModel
            {
                Coefficient = "3.5",
                Exponent = "2",
            };

            // Act
            var polynomialTerm = viewModel.ToPolynomialTerm();

            // Assert
            polynomialTerm.Coefficient.Should().Be(3.5);
            polynomialTerm.Exponent.Should().Be(2);
        }

        /// <summary>
        /// Tests that <see cref="PolynomialTermViewModel.ToPolynomialTerm"/> returns a coefficient of 0 when the coefficient is invalid.
        /// </summary>
        [Fact]
        public void ToPolynomialTerm_ShouldReturnZeroCoefficient_WhenCoefficientIsInvalid()
        {
            // Arrange
            var viewModel = new PolynomialTermViewModel
            {
                Coefficient = "invalid",
                Exponent = "2",
            };

            // Act
            var polynomialTerm = viewModel.ToPolynomialTerm();

            // Assert
            polynomialTerm.Coefficient.Should().Be(0);
            polynomialTerm.Exponent.Should().Be(2);
        }

        /// <summary>
        /// Tests that <see cref="PolynomialTermViewModel.ToPolynomialTerm"/> returns an exponent of 0 when the exponent is invalid.
        /// </summary>
        [Fact]
        public void ToPolynomialTerm_ShouldReturnZeroExponent_WhenExponentIsInvalid()
        {
            // Arrange
            var viewModel = new PolynomialTermViewModel
            {
                Coefficient = "3.5",
                Exponent = "invalid",
            };

            // Act
            var polynomialTerm = viewModel.ToPolynomialTerm();

            // Assert
            polynomialTerm.Coefficient.Should().Be(3.5);
            polynomialTerm.Exponent.Should().Be(0);
        }

        /// <summary>
        /// Tests that <see cref="PolynomialTermViewModel.ToPolynomialTerm"/> returns a coefficient and exponent of 0 when both are invalid.
        /// </summary>
        [Fact]
        public void ToPolynomialTerm_ShouldReturnZeroCoefficientAndExponent_WhenBothAreInvalid()
        {
            // Arrange
            var viewModel = new PolynomialTermViewModel
            {
                Coefficient = "invalid",
                Exponent = "invalid",
            };

            // Act
            var polynomialTerm = viewModel.ToPolynomialTerm();

            // Assert
            polynomialTerm.Coefficient.Should().Be(0);
            polynomialTerm.Exponent.Should().Be(0);
        }
    }
}