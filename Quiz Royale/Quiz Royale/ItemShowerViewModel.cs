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
    public abstract class ItemShowerViewModel: BaseViewModel
    {
        protected IList<Item> _allItems;
        protected IAccountProvider _accountProvider;
        private FilterFactory _filterFactory;

        public ICommand ShowBorders { get; set; }

        public ICommand ShowProfilePictures { get; set; }

        public ICommand ShowBoosters { get; set; }

        public ICommand ShowTitles { get; set; }

        public ObservableCollection<Item> SelectedItems { get; private set; }

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

        private void FilterAll(IItemFilter filter)
        {
            SelectedItems.Clear();
            foreach(Item item in _allItems)
            {
                if(filter.Filter(item))
                {
                    SelectedItems.Add(item);
                }
            }
        }
    }
}
