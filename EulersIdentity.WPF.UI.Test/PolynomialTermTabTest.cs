// <copyright file="PolynomialTermTabTest.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace Sde.EulersIdentity.WPF.UI.Test
{
    using LightBDD.Framework;
    using LightBDD.Framework.Scenarios;
    using LightBDD.XUnit2;

    /// <summary>
    /// UI tests for the polynomial term tab of the main window.
    /// </summary>
    public partial class PolynomialTermTabTest : UITestBase
    {
        private const string CoefficientTextBoxName = "CoefficientTextBox";
        private const string ExponentTextBoxName = "ExponentTextBox";
        private const string XValueTextBoxName = "XValueTextBox";

        /// <summary>
        /// Verifies that when a user enters a valid value into a specified text box on the Polynomial Term tab,
        /// the value is correctly displayed in the text box.
        /// </summary>
        /// <param name="automationId">The automation ID of the text box being tested.</param>
        /// <param name="value">The value to enter into the text box.</param>
        [Scenario]
        //[Scenario(Skip = "still investigating the validation")]
        [InlineData(CoefficientTextBoxName, 3.5)]
        [InlineData(CoefficientTextBoxName, 2)]
        [InlineData(CoefficientTextBoxName, -1.25)]
        [InlineData(CoefficientTextBoxName, Math.PI)]
        [InlineData(CoefficientTextBoxName, "-")]
        [InlineData(ExponentTextBoxName, 3.5)]
        [InlineData(ExponentTextBoxName, 2)]
        [InlineData(ExponentTextBoxName, -1.25)]
        [InlineData(ExponentTextBoxName, Math.PI)]
        [InlineData(ExponentTextBoxName, "-")]
        [InlineData(XValueTextBoxName, 3.5)]
        [InlineData(XValueTextBoxName, 2)]
        [InlineData(XValueTextBoxName, -1.25)]
        [InlineData(XValueTextBoxName, Math.PI)]
        [InlineData(XValueTextBoxName, "-")]
        public void UserEntersValidValue_ValueIsDisplayed(string automationId, double value)
        {
            this.Runner.RunScenario(
                given => this.TheApplicationHasStarted(),
                when => this.TheUserEntersAValueIntoTheTextBox(automationId, value.ToString()),
                then => this.TheTextBoxDisplaysTheValue(automationId, value.ToString()));
        }

        /// <summary>
        /// Verifies that the application handles invalid input values entered into a text box gracefully,
        /// ensuring that the displayed value is corrected or cleared as expected.
        /// </summary>
        /// <remarks>
        /// This test ensures that the application can handle various invalid input scenarios, such as
        /// alphanumeric strings, special characters, or improperly formatted numbers, without crashing or
        /// displaying incorrect results. The behavior is validated for multiple text boxes in the
        /// application.
        /// </remarks>
        /// <param name="automationId">
        /// The automation ID of the text box where the value is entered. This identifies the specific text
        /// box being tested (e.g., "CoefficientTextBox", "ExponentTextBox", or "XValueTextBox").
        /// </param>
        /// <param name="coefficient">
        /// The invalid input value entered into the text box.
        /// This value may contain non-numeric characters, special symbols, or other invalid formats.
        /// </param>
        /// <param name="expectedDisplay">
        /// The expected value displayed in the text box after the invalid input is processed.
        /// This may be a corrected numeric value or an empty string, depending on the input.
        /// </param>
        //[Scenario(Skip = "invalid input not handled gracefully yet")]
        [Scenario]
        [InlineData(CoefficientTextBoxName, "1a2", "12")]
        [InlineData(CoefficientTextBoxName, "abc", "")]
        [InlineData(CoefficientTextBoxName, "", "")]
        [InlineData(CoefficientTextBoxName, "!@#$%", "")]
        [InlineData(CoefficientTextBoxName, "3.5.7", "3.57")]
        [InlineData(CoefficientTextBoxName, "1-2", "12")]
        [InlineData(ExponentTextBoxName, "1a2", "12")]
        [InlineData(ExponentTextBoxName, "abc", "")]
        [InlineData(ExponentTextBoxName, "", "")]
        [InlineData(ExponentTextBoxName, "!@#$%", "")]
        [InlineData(ExponentTextBoxName, "3.5.7", "3.57")]
        [InlineData(ExponentTextBoxName, "1-2", "12")]
        [InlineData(XValueTextBoxName, "1a2", "12")]
        [InlineData(XValueTextBoxName, "abc", "")]
        [InlineData(XValueTextBoxName, "", "")]
        [InlineData(XValueTextBoxName, "!@#$%", "")]
        [InlineData(XValueTextBoxName, "3.5.7", "3.57")]
        [InlineData(XValueTextBoxName, "1-2", "12")]
        public void UserEntersInvalidValue_ValueIsHandledGracefully(
            string automationId,
            string coefficient,
            string expectedDisplay)
        {
            this.Runner.RunScenario(
                given => this.TheApplicationHasStarted(),
                when => this.TheUserEntersAValueIntoTheTextBox(automationId, coefficient),
                then => this.TheTextBoxDisplaysTheValue(automationId, expectedDisplay));
        }

        /// <summary>
        /// Verifies that when a valid coefficient is entered by the user, the coefficient is included in the string
        /// representation of the polynomial term.
        /// </summary>
        /// <remarks>This test ensures that the application correctly incorporates the user-provided
        /// coefficient into the string representation of a polynomial term. The test is parameterized to validate
        /// behavior for various coefficient values, including edge cases such as negative and irrational
        /// numbers.</remarks>
        /// <param name="coefficient">
        /// The coefficient value entered by the user.
        /// This can be any valid double value, including positive, negative, or fractional numbers.
        /// </param>
        //[Scenario(Skip = "string representation not working yet")]
        [Scenario]
        [InlineData(3.5)]
        [InlineData(2)]
        [InlineData(-1.25)]
        [InlineData(Math.PI)]
        public void UserEntersValidCoefficient_CoefficientIsIncludedInStringRepresentationOfTerm(
            double coefficient)
        {
            this.Runner.RunScenario(
                given => this.TheApplicationHasStarted(),
                when => this.TheUserEntersAValueIntoTheTextBox("CoefficientTextBox", coefficient.ToString()),
                then => this.TheCoefficientIsIncludedInTheStringRepresentationOfTheTerm(coefficient.ToString()));
        }

        /// <summary>
        /// Verifies that when a valid exponent is entered by the user, the exponent is included in the string
        /// representation of the polynomial term.
        /// </summary>
        /// <remarks>This test ensures that the application correctly incorporates the user-provided
        /// exponent into the string representation of a polynomial term.
        /// The test is parameterized to validate behavior for various exponent values, including edge
        /// cases such as negative and irrational numbers.
        /// </remarks>
        /// <param name="exponent">
        /// The exponent value entered by the user.
        /// This can be any valid double value, including positive, negative, or fractional numbers.
        /// </param>
        //[Scenario(Skip = "string representation not working yet")]
        [Scenario]
        [InlineData(3.5)]
        [InlineData(2)]
        [InlineData(-1.25)]
        [InlineData(Math.PI)]
        public void UserEntersValidExponent_ExponentIsIncludedInStringRepresentationOfTerm(
            double exponent)
        {
            this.Runner.RunScenario(
                given => this.TheApplicationHasStarted(),
                when => this.TheUserEntersAValueIntoTheTextBox("ExponentTextBox", exponent.ToString()),
                then => this.TheExponentIsIncludedInTheStringRepresentationOfTheTerm(exponent.ToString()));
        }
    }
}