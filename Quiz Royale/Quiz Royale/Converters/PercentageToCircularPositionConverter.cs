using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Quiz_Royale.Converters
{
    /// <summary>
    /// Deze klasse zorgt ervoor dat een percentage tussen de 0 en 100 wordt omgezet naar een x en y positie op een cirkel met een bepaalde radius.
    /// Bij het converten wordt daarvoor een Thickness met de x en y positie teruggegeven.
    /// Een instantie van deze klasse houdt een totaal bij, zodat de x en y positie wordt bepaald vanaf de vorige x en y positie.
    /// Zo wordt er in feite een cirkel "rond gelopen".
    /// </summary>
    public class PercentageToCircularPositionAdditionConverter : IMultiValueConverter
    {
        private double _totalOfAll;

        /// <summary>
        /// Creëert een PercentageToCircularPositionAdditionConverter.
        /// </summary>
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
