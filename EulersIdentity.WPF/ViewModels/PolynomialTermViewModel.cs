using System;
using System.Windows.Input;
using Sde.EulersIdentity;

namespace Sde.EulersIdentity.WPF.ViewModels
{
    /// <summary>
    /// ViewModel for the PolynomialTerm control.
    /// </summary>
    public class PolynomialTermViewModel : ViewModelBase
    {
        private string coefficient;
        private string exponent;
        private string xValue;
        private string result;

        /// <summary>
        /// Gets or sets the coefficient value as a string.
        /// </summary>
        public string Coefficient
        {
            get => coefficient;
            set => SetProperty(ref coefficient, value);
        }

        /// <summary>
        /// Gets or sets the exponent value as a string.
        /// </summary>
        public string Exponent
        {
            get => exponent;
            set => SetProperty(ref exponent, value);
        }

        /// <summary>
        /// Gets or sets the x value as a string.
        /// </summary>
        public string XValue
        {
            get => xValue;
            set => SetProperty(ref xValue, value);
        }

        /// <summary>
        /// Gets the result of the polynomial evaluation.
        /// </summary>
        public string Result
        {
            get => result;
            private set => SetProperty(ref result, value);
        }

        /// <summary>
        /// Command to evaluate the polynomial term.
        /// </summary>
        public ICommand EvaluateCommand { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PolynomialTermViewModel"/> class.
        /// </summary>
        public PolynomialTermViewModel()
        {
            EvaluateCommand = new RelayCommand(Evaluate, CanEvaluate);
        }

        private bool CanEvaluate()
        {
            return !string.IsNullOrWhiteSpace(Coefficient) &&
                   !string.IsNullOrWhiteSpace(Exponent) &&
                   !string.IsNullOrWhiteSpace(XValue);
        }

        private void Evaluate()
        {
            try
            {
                if (!double.TryParse(Coefficient, out double coefficientValue))
                {
                    throw new FormatException("Invalid coefficient.");
                }

                if (!double.TryParse(Exponent, out double exponentValue))
                {
                    throw new FormatException("Invalid exponent.");
                }

                if (!double.TryParse(XValue, out double xValue))
                {
                    throw new FormatException("Invalid value for x.");
                }

                var term = new PolynomialTerm(coefficientValue, exponentValue);
                Result = term.Evaluate(xValue).ToString();
            }
            catch (Exception ex)
            {
                Result = $"Error: {ex.Message}";
            }
        }
    }
}