// <copyright file="PolynomialTest.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace Sde.EulersIdentity.Test
{
    using FluentAssertions;
    using Xunit;

    /// <summary>
    /// Unit tests for the <see cref="Polynomial"/> class.
    /// </summary>
    public class PolynomialTest
    {
        /// <summary>
        /// Verifies that the Evaluate method returns the correct value for a polynomial.
        /// </summary>
        [Fact]
        public void Evaluate_ShouldReturnCorrectValue()
        {
            // Arrange
            var polynomial = new Polynomial();
            polynomial.Add(new PolynomialTerm(3, 2)); // 3x^2
            polynomial.Add(new PolynomialTerm(2, 1)); // 2x
            polynomial.Add(new PolynomialTerm(1, 0)); // 1

            // Act
            var result = polynomial.Evaluate(2); // Evaluate for x = 2

            // Assert
            result.Should().Be(17); // 3 * 2^2 + 2 * 2 + 1 = 17
        }

        /// <summary>
        /// Verifies that the Subtract method correctly subtracts a term from the polynomial.
        /// </summary>
        [Fact]
        public void Subtract_ShouldSubtractTermCorrectly()
        {
            // Arrange
            var polynomial = new Polynomial();
            polynomial.Add(new PolynomialTerm(3, 2)); // 3x^2

            // Act
            polynomial.Subtract(new PolynomialTerm(1, 2)); // Subtract 1x^2

            // Assert
            polynomial.Evaluate(1).Should().Be(2); // 3x^2 - 1x^2 = 2x^2
        }

        /// <summary>
        /// Verifies that the Multiply method correctly multiplies the polynomial by a term.
        /// </summary>
        [Fact]
        public void Multiply_ShouldMultiplyTermCorrectly()
        {
            // Arrange
            var polynomial = new Polynomial();
            polynomial.Add(new PolynomialTerm(3, 2)); // 3x^2

            // Act
            polynomial.Multiply(new PolynomialTerm(2, 1)); // Multiply by 2x

            // Assert
            polynomial.Evaluate(1).Should().Be(6); // 3x^2 * 2x = 6x^3
        }

        /// <summary>
        /// Verifies that the Divide method correctly divides the polynomial by a term.
        /// </summary>
        [Fact]
        public void Divide_ShouldDivideTermCorrectly()
        {
            // Arrange
            var polynomial = new Polynomial();
            polynomial.Add(new PolynomialTerm(6, 3)); // 6x^3

            // Act
            polynomial.Divide(new PolynomialTerm(2, 1)); // Divide by 2x

            // Assert
            polynomial.Evaluate(1).Should().Be(3); // 6x^3 / 2x = 3x^2
        }

        /// <summary>
        /// Verifies that the ToString method returns the correct string representation of the polynomial.
        /// </summary>
        [Fact]
        public void ToString_ShouldReturnCorrectRepresentation()
        {
            // Arrange
            var polynomial = new Polynomial();
            polynomial.Add(new PolynomialTerm(3, 2)); // 3x^2
            polynomial.Add(new PolynomialTerm(2, 1)); // 2x

            // Act
            var result = polynomial.ToString();

            // Assert
            result.Should().Be("3x^2 + 2x^1");
        }
    }
}