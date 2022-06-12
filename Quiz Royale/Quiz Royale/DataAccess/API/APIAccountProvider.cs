using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale
{
    public class APIAccountProvider : APIProcessor, IAccountProvider
    {
        private static Account s_account;

        public async void Initialize()
        {
            s_account = await _apiHandler.Fetch<Account>("/Player");
        }

        public Account GetAccount()
        {
            return new Account("tim", 1, 1, 1, new Inventory());
        }
    }
}
