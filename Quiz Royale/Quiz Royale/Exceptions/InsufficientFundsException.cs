using System;

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
