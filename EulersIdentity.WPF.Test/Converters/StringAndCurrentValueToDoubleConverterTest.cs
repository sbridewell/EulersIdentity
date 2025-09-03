// <copyright file="StringAndCurrentValueToDoubleConverterTest.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace Sde.EulersIdentity.WPF.Test.Converters
{
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Windows.Data;
    using FluentAssertions;
    using Sde.EulersIdentity.WPF.Converters;
    using Xunit;

    /// <summary>
    /// Unit tests for the <see cref="StringAndCurrentValueToDoubleConverter"/> class.
    /// </summary>
    public class StringAndCurrentValueToDoubleConverterTest
    {
        private readonly StringAndCurrentValueToDoubleConverter converter = new();

        /// <summary>
        /// Tests that Convert returns the string representation of the current value.
        /// </summary>
        [Fact]
        public void Convert_ShouldReturnStringForCurrentValue()
        {
            // Arrange
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            object[] values = { 123.45, null };
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

            // Act
            var result = this.converter.Convert(values, typeof(string), string.Empty, CultureInfo.InvariantCulture);

            // Assert
            result.Should().Be("123.45");
        }

        /// <summary>
        /// Tests that Convert returns an empty string when the current value is not a double.
        /// </summary>
        [Fact]
        public void Convert_ShouldReturnEmptyStringForInvalidCurrentValue()
        {
            // Arrange
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            object[] values = { "invalid", null };
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

            // Act
            var result = this.converter.Convert(values, typeof(string), string.Empty, CultureInfo.InvariantCulture);

            // Assert
            result.Should().Be(string.Empty);
        }

        /// <summary>
        /// Tests that ConvertBack returns the parsed double value and Binding.DoNothing for valid input.
        /// </summary>
        [Fact]
        public void ConvertBack_ShouldReturnParsedDoubleForValidString()
        {
            // Arrange
            object value = "123.45";

            // Act
            var result = this.converter.ConvertBack(value, new[] { typeof(double), typeof(object) }, string.Empty, CultureInfo.InvariantCulture);

            // Assert
            result.Should().BeEquivalentTo(new object[] { 123.45, Binding.DoNothing });
        }

        /// <summary>
        /// Tests that ConvertBack returns Binding.DoNothing for invalid input.
        /// </summary>
        [Fact]
        public void ConvertBack_ShouldReturnBindingDoNothingForInvalidString()
        {
            // Arrange
            object value = "invalid";

            // Act
            var result = this.converter.ConvertBack(value, new[] { typeof(double), typeof(object) }, string.Empty, CultureInfo.InvariantCulture);

            // Assert
            result.Should().BeEquivalentTo(new object[] { Binding.DoNothing, Binding.DoNothing });
        }

        /// <summary>
        /// Tests that ConvertBack returns Binding.DoNothing for null input.
        /// </summary>
        [Fact]
        public void ConvertBack_ShouldReturnBindingDoNothingForNullInput()
        {
            // Arrange
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            object value = null;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            // Act
#pragma warning disable CS8604 // Possible null reference argument.
            var result = this.converter.ConvertBack(value, new[] { typeof(double), typeof(object) }, string.Empty, CultureInfo.InvariantCulture);
#pragma warning restore CS8604 // Possible null reference argument.

            // Assert
            result.Should().BeEquivalentTo(new object[] { Binding.DoNothing, Binding.DoNothing });
        }
    }
}