namespace Sde.EulersIdentity.WPF.Utilities
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Provides utility methods for validating input.
    /// </summary>
    public static class InputValidationUtilities
    {
        /// <summary>
        /// The regular expression for validating floating-point input.
        /// </summary>
        public static readonly Regex FloatingPointRegex = new(@"^-?$|^-?(?:[0-9]+(\.[0-9]*)?|\.[0-9]+)$");

        /// <summary>
        /// Validates whether the given input is a valid floating-point number.
        /// </summary>
        /// <param name="input">The input string to validate.</param>
        /// <returns><c>true</c> if the input is valid; otherwise, <c>false</c>.</returns>
        public static bool IsValidFloatingPointInput(string input)
        {
            return FloatingPointRegex.IsMatch(input);
        }
    }
}