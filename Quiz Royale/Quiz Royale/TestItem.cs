using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale
{
    class TestItem : ItemProvider
    {
        private ItemFactory itemFactory;

        public TestItem()
        {
            this.itemFactory = new ItemFactory();
        }

        public IList<Item> GetItems()
        {
            return new List<Item>
            {
                 itemFactory.MakeItem("Booster","Booster","picture",10, Payment.COINS,"10")
            };
        }
    }
}
