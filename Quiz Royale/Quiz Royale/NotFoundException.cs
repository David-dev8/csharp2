using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Royale
{
    public class NotFoundException: Exception
    {
        public NotFoundException(): base("The requested resource is not found")
        {
        }
    }
}
