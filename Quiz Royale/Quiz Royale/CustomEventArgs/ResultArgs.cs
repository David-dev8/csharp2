using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Royale
{
    public class ResultArgs : EventArgs
    {
        public bool Result { get; }

        public int XP { get; }

        public int Coins { get; }

        public ResultArgs(bool result, int xp, int coins)
        { 
            Result = result;
            XP = xp;
            Coins = coins;
        }
    }
}
