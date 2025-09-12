// <copyright file="FloatingPointInputBehaviourTest.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace Sde.EulersIdentity.WPF.Test.Behaviours
{
    using FluentAssertions;
    using Sde.EulersIdentity.WPF.Behaviours;
    using Xunit;

    /// <summary>
    /// Unit tests for the <see cref="FloatingPointInputBehaviour"/> class.
    /// </summary>
    public class FloatingPointInputBehaviourTest
    {
        /// <summary>
        /// Test cases for the IsValidFloatingPointInput method.
        /// </summary>
        /// <param name="input">The user input to validate.</param>
        /// <param name="expected">Whether or not the input should pass validation.</param>
        [Theory]
        [InlineData("1.23", true)] // Valid number
        [InlineData("-1.23", true)] // Valid negative number
        [InlineData("1.", true)] // Valid number with trailing decimal
        [InlineData(".23", true)] // Valid number with leading decimal
        [InlineData("1.2.3", false)] // Invalid: multiple decimal points
        [InlineData("--1.23", false)] // Invalid: multiple negative signs
        [InlineData("abc", false)] // Invalid: non-numeric input
        [InlineData("", true)] // Valid: empty string
        [InlineData(".", false)] // Invalid: only decimal point
        [InlineData("-", true)] // Valid: single hyphen
        [InlineData("-1.", true)] // Valid negative number with trailing decimal
        public void IsValidFloatingPointInput_ShouldReturnExpectedResult(string input, bool expected)
        {
            // Act
            var result = FloatingPointInputBehaviour.IsValidFloatingPointInput(input);

            // Assert
            result.Should().Be(expected);
        }

        /// <summary>
        /// Tests that the input validation works correctly for various floating point numbers,
        /// including negative numbers.
        /// </summary>
        /// <param name="currentText">The text which is already in the text box.</param>
        /// <param name="newInput">The text newly entered by the user.</param>
        /// <param name="expected">Whether or not the input should pass validation.</param>
        [Theory]
        [InlineData("1.2", ".", false)] // Multiple decimal points
        [InlineData("1", ".", true)] // Single decimal point
        [InlineData("-1", ".", true)] // Negative number with decimal
        [InlineData("1.2", "3", true)] // Valid number
        [InlineData("1.2", "-", false)] // Invalid negative sign
        [InlineData("-1.", "2", true)] // Valid negative number with trailing decimal and digit
        public void OnPreviewTextInput_ShouldValidateCombinedText(string currentText, string newInput, bool expected)
        {
            // Arrange
            var combinedText = currentText + newInput;

            // Act
            var isValid = FloatingPointInputBehaviour.IsValidFloatingPointInput(combinedText);

            // Assert
            isValid.Should().Be(expected);
        }

        /// <summary>
        /// Tests that validation in the ValidatePreviewInput method works correctly.
        /// </summary>
        /// <param name="currentText">The text which is already in the text box.</param>
        /// <param name="newInput">The text newly entered by the user.</param>
        /// <param name="selectionStart">The cursor position within the text box before user input.</param>
        /// <param name="expected">Whether or not the input should pass validation.</param>
        [Theory]
        [InlineData("1.2", ".", 3, false)] // Invalid: trailing decimal point
        [InlineData("1.2", ".", 2, false)] // Invalid: multiple decimal points
        [InlineData("-1", ".", 2, true)] // Valid negative number with decimal
        [InlineData("1.2", "-", 0, true)] // Valid negative sign at the start
        [InlineData("", "1", 0, true)] // Valid: inserting a number into an empty string
        [InlineData("", ".", 0, false)] // Invalid: inserting only a decimal point
        [InlineData("", "-", 0, true)] // Valid: inserting a negative sign into an empty string
        public void ValidatePreviewInput_ShouldReturnExpectedResult(string currentText, string newInput, int selectionStart, bool expected)
        {
            // Act
            var result = FloatingPointInputBehaviour.ValidatePreviewInput(currentText, newInput, selectionStart);

            // Assert
            result.Should().Be(expected);
        }

        /// <summary>
        /// Tests that validation in the ValidatePasteInput method works correctly.
        /// </summary>
        /// <param name="pastedText">The text pasted into the text box.</param>
        /// <param name="expected">Whether or not the input should pass validation.</param>
        [Theory]
        [InlineData("1.23", true)] // Valid pasted text
        [InlineData("1.2.3", false)] // Invalid: multiple decimal points
        [InlineData("-4.56", true)] // Valid negative number
        [InlineData("abc", false)] // Invalid: non-numeric input
        [InlineData("", true)] // Valid: empty string
        [InlineData(".", false)] // Invalid: only decimal point
        [InlineData("-", true)] // Invalid: only negative sign
        public void ValidatePasteInput_ShouldReturnExpectedResult(string pastedText, bool expected)
        {
            // Act
            var result = FloatingPointInputBehaviour.ValidatePasteInput(pastedText);

            // Assert
            result.Should().Be(expected);
        }
    }
}
