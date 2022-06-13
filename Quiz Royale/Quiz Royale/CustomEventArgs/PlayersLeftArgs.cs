using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Royale
{
    public class PlayersLeftArgs: EventArgs
    {
        public IList<Player> Players { get; }

        public PlayersLeftArgs(IList<Player> players)
        {
            Players = players;
        }
    }
}
