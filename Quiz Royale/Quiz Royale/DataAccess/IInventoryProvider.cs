using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Royale
{
    public interface IInventoryProvider
    {
        public Task<IList<Item>> GetAcquiredItems();
        public Task<IList<Item>> GetActiveItems();
    }
}
