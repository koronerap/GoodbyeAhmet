using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace GoodbyeAhmetWPF.Converters
{
    public class StringFormatConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length > 0 && values[0] is string format && !string.IsNullOrEmpty(format))
            {
                try
                {
                    // The first value is the format string, the rest are arguments
                    return string.Format(format, values.Skip(1).ToArray());
                }
                catch (FormatException)
                {
                    return format;
                }
            }
            return string.Empty;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
