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
    /// <summary>
    /// Deze klasse dient als basis voor andere ViewModels die items moeten tonen.
    /// </summary>
    public abstract class ItemShowerViewModel : BaseViewModel
    {
        protected IList<Item> _allItems;
        protected IAccountProvider _accountProvider;
        protected FilterFactory _filterFactory;
        private IList<Item> _selectedItems;
        private bool _isLoading;

        public ICommand ShowBorders { get; set; }

        public ICommand ShowProfilePictures { get; set; }

        public ICommand ShowBoosters { get; set; }

        public ICommand ShowTitles { get; set; }

        /// <summary>
        /// Deze property geeft toegang tot het geselecteerde item.
        /// </summary>
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

        /// <summary>
        /// Deze property geeft aan of bepaalde dingen nog ingeladen moeten worden.
        /// </summary>
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

        /// <summary>
        /// Creëert een ViewModel voor views waarop items worden getoond.
        /// </summary>
        /// <param name="navigationStore">De navigationStore die wordt gebruikt voor navigatie.</param>
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

        /// <summary>
        /// Filtert op alle borders.
        /// </summary>
        protected void FilterBorders()
        {
            FilterAll(_filterFactory.GetFilter("Border"));
        }

        /// <summary>
        /// Filtert op alle profielfoto's.
        /// </summary>
        protected void FilterProfilePictures()
        {
            FilterAll(_filterFactory.GetFilter("ProfilePicture"));
        }

        /// <summary>
        /// Filtert op alle boosters.
        /// </summary>
        protected void FilterBoosters()
        {
            FilterAll(_filterFactory.GetFilter("Booster"));
        }

        /// <summary>
        /// Filtert op alle spelertitels.
        /// </summary>
        protected void FilterTitles()
        {
            FilterAll(_filterFactory.GetFilter("Title"));
        }

        /// <summary>
        /// Filtert de gegeven lijst met een bepaald filter.
        /// </summary>
        /// <param name="filter">De filter die wordt gebruikt voor het filteren.</param>
        /// <param name="items">De lijst met alle items waarop wordt gefilterd.</param>
        /// <returns>De gefilterde lijst met items</returns>
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

        // Filter alle items met een gegeven filter.
        private void FilterAll(IItemFilter filter)
        {
            SelectedItems = Filter(filter, _allItems);
        }
    }
}
