using Castle.MicroKernel;
using Quiz_Royale.Models.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale.Models.Factories
{
    /// <summary>
    /// Deze klasse levert de functionaliteit om verschillende items te maken.
    /// </summary>
    public class ItemFactory
    {
        /// <summary>
        /// Creëert een bepaalt item met de gegeven eigenschappen.
        /// </summary>
        /// <param name="id">Het id van het item.</param>
        /// <param name="type">Het type van het item.</param>
        /// <param name="name">De naam van het item.</param>
        /// <param name="picture">De afbeelding van het item.</param>
        /// <param name="requiredAmount">De vereiste hoeveelheid XP of coins dat nodig is om het item te kopen.</param>
        /// <param name="payment">De betaalwijze van het item.</param>
        /// <param name="description">De beschrijving van het item.</param>
        /// <returns>Het item met de gegeven eigenschappen.</returns>
        public Item MakeItem(int id, ItemType type, string name, string picture, int requiredAmount, Payment payment, string description = "")
        {
            return type switch
            {
                ItemType.BOOST => new Booster(id, name, picture, requiredAmount, payment, description),
                ItemType.TITLE => new PlayerTitle(id, name, picture, requiredAmount, payment),
                ItemType.PROFILE_PICTURE => new ProfilePicture(id, name, picture, requiredAmount, payment),
                ItemType.BORDER => new Border(id, name, picture, requiredAmount, payment),
                _ => null,
            };
        }
    }
}
