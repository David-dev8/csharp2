using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Quiz_Royale
{
    public class InverseBooleanToOpacityConverter: IValueConverter
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
