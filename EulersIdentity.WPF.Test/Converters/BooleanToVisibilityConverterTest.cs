// <copyright file="BooleanToVisibilityConverterTest.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace Sde.EulersIdentity.WPF.Test.Converters
{
    using System.Globalization;
    using System.Windows;
    using FluentAssertions;
    using Sde.EulersIdentity.WPF.Converters;
    using Xunit;

    /// <summary>
    /// Unit tests for the <see cref="BooleanToVisibilityConverter"/> class.
    /// </summary>
    public class BooleanToVisibilityConverterTest
    {
        private readonly BooleanToVisibilityConverter converter = new();

        /// <summary>
        /// Tests that Convert returns Visibility.Visible for true.
        /// </summary>
        [Fact]
        public void Convert_ShouldReturnVisibleForTrue()
        {
            // Arrange
            object value = true;

            // Act
            var result = this.converter.Convert(value, typeof(Visibility), string.Empty, CultureInfo.InvariantCulture);

            // Assert
            result.Should().Be(Visibility.Visible);
        }

        /// <summary>
        /// Tests that Convert returns Visibility.Collapsed for false.
        /// </summary>
        [Fact]
        public void Convert_ShouldReturnCollapsedForFalse()
        {
            // Arrange
            object value = false;

            // Act
            var result = this.converter.Convert(value, typeof(Visibility), string.Empty, CultureInfo.InvariantCulture);

            // Assert
            result.Should().Be(Visibility.Collapsed);
        }

        /// <summary>
        /// Tests that Convert returns Visibility.Collapsed for invalid input.
        /// </summary>
        [Fact]
        public void Convert_ShouldReturnCollapsedForInvalidInput()
        {
            // Arrange
            object value = "invalid";

            // Act
            var result = this.converter.Convert(value, typeof(Visibility), string.Empty, CultureInfo.InvariantCulture);

            // Assert
            result.Should().Be(Visibility.Collapsed);
        }

        /// <summary>
        /// Tests that ConvertBack throws NotImplementedException.
        /// </summary>
        [Fact]
        public void ConvertBack_ShouldThrowNotImplementedException()
        {
            // Arrange
            object value = Visibility.Visible;

            // Act
            var act = () => this.converter.ConvertBack(value, typeof(bool), string.Empty, CultureInfo.InvariantCulture);

            // Assert
            act.Should().Throw<NotImplementedException>().WithMessage("ConvertBack is not implemented for BooleanToVisibilityConverter.");
        }
    }
}