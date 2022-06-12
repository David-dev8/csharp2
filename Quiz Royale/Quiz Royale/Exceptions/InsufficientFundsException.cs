using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Royale.Exceptions
{
    public class InsufficientFundsException: Exception
    {
        public InsufficientFundsException(): base("Not enough funds to obtain the item")
        {
        }
    }
}
