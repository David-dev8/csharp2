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
                return _accountProvider.GetAccount();
            }
        }

        //public IList<Item> Items
        //{
        //    set
        //    {
        //        _items = value;
        //        OnPropertyChanged();

        //    }
        //    get
        //    {
        //        return _items;
        //    }
        //}

        //public string Name
        //{
        //    get
        //    {
        //        return "test";
        //    }
        //}

        //public ICommand ShowBorders { get; set; }
        //public ICommand ShowProfilePictures { get; set; }
        //public ICommand ShowTitles { get; set; }
        //public ICommand ShowBoosters { get; set; }

        public ProfileViewModel(NavigationStore navigationStore) : base(navigationStore)
        {
            _accountDataProvider = new APIAccountDataProvider();
            //_accountProvider = new APIAccountProvider();
            //_itemProvider = new TestItem();
            //ShowBorders = new RelayCommand(ShowBorder);
            //ShowProfilePictures = new RelayCommand(ShowProfilePicture);
            //ShowTitles = new RelayCommand(ShowTitle);
            //ShowBoosters = new RelayCommand(ShowBooster);
            //_items = _itemProvider.GetItems();



        }

        //private void ShowBorder()
        //{
        //   Items = new List<Item>
        //    {
        //         new Border ("Border","Border",1,Payment.XP)
        //    };
        //}

        //private void ShowProfilePicture()
        //{
        //    Items = new List<Item>
        //    {
        //         new ProfilePicture ("Profile","Profile",1,Payment.XP)
        //    };
        //}

        //private void ShowTitle()
        //{
        //    Items = new List<Item>
        //    {
        //         new PlayerTitle ("Title","Title",1,Payment.XP)
        //    };
        //}

        //private void ShowBooster()
        //{
        //    Items = new List<Item>
        //    {
        //         new Booster ("Booster","Booster",1,Payment.XP,"Booster",1)
        //    };
        //}


    }
}