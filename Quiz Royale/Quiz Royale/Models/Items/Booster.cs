namespace Quiz_Royale.Models.Items
{
    /// <summary>
    /// Deze klasse vertegenwoordigt een booster die de gebruiker kan kopen in de shop.
    /// </summary>
    public class Booster : Item
    {
        public string Description { get; set; }

        /// <summary>
        /// Creëert een booster die de gebruiker kan kopen en gebruiken.
        /// </summary>
        /// <param name="id">Het id van de booster.</param>
        /// <param name="name">De naam van de booster.</param>
        /// <param name="picture">De afbeelding van de booster.</param>
        /// <param name="requiredAmount">De hoeveelheid XP of coins dat nodig is om de booster te kopen.</param>
        /// <param name="payment">De betaalwijze om de booster te kopen.</param>
        /// <param name="description">De beschrijving van de booster.</param>
        public Booster(int id, string name, string picture, int requiredAmount, Payment payment, string description)
            : base(id, name, picture, requiredAmount, payment)
        {
            Description = description;
        }
    }
}
