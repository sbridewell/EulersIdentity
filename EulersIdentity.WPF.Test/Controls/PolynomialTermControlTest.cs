// <copyright file="PolynomialTermControlTest.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace Sde.EulersIdentity.WPF.Test.Views
{
    using System.Threading;
    using System.Windows.Input;
    using FluentAssertions;
    using Sde.EulersIdentity.WPF.Views;
    using Xunit;

    /// <summary>
    /// Unit tests for the <see cref="PolynomialTermControl"/> class.
    /// </summary>
    public class PolynomialTermControlTest
    {
        /// <summary>
        /// Tests that the control initializes correctly.
        /// </summary>
        [Fact]
        public void TestPolynomialTermControlInitialization()
        {
            // Arrange
            PolynomialTermControl? control = null;

            var thread = new Thread(() =>
            {
                control = new PolynomialTermControl();
            });

            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();

            // Act
            // No action needed for initialization test.

            // Assert
            control.Should().NotBeNull();
        }

        /// <summary>
        /// Tests that the OnEvaluateClick event handler executes without errors.
        /// </summary>
        [Fact]
        public void OnEvaluateClick_ShouldExecuteWithoutErrors()
        {
            // Arrange
            PolynomialTermControl? control = null;

            var thread = new Thread(() =>
            {
                control = new PolynomialTermControl();
            });

            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();

            // Act
            var exception = Record.Exception(() => control?.OnEvaluateClick(null, null));

            // Assert
            exception.Should().BeNull();
        }

        /// <summary>
        /// Tests that the OnInputChanged event handler executes without errors.
        /// </summary>
        [Fact]
        public void OnInputChanged_ShouldExecuteWithoutErrors()
        {
            // Arrange
            PolynomialTermControl? control = null;

            var thread = new Thread(() =>
            {
                control = new PolynomialTermControl();
            });

            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();

            // Act
            var exception = Record.Exception(() => control?.OnInputChanged(null, null));

            // Assert
            exception.Should().BeNull();
        }

        /// <summary>
        /// Tests that the OnPreviewTextInput event handler executes without errors.
        /// </summary>
        [Fact]
        public void OnPreviewTextInput_ShouldExecuteWithoutErrors()
        {
            // Arrange
            Exception? exception = null;

            var thread = new Thread(() =>
            {
                try
                {
                    var control = new PolynomialTermControl();

                    var textCompositionEventArgs = new TextCompositionEventArgs(
                        InputManager.Current.PrimaryKeyboardDevice,
                        new TextComposition(
                            InputManager.Current,
                            null,
                            "1"))
                    {
                        RoutedEvent = TextCompositionManager.PreviewTextInputEvent,
                    };

                    // Act
                    exception = Record.Exception(() => control.RaiseEvent(textCompositionEventArgs));
                }
                catch (Exception ex)
                {
                    exception = ex;
                }
            });

            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();

            // Assert
            exception.Should().BeNull();
        }

        /// <summary>
        /// Tests that the OnTextBoxGotFocus event handler executes without errors.
        /// </summary>
        [Fact]
        public void OnTextBoxGotFocus_ShouldExecuteWithoutErrors()
        {
            // Arrange
            PolynomialTermControl? control = null;

            var thread = new Thread(() =>
            {
                control = new PolynomialTermControl();
            });

            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();

            // Act
            var exception = Record.Exception(() => control?.OnTextBoxGotFocus(null, null));

            // Assert
            exception.Should().BeNull();
        }
    }
}