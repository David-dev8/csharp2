using System;
using System.Collections;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Quiz_Royale
{
    public class HorizontalScrollList : ListView
    {
        public static readonly DependencyProperty DisabledItemsProperty =
            DependencyProperty.Register("DisabledItems", typeof(IEnumerable), typeof(HorizontalScrollList), 
                new PropertyMetadata(DisableItems));

        static HorizontalScrollList()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(HorizontalScrollList), new FrameworkPropertyMetadata(typeof(HorizontalScrollList)));
            ItemsSourceProperty.OverrideMetadata(typeof(HorizontalScrollList), new FrameworkPropertyMetadata(DisableItems));
        }

        private static void DisableItems(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((HorizontalScrollList) d).DisableItems();
        }

        private int _currentDisplayedItem;

        public IEnumerable DisabledItems
        {
            get
            {
                return (IEnumerable) GetValue(DisabledItemsProperty);
            }
            set
            {
                SetValue(DisabledItemsProperty, value);
            }
        }

        public HorizontalScrollList()
        {
            Loaded += HorizontalScrollList_Loaded;
        }

        private void HorizontalScrollList_Loaded(object sender, RoutedEventArgs e)
        {
            PreviewMouseWheel += Shop_PreviewMouseWheel;
        }

        private void Shop_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ShiftCurrent(e.Delta);
            ScrollIntoView(Items.GetItemAt(_currentDisplayedItem));  
            e.Handled = true;
        }

        private void ShiftCurrent(int delta)
        {
            if (_currentDisplayedItem == 0 && delta > 0)
            {
                _currentDisplayedItem = Math.Min(GetMinimumDisplayedItems(), Items.Count - 1);
            }
            else
            {
                _currentDisplayedItem += delta < 0 ? -1 : 1;
                _currentDisplayedItem = Math.Min(Math.Max(0, _currentDisplayedItem), Items.Count - 1);
            }
        }

        private int GetMinimumDisplayedItems()
        {
            return (int)(ActualWidth / GetItemWidth());
        }

        private double GetItemWidth()
        {
            return ((FrameworkElement) ItemContainerGenerator.ContainerFromItem(Items[0])).ActualWidth;
        }

        private void DisableItems()
        {
            if(DisabledItems != null)
            {
                foreach (object item in DisabledItems)
                {
                    FrameworkElement container = ItemContainerGenerator.ContainerFromItem(item) as FrameworkElement;
                    if (container != null)
                    {
                        container.IsEnabled = false;
                    }
                }
            }
        }
    }
}
