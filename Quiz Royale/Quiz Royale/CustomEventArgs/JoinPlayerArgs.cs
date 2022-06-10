using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Royale
{
    public class JoinPlayerArgs : EventArgs
    {
        public Player Player { get; }

        public JoinPlayerArgs(Player player)
        { 
            Player = player;
        }
    }
}
