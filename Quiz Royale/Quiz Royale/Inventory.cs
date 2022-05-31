using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale
{
    class Inventory
    {
        IInventoryProvider provider;
        IInventoryMutator mutator;
        ItemFactory itemFactory;

        public IList<Item> items 
        {
            get
            {
                return new List<Item> { itemFactory.MakeItem("Booster","Booster","picture","10") };
            }
        }

        public IList<Booster> getBoosters()
        {
            return null;
        }

        public void equipItem(Item item)
        {
                
        }

        public void addItem(Item item)
        {

        }
    }
}
