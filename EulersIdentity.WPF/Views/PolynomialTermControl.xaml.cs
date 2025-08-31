// <copyright file="PolynomialTermControl.xaml.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

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

            // Ensure the DataContext is inherited from the parent, if available.
            if (Application.Current?.MainWindow != null)
            {
                this.DataContext = Application.Current.MainWindow.DataContext;
            }
        }

        /// <summary>
        /// Handles the Evaluate button click event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event arguments.</param>
        public void OnEvaluateClick(object sender, RoutedEventArgs e)
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

        /// <summary>
        /// Handles the input changed event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event arguments.</param>
        public void OnInputChanged(object sender, TextChangedEventArgs e)
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

        /// <summary>
        /// Handles the preview text input event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event arguments.</param>
        public void OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e == null)
            {
                throw new ArgumentNullException(nameof(e), "Event arguments cannot be null.");
            }

            e.Handled = !NumericRegex.IsMatch(e.Text);
        }

        /// <summary>
        /// Handles the text box got focus event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event arguments.</param>
        public void OnTextBoxGotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.SelectAll();
            }
        }
    }
}