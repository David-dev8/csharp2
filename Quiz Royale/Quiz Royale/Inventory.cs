using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale
{
    public class Inventory
    {
        IInventoryProvider _provider;
        IInventoryMutator _mutator;

        public IList<Booster> GetBoosters()
        {
            return null;
        }

        public void EquipItem(Item item)
        {
                
        }

        public void AddItem(Item item)
        {

        }
    }
}
