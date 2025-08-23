// <copyright file="IEquation.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace Sde.EulersIdentity
{
    /// <summary>
    /// Interface for a mathematical equation.
    /// </summary>
    public interface IEquation
    {
        /// <summary>
        /// Gets the polynomial on the left side of the equation.
        /// </summary>
        IPolynomial Left { get; }

        /// <summary>
        /// Gets the polynomial on the right side of the equation.
        /// </summary>
        IPolynomial Right { get; }
    }
}
