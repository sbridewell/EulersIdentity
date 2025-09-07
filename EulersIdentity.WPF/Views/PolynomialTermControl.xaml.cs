// <copyright file="PolynomialTermControl.xaml.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace Sde.EulersIdentity.WPF.Views
{
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Text.RegularExpressions;
    using System.Windows.Controls;
    using System.Windows.Input;

    /// <summary>
    /// Interaction logic for PolynomialTermControl.xaml.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public partial class PolynomialTermControl : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PolynomialTermControl"/> class.
        /// </summary>
        public PolynomialTermControl()
        {
            this.InitializeComponent();

            // Log the DataContext for debugging purposes.
            this.Loaded += (s, e) =>
            {
                Debug.WriteLine($"PolynomialTermControl DataContext: {this.DataContext?.GetType().Name ?? "null"}");
            };
        }

        /// <summary>
        /// Handles the GotFocus event for text boxes to pre-select all text.
        /// </summary>
        /// <param name="sender">The text box that received focus.</param>
        /// <param name="e">The event arguments.</param>
        private void TextBox_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.SelectAll();
            }
        }

        /// <summary>
        /// Handles the PreviewTextInput event to suppress invalid characters.
        /// </summary>
        /// <param name="sender">The text box receiving input.</param>
        /// <param name="e">The event arguments.</param>
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Allow only numeric input, decimal points, and negative signs.
            // Adjusted to ensure it handles valid input for all text boxes.
            string input = e.Text;
            bool isValid = Regex.IsMatch(input, "^[0-9]*[.,]?[0-9]*$|^-$");

            // Log the input and the result of the regular expression match.
            Debug.WriteLine($"TextBox_PreviewTextInput: Input='{input}', IsValid={isValid}");

            e.Handled = !isValid;
        }
    }
}