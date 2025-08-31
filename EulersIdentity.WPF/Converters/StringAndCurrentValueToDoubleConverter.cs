using System;
using System.Globalization;
using System.Windows.Data;

namespace Sde.EulersIdentity.WPF.Converters
{
    /// <summary>
    /// Converts between string and double values for data binding, using the current value as a fallback.
    /// </summary>
    public class StringAndCurrentValueToDoubleConverter : IMultiValueConverter
    {
        /// <inheritdoc/>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] is double currentValue)
            {
                return currentValue.ToString(culture);
            }

            return string.Empty;
        }

        /// <inheritdoc/>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            if (value is string stringValue && double.TryParse(stringValue, NumberStyles.Any, culture, out double result))
            {
                return new object[] { result, Binding.DoNothing };
            }

            // Return the current value if the input is invalid.
            return new object[] { Binding.DoNothing, Binding.DoNothing };
        }
    }
}