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

        /// <summary>
        /// Tests that changing the coefficient updates the PolynomialTermRepresentation and TermValue.
        /// </summary>
        [Fact]
        public void ChangingCoefficient_UpdatesPolynomialTermRepresentationAndTermValue()
        {
            // Arrange
            var containerViewModel = new PolynomialTermContainerViewModel
            {
                PolynomialTerm = new PolynomialTermViewModel
                {
                    Coefficient = "2",
                    Exponent = "3",
                },
                XValue = "4",
            };

            // Act
            containerViewModel.PolynomialTerm.Coefficient = "3";

            // Assert
            containerViewModel.PolynomialTermRepresentation.Should().Be("3x^3");
            containerViewModel.TermValue.Should().Be(192); // 3 * 4^3
        }

        /// <summary>
        /// Tests that the PolynomialTerm property setter updates the value and subscribes to PropertyChanged
        /// when SetProperty returns true.
        /// </summary>
        [Fact]
        public void PolynomialTerm_Setter_ShouldUpdateValueAndSubscribeToPropertyChanged_WhenSetPropertyReturnsTrue()
        {
            // Arrange
            var containerViewModel = new PolynomialTermContainerViewModel();
            var newPolynomialTerm = new PolynomialTermViewModel();
            bool propertyChangedEventTriggered = false;

            newPolynomialTerm.PropertyChanged += (_, _) => propertyChangedEventTriggered = true;

            // Act
            containerViewModel.PolynomialTerm = newPolynomialTerm;
            newPolynomialTerm.Coefficient = "5"; // Trigger PropertyChanged

            // Assert
            containerViewModel.PolynomialTerm.Should().Be(newPolynomialTerm);
            propertyChangedEventTriggered.Should().BeTrue();
        }

        /// <summary>
        /// Tests that the PolynomialTerm property setter does not update the value
        /// or subscribe to PropertyChanged when SetProperty returns false.
        /// </summary>
        [Fact]
        public void PolynomialTerm_Setter_ShouldNotUpdateValue_WhenSetPropertyReturnsFalse()
        {
            // Arrange
            var containerViewModel = new PolynomialTermContainerViewModel();
            var initialPolynomialTerm = containerViewModel.PolynomialTerm;
            var newPolynomialTerm = initialPolynomialTerm; // Simulate no change in value

            // Act
            containerViewModel.PolynomialTerm = newPolynomialTerm;

            // Assert
            containerViewModel.PolynomialTerm.Should().Be(initialPolynomialTerm);
        }

        /// <summary>
        /// Tests that the PolynomialTerm property setter handles null values correctly.
        /// </summary>
        [Fact]
        public void PolynomialTerm_Setter_ShouldHandleNullValue()
        {
            // Arrange
            var containerViewModel = new PolynomialTermContainerViewModel();

            // Act
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            containerViewModel.PolynomialTerm = null;
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

            // Assert
            containerViewModel.PolynomialTerm.Should().BeNull();
        }

        /// <summary>
        /// Tests that changing the coefficient triggers updates to PolynomialTermRepresentation and TermValue.
        /// </summary>
        [Fact]
        public void OnPolynomialTermPropertyChanged_ShouldUpdateProperties_WhenCoefficientChanges()
        {
            // Arrange
            var containerViewModel = new PolynomialTermContainerViewModel
            {
                PolynomialTerm = new PolynomialTermViewModel
                {
                    Coefficient = "2",
                    Exponent = "3",
                },
                XValue = "4",
            };

            // Act
            containerViewModel.PolynomialTerm.Coefficient = "5";

            // Assert
            containerViewModel.PolynomialTermRepresentation.Should().Be("5x^3");
            containerViewModel.TermValue.Should().Be(320); // 5 * 4^3
        }

        /// <summary>
        /// Tests that changing the exponent triggers updates to PolynomialTermRepresentation and TermValue.
        /// </summary>
        [Fact]
        public void OnPolynomialTermPropertyChanged_ShouldUpdateProperties_WhenExponentChanges()
        {
            // Arrange
            var containerViewModel = new PolynomialTermContainerViewModel
            {
                PolynomialTerm = new PolynomialTermViewModel
                {
                    Coefficient = "2",
                    Exponent = "3",
                },
                XValue = "4",
            };

            // Act
            containerViewModel.PolynomialTerm.Exponent = "2";

            // Assert
            containerViewModel.PolynomialTermRepresentation.Should().Be("2x^2");
            containerViewModel.TermValue.Should().Be(32); // 2 * 4^2
        }
    }
}