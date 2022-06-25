using System;
using System.Globalization;
using System.Windows.Data;

namespace Quiz_Royale.Converters
{
    /// <summary>
    /// Deze klasse zorgt ervoor dat een percentage tussen de 0 en 100 wordt omgezet naar een hoek in graden.
    /// Een instantie van deze klasse zal ook een totaal bijhouden van alle hoeken waar hij naar heeft omgezet.
    /// Op deze wijze kan een hoek vanaf de laatste hoek verdergaan en ontstaat een cirkel.
    /// </summary>
    public class PercentageToAngleAdditionConverter : IValueConverter
    {
        // Bijhouden hoeveel de som totaal is tot nu toe
        private double _totalOfAll;

        /// <summary>
        /// Creëert een PercentageToAngleAdditionConverter.
        /// </summary>
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
