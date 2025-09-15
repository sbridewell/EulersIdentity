// <copyright file="PolynomialContainerViewModelTest.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace Sde.EulersIdentity.WPF.Test.ViewModels
{
    using FluentAssertions;
    using Sde.EulersIdentity.WPF.ViewModels;
    using Xunit;

    /// <summary>
    /// Unit tests for the <see cref="PolynomialContainerViewModel"/> class.
    /// </summary>
    public class PolynomialContainerViewModelTest
    {
        /// <summary>
        /// Tests that the <see cref="PolynomialContainerViewModel"/> initializes its properties correctly.
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeProperties()
        {
            // Act
            var viewModel = new PolynomialContainerViewModel();

            // Assert
            viewModel.PolynomialControlViewModel.Should().NotBeNull();
            viewModel.XValue.Should().Be(0);
            viewModel.PolynomialString.Should().BeEmpty();
            viewModel.EvaluationResult.Should().Be(0);
        }

        /// <summary>
        /// Tests that the <see cref="PolynomialContainerViewModel.EvaluateCommand"/> calculates the correct polynomial string and evaluation result.
        /// </summary>
        [Fact]
        public void EvaluateCommand_ShouldCalculatePolynomialStringAndResult()
        {
            // Arrange
            var viewModel = new PolynomialContainerViewModel();
            viewModel.PolynomialControlViewModel.AddTermCommand.Execute(null);
            var term = viewModel.PolynomialControlViewModel.Terms.First();
            term.Coefficient = "2";
            term.Exponent = "3";
            viewModel.XValue = 2;

            // Act
            viewModel.EvaluateCommand.Execute(null);

            // Assert
            viewModel.PolynomialString.Should().Be("2x^3");
            viewModel.EvaluationResult.Should().Be(16); // 2 * (2^3) = 16
        }

        /// <summary>
        /// Tests that the <see cref="PolynomialContainerViewModel.EvaluateCommand"/> handles an empty terms collection correctly.
        /// </summary>
        [Fact]
        public void EvaluateCommand_ShouldHandleEmptyTermsCollection()
        {
            // Arrange
            var viewModel = new PolynomialContainerViewModel();
            viewModel.XValue = 2;

            // Act
            viewModel.EvaluateCommand.Execute(null);

            // Assert
            viewModel.PolynomialString.Should().Be("0");
            viewModel.EvaluationResult.Should().Be(0);
        }

        /// <summary>
        /// Tests that the <see cref="PolynomialContainerViewModel.XValue"/> property updates correctly.
        /// </summary>
        [Fact]
        public void XValue_ShouldUpdateCorrectly()
        {
            // Arrange
            var viewModel = new PolynomialContainerViewModel();

            // Act
            viewModel.XValue = 5;

            // Assert
            viewModel.XValue.Should().Be(5);
        }
    }
}
