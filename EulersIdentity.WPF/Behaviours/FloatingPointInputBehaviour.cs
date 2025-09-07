// <copyright file="FloatingPointInputBehaviour.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace Sde.EulersIdentity.WPF.Behaviours
{
    using System.Text.RegularExpressions;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using Microsoft.Xaml.Behaviors;

    /// <summary>
    /// A behaviour to restrict TextBox input to valid floating-point numbers.
    /// </summary>
    public class FloatingPointInputBehaviour : Behavior<TextBox>
    {
        private static readonly Regex NumericRegex = new(@"^-?(?:[0-9]+(\.[0-9]*)?|\.[0-9]+)$");

        /// <summary>
        /// Validates whether the given input is a valid floating-point number.
        /// </summary>
        /// <param name="input">The input string to validate.</param>
        /// <returns><c>true</c> if the input is valid; otherwise, <c>false</c>.</returns>
        public static bool IsValidFloatingPointInput(string input)
        {
            return NumericRegex.IsMatch(input);
        }

        /// <inheritdoc/>
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.PreviewTextInput += OnPreviewTextInput;
            DataObject.AddPastingHandler(this.AssociatedObject, OnPaste);
        }

        /// <inheritdoc/>
        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.PreviewTextInput -= OnPreviewTextInput;
            DataObject.RemovePastingHandler(this.AssociatedObject, OnPaste);
        }

        private void OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                e.Handled = !ValidatePreviewInput(textBox.Text, e.Text, textBox.SelectionStart);
            }
        }

        private void OnPaste(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(DataFormats.Text))
            {
                var pastedText = e.DataObject.GetData(DataFormats.Text) as string;
                if (!ValidatePasteInput(pastedText))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }

        /// <summary>
        /// Validates the combined text for the PreviewTextInput event.
        /// </summary>
        /// <param name="currentText">The current text in the TextBox.</param>
        /// <param name="newInput">The new input being added.</param>
        /// <param name="selectionStart">The position where the new input will be inserted.</param>
        /// <returns><c>true</c> if the combined text is valid; otherwise, <c>false</c>.</returns>
        public static bool ValidatePreviewInput(string currentText, string newInput, int selectionStart)
        {
            var fullText = currentText.Insert(selectionStart, newInput);
            return IsValidFloatingPointInput(fullText);
        }

        /// <summary>
        /// Validates the pasted text for the Pasting event.
        /// </summary>
        /// <param name="pastedText">The text being pasted.</param>
        /// <returns><c>true</c> if the pasted text is valid; otherwise, <c>false</c>.</returns>
        public static bool ValidatePasteInput(string pastedText)
        {
            return IsValidFloatingPointInput(pastedText);
        }
    }
}
