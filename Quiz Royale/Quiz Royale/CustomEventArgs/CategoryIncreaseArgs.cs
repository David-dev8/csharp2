using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Royale.CustomEventArgs
{
    /// <summary>
    /// Deze klasse bevat informatie voor wanneer de kans op een categorie wordt verhoogd.
    /// </summary>
    public class CategoryIncreaseArgs : EventArgs
    {
        public string CatId { get; }

        /// <summary>
        /// Creërt CategoryIncreaseArgs met het gegeven categorie id.
        /// </summary>
        /// <param name="catId">Het id van de categorie waarvan de kans is verhoogt.</param>
        public CategoryIncreaseArgs(string catId)
        {
            CatId = catId;
        }
    }
}
