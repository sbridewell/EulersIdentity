using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Sde.EulersIdentity.WPF.Converters
{
    /// <summary>
    /// Converts a boolean value to a Visibility value.
    /// </summary>
    public class BooleanToVisibilityConverter : IValueConverter
    {
        /// <inheritdoc/>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool booleanValue)
            {
                return booleanValue ? Visibility.Visible : Visibility.Collapsed;
            }

            return Visibility.Collapsed;
        }

        /// <inheritdoc/>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException("ConvertBack is not implemented for BooleanToVisibilityConverter.");
        }
    }
}