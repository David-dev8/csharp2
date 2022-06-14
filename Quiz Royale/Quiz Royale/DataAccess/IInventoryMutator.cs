using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Royale
{

    /// <summary>
    /// Deze interface geeft de verplichte methodes aan om de juiste implementatie van een inventory mutator te maken.
    /// </summary>
    public interface IInventoryMutator
    {
        /// <summary>
        /// Het selecteren van een bepaald item en deze actief maken.
        /// </summary>
        /// <param name="item">Het geselecteerde item.</param>
        /// <returns>De task van de bijbehorende actie.</returns>
        public Task EquipItem(Item item);

        /// <summary>
        /// Het selecteren van een bepaald item en deze proberen te verkrijgen.
        /// </summary>
        /// <param name="item">Het geselecteerde item.</param>
        /// <returns>De task van de bijbehorende actie.</returns>
        public Task ObtainItem(Item item);
    }
}
