using Microsoft.Toolkit.Helpers;
using Quiz_Royale.Filters;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Quiz_Royale
{
    public abstract class ItemShowerViewModel : BaseViewModel
    {
        protected IList<Item> _allItems;
        protected IAccountProvider _accountProvider;
        protected FilterFactory _filterFactory;

        public ICommand ShowBorders { get; set; }

        public ICommand ShowProfilePictures { get; set; }

        public ICommand ShowBoosters { get; set; }

        public ICommand ShowTitles { get; set; }

        private IList<Item> _selectedItems;

        public IList<Item> SelectedItems
        {
            get
            {
                return _selectedItems;
            }
            set
            {
                _selectedItems = value;
                OnPropertyChanged();
            }
        }


        private IList<Item> _disabledItems;

        public IList<Item> DisabledItems
        {
            get
            {
                return _disabledItems;
            }
            set
            {
                _disabledItems = value;
                OnPropertyChanged();
            }
        }

        private bool _isLoading;

        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                _isLoading = value;
                OnPropertyChanged();
            }
        }

        public ItemShowerViewModel(NavigationStore navigationStore): base(navigationStore)
        {
            _filterFactory = new FilterFactory();
            _accountProvider = new APIAccountProvider();
            SelectedItems = new ObservableCollection<Item>();

            ShowBorders = new RelayCommand(FilterBorders);
            ShowProfilePictures = new RelayCommand(FilterProfilePictures);
            ShowBoosters = new RelayCommand(FilterBoosters);
            ShowTitles = new RelayCommand(FilterTitles);
        }

        protected void FilterBorders()
        {
            FilterAll(_filterFactory.GetFilter("Border"));
        }

        protected void FilterProfilePictures()
        {
            FilterAll(_filterFactory.GetFilter("ProfilePicture"));
        }

        protected void FilterBoosters()
        {
            FilterAll(_filterFactory.GetFilter("Booster"));
        }

        protected void FilterTitles()
        {
            // todo enum van filters?
            FilterAll(_filterFactory.GetFilter("Title"));
        }

        protected IList<Item> Filter(IItemFilter filter, IList<Item> items)
        {
            IList<Item> filteredItems = new List<Item>();
            foreach (Item item in items)
            {
                if (filter.Filter(item))
                {
                    filteredItems.Add(item);
                }
            }
            return filteredItems;
        }

        private void FilterAll(IItemFilter filter)
        {
            SelectedItems = Filter(filter, _allItems);
        }
    }
}
