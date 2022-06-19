using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Royale.CustomEventArgs
{
    /// <summary>
    /// Deze klasse bevat informatie voor wanneer een een statusbericht is veranderd.
    /// </summary>
    public class UpdateStatusArgs : EventArgs
    {
        public string Message { get; }

        /// <summary>
        /// Creëert een UpdateStatusArgs met het gegeven bericht.
        /// </summary>
        /// <param name="message">Het nieuwe bericht.</param>
        public UpdateStatusArgs(string message)
        {
            Message = message;
        }
    }
}
