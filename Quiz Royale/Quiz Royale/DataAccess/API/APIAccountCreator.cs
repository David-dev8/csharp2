using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Royale
{
    public class APIAccountCreator : APIProcessor, IAccountCreator
    {
        private const int USERNAME_MAX_LENGTH = 20;

        public async Task<TokenCredentials> CreateAccount(string username)
        {
            if(string.IsNullOrEmpty(username) || username.Length > USERNAME_MAX_LENGTH)
            {
                throw new ArgumentException("username");
            }
            return await _apiHandler.Create<TokenCredentials, dynamic>("Player", new { username = username}); // todo mag dit?
        }
    }
}
