using Quiz_Royale.Models.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale.Filters
{
    /// <summary>
    /// Deze filter controleert of een bepaald item van het type booster is.
    /// </summary>
    public class BoosterFilter : IItemFilter
    {
        public bool Filter(Item item)
        {
            return item is Booster;
        }
    }
}
