using Microsoft.Toolkit.Helpers;
using Quiz_Royale.Base;
using Quiz_Royale.DataAccess;
using Quiz_Royale.DataAccess.API;
using Quiz_Royale.Models;
using Quiz_Royale.Models.Items;
using Quiz_Royale.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Quiz_Royale.ViewModels
{
    /// <summary>
    /// Deze klasse dient als ViewModel voor het profiel van de gebruiker. 
    /// </summary>
    public class ProfileViewModel : ItemShowerViewModel
    {
        private IAccountDataProvider _accountDataProvider;

        public NotifyTaskCompletion<IList<CategoryIntensity>> Mastery { get; set; }

        public NotifyTaskCompletion<IList<Badge>> Badges { get; set; }

        public NotifyTaskCompletion<Account> Account { get; set; }

        /// <summary>
        /// Creëert een ProfielViewModel met een gegeven navigationStore.
        /// </summary>
        /// <param name="navigationStore">De navigationStore die wordt gebruikt voor navigatie.</param>
        public ProfileViewModel(NavigationStore navigationStore) : base(navigationStore)
        {
            _accountDataProvider = new APIAccountDataProvider();
            _accountProvider = new APIAccountProvider();

            Mastery = new NotifyTaskCompletion<IList<CategoryIntensity>>(_accountDataProvider.GetCategoryMastery());
            Badges = new NotifyTaskCompletion<IList<Badge>>(_accountDataProvider.GetBadges());
            Account = new NotifyTaskCompletion<Account>(_accountProvider.GetAccount());

            Account.Result.Inventory.PropertyChanged += Inventory_PropertyChanged;

            ShowInventory();
        }

        // Registreer de geëquipte items van de gebruikers als ze (weer) opnieuw geladen
        private void Inventory_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(((Inventory) sender).ActiveItems.IsSuccessfullyCompleted)
            {
                EquippedItems = Account.Result.Inventory.ActiveItems.Result;
            }
        }

        // Sla alle items en de geëquipte items op, mochten deze geladen zijn.
        // Door niet direct alle items van de inventory te binden, kan nog gefilterd worden.
        private void ShowInventory()
        {
            _allItems = Account.Result?.Inventory.AllItems?.Result;
            FilterBorders();
            _equippedItems = Account.Result?.Inventory.ActiveItems?.Result;
        }


        private IList<Item> _equippedItems;

        /// <summary>
        /// Deze property geeft toegang tot de geëquipte items van een gebruiker.
        /// Als er een item wordt geselecteerd zal deze voor de gebruiker worden geëquipt.
        /// </summary>
        public IList<Item> EquippedItems
        {
            get
            {
                return Account.Result.Inventory.ActiveItems.Result;
            }
            set
            {
                Item newItem = GetNewItem(value);
                if(newItem != null)
                {
                    Account.Result.Inventory.EquipItem(newItem);
                }
                else
                {
                    _equippedItems = value;
                }
                OnPropertyChanged();
            }
        }

        // Controleert of een gegeven lijst van items een element bevat dat nog niet geregistreerd is als geëquipt en dus nieuw is.
        // Als dit het geval is, geeft deze methode dit nieuwe item terug, anders null.
        private Item GetNewItem(IList<Item> newItems)
        {
            if(newItems.Count == 0)
            {
                return null;
            }
            if(EquippedItems == null)
            {
                return newItems[0];
            }    
            return newItems.Where(i => !EquippedItems.Contains(i)).SingleOrDefault();
        }
    }
}