using Quiz_Royale.Models;
using Quiz_Royale.Models.Games;
using System;
using System.Collections.Generic;

namespace Quiz_Royale.CustomEventArgs
{
    /// <summary>
    /// Deze klasse bevat informatie voor wanneer een speler een spel succesvol of onsuccesvol joint.
    /// </summary>
    public class JoinStatusArgs : EventArgs
    {
        public bool Status { get; }

        public string Message { get; }

        public IList<Player> Players { get; }

        public IList<CategoryIntensity> categories { get; }

        /// <summary>
        /// Creëert JoinStatusArgs met de gegeven waarden.
        /// </summary>
        /// <param name="status">Of het joinen gelukt is of niet.</param>
        /// <param name="message">Een beschrijvende melding die de huidige stand van zaken van het spel aangeeft.</param>
        /// <param name="players">De spelers die al in het spel waren toen de speler gejoind was.</param>
        /// <param name="cats">Een lijst met alle categorieën en hun initiële kansen.</param>
        public JoinStatusArgs(bool status, string message, IList<Player> players, IList<CategoryIntensity> cats)
        { 
            Status = status;
            Message = message;
            Players = players;
            categories = cats;
        }
    }
}
