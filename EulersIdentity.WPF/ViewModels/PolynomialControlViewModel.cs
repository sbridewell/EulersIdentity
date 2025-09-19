// <copyright file="PolynomialControlViewModel.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace Sde.EulersIdentity.WPF.ViewModels
{
    using System.Collections.ObjectModel;

    /// <summary>
    /// ViewModel for managing a collection of polynomial terms and evaluating the polynomial.
    /// </summary>
    public class PolynomialControlViewModel : ViewModelBase
    {
        private double xValue;
        private double result;

        /// <summary>
        /// Initializes a new instance of the <see cref="PolynomialControlViewModel"/> class.
        /// </summary>
        public PolynomialControlViewModel()
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
        /// Gets or sets the value of x for evaluation.
        /// </summary>
        public double XValue
        {
            get => this.xValue;
            set
            {
                if (this.SetProperty(ref this.xValue, value))
                {
                    // Notify commands that depend on XValue.
                    this.EvaluateCommand.RaiseCanExecuteChanged();
                }
            }
        }

        /// <summary>
        /// Gets the evaluation result of the polynomial.
        /// </summary>
        public double Result
        {
            get => this.result;
            private set => this.SetProperty(ref this.result, value);
        }

        /// <summary>
        /// Gets a command to add a new term to the polynomial.
        /// </summary>
        public RelayCommand AddTermCommand { get; }

        /// <summary>
        /// Gets a command to remove the last term from the polynomial.
        /// </summary>
        public RelayCommand RemoveTermCommand { get; }

        /// <summary>
        /// Gets a command to evaluate the polynomial.
        /// </summary>
        public RelayCommand EvaluateCommand { get; }

        /// <summary>
        /// Converts the current polynomial view model to a <see cref="Polynomial"/> object.
        /// </summary>
        /// <returns>The corresponding <see cref="Polynomial"/> object.</returns>
        public Polynomial ToPolynomial()
        {
            return new Polynomial(this.Terms.Select(term => term.ToPolynomialTerm()));
        }

        private void AddTerm()
        {
            this.Terms.Add(new PolynomialTermViewModel());
            this.RemoveTermCommand.RaiseCanExecuteChanged();
        }

        private void RemoveTerm()
        {
            if (this.Terms.Any())
            {
                this.Terms.RemoveAt(this.Terms.Count - 1);
                this.RemoveTermCommand.RaiseCanExecuteChanged();
            }
        }

        private bool CanRemoveTerm()
        {
            return this.Terms.Any();
        }

        private void Evaluate()
        {
            var polynomial = new Polynomial(this.Terms.Select(term => term.ToPolynomialTerm()));
            this.Result = polynomial.Evaluate(this.XValue);
        }

        private bool CanEvaluate()
        {
            return this.Terms.Any();
        }
    }
}