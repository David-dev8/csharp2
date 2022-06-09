using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale
{
    public class APIInventoryProvider : IInventoryProvider
    {
        public IList<Item> GetAcquiredItems()
        {
            throw new NotImplementedException();
        }

        public IList<Item> GetActivateItems()
        {
            var itemFactory = new ItemFactory();
            return new List<Item> 
            {
                itemFactory.MakeItem("ProfilePicture", "A nice picture", "/Assets/testProfilePicture.png", 0, Payment.XP),
                itemFactory.MakeItem("Border", "A nice border", "/Assets/testBorder.png", 0, Payment.COINS),
                itemFactory.MakeItem("PlayerTitle", "True Champion Of All Time", "/Assets/testBorder.png", 0, Payment.COINS),
                itemFactory.MakeItem("Border", "A nice border", "/Assets/testBorder.png", 0, Payment.COINS),
                itemFactory.MakeItem("Booster", "50/50", "/Assets/testBoost.png", 0, Payment.COINS, "Remove 2 of the 4 answers", 1),
                itemFactory.MakeItem("Booster", "50/50", "/Assets/testBoost.png", 0, Payment.COINS, "Remove 2 of the 4 answers", 1),
                itemFactory.MakeItem("Booster", "50/50", "/Assets/testBoost.png", 0, Payment.COINS, "Remove 2 of the 4 answers", 1),
                itemFactory.MakeItem("Booster", "50/50", "/Assets/testBoost.png", 0, Payment.COINS, "Remove 2 of the 4 answers", 1),
                itemFactory.MakeItem("Booster", "50/50", "/Assets/testBoost.png", 0, Payment.COINS, "Remove 2 of the 4 answers", 1),
            };

        }
    }
}
