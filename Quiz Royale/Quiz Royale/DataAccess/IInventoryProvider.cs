using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale
{
    public interface IInventoryProvider
    {
        public IList<Item> GetAcquiredItems();
        public IList<Item> GetActivateItems();
    }
}
