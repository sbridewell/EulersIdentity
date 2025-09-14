// <copyright file="PolynomialTermTabTest.Steps.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace Sde.EulersIdentity.WPF.UI.Test
{
    using FlaUI.Core.AutomationElements;
    using FlaUI.Core.Tools;
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
            var textBox = this.FindControlByAutomationId<TextBox>(automationId);
            textBox.Text = coefficient;
        }

        #endregion

        #region then steps

        private void TheTextBoxDisplaysTheValue(string automationId, string coefficient)
        {
            var textBox = this.FindControlInTab<TextBox>(0, automationId);
            textBox.Text.Should().Be(coefficient);
        }

        /// <summary>
        /// Verifies that the PolynomialTermAndResultTextBlock displays the expected result.
        /// </summary>
        /// <param name="expectedResult">The expected result to verify.</param>
        private void ThePolynomialTermAndResultTextBlockDisplays(string expectedResult)
        {
            var actualResult = this.GetTextBlockValue("PolynomialTermAndResultTextBlock");
            actualResult.Should().Be(expectedResult);
        }

        #endregion
    }
}