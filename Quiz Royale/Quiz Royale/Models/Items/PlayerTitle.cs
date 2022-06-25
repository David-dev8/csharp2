namespace Quiz_Royale.Models.Items
{
    /// <summary>
    /// Deze klasse vertegenwoordigt de spelerstitel van de gebruiker.
    /// </summary>
    public class PlayerTitle : Item
    {
        /// <summary>
        /// Creëert een spelerstitel die gebruiker kan kopen en gebruiken.
        /// </summary>
        /// <param name="id">Het id van de spelerstitel.</param>
        /// <param name="name">De spelerstitel.</param>
        /// <param name="picture">De afbeelding van de spelerstitel.</param>
        /// <param name="requiredAmount">De hoeveelheid XP of coins die nodig is om de titel te kopen.</param>
        /// <param name="payment">De betaalwijze om de titel te kopen.</param>
        public PlayerTitle(int id, string name, string picture, int requiredAmount, Payment payment)
            : base(id, name, picture, requiredAmount, payment)
        {
        }
    }
}
