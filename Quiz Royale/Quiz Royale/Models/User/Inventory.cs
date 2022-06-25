using Microsoft.Toolkit.Helpers;
using Quiz_Royale.Base;
using Quiz_Royale.DataAccess;
using Quiz_Royale.DataAccess.API;
using Quiz_Royale.Filters;
using Quiz_Royale.Models.Items;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quiz_Royale.Models.User
{
    /// <summary>
    /// Deze klasse vertegenwoordigt de inventory van een gebruiker.
    /// </summary>
    public class Inventory : Observable
    {
        private IInventoryProvider _provider;
        private IInventoryMutator _mutator;

        private NotifyTaskCompletion<IList<Item>> _activeItems { get; set; }

        public NotifyTaskCompletion<IList<Item>> ActiveItems
        {
            get
            {
                return _activeItems;
            }
            set
            {
                _activeItems = value;
                OnPropertyChanged();
            }
        }
        private NotifyTaskCompletion<IList<Item>> _allItems { get; set; }

        public NotifyTaskCompletion<IList<Item>> AllItems
        {
            get
            {
                return _allItems;
            }
            set
            {
                _allItems = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Deze property geeft toegang tot de actieve profielfoto van de gebruiker.
        /// </summary>
        public Item ActiveProfilePicture
        {
            get
            {
                return GetItemByType("ProfilePicture");
            }
        }

        /// <summary>
        /// Deze property geeft toegang tot de actieve spelerstitel van de gebruiker.
        /// </summary>
        public Item ActivePlayerTitle
        {
            get
            {
                return GetItemByType("Title");
            }
        }

        /// <summary>
        /// Deze property geeft toegang tot de actieve border van de gebruiker.
        /// </summary>
        public Item ActiveBorder
        {
            get
            {
                return GetItemByType("Border");
            }
        }

        /// <summary>
        /// Deze property geeft toegang tot alle boosters van de gebruiker.
        /// </summary>
        public IList<Item> Boosters
        {
            get
            {
                return GetBoosters();
            }
        }

        /// <summary>
        /// Creëert een inventory voor de gebruiker.
        /// </summary>
        public Inventory()
        {
            _provider = new APIInventoryProvider();
            _mutator = new APIInventoryMutator();
            AllItems = new NotifyTaskCompletion<IList<Item>>(_provider.GetAcquiredItems());
            AllItems.PropertyChanged += AllItems_PropertyChanged;
            ActiveItems = new NotifyTaskCompletion<IList<Item>>(_provider.GetActiveItems());
        }

        // Haalt het actieve item op van het type dat wordt meegegeven.
        private Item GetItemByType(string type)
        {
            if(ActiveItems.Result == null)
            {
                return null;
            }

            var filterFactory = new FilterFactory();
            IItemFilter filter = filterFactory.GetFilter(type);

            foreach(var item in ActiveItems.Result)
            {
                if(filter.Filter(item))
                {
                    return item;
                }
            }
            return null;
        }

        // Haalt alle boosters op die de gebruiker heeft.
        private IList<Item> GetBoosters()
        {
            if(ActiveItems.Result == null)
            {
                return null;
            }

            IList<Item> boosters = new List<Item>();
            var filterFactory = new FilterFactory();
            IItemFilter filter = filterFactory.GetFilter("Booster");

            foreach(var item in ActiveItems.Result)
            {
                if(filter.Filter(item))
                {
                    boosters.Add(item);
                }
            }
            return boosters;
        }

        /// <summary>
        /// Selecteert het gegeven item en maakt deze actief.
        /// </summary>
        /// <param name="item">Het geselecteerde item.</param>
        public async Task EquipItem(Item item)
        {
            await _mutator.EquipItem(item);
            ActiveItems = new NotifyTaskCompletion<IList<Item>>(_provider.GetActiveItems());
            ActiveItems.PropertyChanged += ActiveItems_PropertyChanged;
        }

        private void ActiveItems_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            OnPropertyChanged(nameof(ActiveItems));
            OnPropertyChanged(nameof(ActiveBorder));
            OnPropertyChanged(nameof(ActivePlayerTitle));
            OnPropertyChanged(nameof(ActiveProfilePicture));
        }

        /// <summary>
        /// Voegt een item toe aan de inventory.
        /// </summary>
        /// <param name="item">Het item dat moet worden toegevoegd.</param>
        /// <returns></returns>
        public async Task AddItem(Item item)
        {
            await _mutator.ObtainItem(item);
            AllItems = new NotifyTaskCompletion<IList<Item>>(_provider.GetAcquiredItems());
            AllItems.PropertyChanged += AllItems_PropertyChanged;
        }

        public void RemoveItem(Item item)
        {
            AllItems.Result.Remove(item);
            ActiveItems.Result.Remove(item);
        }

        private void AllItems_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            OnPropertyChanged(nameof(AllItems));
        }

        /// <summary>
        /// Controleert of de gebruiker het item al in bezit heeft.
        /// </summary>
        /// <param name="item">Het item waarop moet worden gecontroleerd.</param>
        /// <returns>True als de gebruiker het item al heeft, anders false.</returns>
        public bool HasItem(Item item)
        {
            return AllItems.Result.Contains(item);
        }
    }
}
