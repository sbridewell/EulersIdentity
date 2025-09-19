// <copyright file="InputValidationUtilitiesTest.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace Sde.EulersIdentity.WPF.Test.Utilities
{
    using FluentAssertions;
    using Sde.EulersIdentity.WPF.Utilities;
    using Xunit;

    /// <summary>
    /// Unit tests for the <see cref="InputValidationUtilities"/> class.
    /// </summary>
    public class InputValidationUtilitiesTest
    {
        /// <summary>
        /// Tests the <see cref="InputValidationUtilities.IsValidFloatingPointInput"/> method
        /// with valid and invalid inputs.
        /// </summary>
        /// <param name="input">The input string to validate.</param>
        /// <param name="expected">Whether the input is expected to be valid.</param>
        [Theory]
        [InlineData("1.23", true)] // Valid floating-point number
        [InlineData("-4.56", true)] // Valid negative floating-point number
        [InlineData("0", true)] // Valid integer
        [InlineData("123", true)] // Valid integer
        [InlineData("1.2.3", false)] // Invalid: multiple decimal points
        [InlineData("--1.23", false)] // Invalid: multiple negative signs
        [InlineData("abc", false)] // Invalid: non-numeric input
        [InlineData("", true)] // Valid: empty string
        [InlineData(".", true)] // Valid: only decimal point
        [InlineData("-", true)] // Valid: single hyphen
        [InlineData("-.", true)] // Valid: negative decimal
        [InlineData("-1.", true)] // Valid negative number with trailing decimal
        [InlineData(".23", true)] // Valid number with leading decimal
        [InlineData("1.", true)] // Valid number with trailing decimal
        public void IsValidFloatingPointInput_ShouldReturnExpectedResult(string input, bool expected)
        {
            // Act
            var result = InputValidationUtilities.IsValidFloatingPointInput(input);

            // Assert
            result.Should().Be(expected);
        }

        /// <summary>
        /// Tests the <see cref="InputValidationUtilities.CleanFloatingPointInput"/> method
        /// with various inputs.
        /// </summary>
        /// <param name="input">The input string to clean.</param>
        /// <param name="expected">The expected cleaned string.</param>
        [Theory]
        [InlineData("1.23", "1.23")] // Valid input
        [InlineData("-4.56", "-4.56")] // Valid negative input
        [InlineData("1.2.3", "1.23")] // Invalid: multiple decimal points
        [InlineData("--1.23", "-1.23")] // Invalid: multiple negative signs
        [InlineData("abc", "")] // Invalid: non-numeric input
        [InlineData("", "")] // Empty string
        [InlineData(".", ".")] // Valid: single decimal point
        [InlineData("-", "-")] // Valid: single hyphen
        [InlineData("-.", "-.")] // Valid: negative decimal
        [InlineData("-1.", "-1.")] // Valid negative number with trailing decimal
        [InlineData(".23", ".23")] // Valid number with leading decimal
        [InlineData("1.", "1.")] // Valid number with trailing decimal
        public void CleanFloatingPointInput_ShouldReturnExpectedResult(string input, string expected)
        {
            // Act
            var result = InputValidationUtilities.CleanFloatingPointInput(input);

            // Assert
            result.Should().Be(expected);
        }
    }
}