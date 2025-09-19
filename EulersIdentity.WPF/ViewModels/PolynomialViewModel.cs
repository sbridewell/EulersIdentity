// <copyright file="PolynomialViewModel.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace Sde.EulersIdentity.WPF.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Windows.Input;
    using Sde.EulersIdentity;

    /// <summary>
    /// ViewModel for managing polynomials in the WPF application.
    /// </summary>
    public class PolynomialViewModel : ViewModelBase
    {
        private string xValue = string.Empty;
        private string result = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="PolynomialViewModel"/> class.
        /// </summary>
        public PolynomialViewModel()
        {
            this.Terms = new ObservableCollection<PolynomialTermViewModel>();
            this.AddTermCommand = new RelayCommand(this.AddTerm);
            this.RemoveTermCommand = new RelayCommand(this.RemoveTerm, this.CanRemoveTerm);
            this.EvaluateCommand = new RelayCommand(this.Evaluate, this.CanEvaluate);
        }

        /// <summary>
        /// Gets the collection of polynomial terms.
        /// </summary>
        public ObservableCollection<PolynomialTermViewModel> Terms { get; }

        /// <summary>
        /// Gets or sets the value of x for polynomial evaluation.
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
        /// Gets the command to add a new polynomial term.
        /// </summary>
        public ICommand AddTermCommand { get; }

        /// <summary>
        /// Gets the command to remove the last polynomial term.
        /// </summary>
        public ICommand RemoveTermCommand { get; }

        /// <summary>
        /// Gets the command to evaluate the polynomial.
        /// </summary>
        public ICommand EvaluateCommand { get; }

        private void AddTerm()
        {
            this.Terms.Add(new PolynomialTermViewModel());
            Debug.WriteLine("Current Terms Collection:");
            foreach (var term in this.Terms)
            {
                Debug.WriteLine(term.GetType().Name);
            }
        }

        private bool CanRemoveTerm()
        {
            return this.Terms.Count > 0;
        }

        private void RemoveTerm()
        {
            if (this.Terms.Count > 0)
            {
                this.Terms.RemoveAt(this.Terms.Count - 1);
            }
        }

        private bool CanEvaluate()
        {
            return this.Terms.Count > 0 && !string.IsNullOrWhiteSpace(this.XValue);
        }

        private void Evaluate()
        {
            var polynomial = new Polynomial();

            foreach (var termViewModel in this.Terms)
            {
                if (double.TryParse(termViewModel.Coefficient, out double coefficient) &&
                    double.TryParse(termViewModel.Exponent, out double exponent))
                {
                    polynomial.Add(new PolynomialTerm(coefficient, exponent));
                }
            }

            if (double.TryParse(this.XValue, out double x))
            {
                this.Result = polynomial.Evaluate(x).ToString();
            }
            else
            {
                this.Result = "Invalid x value.";
            }
        }
    }
}