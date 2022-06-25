using Quiz_Royale.Models.Items;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quiz_Royale.DataAccess.API
{
    /// <summary>
    /// Haalt alle items op die in de shop kunnen worden gekocht.
    /// </summary>
    public class APIItemProvider : APIProcessor, IItemProvider
    {
        public async Task<IList<Item>> GetItems()
        {
            return await _apiHandler.FetchAll<Item>("/Item/Items");
        }
    }
}
