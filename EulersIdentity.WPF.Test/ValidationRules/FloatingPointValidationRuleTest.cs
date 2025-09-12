// <copyright file="FloatingPointValidationRuleTest.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace Sde.EulersIdentity.WPF.Test.ValidationRules
{
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using FluentAssertions;
    using Sde.EulersIdentity.WPF.ValidationRules;
    using Xunit;

    /// <summary>
    /// Unit tests for the <see cref="FloatingPointValidationRule"/> class.
    /// </summary>
    public class FloatingPointValidationRuleTest
    {
        /// <summary>
        /// Tests the Validate method with valid and invalid inputs.
        /// </summary>
        /// <param name="input">The text to validate.</param>
        /// <param name="expectedIsValid">Whether the validation is expected to pass.</param>
        [Theory]
        [InlineData("1.23", true)] // Valid floating-point number
        [InlineData("-4.56", true)] // Valid negative floating-point number
        [InlineData("0", true)] // Valid integer
        [InlineData("123", true)] // Valid integer
        [InlineData("1.2.3", false)] // Invalid: multiple decimal points
        [InlineData("--1.23", false)] // Invalid: multiple negative signs
        [InlineData("abc", false)] // Invalid: non-numeric input
        [InlineData("", false)] // Invalid: empty string
        [InlineData(null, false)] // Invalid: null value
        [SuppressMessage(
            "Usage",
            "xUnit1012:Null should only be used for nullable parameters",
            Justification = "Intentional test for null argument scenario")]
        public void Validate_ShouldReturnExpectedResult(string input, bool expectedIsValid)
        {
            // Arrange
            var rule = new FloatingPointValidationRule();

            // Act
            var result = rule.Validate(input, CultureInfo.InvariantCulture);

            // Assert
            result.IsValid.Should().Be(expectedIsValid);
        }
    }
}
