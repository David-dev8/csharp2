using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Royale
{
    public class WinArgs: EventArgs
    { 
        public int XP { get; }

        public int Coins { get; }

        public WinArgs(int xp, int coins)
        {
            XP = xp;
            Coins = coins;
        }
    }
}
