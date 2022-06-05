using Quiz_Royale.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale
{
    public class Inventory
    {
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

        public Inventory()
        {
            _provider = new APIInventoryProvider();
            // TODO ook mutator
        }

        public Item GetItemByType(string type)
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

        public IList<Booster> GetBoosters()
        {
            return null;
        }

        public void EquipItem(Item item)
        {
                
        }

        public void AddItem(Item item)
        {

        }
    }
}
