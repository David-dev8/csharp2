using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Royale.Exceptions
{
    public class InvalidDataException: Exception
    {
        public InvalidDataException(): base("There is something wrong with the data")
        {
        }
    }
}
