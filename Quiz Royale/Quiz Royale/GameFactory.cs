using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale
{
    public class GameFactory
    {
        // TODO met strings of iets anders?
        public Game CreateGame(Mode mode, Account account)
        {
            return mode switch
            {
                Mode.QUIZ_ROYALE => new QuizRoyale(account),
                _ => null // todo
            };
        }
    }
}
