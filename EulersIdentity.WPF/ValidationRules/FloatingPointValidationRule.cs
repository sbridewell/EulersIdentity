// <copyright file="FloatingPointValidationRule.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace Sde.EulersIdentity.WPF.ValidationRules
{
    using System.Globalization;
    using System.Windows.Controls;

    /// <summary>
    /// Represents a validation rule that checks whether the input value is a valid floating-point number.
    /// </summary>
    /// <remarks>This rule is typically used in data binding scenarios to validate user input. The input value
    /// is expected to be a string that can be parsed as a <see cref="double"/>. If the input is not a valid
    /// floating-point number, the validation fails.</remarks>
    public class FloatingPointValidationRule : ValidationRule
    {
        /// <inheritdoc/>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is string input && double.TryParse(input, out _))
            {
                return ValidationResult.ValidResult;
            }

            return new ValidationResult(false, "Input must be a valid floating-point number.");
        }
    }
}
