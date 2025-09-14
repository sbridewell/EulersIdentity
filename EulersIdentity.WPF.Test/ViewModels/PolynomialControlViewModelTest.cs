using System.Linq;
using FluentAssertions;
using Sde.EulersIdentity.WPF.ViewModels;
using Xunit;

namespace Sde.EulersIdentity.WPF.Test.ViewModels
{
    /// <summary>
    /// Unit tests for the <see cref="PolynomialControlViewModel"/> class.
    /// </summary>
    public class PolynomialControlViewModelTest
    {
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
    }
}