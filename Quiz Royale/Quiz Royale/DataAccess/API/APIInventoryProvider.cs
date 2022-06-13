using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Royale
{
    public class APIInventoryProvider : APIProcessor, IInventoryProvider
    {
        public Task<IList<Item>> GetAcquiredItems()
        {
            return _apiHandler.FetchAll<Item>("/Item/Inventory");
        }

        public Task<IList<Item>> GetActiveItems()
        {
            return _apiHandler.FetchAll<Item>("Item/ActiveItems");
        }
    }
}
