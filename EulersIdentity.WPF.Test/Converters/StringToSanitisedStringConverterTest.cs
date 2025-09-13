// <copyright file="StringToSanitisedStringConverterTest.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace Sde.EulersIdentity.WPF.Test.Converters
{
    using System.Globalization;
    using FluentAssertions;
    using Sde.EulersIdentity.WPF.Converters;

    /// <summary>
    /// Unit tests for the <see cref="Sde.EulersIdentity.WPF.Converters.StringToSanitisedDoubleStringConverter"/> class.
    /// </summary>
    public class StringToSanitisedStringConverterTest
    {
        /// <summary>
        /// Tests the Convert method.
        /// </summary>
        [Fact]
        public void Convert_ShouldSanitizeInput()
        {
            // Arrange
            var converter = new StringToSanitisedDoubleStringConverter();
            string input = "12.34abc";
            string expected = "12.34";

            // Act
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            var result = converter.Convert(input, null, null, CultureInfo.InvariantCulture);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

            // Assert
            result.Should().Be(expected);
        }

        /// <summary>
        /// Tests the ConvertBack method.
        /// </summary>
        [Fact]
        public void ConvertBack_ShouldSanitizeInput()
        {
            // Arrange
            var converter = new StringToSanitisedDoubleStringConverter();
            string input = "12.34abc";
            string expected = "12.34";

            // Act
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            var result = converter.ConvertBack(input, null, null, CultureInfo.InvariantCulture);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

            // Assert
            result.Should().Be(expected);
        }

        /// <summary>
        /// Tests that the Convert method returns non-string inputs unchanged.
        /// </summary>
        [Fact]
        public void Convert_ShouldReturnNonStringInputUnchanged()
        {
            // Arrange
            var converter = new StringToSanitisedDoubleStringConverter();
            int input = 42; // Example of a non-string input
            int expected = input;

            // Act
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            var result = converter.Convert(input, null, null, CultureInfo.InvariantCulture);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

            // Assert
            result.Should().Be(expected);
        }
    }
}
