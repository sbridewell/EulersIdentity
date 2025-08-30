// <copyright file="EquationTest.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace Sde.EulersIdentity.Test
{
    using FluentAssertions;
    using Xunit;

    /// <summary>
    /// Unit tests for <see cref="Equation"/>.
    /// </summary>
    public class EquationTest
    {
        /// <summary>
        /// Tests that the ToString method returns the correct string representation.
        /// </summary>
        [Fact]
        public void ToString_ReturnsCorrectRepresentation()
        {
            // Arrange
            var left = new Polynomial();
            left.Add(new PolynomialTerm(3, 2));
            left.Add(new PolynomialTerm(2, 1));
            left.Add(new PolynomialTerm(1, 0));

            var right = new Polynomial();
            right.Add(new PolynomialTerm(2, 2));
            right.Add(new PolynomialTerm(1, 0));

            var equation = new Equation(left, right);
            string expectedString = "3x^2 + 2x^1 + 1x^0 = 2x^2 + 1x^0";

            // Act
            string result = equation.ToString();

            // Assert
            result.Should().Be(expectedString);
        }
    }
}