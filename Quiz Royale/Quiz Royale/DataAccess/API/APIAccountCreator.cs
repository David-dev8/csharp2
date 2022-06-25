using Quiz_Royale.DataAccess.API.Data;
using Quiz_Royale.Models.User;
using System;
using System.Threading.Tasks;

namespace Quiz_Royale.DataAccess.API
{
    /// <summary>
    /// Deze klasse creëert een account voor de gebruiker.
    /// </summary>
    public class APIAccountCreator : APIProcessor, IAccountCreator
    {
        private const int USERNAME_MAX_LENGTH = 20;

        public async Task<TokenCredentials> CreateAccount(string username)
        {
            if(string.IsNullOrEmpty(username) || username.Length > USERNAME_MAX_LENGTH)
            {
                throw new ArgumentException("username");
            }
            return await _apiHandler.Create<TokenCredentials, PlayerCreationData>("Player", new PlayerCreationData(username));
        }
    }
}
