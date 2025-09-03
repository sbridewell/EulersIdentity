// <copyright file="PolynomialTermViewModel.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace Sde.EulersIdentity.WPF.ViewModels
{
    using System;
    using System.Windows.Input;
    using Sde.EulersIdentity;

    /// <summary>
    /// ViewModel for the PolynomialTerm control.
    /// </summary>
    public class PolynomialTermViewModel : ViewModelBase
    {
        private string coefficient = string.Empty;
        private string exponent = string.Empty;
        private string xValue = string.Empty;
        private string result = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="PolynomialTermViewModel"/> class.
        /// </summary>
        public PolynomialTermViewModel()
        {
            this.EvaluateCommand = new RelayCommand(this.Evaluate, this.CanEvaluate);
        }

        /// <summary>
        /// Gets or sets the coefficient value as a string.
        /// </summary>
        public string Coefficient
        {
            get => this.coefficient;
            set => this.SetProperty(ref this.coefficient, value);
        }

        /// <summary>
        /// Gets or sets the exponent value as a string.
        /// </summary>
        public string Exponent
        {
            get => this.exponent;
            set => this.SetProperty(ref this.exponent, value);
        }

        /// <summary>
        /// Gets or sets the x value as a string.
        /// </summary>
        public string XValue
        {
            get => this.xValue;
            set => this.SetProperty(ref this.xValue, value);
        }

        /// <summary>
        /// Gets the result of the polynomial evaluation.
        /// </summary>
        public string Result
        {
            get => this.result;
            private set => this.SetProperty(ref this.result, value);
        }

        /// <summary>
        /// Gets a command to evaluate the polynomial term.
        /// </summary>
        public ICommand EvaluateCommand { get; }

        private bool CanEvaluate()
        {
            return !string.IsNullOrWhiteSpace(this.Coefficient) &&
                   !string.IsNullOrWhiteSpace(this.Exponent) &&
                   !string.IsNullOrWhiteSpace(this.XValue);
        }

        private void Evaluate()
        {
            try
            {
                if (!double.TryParse(this.Coefficient, out double coefficientValue))
                {
                    throw new FormatException("Invalid coefficient.");
                }

                if (!double.TryParse(this.Exponent, out double exponentValue))
                {
                    throw new FormatException("Invalid exponent.");
                }

                if (!double.TryParse(this.XValue, out double numericXValue))
                {
                    throw new FormatException("Invalid value for x.");
                }

                var term = new PolynomialTerm(coefficientValue, exponentValue);
                this.Result = term.Evaluate(numericXValue).ToString();
            }
            catch (Exception ex)
            {
                this.Result = $"Error: {ex.Message}";
            }
        }
    }
}