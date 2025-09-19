// <copyright file="PolynomialTermViewModel.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace Sde.EulersIdentity.WPF.ViewModels
{
    using System;
    using System.Windows.Input;
    using Sde.EulersIdentity;
    using Sde.EulersIdentity.WPF.Utilities;

    /// <summary>
    /// ViewModel for the PolynomialTerm control.
    /// </summary>
    public class PolynomialTermViewModel : ViewModelBase
    {
        private string coefficient = string.Empty;
        private string exponent = string.Empty;

        /// <summary>
        /// Gets or sets the coefficient value as a string.
        /// </summary>
        public string Coefficient
        {
            get => this.coefficient;
            set
            {
                var sanitised = InputValidationUtilities.CleanFloatingPointInput(value);
                this.SetProperty(ref this.coefficient, sanitised);
            }
        }

        /// <summary>
        /// Gets or sets the exponent value as a string.
        /// </summary>
        public string Exponent
        {
            get => this.exponent;
            set
            {
                var sanitised = InputValidationUtilities.CleanFloatingPointInput(value);
                this.SetProperty(ref this.exponent, sanitised);
            }
        }

        /// <summary>
        /// Converts the view model to a PolynomialTerm.
        /// </summary>
        /// <returns>A PolynomialTerm object.</returns>
        public PolynomialTerm ToPolynomialTerm()
        {
            var newCoefficient = double.TryParse(this.Coefficient, out var parsedCoefficient) ? parsedCoefficient : 0;
            var newExponent = double.TryParse(this.Exponent, out var parsedExponent) ? parsedExponent : 0;
            return new PolynomialTerm(newCoefficient, newExponent);
        }
    }
}