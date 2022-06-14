using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Royale
{
    /// <summary>
    /// Deze klasse dient als basis voor de providers en mutators om bewerkingen te doen aan de gegevens van de gebruiker.
    /// </summary>
    public abstract class APIProcessor
    {
        protected APIHandler _apiHandler;

        /// <summary>
        /// Creëert een processor om gegevens te kunnen bewerken en op te kunnen halen van de API.
        /// </summary>
        public APIProcessor()
        {
            _apiHandler = new APIHandler();
        }
    }
}
