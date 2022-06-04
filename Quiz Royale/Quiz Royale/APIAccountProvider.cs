using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale
{
    public class APIAccountProvider : IAccountProvider
    {
        public Account GetAccount(string username)
        {
            return new Account(username, 100, 2000, 150, new Inventory());
        }
    }
}
