using Quiz_Royale.Models.Items;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quiz_Royale.DataAccess
{
    /// <summary>
    /// Deze interface geeft de verplichte methodes aan om de juiste implementatie van een item provider te maken.
    /// </summary>
    public interface IItemProvider
    {
        /// <summary>
        /// Haalt alle items op die in de applicatie kunnen worden gebruikt.
        /// </summary>
        /// <returns>Eeen lijst van alle items.</returns>
        public Task<IList<Item>> GetItems();
    }
}
