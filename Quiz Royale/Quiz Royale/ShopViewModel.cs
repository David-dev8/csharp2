using Quiz_Royale.Exceptions;
using System;
using System.Collections.Generic;
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

        public ShopViewModel(NavigationStore navigationStore) : base(navigationStore)
        {
            navigationStore.IsLoading = true;
            _shop = new Shop();
            _shop.PropertyChanged += _shop_PropertyChanged;
        }

        private void _shop_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(_shop.Items != null)
            {
                _allItems = _shop.Items;
                FilterBorders();
            }
        }

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
    }
}
