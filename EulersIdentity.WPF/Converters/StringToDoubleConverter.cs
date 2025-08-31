// <copyright file="StringToDoubleConverter.cs" company="Simon Bridewell">
// Copyright (c) Simon Bridewell.
// Released under the MIT license - see LICENSE.txt in the repository root.
// </copyright>

namespace Sde.EulersIdentity.WPF.Converters
{
    using System.Globalization;
    using System.Windows.Data;

    /// <summary>
    /// Converts between string and double values for data binding.
    /// </summary>
    public class StringToDoubleConverter : IValueConverter
    {
        /// <inheritdoc/>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double doubleValue)
            {
                return doubleValue.ToString(culture);
            }

            return string.Empty;
        }

        /// <inheritdoc/>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string stringValue)
            {
                if (string.IsNullOrWhiteSpace(stringValue))
                {
                    return 0.0; // Treat empty strings as zero.
                }

                if (double.TryParse(stringValue, NumberStyles.Any, culture, out double result))
                {
                    return result;
                }
            }

            return 0.0; // Default to zero for invalid input.
        }
    }
}