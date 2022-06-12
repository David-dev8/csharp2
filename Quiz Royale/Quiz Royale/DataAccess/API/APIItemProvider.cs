using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Royale.DataAccess.API
{
    public class APIItemProvider : APIProcessor, IItemProvider
    {
        public async Task<IList<Item>> GetItems()
        {
            return await _apiHandler.FetchAll<Item>("/Item/Items");
        }
    }
}
