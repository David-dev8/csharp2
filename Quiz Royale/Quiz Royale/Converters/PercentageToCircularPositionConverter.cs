using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Quiz_Royale
{
    public class PercentageToCircularPositionAdditionConverter : IMultiValueConverter
    {
        private double _totalOfAll;

        public PercentageToCircularPositionAdditionConverter()
        {
            _totalOfAll = 0;
        }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double percentage = System.Convert.ToDouble(values[0]);
            double radius = System.Convert.ToInt32(values[1]) * 0.6;

            // Bereken de hoek in radialen
            double angle = percentage * 3.6 * (Math.PI / 180);

            double oldTotal = _totalOfAll;
            _totalOfAll += angle;

            double angleInBetween = (oldTotal + _totalOfAll) / 2;

            double x = Math.Cos(angleInBetween) * radius;
            double y = Math.Sin(angleInBetween) * radius;

            double elementWidth = System.Convert.ToDouble(values[2]);
            x -= elementWidth / 2;
            y -= elementWidth / 2;

            _totalOfAll %= 2 * Math.PI;

            return new Thickness(x, y, 0, 0);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
