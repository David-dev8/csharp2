using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Royale
{
    /// <summary>
    /// Haalt de items op die in de inventory zitten van de gebruiker.
    /// </summary>
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
