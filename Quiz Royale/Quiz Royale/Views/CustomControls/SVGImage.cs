using SharpVectors.Converters;
using SharpVectors.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Quiz_Royale.Views.CustomControls
{
    public class SVGImage : SvgViewbox
    {
        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register("Color", typeof(string), typeof(SVGImage), new PropertyMetadata(null));

        static SVGImage()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SVGImage), new FrameworkPropertyMetadata(typeof(SVGImage)));
        }

        public string Color
        {
            get { return (string)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        public SVGImage()
        {
            Loaded += SVGImage_Loaded;
        }

        private void SVGImage_Loaded(object sender, RoutedEventArgs e)
        {
            if (Color != null)
            {
                SvgDrawingCanvas canvas = (SvgDrawingCanvas)Child;
                List<Drawing> drawings = (List<Drawing>)typeof(SvgDrawingCanvas)
                    .GetField("_drawObjects", BindingFlags.NonPublic | BindingFlags.Instance)
                    .GetValue(canvas);

                foreach (Drawing drawing in drawings)
                {
                    if (drawing is GeometryDrawing geometryDrawing)
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
