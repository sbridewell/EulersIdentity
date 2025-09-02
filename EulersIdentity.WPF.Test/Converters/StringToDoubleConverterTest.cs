// <copyright file="StringToDoubleConverterTest.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace Sde.EulersIdentity.WPF.Test.Converters
{
    using System.Globalization;
    using FluentAssertions;
    using Sde.EulersIdentity.WPF.Converters;
    using Xunit;

    /// <summary>
    /// Unit tests for the <see cref="StringToDoubleConverter"/> class.
    /// </summary>
    public class StringToDoubleConverterTest
    {
        private readonly StringToDoubleConverter converter = new();

        /// <summary>
        /// Tests that Convert returns the string representation of a double.
        /// </summary>
        [Fact]
        public void Convert_ShouldReturnStringForDouble()
        {
            // Arrange
            object value = 123.45;

            // Act
            var result = this.converter.Convert(value, typeof(string), string.Empty, CultureInfo.InvariantCulture);

            // Assert
            result.Should().Be("123.45");
        }

        /// <summary>
        /// Tests that Convert returns an empty string for invalid input.
        /// </summary>
        [Fact]
        public void Convert_ShouldReturnEmptyStringForInvalidInput()
        {
            // Arrange
            object value = "invalid";

            // Act
            var result = this.converter.Convert(value, typeof(string), string.Empty, CultureInfo.InvariantCulture);

            // Assert
            result.Should().Be(string.Empty);
        }

        /// <summary>
        /// Tests that ConvertBack returns a double for a valid string.
        /// </summary>
        [Fact]
        public void ConvertBack_ShouldReturnDoubleForValidString()
        {
            // Arrange
            object value = "123.45";

            // Act
            var result = this.converter.ConvertBack(value, typeof(double), string.Empty, CultureInfo.InvariantCulture);

            // Assert
            result.Should().Be(123.45);
        }

        /// <summary>
        /// Tests that ConvertBack returns zero for an empty string.
        /// </summary>
        [Fact]
        public void ConvertBack_ShouldReturnZeroForEmptyString()
        {
            // Arrange
            object value = string.Empty;

            // Act
            var result = this.converter.ConvertBack(value, typeof(double), string.Empty, CultureInfo.InvariantCulture);

            // Assert
            result.Should().Be(0.0);
        }

        /// <summary>
        /// Tests that ConvertBack returns zero for an invalid string.
        /// </summary>
        [Fact]
        public void ConvertBack_ShouldReturnZeroForInvalidString()
        {
            // Arrange
            object value = "invalid";

            // Act
            var result = this.converter.ConvertBack(value, typeof(double), string.Empty, CultureInfo.InvariantCulture);

            // Assert
            result.Should().Be(0.0);
        }
    }
}