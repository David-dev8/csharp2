using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale
{
    public class GameFactory
    {
        // TODO met strings of iets anders?
        public Game CreateGame(string game)
        {
            return game switch
            {
                "QuizRoyale" => new QuizRoyale(new Account("De super fantastische speler", 100, 2300, 150)),
                _ => null,
            };
        }
    }
}
