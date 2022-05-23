using Castle.MicroKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale
{
    class ItemFactory
    {
        public Item MakeItem(string type, params object[] arguments)
        {
            switch (type)
            {
                case "booster":
                    return new Booster("d");
                    break;

     
                default:
                    return new Booster("a");
                    break;
            }
        }
    }
}
