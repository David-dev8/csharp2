using Microsoft.Toolkit.Helpers;
using Quiz_Royale.DataAccess;
using Quiz_Royale.DataAccess.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Quiz_Royale
{
    public class ProfileViewModel : ItemShowerViewModel
    {
        private IAccountDataProvider _accountDataProvider;

        public NotifyTaskCompletion<IList<CategoryIntensity>> Mastery { get; set; }

        public NotifyTaskCompletion<IList<Badge>> Badges { get; set; }

        public NotifyTaskCompletion<Account> Account { get; set; }

        public ProfileViewModel(NavigationStore navigationStore) : base(navigationStore)
        {
            _accountDataProvider = new APIAccountDataProvider();
            _accountProvider = new APIAccountProvider();

            Mastery = new NotifyTaskCompletion<IList<CategoryIntensity>>(_accountDataProvider.GetCategoryMastery());
            Badges = new NotifyTaskCompletion<IList<Badge>>(_accountDataProvider.GetBadges());
            Account = new NotifyTaskCompletion<Account>(_accountProvider.GetAccount());

            Account.Result.Inventory.PropertyChanged += Inventory_PropertyChanged;

            ShowInventory();
        }

        private void Inventory_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(((Inventory) sender).ActiveItems.IsSuccessfullyCompleted)
            {
                EquippedItems = Account.Result.Inventory.ActiveItems.Result;
            }
        }

        private void ShowInventory()
        {
            _allItems = Account.Result?.Inventory.AllItems?.Result;
            FilterBorders();
            _equippedItems = Account.Result?.Inventory.ActiveItems?.Result;
        }


        private IList<Item> _equippedItems;

        public IList<Item> EquippedItems
        {
            get
            {
                return Account.Result.Inventory.ActiveItems.Result;
            }
            set
            {
                Item newItem = GetNewItem(value);
                if(newItem != null)
                {
                    Account.Result.Inventory.EquipItem(newItem);
                }
                else
                {
                    _equippedItems = value;
                }
                OnPropertyChanged();
            }
        }

        private Item GetNewItem(IList<Item> newItems)
        {
            if(newItems.Count == 0)
            {
                return null;
            }
            if(EquippedItems == null)
            {
                return newItems[0];
            }    
            return newItems.Where(i => !EquippedItems.Contains(i)).SingleOrDefault();
        }
    }
}