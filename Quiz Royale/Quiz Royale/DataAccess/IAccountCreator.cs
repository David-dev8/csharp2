using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Royale.DataAccess
{
    /// <summary>
    /// Deze interface geeft de verplichte methodes aan om de juiste implementatie van een account creator te maken.
    /// </summary>
    public interface IAccountCreator
    {
        /// <summary>
        /// Creëert een account met de gegeven naam.
        /// </summary>
        /// <param name="username">De naam van het account.</param>
        /// <returns>De access token van de gebruiker.</returns>
        public Task<TokenCredentials> CreateAccount(string username);
    }
}
