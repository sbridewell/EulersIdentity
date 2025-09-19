// <copyright file="PolynomialControlViewModelTest.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace Sde.EulersIdentity.WPF.Test.ViewModels
{
    using System.Linq;
    using FluentAssertions;
    using Sde.EulersIdentity.WPF.ViewModels;
    using Xunit;

    /// <summary>
    /// Unit tests for the <see cref="PolynomialControlViewModel"/> class.
    /// </summary>
    public class PolynomialControlViewModelTest
    {
        /// <summary>
        /// Tests that the <see cref="PolynomialControlViewModel.AddTermCommand"/> adds a new
        /// term to the <see cref="PolynomialControlViewModel.Terms"/> collection.
        /// </summary>
        [Fact]
        public void AddTerm_ShouldAddNewTermToTermsCollection()
        {
            // Arrange
            var viewModel = new PolynomialControlViewModel();

            // Act
            viewModel.AddTermCommand.Execute(null);

            // Assert
            viewModel.Terms.Should().HaveCount(1);
        }

        /// <summary>
        /// Tests that the <see cref="PolynomialControlViewModel.RemoveTermCommand"/> removes the
        /// last term from the <see cref="PolynomialControlViewModel.Terms"/> collection.
        /// </summary>
        [Fact]
        public void RemoveTerm_ShouldRemoveLastTermFromTermsCollection()
        {
            // Arrange
            var viewModel = new PolynomialControlViewModel();
            viewModel.AddTermCommand.Execute(null);

            // Act
            viewModel.RemoveTermCommand.Execute(null);

            // Assert
            viewModel.Terms.Should().BeEmpty();
        }

        /// <summary>
        /// Tests that the <see cref="PolynomialControlViewModel.RemoveTermCommand"/> does not throw
        /// an exception when the <see cref="PolynomialControlViewModel.Terms"/> collection is empty.
        /// </summary>
        [Fact]
        public void RemoveTerm_ShouldNotThrow_WhenTermsCollectionIsEmpty()
        {
            // Arrange
            var viewModel = new PolynomialControlViewModel();

            // Act
            var action = () => viewModel.RemoveTermCommand.Execute(null);

            // Assert
            action.Should().NotThrow();
        }

        /// <summary>
        /// Tests that the <see cref="PolynomialControlViewModel.EvaluateCommand"/> calculates the correct
        /// result based on the terms in the <see cref="PolynomialControlViewModel.Terms"/> collection and
        /// the value of <see cref="PolynomialControlViewModel.XValue"/>.
        /// </summary>
        [Fact]
        public void Evaluate_ShouldCalculateCorrectResult()
        {
            // Arrange
            var viewModel = new PolynomialControlViewModel();
            viewModel.AddTermCommand.Execute(null);
            var term = viewModel.Terms.First();
            term.Coefficient = "2";
            term.Exponent = "3";
            viewModel.XValue = 2;

            // Act
            viewModel.EvaluateCommand.Execute(null);

            // Assert
            viewModel.Result.Should().Be(16); // 2 * (2^3) = 16
        }

        /// <summary>
        /// Tests that the <see cref="PolynomialControlViewModel.EvaluateCommand"/> cannot execute when the
        /// <see cref="PolynomialControlViewModel.Terms"/> collection is empty.
        /// </summary>
        [Fact]
        public void Evaluate_ShouldNotExecute_WhenNoTermsExist()
        {
            // Arrange
            var viewModel = new PolynomialControlViewModel();

            // Act
            var canExecute = viewModel.EvaluateCommand.CanExecute(null);

            // Assert
            canExecute.Should().BeFalse();
        }

        /// <summary>
        /// Tests that the <see cref="PolynomialControlViewModel.ToPolynomial"/> method correctly converts the terms in the view model to a <see cref="Polynomial"/> object.
        /// </summary>
        [Fact]
        public void ToPolynomial_ShouldConvertTermsToPolynomial()
        {
            // Arrange
            var viewModel = new PolynomialControlViewModel();
            viewModel.AddTermCommand.Execute(null);
            var term = viewModel.Terms.First();
            term.Coefficient = "3";
            term.Exponent = "2";

            // Act
            var polynomial = viewModel.ToPolynomial();

            // Assert
            polynomial.Terms.Should().HaveCount(1);
            var polynomialTerm = polynomial.Terms.First();
            polynomialTerm.Coefficient.Should().Be(3);
            polynomialTerm.Exponent.Should().Be(2);
        }

        /// <summary>
        /// Tests that the CanRemoveTerm method returns true when there are terms in
        /// the <see cref="PolynomialControlViewModel.Terms"/> collection.
        /// </summary>
        [Fact]
        public void CanRemoveTerm_ShouldReturnTrue_WhenTermsExist()
        {
            // Arrange
            var viewModel = new PolynomialControlViewModel();
            viewModel.AddTermCommand.Execute(null);

            // Act
            var canRemove = viewModel.RemoveTermCommand.CanExecute(null);

            // Assert
            canRemove.Should().BeTrue();
        }

        /// <summary>
        /// Tests that the CanRemoveTerm method returns false when the
        /// <see cref="PolynomialControlViewModel.Terms"/> collection is empty.
        /// </summary>
        [Fact]
        public void CanRemoveTerm_ShouldReturnFalse_WhenNoTermsExist()
        {
            // Arrange
            var viewModel = new PolynomialControlViewModel();

            // Act
            var canRemove = viewModel.RemoveTermCommand.CanExecute(null);

            // Assert
            canRemove.Should().BeFalse();
        }
    }
}