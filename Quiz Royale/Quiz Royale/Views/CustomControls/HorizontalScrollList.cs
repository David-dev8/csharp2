using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Quiz_Royale.Views.CustomControls
{
    /// <summary>
    /// Deze CustomControl kan horizontaal scrollen door een horizontale lijst van items.
    /// Hij biedt ook de mogelijkheid om meerdere gedisable items en (pre)geselecteerde items mee te geven.
    /// Deze worden automatisch gerefreshed als ze in de binding veranderen.
    /// </summary>
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

        // Disable de items van een HorizontalScrollList
        private static void DisableItems(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((HorizontalScrollList)d).DisableItems();
        }

        // Selecteer de items die aangegeven zijn als geselecteerd van een HorizontalScrollList
        private static void SelectItems(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((HorizontalScrollList)d).SelectItems();
        }

        // Refresh de geselecteerde en gedisablede item als deze veranderd zijn.
        private static void Refresh(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var scrollList = (HorizontalScrollList)d;
            scrollList.DisableItems();
            scrollList.SelectItems();
        }

        private bool _isReselecting;
        private int _currentDisplayedItem;

        /// <summary>
        /// Deze property geeft toegang tot de gedisablede items van de HorizontalScrollList
        /// </summary>
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

        /// <summary>
        /// Deze property geeft toegang tot de geselecteerde items van de HorizontalScrollList.
        /// </summary>
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

        /// <summary>
        /// Creëert een HorizontalScrollList.
        /// </summary>
        public HorizontalScrollList()
        {
            Loaded += HorizontalScrollList_Loaded;
            SelectionChanged += HorizontalScrollList_SelectionChanged;
        }

        // Markeer alle items die geselecteerd moeten worden intern als geselecteerd, zodat ze geselecteerd worden weergegeven.
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

        // Maak horizontaal scrollen mogelijk wanneer de control is geladen.
        private void HorizontalScrollList_Loaded(object sender, RoutedEventArgs e)
        {
            PreviewMouseWheel += Shop_PreviewMouseWheel;
        }

        // Scroll horizontaal.
        private void Shop_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ShiftCurrent(e.Delta);
            ScrollIntoView(Items.GetItemAt(_currentDisplayedItem));
            e.Handled = true;
        }

        // Verander het item dat nu in beeld gescrolld moet zijn, afhankelijk van of delta positief of negatief is.
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

        // Haal het minimum aantal items op dat altijd op het scherm staat, afhankelijk van de breedte van één item.
        private int GetMinimumDisplayedItems()
        {
            return (int)(ActualWidth / GetItemWidth());
        }

        // Haal de breedte van één item op.
        private double GetItemWidth()
        {
            if(Items.Count == 0)
            {
                return 1;
            }
            return ((FrameworkElement)ItemContainerGenerator.ContainerFromItem(Items[0])).ActualWidth;
        }

        // Markeer alle gedisablede items van de HorizontalScrollList intern als gedisabled.
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

        // Zorg ervoor dat de geselecteerde items worden geüpdatet als de gebruiker een selectie veranderd.
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
