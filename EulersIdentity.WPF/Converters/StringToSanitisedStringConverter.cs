// <copyright file="StringToSanitisedStringConverter.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace Sde.EulersIdentity.WPF.Converters
{
    using System.Globalization;
    using System.Windows.Data;
    using Sde.EulersIdentity.WPF.Utilities;

    /// <summary>
    /// Sanitises a string to ensure it is a valid floating-point number format.
    /// </summary>
    public class StringToSanitisedStringConverter : IValueConverter
    {
        /// <inheritdoc/>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string input)
            {
                return InputValidationUtilities.CleanFloatingPointInput(input);
            }

            return value;
        }

        /// <inheritdoc/>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return this.Convert(value, targetType, parameter, culture);
        }
    }
}
