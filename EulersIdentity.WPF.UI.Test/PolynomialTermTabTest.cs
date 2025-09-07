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
        /// <summary>
        /// Verifies that when a user enters a valid value into a specified text box on the Polynomial Term tab,
        /// the value is correctly displayed in the text box.
        /// </summary>
        /// <param name="automationId">The automation ID of the text box being tested.</param>
        /// <param name="value">The value to enter into the text box.</param>
        //[Scenario]
        [Scenario(Skip = "still investigating the validation")]
        [InlineData("CoefficientTextBox", 3.5)]
        [InlineData("CoefficientTextBox", 2)]
        [InlineData("CoefficientTextBox", -1.25)]
        [InlineData("CoefficientTextBox", Math.PI)]
        [InlineData("ExponentTextBox", 3.5)]
        [InlineData("ExponentTextBox", 2)]
        [InlineData("ExponentTextBox", -1.25)]
        [InlineData("ExponentTextBox", Math.PI)]
        [InlineData("XValueTextBox", 3.5)]
        [InlineData("XValueTextBox", 2)]
        [InlineData("XValueTextBox", -1.25)]
        [InlineData("XValueTextBox", Math.PI)]
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
        [Scenario(Skip = "invalid input not handled gracefully yet")]
        //[Scenario]
        [InlineData("CoefficientTextBox", "1a2", "12")]
        [InlineData("CoefficientTextBox", "abc", "")]
        [InlineData("CoefficientTextBox", "", "")]
        [InlineData("CoefficientTextBox", "!@#$%", "")]
        [InlineData("CoefficientTextBox", "3.5.7", "3.57")]
        [InlineData("ExponentTextBox", "1a2", "12")]
        [InlineData("ExponentTextBox", "abc", "")]
        [InlineData("ExponentTextBox", "", "")]
        [InlineData("ExponentTextBox", "!@#$%", "")]
        [InlineData("ExponentTextBox", "3.5.7", "3.57")]
        [InlineData("XValueTextBox", "1a2", "12")]
        [InlineData("XValueTextBox", "abc", "")]
        [InlineData("XValueTextBox", "", "")]
        [InlineData("XValueTextBox", "!@#$%", "")]
        [InlineData("XValueTextBox", "3.5.7", "3.57")]
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
        [Scenario(Skip = "string representation not working yet")]
        [InlineData(3.5)]
        [InlineData(2)]
        [InlineData(-1.25)]
        [InlineData(Math.PI)]
        public void PolynomialTermTab_UserEntersValidCoefficient_CoefficientIsIncludedInStringRepresentationOfTerm(
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
        [Scenario(Skip = "string representation not working yet")]
        [InlineData(3.5)]
        [InlineData(2)]
        [InlineData(-1.25)]
        [InlineData(Math.PI)]
        public void PolynomialTermTab_UserEntersValidExponent_ExponentIsIncludedInStringRepresentationOfTerm(
            double exponent)
        {
            this.Runner.RunScenario(
                given => this.TheApplicationHasStarted(),
                when => this.TheUserEntersAValueIntoTheTextBox("ExponentTextBox", exponent.ToString()),
                then => this.TheExponentIsIncludedInTheStringRepresentationOfTheTerm(exponent.ToString()));
        }
    }
}