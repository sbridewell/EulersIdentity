// <copyright file="PolynomialTermControl.xaml.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace Sde.EulersIdentity.WPF.Controls
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using Sde.EulersIdentity;

    /// <summary>
    /// Interaction logic for PolynomialTermControl.xaml.
    /// </summary>
    public partial class PolynomialTermControl : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PolynomialTermControl"/> class.
        /// </summary>
        public PolynomialTermControl()
        {
            this.InitializeComponent();
        }

        private void OnEvaluateClick(object sender, RoutedEventArgs e)
        {
            try
            {
                this.ErrorLabel.Content = string.Empty;

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
                double result = term.Evaluate(xValue);
                this.ResultLabel.Content = result.ToString();
            }
            catch (Exception ex)
            {
                this.ErrorLabel.Content = ex.Message;
            }
        }

        private void OnInputChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                this.ErrorLabel.Content = string.Empty;

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
                this.TermLabel.Content = term.ToString();
                this.ResultLabel.Content = term.Evaluate(xValue).ToString();
            }
            catch (Exception ex)
            {
                this.ErrorLabel.Content = ex.Message;
                this.TermLabel.Content = string.Empty;
                this.ResultLabel.Content = string.Empty;
            }
        }
    }
}