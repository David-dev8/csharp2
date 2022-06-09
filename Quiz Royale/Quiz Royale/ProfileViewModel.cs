using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Quiz_Royale
{
    public class ProfileViewModel : BaseViewModel
    {
        private IList<Item> _items;
        private IAccountDataProvider _accountDataProvider;
        private IAccountProvider _accountProvider;
        private Account _account;
        private Inventory _inventory;
        private ItemProvider _itemProvider;
        public IList<Mastery> Mastery 
        {
            get 
            {
                return _accountDataProvider.GetCategoryMastery();
            } 
        }

        public IList<Badge> Badge
        {
            get
            {
                return _accountDataProvider.GetBadges();
            }
        }

        public Account Account
        {
            get
            {
                return _accountProvider.GetAccount("test");
            }
        }

        public IList<Item> Items
        {
            set
            {
                _items = value;
                OnPropertyChanged();
              
            }
            get
            {
                return _items;
            }
        }

        public string Name
        {
            get
            {
                return "test";
            }
        }

        public ICommand ShowBorders { get; set; }

        public ProfileViewModel(NavigationStore navigationStore) : base(navigationStore)
        {
            _accountDataProvider = new TestData();
            _accountProvider = new TestAccount();
            _itemProvider = new TestItem();
            ShowBorders = new RelayCommand(ShowBorder);
            _items = _itemProvider.GetItems();

        }

        private void ShowBorder()
        {
           Items = new List<Item>
            {
                 new Booster ("hallo","hallo",1,Payment.XP,"10", 1)
            };
        }
    }
}