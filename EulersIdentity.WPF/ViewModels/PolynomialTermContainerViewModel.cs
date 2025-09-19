// <copyright file="PolynomialTermContainerViewModel.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace Sde.EulersIdentity.WPF.ViewModels
{
    using System.ComponentModel;

    /// <summary>
    /// ViewModel for the PolynomialTermContainer control.
    /// </summary>
    public class PolynomialTermContainerViewModel : ViewModelBase
    {
        private string xValue = string.Empty;
        private PolynomialTermViewModel polynomialTerm = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="PolynomialTermContainerViewModel"/> class.
        /// </summary>
        public PolynomialTermContainerViewModel()
        {
            this.PolynomialTerm = new PolynomialTermViewModel();
        }

        /// <summary>
        /// Gets or sets the PolynomialTermViewModel.
        /// </summary>
        public PolynomialTermViewModel PolynomialTerm
        {
            get => this.polynomialTerm;
            set
            {
                if (this.SetProperty(ref this.polynomialTerm, value) && this.polynomialTerm != null)
                {
                    this.polynomialTerm.PropertyChanged += this.OnPolynomialTermPropertyChanged;
                }
            }
        }

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
                    this.OnPropertyChanged(nameof(this.PolynomialTermAndResult));
                }
            }
        }

        /// <summary>
        /// Gets the formatted string representation of the polynomial term and its result.
        /// Example: "2 * 9^3 = 1458".
        /// </summary>
        public string PolynomialTermAndResult
        {
            get
            {
                if (double.TryParse(this.PolynomialTerm.Coefficient, out double parsedCoefficient)
                    && double.TryParse(this.XValue, out double parsedXValue)
                    && double.TryParse(this.PolynomialTerm.Exponent, out double parsedExponent))
                {
                    var result = parsedCoefficient * Math.Pow(parsedXValue, parsedExponent);
                    return $"{parsedCoefficient} * {parsedXValue}^{parsedExponent} = {result}";
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        private void OnPolynomialTermPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            // If any more properties are added to PolynomialTermViewModel that don't affect the result,
            // then we need to add the following test to avoid unnecessary updates:
            ////if (e.PropertyName == nameof(PolynomialTermViewModel.Coefficient) ||
            ////    e.PropertyName == nameof(PolynomialTermViewModel.Exponent))
            ////{
            ////    this.OnPropertyChanged(nameof(this.PolynomialTermAndResult));
            ////}

            this.OnPropertyChanged(nameof(this.PolynomialTermAndResult));
        }
    }
}
