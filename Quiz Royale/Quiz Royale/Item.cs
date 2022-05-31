using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale
{
    abstract class Item
    {
        public string Name { get; set; }
        public string Picture { get; set; }
        public string RequiredAmount { get; set; }
        //public Payment Payment { get; set; }
    }
}
