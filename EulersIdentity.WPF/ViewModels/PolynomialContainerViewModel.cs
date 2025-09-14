using System.Windows.Input;
using Sde.EulersIdentity.WPF.Utilities;

namespace Sde.EulersIdentity.WPF.ViewModels
{
    /// <summary>
    /// ViewModel for the PolynomialContainer user control.
    /// </summary>
    public class PolynomialContainerViewModel : ViewModelBase
    {
        private double xValue;
        private string polynomialString;
        private double evaluationResult;

        /// <summary>
        /// Initializes a new instance of the <see cref="PolynomialContainerViewModel"/> class.
        /// </summary>
        public PolynomialContainerViewModel()
        {
            PolynomialControlViewModel = new PolynomialControlViewModel();
            EvaluateCommand = new RelayCommand(Evaluate);
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
            get => xValue;
            set => SetProperty(ref xValue, value);
        }

        /// <summary>
        /// Gets the string representation of the polynomial.
        /// </summary>
        public string PolynomialString
        {
            get => polynomialString;
            private set => SetProperty(ref polynomialString, value);
        }

        /// <summary>
        /// Gets the evaluation result of the polynomial.
        /// </summary>
        public double EvaluationResult
        {
            get => evaluationResult;
            private set => SetProperty(ref evaluationResult, value);
        }

        /// <summary>
        /// Gets the command to evaluate the polynomial.
        /// </summary>
        public ICommand EvaluateCommand { get; }

        private void Evaluate()
        {
            var polynomial = PolynomialControlViewModel.ToPolynomial();
            PolynomialString = polynomial.ToString();
            EvaluationResult = polynomial.Evaluate(XValue);
        }
    }
}