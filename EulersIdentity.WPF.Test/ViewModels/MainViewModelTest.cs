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
    }
}