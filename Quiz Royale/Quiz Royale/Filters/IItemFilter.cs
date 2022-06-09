using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale.Filters
{
    public interface IItemFilter
    {
        bool Filter(Item item);
    }
}
