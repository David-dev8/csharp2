using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Royale.Exceptions
{
    /// <summary>
    /// Deze exceptie kan worden opgegooid wanneer er niet genoeg geld is om iets in de shop te kopen.
    /// </summary>
    public class InsufficientFundsException: Exception
    {
        public InsufficientFundsException(): base("Not enough funds to obtain the item")
        {
        }
    }
}
