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

        public Account Account { get; set; }

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

        public ShopViewModel(NavigationStore navigationStore) : base(navigationStore)
        {
            IsLoading = true;
            _shop = new Shop();
            _shop.Items.PropertyChanged += Items_PropertyChanged;
            Account = _accountProvider.GetAccount();
        }

        private void Items_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (_shop.Items.IsSuccessfullyCompleted)
            {
                FillBuyables(_shop.Items.Result);
                FillRewards(_shop.Items.Result);
                DisabledItems = _shop.GetItemsOutOfStock(Account);
                App.Current.Dispatcher.Invoke(() =>
                {
                    FilterBorders();
                });
                IsLoading = false;
            }
        }

        private async Task Buy()
        {
            // todo try catch?
            try
            {
                await _shop.BuyItem(Account, _itemSelected);
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
