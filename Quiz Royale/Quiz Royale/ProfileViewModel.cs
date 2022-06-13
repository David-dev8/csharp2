using Microsoft.Toolkit.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Quiz_Royale
{
    public class ProfileViewModel : ItemShowerViewModel
    {
        //private IList<Item> _items;
        private IAccountDataProvider _accountDataProvider;
        //private IAccountProvider _accountProvider;
        //private Account _account;
        //private Inventory _inventory;
        //private ItemProvider _itemProvider;
        public NotifyTaskCompletion<IList<CategoryMastery>> Mastery { get; set; }

        public NotifyTaskCompletion<IList<Badge>> Badges { get; set; }

        public NotifyTaskCompletion<Account> Account { get; set; }

        public ProfileViewModel(NavigationStore navigationStore) : base(navigationStore)
        {
            _accountDataProvider = new APIAccountDataProvider();
            _accountProvider = new APIAccountProvider();

            Mastery = new NotifyTaskCompletion<IList<CategoryMastery>>(_accountDataProvider.GetCategoryMastery());
            Badges = new NotifyTaskCompletion<IList<Badge>>(_accountDataProvider.GetBadges());
            Account = new NotifyTaskCompletion<Account>(_accountProvider.GetAccount());
        }
    }
}