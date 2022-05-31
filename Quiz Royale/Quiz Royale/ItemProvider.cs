using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale
{
    interface ItemProvider
    {
        IList<Item> GetItems();
    }
}
