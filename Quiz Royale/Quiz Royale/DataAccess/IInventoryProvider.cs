using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Royale
{
    /// <summary>
    /// Deze interface geeft de verplichte methodes aan om de juiste implementatie van een inventory provider te maken.
    /// </summary>
    public interface IInventoryProvider
    {
        public Task<IList<Item>> GetAcquiredItems();
        public Task<IList<Item>> GetActiveItems();
    }
}
