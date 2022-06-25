using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Quiz_Royale.Converters
{
    /// <summary>
    /// Deze klasse is verantwoordelijk voor het omzetten van een boolean naar een kleur die aangeeft of iets goed of fout is.
    /// </summary>
    public class BooleanToCorrectColorConverter : IValueConverter
    {
        private static readonly string CORRECT_COLOR = "#006400";
        private static readonly string INCORRECT_COLOR = "#ff0000";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value == null)
            {
                return Brushes.Transparent;
            }
            string color = (bool)value ? CORRECT_COLOR : INCORRECT_COLOR;
            return new SolidColorBrush()
            {
                Color = (Color)ColorConverter.ConvertFromString(color)
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
