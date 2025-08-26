// <copyright file="Polynomial.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace Sde.EulersIdentity
{
    /// <summary>
    /// Represents a polynomial, which is a mathematical expression consisting
    /// of variables and coefficients.
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
        /// Gets the terms which make up the polynomial.
        /// </summary>
        public IReadOnlyList<IPolynomialTerm> Terms => this.terms.AsReadOnly();

        /// <summary>
        /// Adds the supplied term to the polynomial.
        /// </summary>
        /// <param name="term">The term to add to the polynomial.</param>
        public void Add(IPolynomialTerm term)
        {
            this.terms.Add(term);
        }

        /// <summary>
        /// Subtracts the supplied term from the polynomial.
        /// </summary>
        /// <param name="term">The term to subtract from the polynomial.</param>
        public void Subtract(IPolynomialTerm term)
        {
            var existingTerm = this.GetTermByExponent(term.Exponent);
            if (existingTerm != null)
            {
                this.terms.Remove(existingTerm);
                var newCoefficient = existingTerm.Coefficient - term.Coefficient;

                // Avoid adding terms with near-zero coefficients
                if (Math.Abs(newCoefficient) > 0.0001)
                {
                    this.terms.Add(new PolynomialTerm(newCoefficient, existingTerm.Exponent));
                }
            }
            else
            {
                this.terms.Add(new PolynomialTerm(-term.Coefficient, term.Exponent));
            }
        }

        /// <summary>
        /// Gets the term with the specified exponent, or null if no such term exists.
        /// </summary>
        /// <param name="exponent">The exponent of the term to get.</param>
        /// <param name="tolerance">
        /// The maximum difference between the two exponents for them to be considered equal.
        /// </param>
        /// <returns>The term with the specified exponent, or null.</returns>
        public IPolynomialTerm? GetTermByExponent(double exponent, double tolerance = 0.0001)
        {
            return this.terms
                .OfType<PolynomialTerm>()
                .FirstOrDefault(t => Math.Abs(t.Exponent - exponent) <= tolerance);
        }

        /// <summary>
        /// Multiplies the polynomial by the supplied term.
        /// </summary>
        /// <param name="term">The term to multiply by.</param>
        public void Multiply(IPolynomialTerm term)
        {
            for (int i = 0; i < this.terms.Count; i++)
            {
                var currentTerm = this.terms[i];
                this.terms[i] = new PolynomialTerm(
                    currentTerm.Coefficient * term.Coefficient,
                    currentTerm.Exponent + term.Exponent);
            }
        }

        /// <summary>
        /// Divides the polynomial by the supplied term.
        /// </summary>
        /// <param name="term">The term to divide by.</param>
        public void Divide(IPolynomialTerm term)
        {
            for (int i = 0; i < this.terms.Count; i++)
            {
                var currentTerm = this.terms[i];
                this.terms[i] = new PolynomialTerm(
                    currentTerm.Coefficient / term.Coefficient,
                    currentTerm.Exponent - term.Exponent);
            }
        }

        /// <summary>
        /// Evaluates the polynomial at a given value of x.
        /// </summary>
        /// <param name="x">The value of x for which to evaluate the polynomial.</param>
        /// <returns>The value of the polynomial for the supplied value of x.</returns>
        public double Evaluate(double x)
        {
            return this.terms.Sum(term => term.Evaluate(x));
        }

        /// <summary>
        /// Returns a string representation of the polynomial.
        /// </summary>
        /// <returns>
        /// A string representation of each of the terms in the polynomial.
        /// </returns>
        public override string ToString()
        {
            return string.Join(" + ", this.terms.Select(term => term.ToString()));
        }
    }
}