using Quiz_Royale.Exceptions;
using Quiz_Royale.Filters;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Royale
{
    public class ShopViewModel : ItemShowerViewModel
    {
        private Shop _shop;

        private Item _itemSelected;

        public Item ItemSelected
        {
            set
            {
                if(value != null)
                {
                    _itemSelected = value;
                    Buy();
                }
            }
        }

        public Item RewardSelected
        {
            set
            {
                if (value != null)
                {
                    _itemSelected = value;
                    Buy();
                }
            }
        }

        private IList<Item> _rewards;

        public IList<Item> Rewards
        {
            get
            {
                return _rewards;
            }
            set
            {
                _rewards = value;
                OnPropertyChanged();
            }
        }

        public ShopViewModel(NavigationStore navigationStore) : base(navigationStore)
        {
            IsLoading = true;
            _shop = new Shop();
            _shop.Items.PropertyChanged += Items_PropertyChanged; ;
        }

        private void Items_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (_shop.Items.IsSuccessfullyCompleted)
            {
                FillBuyables(_shop.Items.Result);
                FillRewards(_shop.Items.Result);
                var t = new List<Item>();
                t.Add(_shop.Items.Result[0]);
                DisabledItems = t;
                App.Current.Dispatcher.Invoke(() =>
                {
                    FilterBorders();
                });
                IsLoading = false;
            }
        }

        // todo?
        public bool IsEnabled(Item item)
        {
            return _shop.CanBuy(_accountProvider.GetAccount(), item);
        }

        private async Task Buy()
        {
            // todo try catch?
            try
            {
                await _shop.BuyItem(_accountProvider.GetAccount(), _itemSelected);
            }
            catch(InsufficientFundsException)
            {
                _navigationStore.Error = "Not enough funds to obtain the item";
            }
            catch(Exception)
            {
                _navigationStore.Error = "Something went wrong.";
            }
        }

        private void FillBuyables(IList<Item> items)
        {
            _allItems = Filter(_filterFactory.GetFilter("Buy"), items);
        }

        private void FillRewards(IList<Item> items)
        {
            Rewards = Filter(_filterFactory.GetFilter("Reward"), items);
        }
    }
}
