using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale
{
    public class APIAccountProvider : IAccountProvider
    {
        public Account GetAccount()
        {

            return new Account(username, 100, 2300, 150);

            return new Account("Harrold", 100, 2300, 150, new Inventory());
        }
    }
}
