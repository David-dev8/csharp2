using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale
{
    public class Inventory
    {
        IInventoryProvider provider;
        IInventoryMutator mutator;

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
