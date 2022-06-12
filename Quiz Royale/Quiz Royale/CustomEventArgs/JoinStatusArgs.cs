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
        public Player[] Players { get; }
        IDictionary<Category, float> categories { get; }

        public JoinStatusArgs(bool status, string message, Player[] players, IDictionary<Category, float> cats)
        { 
            Status = status;
            Message = message;
            Players = players;
            categories = cats;
        }
    }
}
