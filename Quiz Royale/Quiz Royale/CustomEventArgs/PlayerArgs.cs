using Quiz_Royale.Models.Games;
using System;

namespace Quiz_Royale.CustomEventArgs
{
    /// <summary>
    /// Deze klasse bevat informatie over wanneer een andere speler het spel joint.
    /// </summary>
    public class PlayerArgs : EventArgs
    {
        public Player Player { get; }

        public string Message { get; }

        /// <summary>
        /// Creëert PlayerArgs met de gegeven waarden.
        /// </summary>
        /// <param name="player">De nieuwe speler.</param>
        /// <param name="message">Een bericht dat de situatie van het spel aangeeft. 
        /// Vaak bevat dit onder andere het aantal spelers dat nog in het spel moet komen voordat het gestart kan worden.</param>
        public PlayerArgs(Player player, string message)
        { 
            Player = player;
            Message = message;
        }
    }
}
