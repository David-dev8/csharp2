using Quiz_Royale.Models.Games;

namespace Quiz_Royale.CustomEventArgs
{
    /// <summary>
    /// Deze klasse bevat informatie voor wanneer een andere speler in een spel een antwoord heeft gegeven.
    /// </summary>
    public class PlayerAnsweredArgs
    {
        public Player Player { get; }

        /// <summary>
        /// Creëert PlayerAnsweredArgs met de gegeven waarden.
        /// </summary>
        /// <param name="player">De speler die geantwoord heeft.</param>
        /// <param name="AnswerTime">De tijd die de speler erover gedaan heeft om te antwoorden.</param>
        public PlayerAnsweredArgs(Player player, double AnswerTime)
        {
            Player = player;
            Player.AnswerTime = AnswerTime;
        }
    }
}
