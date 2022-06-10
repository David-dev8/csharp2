using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Quiz_Royale
{
    public class PercentageToAngleAdditionConverter : IValueConverter
    {
        // We houden bij hoeveel de som totaal is tot nu toe
        private double _totalOfAll;

        public PercentageToAngleAdditionConverter()
        {
            _totalOfAll = 0;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double oldTotalOfAll = _totalOfAll;

            double percentage = System.Convert.ToDouble(value);
            _totalOfAll += percentage * 3.6;

            return oldTotalOfAll;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
