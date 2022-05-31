using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale
{
    class TestAccount : IAccountProvider
    {
        public Account getAccount()
        {
           return new Account("talip",1,1,10);
        }

    }
}
