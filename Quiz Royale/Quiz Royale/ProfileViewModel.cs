using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale
{
    class ProfileViewModel : BaseViewModel
    {
        private IAccountDataProvider _accountDataProvider;
        private IAccountProvider _accountProvider;

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
                return _accountProvider.getAccount();
            }
        }
         
        public string Name
        {
            get
            {
                return "test";
            }
        }

        public ProfileViewModel(NavigationStore navigationStore) : base(navigationStore)
        {
            _accountDataProvider = new TestData();
            _accountProvider = new TestAccount();

        }

    }
}
