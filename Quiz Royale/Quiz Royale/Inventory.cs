using Quiz_Royale.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale
{
    public class Inventory
    {

        IInventoryProvider provider;
        IInventoryMutator mutator;
        ItemFactory itemFactory;

        public IList<Item> items 
        {
            get
            {
                return new List<Item> { itemFactory.MakeItem("Booster","Booster","picture","10") };
            }
        }

        private IInventoryProvider _provider;
        private IInventoryMutator _mutator;

        public Item ActiveProfilePicture
        {
            get
            {
                return GetItemByType("ProfilePicture");
            }
        }

        public Item ActivePlayerTitle
        {
            get
            {
                return GetItemByType("Title");
            }
        }

        public Item ActiveBorder
        {
            get
            {
                return GetItemByType("Border");
            }
        }

        public IList<Item> Boosters
        {
            get
            {
                return GetBoosters();
            }
        }

        public Inventory()
        {
            _provider = new APIInventoryProvider();
            // TODO ook mutator
        }

        private Item GetItemByType(string type)
        {
            var filterFactory = new FilterFactory();
            IItemFilter filter = filterFactory.GetFilter(type);

            foreach(var item in _provider.GetActivateItems())
            {
                if(filter.Filter(item))
                {
                    return item;
                }
            }
            return null;
        }

        private IList<Item> GetBoosters()
        {
            IList<Item> boosters = new List<Item>();
            var filterFactory = new FilterFactory();
            IItemFilter filter = filterFactory.GetFilter("Booster");

            foreach (var item in _provider.GetActivateItems())
            {
                if (filter.Filter(item))
                {
                    boosters.Add(item);
                }
            }
            return boosters;
        }

        public void EquipItem(Item item)
        {
                
        }

        public void AddItem(Item item)
        {

        }
    }
}
