using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Royale
{
    public class PlayerAnsweredEventArgs
    {
        public Player Player { get; }

        public PlayerAnsweredEventArgs(Player player, double AnswerTime)
        {
            Player = player;
            Player.AnswerTime = AnswerTime;
        }
    }
}
