// <copyright file="InputValidationUtilities.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace Sde.EulersIdentity.WPF.Utilities
{
    using System.Text;
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

        /// <summary>
        /// Removes invalid characters from the input string, ensuring it represents a valid floating-point number.
        /// </summary>
        /// <param name="input">The input string to clean.</param>
        /// <returns>The cleaned string with only valid floating-point characters.</returns>
        public static string CleanFloatingPointInput(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            var cleanedInput = new StringBuilder();
            foreach (char c in input)
            {
                // Append the character if it's the first character and valid, or if it forms a valid floating-point number
                if ((cleanedInput.Length == 0 && (c == '-' || c == '.')) ||
                    IsValidFloatingPointInput(cleanedInput.ToString() + c))
                {
                    cleanedInput.Append(c);
                }
            }

            return cleanedInput.ToString();
        }
    }
}