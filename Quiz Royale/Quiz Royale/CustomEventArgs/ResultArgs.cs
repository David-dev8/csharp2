using System;

namespace Quiz_Royale.CustomEventArgs
{
    /// <summary>
    /// Deze klasse bevat informatie voor de evaluatie van het antwoord dat is gegeven op een vraag.
    /// </summary>
    public class ResultArgs : EventArgs
    {
        public bool Result { get; }

        public int XP { get; }

        public int Coins { get; }

        /// <summary>
        /// Creëert ResultArgs met de gegeven waarden.
        /// </summary>
        /// <param name="result">Of het gegeven antwoord goed was of niet.</param>
        /// <param name="xp">De xp die verdiend is met het geven van het antwoord.</param>
        /// <param name="coins">De munten die verdiend zijn met het geven van het antwoord.</param>
        public ResultArgs(bool result, int xp, int coins)
        { 
            Result = result;
            XP = xp;
            Coins = coins;
        }
    }
}
