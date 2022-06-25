using System;

namespace Quiz_Royale.CustomEventArgs
{
    /// <summary>
    /// Deze klasse bevat informatie voor wanneer een speler een spel gewonnen heeft.
    /// </summary>
    public class WinArgs : EventArgs
    {
        public int XP { get; }

        public int Coins { get; }

        /// <summary>
        /// Creëert WinArgs met de gegeven waarden.
        /// </summary>
        /// <param name="xp">De xp die verdiend is met het winnen van het spel.</param>
        /// <param name="coins">De munten die verdiend zijn met het winnen van het spel.</param>
        public WinArgs(int xp, int coins)
        {
            XP = xp;
            Coins = coins;
        }
    }
}
