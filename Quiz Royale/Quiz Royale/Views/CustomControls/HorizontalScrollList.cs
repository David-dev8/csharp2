using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Quiz_Royale.Views.CustomControls
{
    public class HorizontalScrollList : ListView
    {
        public static readonly DependencyProperty DisabledItemsProperty =
            DependencyProperty.Register("DisabledItems", typeof(IEnumerable), typeof(HorizontalScrollList),
                new FrameworkPropertyMetadata(DisableItems));

        public static readonly DependencyProperty ItemsSelectedProperty =
            DependencyProperty.Register("ItemsSelected", typeof(IEnumerable), typeof(HorizontalScrollList),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, SelectItems));

        static HorizontalScrollList()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(HorizontalScrollList), new FrameworkPropertyMetadata(typeof(HorizontalScrollList)));
            ItemsSourceProperty.OverrideMetadata(typeof(HorizontalScrollList), new FrameworkPropertyMetadata(Refresh));
        }

        private static void DisableItems(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((HorizontalScrollList)d).DisableItems();
        }

        private static void SelectItems(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((HorizontalScrollList)d).SelectItems();
        }

        private static void Refresh(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var scrollList = (HorizontalScrollList)d;
            scrollList.DisableItems();
            scrollList.SelectItems();
        }

        private bool _isReselecting;
        private int _currentDisplayedItem;

        public IEnumerable DisabledItems
        {
            get
            {
                return (IEnumerable)GetValue(DisabledItemsProperty);
            }
            set
            {
                SetValue(DisabledItemsProperty, value);
            }
        }

        public IEnumerable ItemsSelected
        {
            get
            {
                return (IEnumerable)GetValue(ItemsSelectedProperty);
            }
            set
            {
                SetValue(ItemsSelectedProperty, value);
            }
        }

        public HorizontalScrollList()
        {
            Loaded += HorizontalScrollList_Loaded;
            SelectionChanged += HorizontalScrollList_SelectionChanged;
        }

        private void HorizontalScrollList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(SelectionMode == SelectionMode.Multiple && e.AddedItems.Count > 0)
            {
                Type type = e.AddedItems[0].GetType().BaseType;
                Type listType = typeof(List<>).MakeGenericType(new[] { type });
                IList itemsSelected = (IList)Activator.CreateInstance(listType);

                foreach(var item in SelectedItems)
                {
                    itemsSelected.Add(item);
                }
                ItemsSelected = itemsSelected;
            }
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
            if(_currentDisplayedItem == 0 && delta > 0)
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
            if(Items.Count == 0)
            {
                return 1;
            }
            return ((FrameworkElement)ItemContainerGenerator.ContainerFromItem(Items[0])).ActualWidth;
        }

        private void DisableItems()
        {
            if(DisabledItems != null)
            {
                foreach(object item in DisabledItems)
                {
                    FrameworkElement container = ItemContainerGenerator.ContainerFromItem(item) as FrameworkElement;
                    if(container != null)
                    {
                        container.IsEnabled = false;
                    }
                }
            }
        }

        private void SelectItems()
        {
            if(SelectionMode == SelectionMode.Multiple)
            {
                if(!_isReselecting)
                {
                    if(ItemsSelected != null)
                    {
                        _isReselecting = true;
                        SelectedItems.Clear();
                        foreach(var item in ItemsSelected)
                        {
                            SelectedItems.Add(item);
                        }
                        _isReselecting = false;
                    }
                }
            }
        }
    }
}
