namespace Sde.EulersIdentity.WPF.Views
{
    using System;
    using System.Text.RegularExpressions;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using Sde.EulersIdentity;

    /// <summary>
    /// Interaction logic for PolynomialTermControl.xaml.
    /// </summary>
    public partial class PolynomialTermControl : UserControl
    {
        private static readonly Regex NumericRegex = new Regex("^-?[0-9]*(\\.[0-9]*)?$", RegexOptions.Compiled);

        /// <summary>
        /// Initializes a new instance of the <see cref="PolynomialTermControl"/> class.
        /// </summary>
        public PolynomialTermControl()
        {
            this.InitializeComponent();

            // Ensure the DataContext is inherited from the parent.
            this.DataContext = Application.Current.MainWindow?.DataContext;
        }

        private void OnEvaluateClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!double.TryParse(this.CoefficientTextBox.Text, out double coefficient))
                {
                    throw new FormatException("Invalid coefficient.");
                }

                if (!double.TryParse(this.ExponentTextBox.Text, out double exponent))
                {
                    throw new FormatException("Invalid exponent.");
                }

                if (!double.TryParse(this.XValueTextBox.Text, out double xValue))
                {
                    throw new FormatException("Invalid value for x.");
                }

                var term = new PolynomialTerm(coefficient, exponent);
                term.Evaluate(xValue); // Evaluation is still performed, but no longer displayed here.
            }
            catch (Exception)
            {
                // Handle exceptions silently as error display is removed.
            }
        }

        private void OnInputChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (!double.TryParse(this.CoefficientTextBox.Text, out double coefficient))
                {
                    throw new FormatException("Invalid coefficient.");
                }

                if (!double.TryParse(this.ExponentTextBox.Text, out double exponent))
                {
                    throw new FormatException("Invalid exponent.");
                }

                if (!double.TryParse(this.XValueTextBox.Text, out double xValue))
                {
                    throw new FormatException("Invalid value for x.");
                }

                var term = new PolynomialTerm(coefficient, exponent);
                term.Evaluate(xValue); // Evaluation is still performed, but no longer displayed here.
            }
            catch (Exception)
            {
                // Handle exceptions silently as error display is removed.
            }
        }

        private void OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !NumericRegex.IsMatch(e.Text);
        }

        private void OnTextBoxGotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.SelectAll();
            }
        }
    }
}