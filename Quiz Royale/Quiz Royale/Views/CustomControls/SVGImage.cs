using SharpVectors.Converters;
using SharpVectors.Runtime;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Media;

namespace Quiz_Royale.Views.CustomControls
{
    /// <summary>
    /// Deze CustomControl kan een SVG weergeven.
    /// </summary>
    public class SVGImage : SvgViewbox
    {
        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register("Color", typeof(string), typeof(SVGImage), new PropertyMetadata(null));

        static SVGImage()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SVGImage), new FrameworkPropertyMetadata(typeof(SVGImage)));
        }

        /// <summary>
        /// Deze property geeft toegang tot de kleur van de SVG
        /// </summary>
        public string Color
        {
            get 
            { 
                return (string)GetValue(ColorProperty); 
            }
            set 
            { 
                SetValue(ColorProperty, value); 
            }
        }

        /// <summary>
        /// Creëert een SVGImage.
        /// </summary>
        public SVGImage()
        {
            Loaded += SVGImage_Loaded;
        }

        // Laat de SVG zien in de kleur die is meegegeven, zodra de control is geladen.
        private void SVGImage_Loaded(object sender, RoutedEventArgs e)
        {
            if(Color != null)
            {
                SvgDrawingCanvas canvas = (SvgDrawingCanvas)Child;
                List<Drawing> drawings = (List<Drawing>)typeof(SvgDrawingCanvas)
                    .GetField("_drawObjects", BindingFlags.NonPublic | BindingFlags.Instance)
                    .GetValue(canvas);

                foreach(Drawing drawing in drawings)
                {
                    if(drawing is GeometryDrawing geometryDrawing)
                    {
                        geometryDrawing.Brush = new SolidColorBrush()
                        {
                            Color = (Color)ColorConverter.ConvertFromString(Color)
                        };
                    }
                }
            }
        }
    }
}
