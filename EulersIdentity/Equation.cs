// <copyright file="Equation.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace Sde.EulersIdentity
{
    /// <summary>
    /// Represents a mathematical equation with polynomial expressions on both sides.
    /// </summary>
    public class Equation(IPolynomial left, IPolynomial right) : IEquation
    {
        /// <summary>
        /// Gets the polynomial on the left side of the equation.
        /// </summary>
        public IPolynomial Left { get; } = left;

        /// <summary>
        /// Gets the polynomial on the right side of the equation.
        /// </summary>
        public IPolynomial Right { get; } = right;

        /// <summary>
        /// Returns a string representation of the equation.
        /// </summary>
        /// <returns>
        /// A string representation of the equation, in the format "left = right".
        /// </returns>
        public override string ToString()
        {
            return $"{this.Left} = {this.Right}";
        }
    }
}