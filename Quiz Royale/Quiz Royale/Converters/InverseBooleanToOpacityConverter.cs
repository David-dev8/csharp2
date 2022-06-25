using System;
using System.Globalization;
using System.Windows.Data;

namespace Quiz_Royale.Converters
{
    /// <summary>
    /// Deze klasse is verantwoordelijk voor het omgekeerd omzetten van een boolean naar een waarde voor opacity. 
    /// True zorgt voor verminderde opacity, false geeft juist volledige opacity.
    /// </summary>
    public class InverseBooleanToOpacityConverter : IValueConverter
    {
        private const double _opacity = 0.4;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isTrue = System.Convert.ToBoolean(value);

            return isTrue ? _opacity : 1;
        }

        // Deze methode word nooit gebruikt, maar moet aanwezig zijn voor de inteface
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
