using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Royale.DataAccess.API
{
    /// <summary>
    /// Deze klasse bewerkt de inventory van een gebruiker.
    /// Items kunnen worden toegevoegd en geselecteerd.
    /// </summary>
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
