using Microsoft.Toolkit.Helpers;
using Quiz_Royale.DataAccess.API;
using Quiz_Royale.Filters;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Royale
{
    public class Inventory: Observable
    {

        IInventoryProvider provider;
        IInventoryMutator mutator;
        ItemFactory itemFactory;

        public IList<Item> items 
        {
            get
            {
                return new List<Item> 
                { 
                    itemFactory.MakeItem(1, ItemType.BORDER, "picture", "picture",10, Payment.XP), 
                    itemFactory.MakeItem(1, ItemType.PROFILE_PICTURE, "picture2", "picture2",10, Payment.XP)
                };
            }
        }

        private IInventoryProvider _provider;
        private IInventoryMutator _mutator;
        private NotifyTaskCompletion<IList<Item>> _activeItems;
        private NotifyTaskCompletion<IList<Item>> _allItems;

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
            _allItems = new NotifyTaskCompletion<IList<Item>>(_provider.GetAcquiredItems());
            _activeItems = new NotifyTaskCompletion<IList<Item>>(_provider.GetActiveItems());
        }

        private Item GetItemByType(string type)
        {
            if (_activeItems.Result == null)
            {
                return null;
            }

            var filterFactory = new FilterFactory();
            IItemFilter filter = filterFactory.GetFilter(type);

            foreach(var item in _activeItems.Result)
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
            if (_activeItems.Result == null)
            {
                return null;
            }

            IList<Item> boosters = new List<Item>();
            var filterFactory = new FilterFactory();
            IItemFilter filter = filterFactory.GetFilter("Booster");

            foreach (var item in _activeItems.Result)
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
            return _allItems.Result.Contains(item);
        }
    }
}
