// <copyright file="PolynomialTerm.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace Sde.EulersIdentity
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Represents a single term in a polynomial, such as 3x^2.
    /// </summary>
    public class PolynomialTerm : IPolynomialTerm
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PolynomialTerm"/> class.
        /// </summary>
        /// <param name="coefficient">The coefficient of the term.</param>
        /// <param name="exponent">The exponent of the term.</param>
        public PolynomialTerm(double coefficient, double exponent)
        {
            this.Coefficient = coefficient;
            this.Exponent = exponent;
        }

        /// <summary>
        /// Gets or sets the coefficient of the term.
        /// </summary>
        public double Coefficient { get; set; }

        /// <summary>
        /// Gets or sets the exponent of the term.
        /// </summary>
        public double Exponent { get; set; }

        /// <summary>
        /// Evaluates the term for a given value of x.
        /// </summary>
        /// <param name="x">The value of x.</param>
        /// <returns>The result of the term evaluation.</returns>
        public double Evaluate(double x)
        {
            return this.Coefficient * Math.Pow(x, this.Exponent);
        }

        /// <summary>
        /// Returns a string representation of the term.
        /// </summary>
        /// <returns>A string representation of the term, in the format cx^e.</returns>
        public override string ToString()
        {
            return $"{this.Coefficient}x^{this.Exponent}";
        }
    }
}