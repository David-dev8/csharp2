using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Royale
{
    public class PlayersLeftEventArgs: EventArgs
    {
        public IList<Player> Players { get; }

        public PlayersLeftEventArgs(IList<Player> players)
        {
            Players = players;
        }
    }
}
