// <copyright file="MainViewModelTest.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace Sde.EulersIdentity.WPF.Test.ViewModels
{
    using System.ComponentModel;
    using FluentAssertions;
    using FluentAssertions.Events;
    using Sde.EulersIdentity.WPF.ViewModels;
    using Xunit;

    /// <summary>
    /// Unit tests for the <see cref="MainViewModel"/> class.
    /// </summary>
    public class MainViewModelTest
    {
        /// <summary>
        /// Tests that the constructor initializes the tabs and selects the first tab.
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitialiseTabsAndSelectFirstTab()
        {
            // Arrange & Act
            var viewModel = new MainViewModel();

            // Assert
            viewModel.Tabs.Should().ContainInOrder("PolynomialTerm", "Polynomial", "Equation");
            viewModel.SelectedTab.Should().Be("PolynomialTerm");
        }

        /// <summary>
        /// Tests that the SelectedTab property raises the PropertyChanged event.
        /// </summary>
        [Fact]
        public void SelectedTab_ShouldRaisePropertyChangedEvent()
        {
            // Arrange
            var viewModel = new MainViewModel();
            using var monitoredViewModel = viewModel.Monitor();

            // Act
            viewModel.SelectedTab = "Polynomial";

            // Assert
            monitoredViewModel.Should().RaisePropertyChangeFor(vm => vm.SelectedTab);
            viewModel.SelectedTab.Should().Be("Polynomial");
        }

        /// <summary>
        /// Tests that the PropertyChanged event is raised when the user selects a different tab.
        /// </summary>
        [Fact]
        public void PropertyChanged_ShouldBeRaisedWhenUserSelectsDifferentTab()
        {
            // Arrange
            var viewModel = new MainViewModel();
            using var monitoredViewModel = viewModel.Monitor();

            // Act
            viewModel.SelectedTab = "Equation";

            // Assert
            monitoredViewModel.Should().Raise("PropertyChanged")
                .WithSender(viewModel)
                .WithArgs<PropertyChangedEventArgs>(args => args.PropertyName == nameof(viewModel.SelectedTab));
        }

        /// <summary>
        /// Tests that the Coefficient property updates correctly and raises PropertyChanged.
        /// </summary>
        [Fact]
        public void Coefficient_ShouldUpdateAndRaisePropertyChanged()
        {
            // Arrange
            var viewModel = new MainViewModel();
            using var monitoredViewModel = viewModel.Monitor();

            // Act
            viewModel.Coefficient = 5.0;

            // Assert
            viewModel.Coefficient.Should().Be(5.0);
            monitoredViewModel.Should().RaisePropertyChangeFor(vm => vm.Coefficient);
        }

        /// <summary>
        /// Tests that the Exponent property updates correctly and raises PropertyChanged.
        /// </summary>
        [Fact]
        public void Exponent_ShouldUpdateAndRaisePropertyChanged()
        {
            // Arrange
            var viewModel = new MainViewModel();
            using var monitoredViewModel = viewModel.Monitor();

            // Act
            viewModel.Exponent = 3.0;

            // Assert
            viewModel.Exponent.Should().Be(3.0);
            monitoredViewModel.Should().RaisePropertyChangeFor(vm => vm.Exponent);
        }

        /// <summary>
        /// Tests that the XValue property updates correctly and raises PropertyChanged.
        /// </summary>
        [Fact]
        public void XValue_ShouldUpdateAndRaisePropertyChanged()
        {
            // Arrange
            var viewModel = new MainViewModel();
            using var monitoredViewModel = viewModel.Monitor();

            // Act
            viewModel.XValue = 2.0;

            // Assert
            viewModel.XValue.Should().Be(2.0);
            monitoredViewModel.Should().RaisePropertyChangeFor(vm => vm.XValue);
        }

        /// <summary>
        /// Tests that the DebugMessages property updates correctly and raises PropertyChanged.
        /// </summary>
        [Fact]
        public void DebugMessages_ShouldUpdateAndRaisePropertyChanged()
        {
            // Arrange
            var viewModel = new MainViewModel();
            using var monitoredViewModel = viewModel.Monitor();

            // Act
            viewModel.DebugMessages = "Test message";

            // Assert
            viewModel.DebugMessages.Should().Be("Test message");
            monitoredViewModel.Should().RaisePropertyChangeFor(vm => vm.DebugMessages);
        }

        /// <summary>
        /// Tests that the DebugEnabled property updates correctly and raises PropertyChanged.
        /// </summary>
        [Fact]
        public void DebugEnabled_ShouldUpdateAndRaisePropertyChanged()
        {
            // Arrange
            var viewModel = new MainViewModel();
            using var monitoredViewModel = viewModel.Monitor();

            // Act
            viewModel.DebugEnabled = false;

            // Assert
            viewModel.DebugEnabled.Should().BeFalse();
            monitoredViewModel.Should().RaisePropertyChangeFor(vm => vm.DebugEnabled);
        }

        /// <summary>
        /// Tests that UpdatePolynomialTermState updates the PolynomialTermState property.
        /// </summary>
        [Fact]
        public void UpdatePolynomialTermState_ShouldUpdatePolynomialTermState()
        {
            // Arrange
            var viewModel = new MainViewModel
            {
                Coefficient = 2.0,
                Exponent = 3.0,
                XValue = 4.0,
            };

            // Act
            viewModel.Coefficient = 5.0; // Triggers UpdatePolynomialTermState

            // Assert
            viewModel.PolynomialTermState.Should().Be("When x is 4 then 5x^3 = 320");
        }

        /// <summary>
        /// Tests that LogDebugMessage appends a debug message when DebugEnabled is true.
        /// </summary>
        [Fact]
        public void LogDebugMessage_ShouldAppendMessageWhenDebugEnabled()
        {
            // Arrange
            var viewModel = new MainViewModel { DebugEnabled = true };

            // Act
            viewModel.Coefficient = 5.0; // Triggers LogDebugMessage

            // Assert
            viewModel.DebugMessages.Should().Contain("Coefficient set to 5");
        }
    }
}