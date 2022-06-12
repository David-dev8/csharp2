using Castle.MicroKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale
{
    public class ItemFactory
    {
        public Item MakeItem(int id, ItemType type, string name, string picture, int requiredAmount, Payment payment, 
            string description = "")
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
