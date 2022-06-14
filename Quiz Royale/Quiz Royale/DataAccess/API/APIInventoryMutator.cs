using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Royale.DataAccess.API
{
    public class APIInventoryMutator : APIProcessor, IInventoryMutator
    {
        public async Task EquipItem(Item item)
        {
            await _apiHandler.Update("/Item/Equip", item.Id);
        }

        public async Task ObtainItem(Item item)
        {
            await _apiHandler.Update("/Item/Obtain", item.Id);
        }
    }
}
