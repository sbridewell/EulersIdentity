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
    /// Unit tests for the <see cref="Sde.EulersIdentity.WPF.Converters.StringToSanitisedStringConverter"/> class.
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
            var converter = new StringToSanitisedStringConverter();
            string input = "12.34abc";
            string expected = "12.34";

            // Act
            var result = converter.Convert(input, null, null, CultureInfo.InvariantCulture);

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
            var converter = new StringToSanitisedStringConverter();
            string input = "12.34abc";
            string expected = "12.34";

            // Act
            var result = converter.ConvertBack(input, null, null, CultureInfo.InvariantCulture);

            // Assert
            result.Should().Be(expected);
        }
    }
}
