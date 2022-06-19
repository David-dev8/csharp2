using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Royale.CustomEventArgs
{
    /// <summary>
    /// Deze klasse bevat informatie over wanneer er eventueel spelers geëlimineerd zijn.
    /// </summary>
    public class PlayersLeftArgs: EventArgs
    {
        public IList<Player> Players { get; }

        /// <summary>
        /// Creëert PlayersLeftArgs met de gegeven spelers.
        /// </summary>
        /// <param name="players">Een lijst van spelers die nog in het spel zitten.</param>
        public PlayersLeftArgs(IList<Player> players)
        {
            Players = players;
        }
    }
}
