// <copyright file="EquationTest.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace Sde.EulersIdentity.Test
{
    using FluentAssertions;
    using Xunit;

    /// <summary>
    /// Unit tests for the <see cref="Equation"/> class.
    /// </summary>
    public class EquationTest
    {
        /// <summary>
        /// Verifies that the constructor initializes the properties correctly.
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitialiseProperties()
        {
            // Arrange
            var left = new Polynomial();
            left.Add(new PolynomialTerm(3, 2)); // 3x^2

            var right = new Polynomial();
            right.Add(new PolynomialTerm(2, 2)); // 2x^2

            // Act
            var equation = new Equation(left, right);

            // Assert
            equation.Left.Should().BeSameAs(left);
            equation.Right.Should().BeSameAs(right);
        }
    }
}