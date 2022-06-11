using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Royale
{
    public class JoinStatusArgs : EventArgs
    {
        public bool Status { get; }
        public string Message { get; }
        public IList<Player> Players { get; }
        public IList<CategoryMastery> categories { get; }

        public JoinStatusArgs(bool status, string message, IList<Player> players, IList<CategoryMastery> cats)
        { 
            Status = status;
            Message = message;
            Players = players;
            categories = cats;
        }
    }
}
