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
    public class Wheel : ItemsControl
    {
        private const double ANGLE_CORRECTION = 270;

        private const int MIN_ROTATIONS = 4;

        private const int MAX_ROTATIONS = 8; // todo resourcedict voor players.xaml?

        private const int ROTATION_DURATION = 5;

        private const int START_DELAY_DURATION = 2;

        public static readonly DependencyProperty TestPropProperty =
            DependencyProperty.Register("RotateTowards", typeof(object), typeof(Wheel), new PropertyMetadata(null));

        private Random random;

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
            random = new Random();
            Loaded += PropertyChangedCallback;
        }

        private void PropertyChangedCallback(object sender, EventArgs args)
        {
            for (int i = 0; i < Items.Count; i++)
            {
                var item = Items.GetItemAt(i);
                if (RotateTowards.Equals(item))
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
            storyboard.BeginTime = new TimeSpan(0, 0, START_DELAY_DURATION);
            storyboard.Begin();
        }

        private DoubleAnimation GetRotateAnimation(double angle)
        {
            return new DoubleAnimation
            {
                To = angle,
                Duration = TimeSpan.FromMilliseconds(ROTATION_DURATION * 1000),
                EasingFunction = new QuadraticEase()
                {
                    EasingMode = EasingMode.EaseOut,
                }
            };
        }

        private double GetRandomAngleInBetween(double firstAngle, double secondAngle)
        {
            return 360 * random.Next(MIN_ROTATIONS, MAX_ROTATIONS) + GetRandomDouble(firstAngle, secondAngle);
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
            return random.NextDouble() * (maximum - minimum) + minimum;
        }

        private T FindByType<T>(DependencyObject element)
        {
            if (element is null)
            {
                return default(T);
            }
            else if (element is T t)
            {
                return t;
            }
            else
            {
                int amountOfChildren = VisualTreeHelper.GetChildrenCount(element);
                for (int i = 0; i < amountOfChildren; i++)
                {
                    T searchedElement = FindByType<T>(VisualTreeHelper.GetChild(element, i));
                    if (searchedElement != null)
                    {
                        return searchedElement;
                    }
                }
            }
            return default(T);
        }
    }
}