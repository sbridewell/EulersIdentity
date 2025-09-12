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
        [InlineData(".", false)] // Invalid: only decimal point
        [InlineData("-", true)] // Valid: single hyphen
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
    }
}