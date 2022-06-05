using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale.Filters
{
    public class TitleFilter : IItemFilter
    {
        public bool Filter(Item item)
        {
            return item is PlayerTitle;
        }
    }
}
