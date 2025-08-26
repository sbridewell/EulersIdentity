// <copyright file="PolynomialTerm.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace Sde.EulersIdentity
{
    /// <summary>
    /// Represents a single term in a polynomial.
    /// </summary>
    public class PolynomialTerm(double coefficient, double exponent) : IPolynomialTerm
    {
        /// <summary>
        /// Gets the coefficient of the term.
        /// </summary>
        public double Coefficient { get; } = coefficient;

        /// <summary>
        /// Gets the exponent of the term.
        /// </summary>
        public double Exponent { get; } = exponent;

        /// <summary>
        /// Evaluates the term at a given value of x.
        /// </summary>
        /// <param name="x">The value of x for which to evaluate the term.</param>
        /// <returns>The value of the term for the supplied value of x.</returns>
        public double Evaluate(double x)
        {
            return this.Coefficient * Math.Pow(x, this.Exponent);
        }

        /// <summary>
        /// Gets a string representation of the term.
        /// </summary>
        /// <returns>
        /// A string representation of the term, in the format cx^e, where
        /// c is the coefficient and e is the exponent.
        /// </returns>
        public override string ToString()
        {
            return $"{this.Coefficient}x^{this.Exponent}";
        }
    }
}