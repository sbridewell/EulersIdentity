using System;
using FluentAssertions;
using Sde.EulersIdentity.WPF.ViewModels;
using Xunit;

namespace Sde.EulersIdentity.WPF.Test.ViewModels
{
    /// <summary>
    /// Unit tests for the <see cref="RelayCommand"/> class.
    /// </summary>
    public class RelayCommandTest
    {
        /// <summary>
        /// Tests that the Execute method invokes the provided action.
        /// </summary>
        [Fact]
        public void Execute_ShouldInvokeAction()
        {
            // Arrange
            var wasExecuted = false;
            var command = new RelayCommand(() => wasExecuted = true);

            // Act
            command.Execute(null);

            // Assert
            wasExecuted.Should().BeTrue();
        }

        /// <summary>
        /// Tests that the CanExecute method returns true when no canExecute function is provided.
        /// </summary>
        [Fact]
        public void CanExecute_ShouldReturnTrueWhenNoCanExecuteProvided()
        {
            // Arrange
            var command = new RelayCommand(() => { });

            // Act
            var canExecute = command.CanExecute(null);

            // Assert
            canExecute.Should().BeTrue();
        }

        /// <summary>
        /// Tests that the CanExecute method returns the value of the provided canExecute function.
        /// </summary>
        [Fact]
        public void CanExecute_ShouldReturnCanExecuteFunctionValue()
        {
            // Arrange
            var canExecuteValue = true;
            var command = new RelayCommand(() => { }, () => canExecuteValue);

            // Act
            var initialCanExecute = command.CanExecute(null);

            // Assert
            initialCanExecute.Should().BeTrue();

            // Act
            canExecuteValue = false;
            var updatedCanExecute = command.CanExecute(null);

            // Assert
            updatedCanExecute.Should().BeFalse();
        }

        /// <summary>
        /// Tests that the RaiseCanExecuteChanged method raises the CanExecuteChanged event when there are subscribers.
        /// </summary>
        [Fact]
        public void RaiseCanExecuteChanged_ShouldRaiseEventWhenSubscribersExist()
        {
            // Arrange
            var command = new RelayCommand(() => { });
            var eventRaised = false;
            command.CanExecuteChanged += (sender, args) => eventRaised = true;

            // Act
            command.RaiseCanExecuteChanged();

            // Assert
            eventRaised.Should().BeTrue();
        }

        /// <summary>
        /// Tests that the RaiseCanExecuteChanged method does not throw an exception when there are no subscribers.
        /// </summary>
        [Fact]
        public void RaiseCanExecuteChanged_ShouldNotThrowWhenNoSubscribers()
        {
            // Arrange
            var command = new RelayCommand(() => { });

            // Act
            var exception = Record.Exception(() => command.RaiseCanExecuteChanged());

            // Assert
            exception.Should().BeNull();
        }

        /// <summary>
        /// Tests that the constructor throws an ArgumentNullException when the execute action is null.
        /// </summary>
        [Fact]
        public void Constructor_ShouldThrowArgumentNullExceptionWhenExecuteIsNull()
        {
            // Act
            var exception = Record.Exception(() => new RelayCommand(null));

            // Assert
            exception.Should().BeOfType<ArgumentNullException>();
        }
    }
}