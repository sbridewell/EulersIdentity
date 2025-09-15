// <copyright file="PolynomialViewModelTest.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace Sde.EulersIdentity.WPF.Test.ViewModels
{
    using FluentAssertions;
    using Sde.EulersIdentity.WPF.ViewModels;
    using Xunit;

    /// <summary>
    /// Unit tests for the <see cref="PolynomialViewModel"/> class.
    /// </summary>
    public class PolynomialViewModelTest
    {
        /// <summary>
        /// Tests that a new term is added to the polynomial.
        /// </summary>
        [Fact]
        public void AddTerm_ShouldAddNewTerm()
        {
            // Arrange
            var viewModel = new PolynomialViewModel();

            // Act
            viewModel.AddTermCommand.Execute(null);

            // Assert
            viewModel.Terms.Should().HaveCount(1);
        }

        /// <summary>
        /// Tests that the last term is removed from the polynomial.
        /// </summary>
        [Fact]
        public void RemoveTerm_ShouldRemoveLastTerm()
        {
            // Arrange
            var viewModel = new PolynomialViewModel();
            viewModel.AddTermCommand.Execute(null);

            // Act
            viewModel.RemoveTermCommand.Execute(null);

            // Assert
            viewModel.Terms.Should().BeEmpty();
        }

        /// <summary>
        /// Tests that the polynomial is evaluated correctly.
        /// </summary>
        [Fact]
        public void Evaluate_ShouldCalculatePolynomialValue()
        {
            // Arrange
            var viewModel = new PolynomialViewModel();
            viewModel.AddTermCommand.Execute(null);
            viewModel.Terms[0].Coefficient = "2";
            viewModel.Terms[0].Exponent = "3";
            viewModel.XValue = "2";

            // Act
            viewModel.EvaluateCommand.Execute(null);

            // Assert
            viewModel.Result.Should().Be("16");
        }

        /// <summary>
        /// Tests that an invalid x value is handled correctly.
        /// </summary>
        [Fact]
        public void Evaluate_ShouldHandleInvalidXValue()
        {
            // Arrange
            var viewModel = new PolynomialViewModel();
            viewModel.AddTermCommand.Execute(null);
            viewModel.Terms[0].Coefficient = "2";
            viewModel.Terms[0].Exponent = "3";
            viewModel.XValue = "invalid";

            // Act
            viewModel.EvaluateCommand.Execute(null);

            // Assert
            viewModel.Result.Should().Be("Invalid x value.");
        }

        /// <summary>
        /// Tests that CanRemoveTerm returns true when there are terms in the collection.
        /// </summary>
        [Fact]
        public void CanRemoveTerm_ShouldReturnTrue_WhenTermsExist()
        {
            // Arrange
            var viewModel = new PolynomialViewModel();
            viewModel.AddTermCommand.Execute(null);

            // Act
            var result = viewModel.RemoveTermCommand.CanExecute(null);

            // Assert
            result.Should().BeTrue();
        }

        /// <summary>
        /// Tests that CanRemoveTerm returns false when there are no terms in the collection.
        /// </summary>
        [Fact]
        public void CanRemoveTerm_ShouldReturnFalse_WhenNoTermsExist()
        {
            // Arrange
            var viewModel = new PolynomialViewModel();

            // Act
            var result = viewModel.RemoveTermCommand.CanExecute(null);

            // Assert
            result.Should().BeFalse();
        }

        /// <summary>
        /// Tests that CanEvaluate returns true when there are terms and XValue is not empty.
        /// </summary>
        [Fact]
        public void CanEvaluate_ShouldReturnTrue_WhenTermsExistAndXValueIsNotEmpty()
        {
            // Arrange
            var viewModel = new PolynomialViewModel();
            viewModel.AddTermCommand.Execute(null);
            viewModel.XValue = "1";

            // Act
            var result = viewModel.EvaluateCommand.CanExecute(null);

            // Assert
            result.Should().BeTrue();
        }

        /// <summary>
        /// Tests that CanEvaluate returns false when there are no terms.
        /// </summary>
        [Fact]
        public void CanEvaluate_ShouldReturnFalse_WhenNoTermsExist()
        {
            // Arrange
            var viewModel = new PolynomialViewModel();
            viewModel.XValue = "1";

            // Act
            var result = viewModel.EvaluateCommand.CanExecute(null);

            // Assert
            result.Should().BeFalse();
        }

        /// <summary>
        /// Tests that CanEvaluate returns false when XValue is empty.
        /// </summary>
        [Fact]
        public void CanEvaluate_ShouldReturnFalse_WhenXValueIsEmpty()
        {
            // Arrange
            var viewModel = new PolynomialViewModel();
            viewModel.AddTermCommand.Execute(null);
            viewModel.XValue = string.Empty;

            // Act
            var result = viewModel.EvaluateCommand.CanExecute(null);

            // Assert
            result.Should().BeFalse();
        }
    }
}