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
            var termStringTextBlock = this.FindControlInTab<Label>(0, "PolynomialTermTextBlock");

            // Get the text from the PolynomialTermTextBlock
            var termString = termStringTextBlock.Text;

            // Define the expected format (e.g., "{coefficient}x^n")
            // This is an example; adjust based on the actual format
            var expectedPrefix = $"{coefficient}x";

            // Assert that the term string starts with the expected prefix
            termString.Should().StartWith(
                expectedPrefix,
                because: $"the coefficient '{coefficient}' should appear at the start of the term string.");
        }

        ///// <summary>
        ///// Verifies that the value of x is included correctly in the string representation of the term.
        ///// </summary>
        ///// <param name="xValue">The expected value of x.</param>
        //private void TheXValueIsIncludedInTheStringRepresentationOfTheTerm(string xValue)
        //{
        //    var termStringTextBlock = this.FindControlInTab<Label>(0, "PolynomialTermTextBlock");

        //    // Get the text from the PolynomialTermTextBlock
        //    var termString = termStringTextBlock.Text;

        //    // Define the expected substring (e.g., "x^n" where n is the exponent)
        //    var expectedSubstring = $"x^{xValue}";

        //    // Assert that the term string contains the expected x value substring
        //    termString.Should().Contain(
        //        expectedSubstring,
        //        because: $"the value of x '{xValue}' should appear in the string representation of the term.");
        //}

        private void TheExponentIsIncludedInTheStringRepresentationOfTheTerm(string exponent)
        {
            // Find the TermStringTextBlock in the Polynomial Term tab
            var termStringTextBlock = this.FindControlInTab<Label>(0, "PolynomialTermTextBlock");

            // Get the text from the TermStringTextBlock
            var termString = termStringTextBlock.Text;

            // Define the expected format (e.g., "coefficient x^exponent")
            // This assumes the exponent is represented as "^exponent" in the term string
            var expectedSubstring = $"^{exponent}";

            // Assert that the term string contains the expected exponent substring
            termString.Should().Contain(
                expectedSubstring,
                because: $"the exponent '{exponent}' should appear in the string representation of the term.");
        }

        private void TheTermValueIsUpdatedCorrectly(string expectedValue)
        {
            var termValueTextBlock = this.FindControlInTab<Label>(0, "TermValueTextBlock");

            // Get the text from the TermValueTextBlock
            var termValue = termValueTextBlock.Text;

            // Assert that the term value matches the expected value
            termValue.Should().Be(
                expectedValue,
                because: $"the term value should be updated to '{expectedValue}' based on the inputs.");
        }

        #endregion
    }
}