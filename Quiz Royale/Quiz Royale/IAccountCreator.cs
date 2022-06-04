using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Royale
{
    public interface IAccountCreator
    {
        public Task<TokenCredentials> CreateAccount(string username);
    }
}
