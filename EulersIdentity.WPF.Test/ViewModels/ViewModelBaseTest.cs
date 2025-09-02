using System.ComponentModel;
using FluentAssertions;
using Sde.EulersIdentity.WPF.ViewModels;
using Xunit;

namespace Sde.EulersIdentity.WPF.Test.ViewModels
{
    /// <summary>
    /// Unit tests for the <see cref="ViewModelBase"/> class.
    /// </summary>
    public class ViewModelBaseTest
    {
        /// <summary>
        /// A test implementation of <see cref="ViewModelBase"/> for testing purposes.
        /// </summary>
        private class TestViewModel : ViewModelBase
        {
            private string testProperty;

            /// <summary>
            /// Gets or sets the test property.
            /// </summary>
            public string TestProperty
            {
                get => testProperty;
                set => SetProperty(ref testProperty, value);
            }
        }

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
    }
}