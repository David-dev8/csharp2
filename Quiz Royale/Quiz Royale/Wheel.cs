using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Quiz_Royale
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:Quiz_Royale"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:Quiz_Royale;assembly=Quiz_Royale"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:Wheel/>
    ///
    /// </summary>
    public class Wheel : ItemsControl
    {
        private const double ANGLE_CORRECTION = 270;

        public static readonly DependencyProperty TestPropProperty =
            DependencyProperty.Register("RotateTowards", typeof(object), typeof(Wheel), new PropertyMetadata(null));

        static Wheel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Wheel), new FrameworkPropertyMetadata(typeof(Wheel)));
        }

        public object RotateTowards
        {
            get { return GetValue(TestPropProperty); }
            set { SetValue(TestPropProperty, value); }
        }

        public Wheel()
        {
            Loaded += PropertyChangedCallback;
        }

        private void PropertyChangedCallback(object sender, EventArgs args)
        {
            for(int i = 0; i < Items.Count; i++)
            {
                var item = Items.GetItemAt(i);
                if(RotateTowards.Equals(item))
                {
                    double currentAngle = GetAngleFromItem(item);
                    double nextAngle = GetAngleFromItem(Items.GetItemAt((i + 1) % Items.Count));
                    double randomAngle = GetRandomAngleInBetween(currentAngle, nextAngle);

                    DoubleAnimation rotateAnimation = GetRotateAnimation(randomAngle);
                    SetupAnimation(rotateAnimation);
                }
            }
        }

        private void SetupAnimation(DoubleAnimation animation)
        {
            Storyboard.SetTarget(animation, this);
            Storyboard.SetTargetProperty(animation, new PropertyPath("RenderTransform.(RotateTransform.Angle)"));

            var storyboard = new Storyboard();
            storyboard.Children.Add(animation);
            storyboard.BeginTime = new TimeSpan(0, 0, 1); // todo random Duration en extra rotatie
            storyboard.Begin();
        }

        private DoubleAnimation GetRotateAnimation(double angle)
        {
            return new DoubleAnimation
            {
                To = angle,
                Duration = TimeSpan.FromMilliseconds(3000),
                EasingFunction = new QuadraticEase()
                {
                    EasingMode = EasingMode.EaseOut,
                }
            };
        }

        private double GetRandomAngleInBetween(double firstAngle, double secondAngle)
        {
            return 360 * 5 + GetRandomDouble(firstAngle, secondAngle);
        }

        private double GetAngleFromItem(object item)
        {
            DependencyObject itemContainer = (FrameworkElement)ItemContainerGenerator.ContainerFromItem(item);
            Path p = FindByType<Path>(itemContainer);
            RotateTransform rotation = p.RenderTransform as RotateTransform;
            return ANGLE_CORRECTION - rotation.Angle;
        }

        private double GetRandomDouble(double minimum, double maximum)
        {
            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }

        private T FindByType<T>(DependencyObject element)
        {
            if(element is null)
            {
                return default(T);
            }
            else if(element is T t)
            {
                return t;
            }
            else
            {
                int amountOfChildren = VisualTreeHelper.GetChildrenCount(element);
                for (int i = 0; i < amountOfChildren; i++)
                {
                    T searchedElement = FindByType<T>(VisualTreeHelper.GetChild(element, i));
                    if(searchedElement != null)
                    {
                        return searchedElement;
                    }
                }
            }
            return default(T);
        }
    }
}
