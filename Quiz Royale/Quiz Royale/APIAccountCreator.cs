using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Royale
{
    public class APIAccountCreator : APIProcessor, IAccountCreator
    { 
        public async Task<TokenCredentials> CreateAccount(string username)
        {
            return await _apiHandler.Create<TokenCredentials, dynamic>("Player", new { username = username}); // todo mag dit?
        }
    }
}
