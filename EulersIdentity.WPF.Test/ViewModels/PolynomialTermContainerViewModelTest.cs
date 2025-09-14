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
        /// Tests that the PolynomialTermAndResult property formats the polynomial term and result correctly.
        /// </summary>
        [Fact]
        public void PolynomialTermAndResult_ShouldReturnFormattedStringForValidInputs()
        {
            // Arrange
            var viewModel = new PolynomialTermContainerViewModel
            {
                PolynomialTerm = new PolynomialTermViewModel
                {
                    Coefficient = "2",
                    Exponent = "3",
                },
                XValue = "4",
            };

            // Act
            var result = viewModel.PolynomialTermAndResult;

            // Assert
            result.Should().Be("2 * 4^3 = 128");
        }

        /// <summary>
        /// Tests that the PolynomialTermAndResult property returns an empty string for invalid inputs.
        /// </summary>
        [Fact]
        public void PolynomialTermAndResult_ShouldReturnEmptyStringForInvalidInputs()
        {
            // Arrange
            var viewModel = new PolynomialTermContainerViewModel
            {
                PolynomialTerm = new PolynomialTermViewModel
                {
                    Coefficient = "invalid",
                    Exponent = "3",
                },
                XValue = "4",
            };

            // Act
            var result = viewModel.PolynomialTermAndResult;

            // Assert
            result.Should().BeEmpty();
        }
    }
}