using Quiz_Royale.Models.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale.Filters
{
    /// <summary>
    /// Deze filter controleert of een bepaald item van het type border is.
    /// </summary>
    public class BorderFilter : IItemFilter
    {
        public bool Filter(Item item)
        {
            return item is Border;
        }
    }
}
