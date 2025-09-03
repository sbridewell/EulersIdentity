// <copyright file="ViewModelBaseTest.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace Sde.EulersIdentity.WPF.Test.ViewModels
{
    using FluentAssertions;
    using Sde.EulersIdentity.WPF.ViewModels;
    using Xunit;

    /// <summary>
    /// Unit tests for the <see cref="ViewModelBase"/> class.
    /// </summary>
    public class ViewModelBaseTest
    {
        /// <summary>
        /// Tests that the PropertyChanged event is raised when a property value changes.
        /// </summary>
        [Fact]
        public void SetProperty_ShouldRaisePropertyChangedEvent()
        {
            // Arrange
            var viewModel = new TestViewModel();
            var propertyName = string.Empty;
            viewModel.PropertyChanged += (sender, args) => propertyName = args.PropertyName;

            // Act
            viewModel.TestProperty = "New Value";

            // Assert
            propertyName.Should().Be("TestProperty");
        }

        /// <summary>
        /// Tests that the PropertyChanged event is not raised when the property value does not change.
        /// </summary>
        [Fact]
        public void SetProperty_ShouldNotRaisePropertyChangedEventIfValueUnchanged()
        {
            // Arrange
            var viewModel = new TestViewModel { TestProperty = "Initial Value" };
            var eventRaised = false;
            viewModel.PropertyChanged += (sender, args) => eventRaised = true;

            // Act
            viewModel.TestProperty = "Initial Value";

            // Assert
            eventRaised.Should().BeFalse();
        }

        /// <summary>
        /// Tests that the getter returns the correct value after the property is set.
        /// </summary>
        [Fact]
        public void TestProperty_GetterShouldReturnCorrectValue()
        {
            // Arrange
            var viewModel = new TestViewModel();

            // Act
            viewModel.TestProperty = "Expected Value";

            // Assert
            viewModel.TestProperty.Should().Be("Expected Value");
        }

        /// <summary>
        /// A test implementation of <see cref="ViewModelBase"/> for testing purposes.
        /// </summary>
        private class TestViewModel : ViewModelBase
        {
            private string testProperty = string.Empty;

            /// <summary>
            /// Gets or sets the test property.
            /// </summary>
            public string TestProperty
            {
                get => this.testProperty;
                set => this.SetProperty(ref this.testProperty, value);
            }
        }
    }
}