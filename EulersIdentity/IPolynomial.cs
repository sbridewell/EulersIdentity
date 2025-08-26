// <copyright file="IPolynomial.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace Sde.EulersIdentity
{
    /// <summary>
    /// Interface for a polynomial, which is a mathematical expression consisting
    /// of variables and coefficients.
    /// </summary>
    public interface IPolynomial
    {
        /// <summary>
        /// Gets the terms which make up the polynomial.
        /// </summary>
        IReadOnlyList<IPolynomialTerm> Terms { get; }

        /// <summary>
        /// Adds the supplied term to the polynomial.
        /// </summary>
        /// <param name="term">The term to add to the polynomial.</param>
        void Add(IPolynomialTerm term);

        /// <summary>
        /// Subtracts the supplied term from the polynomial.
        /// </summary>
        /// <param name="term">The term to subtract from the polynomial.</param>
        void Subtract(IPolynomialTerm term);

        /// <summary>
        /// Multiplies the polynomial by the supplied term.
        /// </summary>
        /// <param name="term">The term to multiply by.</param>
        void Multiply(IPolynomialTerm term);

        /// <summary>
        /// Divides the polynomial by the supplied term.
        /// </summary>
        /// <param name="term">The term to divide by.</param>
        void Divide(IPolynomialTerm term);

        /// <summary>
        /// Evaluates the polynomial at a given value of x.
        /// </summary>
        /// <param name="x">The value of x for which to evaluate the polynomial.</param>
        /// <returns>The value of the polynomial for the supplied value of x.</returns>
        double Evaluate(double x);

        /// <summary>
        /// Gets the term with the specified exponent, or null if no such term exists.
        /// </summary>
        /// <remarks>
        /// In order to avoid using the `==` operator to compare floating point numbers,
        /// this method will look for a term where the difference between the term's
        /// exponent and the supplied exponent is less than a given tolerance.
        /// </remarks>
        /// <param name="exponent">The exponent of the term to get.</param>
        /// <param name="tolerance">
        /// The maximum difference between the two exponents for them to be considered equal.
        /// </param>
        /// <returns>The term with the specified exponent, or null.</returns>
        PolynomialTerm? GetTermByExponent(double exponent, double tolerance = 0.0001);

        /// <summary>
        /// Returns a string representation of the polynomial.
        /// </summary>
        /// <returns>
        /// A string representation of each of the terms in the polynomial.
        /// </returns>
        string ToString();
    }
}
