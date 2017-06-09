using System;
using System.Globalization;
using Xamarin.Forms;

namespace XamarinExample.Core.Converters
{
	public class NullConverter: IValueConverter
	{
		public object WhenNull { get; set; }
		public object WhenValue { get; set; }

		public object Convert (object value, Type targetType, object parameter, CultureInfo culture)
		{
			bool isNullOrDefault = value == null;
			if ((parameter as string) == "HandleDefaultAsNull")
			{
				if (value is string)
				{
					isNullOrDefault = string.IsNullOrEmpty ((string)value);
				}
			}

			return isNullOrDefault ? WhenNull : WhenValue;
		}

		public object ConvertBack (object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException ();
		}
	}
}
