using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale
{
    public abstract class Item
    {
        public string Name { get; set; }
        public string Picture { get; set; }
        public int RequiredAmount { get; set; }
        //public Payment Payment { get; set; }
    }
}
