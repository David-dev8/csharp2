using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Quiz_Royale.Converters
{
    /// <summary>
    /// Deze klasse is verantwoordelijk voor het genereren van een willekeurige x en y positie binnen een bepaalde hoogte en breedte.
    /// Bij het converten wordt daarvoor een Thickness met de x en y positie teruggegeven.
    /// </summary>
    public class RandomPositionConverter: IMultiValueConverter
    {
        private static Random s_random = new Random();

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            FrameworkElement element = (FrameworkElement)values[0];

            // Values bevat als tweede en derde respectievelijk de breedte en hoogte van de parent
            int parentWidth = System.Convert.ToInt32(values[1]);
            int parentHeight = System.Convert.ToInt32(values[2]);
            // Het element zelf heeft ook een breedte en hoogte
            // Dit vermindert de ruimte die er tot beschikking is
            int availableWidth = parentWidth - System.Convert.ToInt32(element.ActualWidth);
            int availableHeight = parentHeight - System.Convert.ToInt32(element.ActualHeight);
            int randomX = s_random.Next(Math.Max(0, availableWidth));
            int randomY = s_random.Next(Math.Max(0, availableHeight));

            // Geef de willekeurige positie als margin door aan het element zodat deze op een willekeurige plek komt
            return new Thickness(randomX, randomY, 0, 0);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
