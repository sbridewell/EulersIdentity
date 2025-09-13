// <copyright file="PolynomialTermTabTest.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace Sde.EulersIdentity.WPF.UI.Test
{
    using LightBDD.Framework.Scenarios;
    using LightBDD.XUnit2;

    /// <summary>
    /// UI tests for the polynomial term tab of the main window.
    /// </summary>
    public partial class PolynomialTermTabTest : UITestBase
    {
        // Define private constants for control names
        private const string CoefficientTextBoxName = "CoefficientTextBox";
        private const string ExponentTextBoxName = "ExponentTextBox";
        private const string XValueTextBoxName = "XValueTextBox";

        private static readonly List<string> TextBoxNames = new()
        {
            CoefficientTextBoxName,
            ExponentTextBoxName,
            XValueTextBoxName,
        };

        private static readonly List<string> ValidValues = new()
        {
            "3.5",
            "2",
            "-1.25",
            Math.PI.ToString(),
            "0",
            "-",
            ".",
            ".0",
            ".1",
            "-1.",
            "-0.5",
            "-1.",
            "-.",
            "4.",
            "0.0",
            "1234567890.1234567890",
            "-1234567890.1234567890",
        };

        private static readonly List<InvalidInput> InvalidValues = new()
        {
            new("1a2", "12"),
            new("abc", string.Empty),
            new(string.Empty, string.Empty),
            new("!@#$%", string.Empty),
            new("3.5.7", "3.57"),
            new("1-2", "12"),
        };

        /// <summary>
        /// Gets all combinations of text box names and valid values.
        /// </summary>
        public static IEnumerable<object[]> ValidValueCombinations =>
            from textBoxName in TextBoxNames
            from value in ValidValues
            select new object[] { textBoxName, value };

        /// <summary>
        /// Gets all combinations of text box names and invalid values.
        /// </summary>
        public static IEnumerable<object[]> InvalidValueCombinations =>
            from textBoxName in TextBoxNames
            from invalidInput in InvalidValues
            select new object[] { textBoxName, invalidInput.UserInput, invalidInput.ExpectedDisplay };

        /// <summary>
        /// Verifies that when a user enters a valid value into a specified text box on the Polynomial Term tab,
        /// the value is correctly displayed in the text box.
        /// </summary>
        /// <param name="automationId">The automation ID of the text box being tested.</param>
        /// <param name="value">The value to enter into the text box.</param>
        [Scenario]
        [MemberData(nameof(ValidValueCombinations))]
        public void UserEntersValidValue_ValueIsDisplayed(string automationId, string value)
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
        /// <param name="automationId">The automation ID of the text box being tested.</param>
        /// <param name="value">The invalid value entered into the text box.</param>
        /// <param name="expectedDisplay">The expected value displayed in the text box.</param>
        [Scenario]
        [MemberData(nameof(InvalidValueCombinations))]
        public void UserEntersInvalidValue_ValueIsHandledGracefully(
            string automationId,
            string value,
            string expectedDisplay)
        {
            this.Runner.RunScenario(
                given => this.TheApplicationHasStarted(),
                when => this.TheUserEntersAValueIntoTheTextBox(automationId, value),
                then => this.TheTextBoxDisplaysTheValue(automationId, expectedDisplay));
        }

        /// <summary>
        /// Verifies that when the user changes the coefficient, the PolynomialTermTextBlock and TermValueTextBlock are updated.
        /// </summary>
        /// <param name="initialCoefficient">The initial coefficient value.</param>
        /// <param name="initialExponent">The initial exponent value.</param>
        /// <param name="initialXValue">The initial x value.</param>
        /// <param name="newCoefficient">The new coefficient value.</param>
        /// <param name="expectedTermValue">The expected term value after the change.</param>
        [Scenario]
        [InlineData("2", "3", "4", "3", "192")] // Example: 3 * 4^3 = 192
        public void UserChangesCoefficient_TextBlocksAreUpdated(
            string initialCoefficient,
            string initialExponent,
            string initialXValue,
            string newCoefficient,
            string expectedTermValue)
        {
            this.Runner.RunScenario(
                given => this.TheApplicationHasStarted(),
                and => this.TheUserEntersAValueIntoTheTextBox(CoefficientTextBoxName, initialCoefficient),
                and => this.TheUserEntersAValueIntoTheTextBox(ExponentTextBoxName, initialExponent),
                and => this.TheUserEntersAValueIntoTheTextBox(XValueTextBoxName, initialXValue),
                when => this.TheUserEntersAValueIntoTheTextBox(CoefficientTextBoxName, newCoefficient),
                then => this.TheCoefficientIsIncludedInTheStringRepresentationOfTheTerm(newCoefficient),
                and => this.TheTermValueIsUpdatedCorrectly(expectedTermValue));
        }

        /// <summary>
        /// Verifies that when the user changes the exponent, the PolynomialTermTextBlock and TermValueTextBlock are updated.
        /// </summary>
        /// <param name="initialCoefficient">The initial coefficient value.</param>
        /// <param name="initialExponent">The initial exponent value.</param>
        /// <param name="initialXValue">The initial x value.</param>
        /// <param name="newExponent">The new exponent value.</param>
        /// <param name="expectedTermValue">The expected term value after the change.</param>
        [Scenario]
        [InlineData("2", "3", "4", "2", "32")] // Example: 2 * 4^2 = 32
        public void UserChangesExponent_TextBlocksAreUpdated(
            string initialCoefficient,
            string initialExponent,
            string initialXValue,
            string newExponent,
            string expectedTermValue)
        {
            this.Runner.RunScenario(
                given => this.TheApplicationHasStarted(),
                and => this.TheUserEntersAValueIntoTheTextBox(CoefficientTextBoxName, initialCoefficient),
                and => this.TheUserEntersAValueIntoTheTextBox(ExponentTextBoxName, initialExponent),
                and => this.TheUserEntersAValueIntoTheTextBox(XValueTextBoxName, initialXValue),
                when => this.TheUserEntersAValueIntoTheTextBox(ExponentTextBoxName, newExponent),
                then => this.TheExponentIsIncludedInTheStringRepresentationOfTheTerm(newExponent),
                and => this.TheTermValueIsUpdatedCorrectly(expectedTermValue));
        }

        /// <summary>
        /// Verifies that when the user changes the x value, the TermValueTextBlock is updated.
        /// </summary>
        /// <param name="initialCoefficient">The initial coefficient value.</param>
        /// <param name="initialExponent">The initial exponent value.</param>
        /// <param name="initialXValue">The initial x value.</param>
        /// <param name="newXValue">The new x value.</param>
        /// <param name="expectedTermValue">The expected term value after the change.</param>
        [Scenario]
        [InlineData("2", "3", "4", "5", "250")] // Example: 2 * 5^3 = 250
        public void UserChangesXValue_TextBlocksAreUpdated(
            string initialCoefficient,
            string initialExponent,
            string initialXValue,
            string newXValue,
            string expectedTermValue)
        {
            this.Runner.RunScenario(
                given => this.TheApplicationHasStarted(),
                and => this.TheUserEntersAValueIntoTheTextBox(CoefficientTextBoxName, initialCoefficient),
                and => this.TheUserEntersAValueIntoTheTextBox(ExponentTextBoxName, initialExponent),
                and => this.TheUserEntersAValueIntoTheTextBox(XValueTextBoxName, initialXValue),
                when => this.TheUserEntersAValueIntoTheTextBox(XValueTextBoxName, newXValue),
                //then => this.TheXValueIsIncludedInTheStringRepresentationOfTheTerm(newXValue),
                and => this.TheTermValueIsUpdatedCorrectly(expectedTermValue));
        }

        /// <summary>
        /// Verifies that when the user changes all values, the PolynomialTermTextBlock and TermValueTextBlock are updated.
        /// </summary>
        /// <param name="initialCoefficient">The initial coefficient value.</param>
        /// <param name="initialExponent">The initial exponent value.</param>
        /// <param name="initialXValue">The initial x value.</param>
        /// <param name="newCoefficient">The new coefficient value.</param>
        /// <param name="newExponent">The new exponent value.</param>
        /// <param name="newXValue">The new x value.</param>
        /// <param name="expectedTermValue">The expected term value after the changes.</param>
        [Scenario]
        [InlineData("2", "3", "4", "3", "2", "5", "75")] // Example: 3 * 5^2 = 75
        public void UserChangesAllValues_TextBlocksAreUpdated(
            string initialCoefficient,
            string initialExponent,
            string initialXValue,
            string newCoefficient,
            string newExponent,
            string newXValue,
            string expectedTermValue)
        {
            this.Runner.RunScenario(
                given => this.TheApplicationHasStarted(),
                and => this.TheUserEntersAValueIntoTheTextBox(CoefficientTextBoxName, initialCoefficient),
                and => this.TheUserEntersAValueIntoTheTextBox(ExponentTextBoxName, initialExponent),
                and => this.TheUserEntersAValueIntoTheTextBox(XValueTextBoxName, initialXValue),
                when => this.TheUserEntersAValueIntoTheTextBox(CoefficientTextBoxName, newCoefficient),
                and => this.TheUserEntersAValueIntoTheTextBox(ExponentTextBoxName, newExponent),
                and => this.TheUserEntersAValueIntoTheTextBox(XValueTextBoxName, newXValue),
                then => this.TheCoefficientIsIncludedInTheStringRepresentationOfTheTerm(newCoefficient),
                and => this.TheExponentIsIncludedInTheStringRepresentationOfTheTerm(newExponent),
                and => this.TheTermValueIsUpdatedCorrectly(expectedTermValue));
        }

        /// <summary>
        /// Represents an invalid input and its expected display value.
        /// </summary>
        private record InvalidInput(string UserInput, string ExpectedDisplay);
    }
}