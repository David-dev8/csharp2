using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale.Filters
{
    public class BuyFilter : IItemFilter
    {
        public bool Filter(Item item)
        {
            return item.Payment == Payment.COINS;
        }
    }
}
