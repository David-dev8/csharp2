using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale
{
    class TestAccount : IAccountProvider
    {
        public Account GetAccount(string username)
        {
           return new Account("talip",1,1,10);
        }

    }
}
