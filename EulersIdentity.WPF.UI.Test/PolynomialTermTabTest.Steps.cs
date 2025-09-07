// <copyright file="PolynomialTermTabTest.Steps.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace Sde.EulersIdentity.WPF.UI.Test
{
    using FlaUI.Core.AutomationElements;
    using FluentAssertions;

    /// <summary>
    /// Test steps for <see cref="PolynomialTermTabTest"/>.
    /// </summary>
    public partial class PolynomialTermTabTest
    {
        #region given steps

        private void TheApplicationHasStarted()
        {
            this.StartApplication();
        }

        #endregion

        #region when steps

        private void TheUserEntersAValueIntoTheTextBox(string automationId, string coefficient)
        {
            var textBox = this.FindControlInTab<TextBox>(0, automationId);
            textBox.Enter(coefficient);
        }

        #endregion

        #region then steps

        private void TheTextBoxDisplaysTheValue(string automationId, string coefficient)
        {
            var textBox = this.FindControlInTab<TextBox>(0, automationId);
            textBox.Text.Should().Be(coefficient);
        }

        private void TheCoefficientIsIncludedInTheStringRepresentationOfTheTerm(string coefficient)
        {
            var termStringTextBlock = this.FindControlInTab<Label>(0, "TermStringTextBlock");

            // Get the text from the TermStringTextBox
            var termString = termStringTextBlock.Text;

            // Define the expected format (e.g., "{coefficient}x^n")
            // This is an example; adjust based on the actual format
            var expectedPrefix = $"{coefficient}x";

            // Assert that the term string starts with the expected prefix
            termString.Should().StartWith(
                expectedPrefix,
                because: $"the coefficient '{coefficient}' should appear at the start of the term string.");
        }

        private void TheExponentIsIncludedInTheStringRepresentationOfTheTerm(string exponent)
        {
            // Find the TermStringTextBlock in the Polynomial Term tab
            var termStringTextBlock = this.FindControlInTab<Label>(0, "TermStringTextBlock");

            // Get the text from the TermStringTextBlock
            var termString = termStringTextBlock.Text;

            // Define the expected format (e.g., "coefficient x^exponent")
            // This assumes the exponent is represented as "^exponent" in the term string
            var expectedSubstring = $"^({exponent})";

            // Assert that the term string contains the expected exponent substring
            termString.Should().Contain(
                expectedSubstring,
                because: $"the exponent '{exponent}' should appear in the string representation of the term.");
        }

        #endregion
    }
}