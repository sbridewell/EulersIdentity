// <copyright file="IPolynomialTerm.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace Sde.EulersIdentity
{
    /// <summary>
    /// Interface for a single term in a polynomial.
    /// </summary>
    /// <remarks>
    /// For example, in the polynomial 3x^2 + 2x + 1, the terms are:
    /// <list type="bullet">
    /// <item>3x^2</item>
    /// <item>2x</item>
    /// <item>1</item>
    /// </list>
    /// In the term 3x^2, the coefficient is 3 and the exponent is 2.
    /// </remarks>
    public interface IPolynomialTerm
    {
        /// <summary>
        /// Gets the coefficient of the term.
        /// </summary>
        double Coefficient { get; }

        /// <summary>
        /// Gets the exponent of the term.
        /// </summary>
        double Exponent { get; }

        /// <summary>
        /// Evaluates the term at a given value of x.
        /// </summary>
        /// <param name="x">The value of x for which to evaluate the term.</param>
        /// <returns>The value of the term for the supplied value of x.</returns>
        double Evaluate(double x);

        /// <summary>
        /// Gets a string representation of the term.
        /// </summary>
        /// <returns>
        /// A string representation of the term, in the format cx^e,, where
        /// c is the coefficient and e is the exponent.
        /// </returns>
        string ToString();
    }
}
