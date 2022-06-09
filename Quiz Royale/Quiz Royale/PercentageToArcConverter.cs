using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Quiz_Royale
{
    public class PercentageToArcConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double percentage = System.Convert.ToDouble(values[0]);
            int radius = System.Convert.ToInt32(values[1]);

            // Bereken de hoek in radialen
            double angle = percentage * 3.6 * (Math.PI / 180);

            double x = Math.Cos(angle) * radius;
            double y = Math.Sin(angle) * radius;

            int isLargeArc = (angle > Math.PI) ? 1 : 0;

            return StreamGeometry.Parse($"M0, 0 L{radius.ToString(CultureInfo.InvariantCulture)}, 0 A{radius.ToString(CultureInfo.InvariantCulture)}, {radius.ToString(CultureInfo.InvariantCulture)} 0 {isLargeArc} 1 " +
                $"{x.ToString(CultureInfo.InvariantCulture)}, {y.ToString(CultureInfo.InvariantCulture)} z");
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
