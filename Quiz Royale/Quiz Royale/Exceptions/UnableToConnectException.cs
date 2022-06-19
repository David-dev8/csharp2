using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Royale.Exceptions
{
    /// <summary>
    /// Deze exceptie kan worden opgegooid wanneer er geen conectie kan worden gemaakt met de hub
    /// </summary>
    public class UnableToConnectException : Exception
    {
        public UnableToConnectException() : base("Failed to make a connection to the server, are you sure you are connected to the internet?")
        { 
        
        }
    }
}
