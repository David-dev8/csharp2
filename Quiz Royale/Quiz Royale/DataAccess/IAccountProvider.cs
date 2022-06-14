using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Royale
{
    /// <summary>
    /// Deze interface geeft de verplichte methodes aan om de juiste implementatie van een account provider te maken.
    /// </summary>
    public interface IAccountProvider
    {
        public Task<Account> GetAccount();
    }
}
