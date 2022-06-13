using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Royale
{
    public interface IAccountProvider
    {
        public Task<Account> GetAccount();
    }
}
