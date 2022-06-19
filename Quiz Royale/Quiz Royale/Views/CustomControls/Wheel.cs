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

namespace Quiz_Royale.Views.CustomControls
{
    public class Wheel : ItemsControl
    {
        public static readonly DependencyProperty RotateTowardsProperty =
            DependencyProperty.Register("RotateTowards", typeof(object), typeof(Wheel), new PropertyMetadata(null));

        static Wheel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Wheel), new FrameworkPropertyMetadata(typeof(Wheel)));
        }

        private const double ANGLE_CORRECTION = 270;

        private const int MIN_ROTATIONS = 4;

        private const int MAX_ROTATIONS = 8;

        private const int ROTATION_DURATION = 5;

        private const int START_DELAY_DURATION = 2;

        private Random random;

        public object RotateTowards
        {
            get
            {
                return GetValue(RotateTowardsProperty);
            }
            set
            {
                SetValue(RotateTowardsProperty, value);
            }
        }

        public Wheel()
        {
            random = new Random();
            Loaded += LoadedCallback;
        }

        private void LoadedCallback(object sender, EventArgs args)
        {
            if (RotateTowards != null)
            {
                for (int i = 0; i < Items.Count; i++)
                {
                    var item = Items.GetItemAt(i);
                    if (RotateTowards.Equals(item))
                    {
                        double currentAngle = GetAngleFromItem(item);
                        double nextAngle = GetAngleFromItem(Items.GetItemAt((i + 1) % Items.Count));
                        if (nextAngle == ANGLE_CORRECTION)
                        {
                            nextAngle -= 360;
                        }
                        double randomAngle = GetRandomAngleInBetween(currentAngle, nextAngle);

                        DoubleAnimation rotateAnimation = GetRotateAnimation(randomAngle);
                        SetupAnimation(rotateAnimation);
                    }
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
            return 360 * random.Next(MIN_ROTATIONS, MAX_ROTATIONS) +
                GetRandomDouble(Math.Min(firstAngle, secondAngle), Math.Max(secondAngle, firstAngle));
        }

        private double GetAngleFromItem(object item)
        {
            DependencyObject itemContainer = ItemContainerGenerator.ContainerFromItem(item);
            Path p = FindByType<Path>(itemContainer);
            RotateTransform rotation = p.RenderTransform as RotateTransform;
            return (ANGLE_CORRECTION - rotation.Angle) % 360;
        }

        private double GetRandomDouble(double minimum, double maximum)
        {
            return random.NextDouble() * (maximum - minimum) + minimum;
        }

        private T FindByType<T>(DependencyObject element)
        {
            if (element is null)
            {
                return default;
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
            return default;
        }
    }
}