using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Royale.DataAccess
{
    /// <summary>
    /// Deze interface geeft de verplichte methodes aan om de juiste implementatie van een account provider te maken.
    /// </summary>
    public interface IAccountProvider
    {
        /// <summary>
        /// Haalt een account op voor de gebruiker.
        /// </summary>
        /// <returns>Het account van de gebruiker.</returns>
        public Task<Account> GetAccount();
    }
}
