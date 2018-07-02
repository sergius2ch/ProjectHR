using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace UIControls.Utils
{
    public class DateTimeToString : ConvertorBase<DateTimeToString>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime date = (DateTime)value;
            string s1 = date.ToShortDateString();
            string s2 = date.ToLongTimeString();
            return $"{s1} {s2}";
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
