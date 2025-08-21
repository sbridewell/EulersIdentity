// <copyright file="PolynomialTermTest.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace Sde.EulersIdentity.Test
{
    using FluentAssertions;
    using Xunit;

    /// <summary>
    /// Unit tests for the <see cref="PolynomialTerm"/> class.
    /// </summary>
    public class PolynomialTermTest
    {
        /// <summary>
        /// Verifies that the Evaluate method returns the correct value for a polynomial term.
        /// </summary>
        [Fact]
        public void Evaluate_ShouldReturnCorrectValue()
        {
            // Arrange
            var term = new PolynomialTerm(3, 2); // Represents 3x^2

            // Act
            var result = term.Evaluate(2); // Evaluate for x = 2

            // Assert
            result.Should().Be(12); // 3 * 2^2 = 12
        }

        /// <summary>
        /// Verifies that the ToString method returns the correct string representation of the term.
        /// </summary>
        [Fact]
        public void ToString_ShouldReturnCorrectRepresentation()
        {
            // Arrange
            var term = new PolynomialTerm(3, 2); // Represents 3x^2

            // Act
            var result = term.ToString();

            // Assert
            result.Should().Be("3x^2");
        }
    }
}