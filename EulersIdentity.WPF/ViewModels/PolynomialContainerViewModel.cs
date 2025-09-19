// <copyright file="PolynomialContainerViewModel.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace Sde.EulersIdentity.WPF.ViewModels
{
    using System.Windows.Input;

    /// <summary>
    /// ViewModel for the PolynomialContainer user control.
    /// </summary>
    public class PolynomialContainerViewModel : ViewModelBase
    {
        private double xValue;
        private string polynomialString = string.Empty;
        private double evaluationResult;

        /// <summary>
        /// Initializes a new instance of the <see cref="PolynomialContainerViewModel"/> class.
        /// </summary>
        public PolynomialContainerViewModel()
        {
            this.PolynomialControlViewModel = new PolynomialControlViewModel();
            this.EvaluateCommand = new RelayCommand(this.Evaluate);
        }

        /// <summary>
        /// Gets the ViewModel for the PolynomialControl.
        /// </summary>
        public PolynomialControlViewModel PolynomialControlViewModel { get; }

        /// <summary>
        /// Gets or sets the value of x for evaluation.
        /// </summary>
        public double XValue
        {
            get => this.xValue;
            set => this.SetProperty(ref this.xValue, value);
        }

        /// <summary>
        /// Gets the string representation of the polynomial.
        /// </summary>
        public string PolynomialString
        {
            get => this.polynomialString;
            private set => this.SetProperty(ref this.polynomialString, value);
        }

        /// <summary>
        /// Gets the evaluation result of the polynomial.
        /// </summary>
        public double EvaluationResult
        {
            get => this.evaluationResult;
            private set => this.SetProperty(ref this.evaluationResult, value);
        }

        /// <summary>
        /// Gets the command to evaluate the polynomial.
        /// </summary>
        public ICommand EvaluateCommand { get; }

        private void Evaluate()
        {
            var polynomial = this.PolynomialControlViewModel.ToPolynomial();
            this.PolynomialString = polynomial.ToString();
            this.EvaluationResult = polynomial.Evaluate(this.XValue);
        }
    }
}