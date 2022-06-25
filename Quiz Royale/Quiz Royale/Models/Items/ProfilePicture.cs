using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale.Models.Items
{
    /// <summary>
    /// Deze klasse vertegenwoordigt een profielfoto die de gebruiker kan kopen in de shop.
    /// </summary>
    public class ProfilePicture : Item 
    {
        /// <summary>
        /// Creëert een profielfoto die de gebruiker kan kopen en gebruiken.
        /// </summary>
        /// <param name="id">Het id van de profielfoto.</param>
        /// <param name="name">De naam van de profielfoto.</param>
        /// <param name="picture">De afbeelding van de profielfoto.</param>
        /// <param name="requiredAmount">De hoeveelheid XP of coins dat nodig is om de profielfoto te kopen.</param>
        /// <param name="payment">De betaalwijze om de profielfoto te kopen.</param>
        public ProfilePicture(int id, string name, string picture, int requiredAmount, Payment payment)
            : base(id, name, picture, requiredAmount, payment) {

        }
    }
}
