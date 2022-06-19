using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Quiz_Royale.Converters
{
    /// <summary>
    /// Deze klasse is verantwoordelijk voor het inverten van een boolean waarde. True wordt dus false en vice versa.
    /// </summary>
    public class InverseBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isTrue = System.Convert.ToBoolean(value);

            return !isTrue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
