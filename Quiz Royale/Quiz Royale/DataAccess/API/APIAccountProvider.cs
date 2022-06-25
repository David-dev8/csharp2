using Quiz_Royale.Models.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Royale.DataAccess.API
{
    /// <summary>
    /// Deze klasse levert het account van de gebruiker.
    /// </summary>
    public class APIAccountProvider : APIProcessor, IAccountProvider
    {
        private static Account s_account;

        public async Task<Account> GetAccount()
        {
            if (s_account == null)
            {
                s_account = await _apiHandler.Fetch<Account>("/Player");
            }

            return s_account;
        }
    }
}
