using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Royale
{
    public class InternalErrorException: Exception
    {
        public InternalErrorException(): base("Something went wrong in the processing of the action")
        {
        }
    }
}
