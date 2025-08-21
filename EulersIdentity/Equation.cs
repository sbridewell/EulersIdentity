// <copyright file="Equation.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace Sde.EulersIdentity
{
    using System;

    /// <summary>
    /// Represents an equation with polynomial expressions on both sides.
    /// </summary>
    public class Equation : IEquation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Equation"/> class.
        /// </summary>
        /// <param name="left">The polynomial on the left side of the equation.</param>
        /// <param name="right">The polynomial on the right side of the equation.</param>
        public Equation(IPolynomial left, IPolynomial right)
        {
            this.Left = left;
            this.Right = right;
        }

        /// <summary>
        /// Gets the polynomial on the left side of the equation.
        /// </summary>
        public IPolynomial Left { get; }

        /// <summary>
        /// Gets the polynomial on the right side of the equation.
        /// </summary>
        public IPolynomial Right { get; }
    }
}