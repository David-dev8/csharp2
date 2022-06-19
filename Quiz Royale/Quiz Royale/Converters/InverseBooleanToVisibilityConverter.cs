using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Quiz_Royale.Converters
{
    /// <summary>
    /// Deze klasse is verantwoordelijk voor het omgekeerd omzetten van een boolean naar een Visibility. 
    /// True zorgt voor geen zichtbaarheid, false geeft juist wel zichtbaarheid.
    /// </summary>
    public class InverseBooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isTrue = System.Convert.ToBoolean(value);

            return isTrue ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
