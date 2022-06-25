using Microsoft.Toolkit.Helpers;
using Quiz_Royale.Base;
using Quiz_Royale.Exceptions;
using Quiz_Royale.Models.Items;
using Quiz_Royale.Models.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quiz_Royale.ViewModels
{
    /// <summary>
    /// Deze klasse dient als ViewModel voor de shop. 
    /// Het bevat properties en commands voor de desbetreffende view.
    /// </summary>
    public class ShopViewModel : ItemShowerViewModel
    {
        private Shop _shop;
        private Item _itemSelected;
        private IList<Item> _rewards;
        private IList<Item> _disabledItems;

        public NotifyTaskCompletion<Account> Account { get; set; }

        /// <summary>
        /// Als er een item wordt geselecteerd zal deze worden gekocht met coins.
        /// </summary>
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

        /// <summary>
        /// Als er een reward item wordt geselecteerd zal deze worden gekocht met XP.
        /// </summary>
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

        /// <summary>
        /// Deze property geeft toegang tot de rewards van de shop.
        /// </summary>
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


        /// <summary>
        /// Deze property geeft toegang tot alle items die gedisabled zijn.
        /// Items die al gekocht zijn en die niet meer opnieuw kunnen worden gekocht worden gedisabled.
        /// </summary>
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

        /// <summary>
        /// Creëert een ShopViewModel met een gegeven navigationStore.
        /// </summary>
        /// <param name="navigationStore">De navigationStore die wordt gebruikt voor navigatie.</param>
        public ShopViewModel(NavigationStore navigationStore) : base(navigationStore)
        {
            IsLoading = true;
            _shop = new Shop();
            _shop.Items.PropertyChanged += Items_PropertyChanged;
            Account = new NotifyTaskCompletion<Account>(_accountProvider.GetAccount());
            Account.Result.Inventory.PropertyChanged += Inventory_PropertyChanged;
        }

        private void Inventory_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(Account.Result.Inventory.AllItems.IsSuccessfullyCompleted)
            {
                DisabledItems = _shop.GetItemsOutOfStock(Account.Result);
            }
        }

        // Zorgt ervoor dat de items die gekocht worden en de rewards apart worden opgeslagen zodra alle items in de shop zijn opgehaald.
        // Filter standaard op de borders.
        private void Items_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (_shop.Items.IsSuccessfullyCompleted && Account.IsSuccessfullyCompleted)
            {
                FillBuyables(_shop.Items.Result);
                FillRewards(_shop.Items.Result);
                DisabledItems = _shop.GetItemsOutOfStock(Account.Result);
                App.Current.Dispatcher.Invoke(() =>
                {
                    FilterBorders();
                });
                IsLoading = false;
            }
        }

        // Koopt het huidige geselecteerde item.
        // Als blijkt dat dit niet mogelijk is, wordt er een foutmelding weergegeven.
        private async Task Buy()
        {
            try
            {
                await _shop.BuyItem(Account.Result, _itemSelected);
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

        // Filtert alle items die gekocht kunnen worden met coins.
        private void FillBuyables(IList<Item> items)
        {
            _allItems = Filter(_filterFactory.GetFilter("Buy"), items);
        }

        // Filtert alle items die gekocht kunnen worden met XP.
        private void FillRewards(IList<Item> items)
        {
            Rewards = Filter(_filterFactory.GetFilter("Reward"), items);
        }
    }
}
