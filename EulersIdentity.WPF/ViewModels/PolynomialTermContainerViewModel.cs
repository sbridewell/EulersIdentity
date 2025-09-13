// <copyright file="PolynomialTermContainerViewModel.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace Sde.EulersIdentity.WPF.ViewModels
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// ViewModel for the PolynomialTermContainer control.
    /// </summary>
    public class PolynomialTermContainerViewModel : ViewModelBase
    {
        private string xValue = string.Empty;
        private double termValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="PolynomialTermContainerViewModel"/> class.
        /// </summary>
        public PolynomialTermContainerViewModel()
        {
            // Subscribe to changes in PolynomialTerm properties
            this.PolynomialTerm.PropertyChanged += this.OnPolynomialTermPropertyChanged;
        }

        /// <summary>
        /// Gets or sets the PolynomialTermViewModel.
        /// </summary>
        public PolynomialTermViewModel PolynomialTerm { get; set; } = new PolynomialTermViewModel();

        /// <summary>
        /// Gets the text representation of the polynomial term in the format cx^e.
        /// </summary>
        public string PolynomialTermRepresentation
            => $"{this.PolynomialTerm.Coefficient}x^{this.PolynomialTerm.Exponent}";

        /// <summary>
        /// Gets or sets the value of x.
        /// </summary>
        public string XValue
        {
            get => this.xValue;
            set
            {
                if (this.SetProperty(ref this.xValue, value))
                {
                    this.CalculateTermValue();
                }
            }
        }

        /// <summary>
        /// Gets the calculated value of the term for the given value of x.
        /// </summary>
        public double TermValue
        {
            get => this.termValue;
            private set => this.SetProperty(ref this.termValue, value);
        }

        private void CalculateTermValue()
        {
            if (
                double.TryParse(this.PolynomialTerm.Coefficient, out double parsedCoefficient)
                && double.TryParse(this.XValue, out double parsedXValue)
                && double.TryParse(this.PolynomialTerm.Exponent, out double parsedExponent))
            {
                this.TermValue = parsedCoefficient * Math.Pow(parsedXValue, parsedExponent);
            }
            else
            {
                this.TermValue = double.NaN; // Indicate invalid input        }
            }
        }

        private void OnPolynomialTermPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(this.PolynomialTerm.Coefficient) ||
                e.PropertyName == nameof(this.PolynomialTerm.Exponent))
            {
                // Notify that PolynomialTermRepresentation has changed
                this.OnPropertyChanged(nameof(this.PolynomialTermRepresentation));
            }
        }
    }
}
