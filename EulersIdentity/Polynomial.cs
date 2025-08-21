// <copyright file="Polynomial.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace Sde.EulersIdentity
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <summary>
    /// Represents a polynomial expression, such as 3x^2 + 2x + 1.
    /// </summary>
    public class Polynomial : IPolynomial
    {
        private readonly List<IPolynomialTerm> terms;

        /// <summary>
        /// Initializes a new instance of the <see cref="Polynomial"/> class.
        /// </summary>
        public Polynomial()
        {
            this.terms = new List<IPolynomialTerm>();
        }

        /// <summary>
        /// Gets the terms of the polynomial.
        /// </summary>
        [ExcludeFromCodeCoverage]
        public List<IPolynomialTerm> Terms => this.terms;

        /// <summary>
        /// Adds a term to the polynomial.
        /// </summary>
        /// <param name="term">The term to add.</param>
        public void Add(IPolynomialTerm term)
        {
            this.terms.Add(term);
        }

        /// <summary>
        /// Subtracts a term from the polynomial.
        /// </summary>
        /// <param name="term">The term to subtract.</param>
        public void Subtract(IPolynomialTerm term)
        {
            this.terms.Add(new PolynomialTerm(-term.Coefficient, term.Exponent));
        }

        /// <summary>
        /// Multiplies the polynomial by a term.
        /// </summary>
        /// <param name="term">The term to multiply by.</param>
        public void Multiply(IPolynomialTerm term)
        {
            for (int i = 0; i < this.terms.Count; i++)
            {
                var current = this.terms[i];
                this.terms[i] = new PolynomialTerm(current.Coefficient * term.Coefficient, current.Exponent + term.Exponent);
            }
        }

        /// <summary>
        /// Divides the polynomial by a term.
        /// </summary>
        /// <param name="term">The term to divide by.</param>
        public void Divide(IPolynomialTerm term)
        {
            for (int i = 0; i < this.terms.Count; i++)
            {
                var current = this.terms[i];
                this.terms[i] = new PolynomialTerm(current.Coefficient / term.Coefficient, current.Exponent - term.Exponent);
            }
        }

        /// <summary>
        /// Evaluates the polynomial for a given value of x.
        /// </summary>
        /// <param name="x">The value of x.</param>
        /// <returns>The result of the polynomial evaluation.</returns>
        public double Evaluate(double x)
        {
            return this.terms.Sum(term => term.Evaluate(x));
        }

        /// <summary>
        /// Returns a string representation of the polynomial.
        /// </summary>
        /// <returns>A string representation of each of the terms in the polynomial.</returns>
        public override string ToString()
        {
            return string.Join(" + ", this.terms);
        }
    }
}