using Quiz_Royale.DataAccess.API;
using Quiz_Royale.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
                return new List<Item> { itemFactory.MakeItem("Booster","Booster","picture",10, Payment.XP) };
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
            _mutator = new APIInventoryMutator();
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

        public async Task AddItem(Item item)
        {
            await _mutator.ObtainItem(item);
        }

        public bool HasItem(Item item)
        {
            return true;
        }
    }
}
