using System;
using System.Globalization;
using Xamarin.Forms;

namespace XamarinExample.Core.Converters
{
	public class BoolConverter : IValueConverter
	{
		public object TrueValue { get; set; }
		public object FalseValue { get; set; }

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is bool) {
				return (bool)value ? TrueValue : FalseValue;
			}
			if (value is string) {
				return bool.Parse((string)value) ? TrueValue : FalseValue;
			}
			throw new NotSupportedException(string.Format("Type {0} is not supported", value.GetType()));
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}

