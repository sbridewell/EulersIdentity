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
        /// Tests that the Coefficient property sanitises input correctly.
        /// </summary>
        [Fact]
        public void Coefficient_ShouldSanitiseInput()
        {
            // Arrange
            var viewModel = new PolynomialTermViewModel();

            // Act
            viewModel.Coefficient = "1.2.3";

            // Assert
            viewModel.Coefficient.Should().Be("1.23");
        }

        /// <summary>
        /// Tests that the Exponent property sanitises input correctly.
        /// </summary>
        [Fact]
        public void Exponent_ShouldSanitiseInput()
        {
            // Arrange
            var viewModel = new PolynomialTermViewModel();

            // Act
            viewModel.Exponent = "4.5.6";

            // Assert
            viewModel.Exponent.Should().Be("4.56");
        }
    }
}