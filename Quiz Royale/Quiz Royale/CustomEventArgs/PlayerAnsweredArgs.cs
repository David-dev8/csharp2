using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Royale
{
    public class PlayerAnsweredArgs
    {
        public Player Player { get; }

        public PlayerAnsweredArgs(Player player, double AnswerTime)
        {
            Player = player;
            Player.AnswerTime = AnswerTime;
        }
    }
}
