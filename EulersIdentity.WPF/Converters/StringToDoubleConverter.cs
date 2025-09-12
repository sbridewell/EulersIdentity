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
#pragma warning disable CS8603 // Possible null reference return.
            return value?.ToString();
#pragma warning restore CS8603 // Possible null reference return.
        }

        /// <inheritdoc/>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string input && double.TryParse(input, out var result))
            {
                return result;
            }

            return Binding.DoNothing;
        }
    }
}