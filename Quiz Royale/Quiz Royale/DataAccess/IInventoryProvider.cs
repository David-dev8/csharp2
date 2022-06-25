using Quiz_Royale.Models.Items;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quiz_Royale.DataAccess
{
    /// <summary>
    /// Deze interface geeft de verplichte methodes aan om de juiste implementatie van een inventory provider te maken.
    /// </summary>
    public interface IInventoryProvider
    {
        /// <summary>
        /// Haalt alle items op die de gebruiker in zijn bezit heeft.
        /// </summary>
        /// <returns>Een lijst van de items die de gebruiker in zijn bezit heeft.</returns>
        public Task<IList<Item>> GetAcquiredItems();

        /// <summary>
        /// Haalt alle actieve items op die de gebruiker heeft geselecteerd.
        /// </summary>
        /// <returns>Een lijst van de actieve items.</returns>
        public Task<IList<Item>> GetActiveItems();
    }
}
