using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale.Models.Items
{
    /// <summary>
    /// Deze klasse vertegenwoordigt een border die de gebruiker kan kopen in de shop.
    /// </summary>
    public class Border : Item
    {
        /// <summary>
        /// Creëert een border die de gebruiker kan kopen en gebruiken.
        /// </summary>
        /// <param name="id">Het id van de border.</param>
        /// <param name="name">De naam van de border.</param>
        /// <param name="picture">De afbeelding van de border.</param>
        /// <param name="requiredAmount">De hoeveelheid XP of coins dat nodig is om de border te kopen.</param>
        /// <param name="payment">De betaalwijze om de border te kopen.</param>
        public Border(int id, string name, string picture, int requiredAmount, Payment payment)
            : base(id, name, picture, requiredAmount, payment)
        {
        }
    }
}
