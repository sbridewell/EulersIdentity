using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Sde.EulersIdentity;

namespace Sde.EulersIdentity.WPF.ViewModels
{
    /// <summary>
    /// ViewModel for managing a collection of polynomial terms and evaluating the polynomial.
    /// </summary>
    public class PolynomialControlViewModel : ViewModelBase
    {
        private double _xValue;
        private double _result;

        /// <summary>
        /// Initializes a new instance of the <see cref="PolynomialControlViewModel"/> class.
        /// </summary>
        public PolynomialControlViewModel()
        {
            Terms = new ObservableCollection<PolynomialTermViewModel>();
            AddTermCommand = new RelayCommand(AddTerm);
            RemoveTermCommand = new RelayCommand(RemoveTerm, CanRemoveTerm);
            EvaluateCommand = new RelayCommand(Evaluate, CanEvaluate);
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
            get => _xValue;
            set
            {
                if (SetProperty(ref _xValue, value))
                {
                    // Notify commands that depend on XValue.
                    ((RelayCommand)EvaluateCommand).RaiseCanExecuteChanged();
                }
            }
        }

        /// <summary>
        /// Gets the evaluation result of the polynomial.
        /// </summary>
        public double Result
        {
            get => _result;
            private set => SetProperty(ref _result, value);
        }

        /// <summary>
        /// Command to add a new term to the polynomial.
        /// </summary>
        public RelayCommand AddTermCommand { get; }

        /// <summary>
        /// Command to remove the last term from the polynomial.
        /// </summary>
        public RelayCommand RemoveTermCommand { get; }

        /// <summary>
        /// Command to evaluate the polynomial.
        /// </summary>
        public RelayCommand EvaluateCommand { get; }

        private void AddTerm()
        {
            Terms.Add(new PolynomialTermViewModel());
            ((RelayCommand)RemoveTermCommand).RaiseCanExecuteChanged();
        }

        private void RemoveTerm()
        {
            if (Terms.Any())
            {
                Terms.RemoveAt(Terms.Count - 1);
                ((RelayCommand)RemoveTermCommand).RaiseCanExecuteChanged();
            }
        }

        private bool CanRemoveTerm()
        {
            return Terms.Any();
        }

        private void Evaluate()
        {
            var polynomial = new Polynomial(Terms.Select(term => term.ToPolynomialTerm()));
            Result = polynomial.Evaluate(XValue);
        }

        private bool CanEvaluate()
        {
            return Terms.Any();
        }

        /// <summary>
        /// Converts the current polynomial view model to a <see cref="Polynomial"/> object.
        /// </summary>
        /// <returns>The corresponding <see cref="Polynomial"/> object.</returns>
        public Polynomial ToPolynomial()
        {
            return new Polynomial(Terms.Select(term => term.ToPolynomialTerm()));
        }
    }
}