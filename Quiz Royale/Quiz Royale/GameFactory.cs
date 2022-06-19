using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale
{
    /// <summary>
    /// Deze klasse zorgt ervoor dat er verschillende gamemodi kunnen worden gemaakt.
    /// </summary>
    public class GameFactory
    {
        /// <summary>
        /// Maakt een game van het gegeven type met het gegeven account.
        /// </summary>
        /// <param name="mode">De modus van de game.</param>
        /// <param name="account">Het account dat meedoet aan het spel.</param>
        /// <returns></returns>
        public Game CreateGame(Mode mode, Account account)
        {
            return mode switch
            {
                Mode.QUIZ_ROYALE => new QuizRoyale(account),
                _ => null
            };
        }
    }
}
