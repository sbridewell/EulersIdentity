// <copyright file="PolynomialTermControlTest.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace Sde.EulersIdentity.WPF.Test.Views
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using FluentAssertions;
    using Sde.EulersIdentity.WPF.Views;
    using Xunit;
    using Xunit.Sdk; // Required for WpfFact

    /// <summary>
    /// Unit tests for the <see cref="PolynomialTermControl"/> class.
    /// </summary>
    public class PolynomialTermControlTest
    {
        private readonly PolynomialTermControl control = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="PolynomialTermControlTest"/> class.
        /// Ensures the control is initialized on an STA thread.
        /// </summary>
        public PolynomialTermControlTest()
        {
            // No need for manual STA thread setup as WpfFact handles it.
        }

        /// <summary>
        /// Tests the constructor to ensure it initializes the DataContext correctly.
        /// </summary>
        [WpfFact]
        public void Constructor_ShouldInitializeDataContext()
        {
            // Act
            var dataContext = this.control.DataContext;

            // Assert
            dataContext.Should().Be(Application.Current?.MainWindow?.DataContext);
        }

        /// <summary>
        /// Tests the OnEvaluateClick method with valid inputs.
        /// </summary>
        [WpfFact]
        public void OnEvaluateClick_ShouldHandleValidInputs()
        {
            // Arrange
            var coefficientTextBox = this.control.TestCoefficientTextBox;
            var exponentTextBox = this.control.TestExponentTextBox;
            var xValueTextBox = this.control.TestXValueTextBox;

            coefficientTextBox.Text = "2.5";
            exponentTextBox.Text = "3";
            xValueTextBox.Text = "1.5";
            var eventArgs = new RoutedEventArgs();

            // Act
            var exception = Record.Exception(() => this.control.OnEvaluateClick(this.control, eventArgs));

            // Assert
            exception.Should().BeNull();
        }

        /// <summary>
        /// Tests the OnEvaluateClick method with invalid inputs.
        /// </summary>
        [WpfFact]
        public void OnEvaluateClick_ShouldHandleInvalidInputs()
        {
            // Arrange
            var coefficientTextBox = this.control.TestCoefficientTextBox;
            var exponentTextBox = this.control.TestExponentTextBox;
            var xValueTextBox = this.control.TestXValueTextBox;

            coefficientTextBox.Text = "invalid";
            exponentTextBox.Text = "3";
            xValueTextBox.Text = "1.5";
            var eventArgs = new RoutedEventArgs();

            // Act
            var exception = Record.Exception(() => this.control.OnEvaluateClick(this.control, eventArgs));

            // Assert
            exception.Should().BeNull();
        }

        /// <summary>
        /// Tests the OnInputChanged method with valid inputs.
        /// </summary>
        [WpfFact]
        public void OnInputChanged_ShouldHandleValidInputs()
        {
            // Arrange
            var coefficientTextBox = this.control.TestCoefficientTextBox;
            var exponentTextBox = this.control.TestExponentTextBox;
            var xValueTextBox = this.control.TestXValueTextBox;

            coefficientTextBox.Text = "2.5";
            exponentTextBox.Text = "3";
            xValueTextBox.Text = "1.5";
            var eventArgs = new TextChangedEventArgs(TextBox.TextChangedEvent, UndoAction.None);

            // Act
            var exception = Record.Exception(() => this.control.OnInputChanged(this.control, eventArgs));

            // Assert
            exception.Should().BeNull();
        }

        /// <summary>
        /// Tests the OnInputChanged method with invalid inputs.
        /// </summary>
        [WpfFact]
        public void OnInputChanged_ShouldHandleInvalidInputs()
        {
            // Arrange
            var coefficientTextBox = this.control.TestCoefficientTextBox;
            var exponentTextBox = this.control.TestExponentTextBox;
            var xValueTextBox = this.control.TestXValueTextBox;

            coefficientTextBox.Text = "invalid";
            exponentTextBox.Text = "3";
            xValueTextBox.Text = "1.5";
            var eventArgs = new TextChangedEventArgs(TextBox.TextChangedEvent, UndoAction.None);

            // Act
            var exception = Record.Exception(() => this.control.OnInputChanged(this.control, eventArgs));

            // Assert
            exception.Should().BeNull();
        }

        /// <summary>
        /// Tests the OnPreviewTextInput method with valid numeric input.
        /// </summary>
        [WpfFact]
        public void OnPreviewTextInput_ShouldAllowValidNumericInput()
        {
            // Arrange
            var eventArgs = new TextCompositionEventArgs(InputManager.Current.PrimaryKeyboardDevice, new TextComposition(InputManager.Current, this.control, "123"))
            {
                RoutedEvent = UIElement.PreviewTextInputEvent,
            };

            // Act
            this.control.OnPreviewTextInput(this.control, eventArgs);

            // Assert
            eventArgs.Handled.Should().BeFalse();
        }

        /// <summary>
        /// Tests the OnPreviewTextInput method with invalid input.
        /// </summary>
        [WpfFact]
        public void OnPreviewTextInput_ShouldBlockInvalidInput()
        {
            // Arrange
            var eventArgs = new TextCompositionEventArgs(InputManager.Current.PrimaryKeyboardDevice, new TextComposition(InputManager.Current, this.control, "abc"))
            {
                RoutedEvent = UIElement.PreviewTextInputEvent,
            };

            // Act
            this.control.OnPreviewTextInput(this.control, eventArgs);

            // Assert
            eventArgs.Handled.Should().BeTrue();
        }

        /// <summary>
        /// Tests the OnTextBoxGotFocus method to ensure it selects all text.
        /// </summary>
        [WpfFact]
        public void OnTextBoxGotFocus_ShouldSelectAllText()
        {
            // Arrange
            var textBox = new TextBox { Text = "Sample Text" };
            var eventArgs = new RoutedEventArgs();

            // Act
            this.control.OnTextBoxGotFocus(textBox, eventArgs);

            // Assert
            textBox.SelectionLength.Should().Be(textBox.Text.Length);
        }
    }
}