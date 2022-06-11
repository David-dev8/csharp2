using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Royale
{
    public class PlayerArgs : EventArgs
    {
        public Player Player { get; }
        public string Message { get; }

        public PlayerArgs(Player player, string message)
        { 
            Player = player;
            Message = message;
        }
    }
}
