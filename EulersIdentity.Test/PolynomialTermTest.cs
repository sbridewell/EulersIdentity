// <copyright file="PolynomialTermTest.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace Sde.EulersIdentity.Test
{
    using FluentAssertions;
    using Xunit;

    /// <summary>
    /// Unit tests for <see cref="PolynomialTerm"/>.
    /// </summary>
    public class PolynomialTermTest
    {
        /// <summary>
        /// Tests that the Evaluate method calculates the correct value.
        /// </summary>
        [Fact]
        public void Evaluate_CalculatesCorrectValue()
        {
            // Arrange
            var term = new PolynomialTerm(3, 2);
            double x = 2;
            double expectedValue = 12; // 3 * 2^2
            double tolerance = 0.0001;

            // Act
            double result = term.Evaluate(x);

            // Assert
            result.Should().BeApproximately(expectedValue, tolerance);
        }

        /// <summary>
        /// Tests that the ToString method returns the correct string representation.
        /// </summary>
        [Fact]
        public void ToString_ReturnsCorrectRepresentation()
        {
            // Arrange
            var term = new PolynomialTerm(3, 2);
            string expectedString = "3x^2";

            // Act
            string result = term.ToString();

            // Assert
            result.Should().Be(expectedString);
        }
    }
}