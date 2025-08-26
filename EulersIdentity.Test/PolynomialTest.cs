// <copyright file="PolynomialTest.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace Sde.EulersIdentity.Test
{
    using FluentAssertions;
    using Xunit;
    using Xunit.Abstractions;

    /// <summary>
    /// Unit tests for <see cref="Polynomial"/>.
    /// </summary>
    public class PolynomialTest(ITestOutputHelper output)
    {
        /// <summary>
        /// Tests that the Add method adds a term to the polynomial.
        /// </summary>
        [Fact]
        public void Add_AddsTermToPolynomial()
        {
            // Arrange
            var polynomial = new Polynomial();
            var term = new PolynomialTerm(3, 2);

            // Act
            polynomial.Add(term);

            // Assert
            polynomial.Terms.Should().Contain(term);
        }

        /// <summary>
        /// Tests that the Evaluate method calculates the correct value.
        /// </summary>
        [Fact]
        public void Evaluate_CalculatesCorrectValue()
        {
            // Arrange
            var polynomial = new Polynomial();
            polynomial.Add(new PolynomialTerm(3, 2));
            polynomial.Add(new PolynomialTerm(2, 1));
            polynomial.Add(new PolynomialTerm(1, 0));
            double x = 2;
            double expectedValue = 17; // 3 * 2^2 + 2 * 2^1 + 1
            double tolerance = 0.0001;

            // Act
            double result = polynomial.Evaluate(x);

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
            var polynomial = new Polynomial();
            polynomial.Add(new PolynomialTerm(3, 2));
            polynomial.Add(new PolynomialTerm(2, 1));
            polynomial.Add(new PolynomialTerm(1, 0));
            string expectedString = "3x^2 + 2x^1 + 1x^0";

            // Act
            string result = polynomial.ToString();

            // Assert
            result.Should().Be(expectedString);
        }

        /// <summary>
        /// Tests that the Subtract method adds a negated term to the polynomial.
        /// </summary>
        [Fact]
        public void Subtract_AddsNegatedTermToPolynomial()
        {
            // Arrange
            var polynomial = new Polynomial();
            polynomial.Add(new PolynomialTerm(3, 2));
            var termToSubtract = new PolynomialTerm(2, 2);
            output.WriteLine($"Expression: {polynomial} minus {termToSubtract}");
            output.WriteLine($"Expected result: 1x^2");

            // Act
            polynomial.Subtract(termToSubtract);

            // Assert
            output.WriteLine($"Actual result: {polynomial}");
            var negatedTerm = polynomial.GetTermByExponent(2);
            negatedTerm.Should().NotBeNull();
            negatedTerm!.Coefficient.Should().BeApproximately(1, 0.0001);
        }

        /// <summary>
        /// Tests that the Subtract method subtracts an existing term from the polynomial.
        /// </summary>
        [Fact]
        public void Subtract_SubtractsExistingTermFromPolynomial()
        {
            // Arrange
            var polynomial = new Polynomial();
            var existingTerm = new PolynomialTerm(3, 2);
            polynomial.Add(existingTerm);
            var termToSubtract = new PolynomialTerm(2, 2);

            // Act
            polynomial.Subtract(termToSubtract);

            // Assert
            var resultTerm = polynomial.GetTermByExponent(2);
            resultTerm.Should().NotBeNull();
            resultTerm!.Coefficient.Should().BeApproximately(1, 0.0001);
        }

        /// <summary>
        /// Tests that the Subtract method adds a negated term when the term does not exist in the polynomial.
        /// </summary>
        [Fact]
        public void Subtract_AddsNegatedTermWhenTermDoesNotExist()
        {
            // Arrange
            var polynomial = new Polynomial();
            var termToSubtract = new PolynomialTerm(2, 2);

            // Act
            polynomial.Subtract(termToSubtract);

            // Assert
            var resultTerm = polynomial.GetTermByExponent(2);
            resultTerm.Should().NotBeNull();
            resultTerm!.Coefficient.Should().BeApproximately(-2, 0.0001);
        }

        /// <summary>
        /// Tests that the Subtract method does not add a term when the resulting coefficient is near zero.
        /// </summary>
        [Fact]
        public void Subtract_DoesNotAddTermWhenCoefficientIsNearZero()
        {
            // Arrange
            var polynomial = new Polynomial();
            var existingTerm = new PolynomialTerm(0.00005, 2);
            polynomial.Add(existingTerm);
            var termToSubtract = new PolynomialTerm(0.00004, 2);

            // Act
            polynomial.Subtract(termToSubtract);

            // Assert
            polynomial.Terms.Should().BeEmpty();
        }

        /// <summary>
        /// Tests that the Multiply method multiplies the polynomial by a term.
        /// </summary>
        [Fact]
        public void Multiply_MultipliesPolynomialByTerm()
        {
            // Arrange
            var polynomial = new Polynomial();
            polynomial.Add(new PolynomialTerm(3, 2));
            var termToMultiply = new PolynomialTerm(2, 1);

            // Act
            polynomial.Multiply(termToMultiply);

            // Assert
            var multipliedTerm = polynomial.GetTermByExponent(3);
            multipliedTerm.Should().NotBeNull();
            multipliedTerm!.Coefficient.Should().BeApproximately(6, 0.0001);
        }

        /// <summary>
        /// Tests that the Divide method divides the polynomial by a term.
        /// </summary>
        [Fact]
        public void Divide_DividesPolynomialByTerm()
        {
            // Arrange
            var polynomial = new Polynomial();
            polynomial.Add(new PolynomialTerm(6, 3));
            var termToDivide = new PolynomialTerm(2, 1);

            // Act
            polynomial.Divide(termToDivide);

            // Assert
            var dividedTerm = polynomial.GetTermByExponent(2);
            dividedTerm.Should().NotBeNull();
            dividedTerm!.Coefficient.Should().BeApproximately(3, 0.0001);
        }
    }
}