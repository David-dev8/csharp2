using Microsoft.Toolkit.Helpers;
using Quiz_Royale.Base;
using Quiz_Royale.DataAccess;
using Quiz_Royale.DataAccess.API;
using Quiz_Royale.Exceptions;
using Quiz_Royale.Models.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quiz_Royale.Models.Items
{
    /// <summary>
    /// Deze klasse heeft alle fucntionaliteiten van de shop. 
    /// In deze klasse kunnen bijvoorbeeld de items worden gekocht.
    /// </summary>
    public class Shop : Observable
    {
        private IItemProvider _itemProvider;

        public NotifyTaskCompletion<IList<Item>> Items { get; }

        /// <summary>
        /// Creëert een shop waarin items kunnen worden gekocht.
        /// </summary>
        public Shop()
        {
            _itemProvider = new APIItemProvider();
            Items = new NotifyTaskCompletion<IList<Item>>(_itemProvider.GetItems());
        }

        /// <summary>
        /// Als een gebruiker het gegeven item kan kopen, wordt deze aan de inventory van de gebruiker toegevoegd.
        /// Anders wordt er een InsufficientFunds exceptie opgegooid.
        /// </summary>
        /// <param name="account">Het account dat het item wil kopen.</param>
        /// <param name="item">Het item dat wordt geprobeerd te kopen.</param>
        /// <returns></returns>
        /// <exception cref="InsufficientFundsException">Deze exceptie wordt opgegooid wanneer de gebruiker niet voldoende coins of XP heeft.</exception>
        public async Task BuyItem(Account account, Item item)
        {
            if(CanBuy(account, item))
            {
                await account.Inventory.AddItem(item);
                RemoveFunds(account, item);
            }
            else
            {
                throw new InsufficientFundsException();
            }
        }

        /// <summary>
        /// Haalt alle items op die niet meer kunnen worden gekocht.
        /// </summary>
        /// <param name="account">Het account dat items wil kopen.</param>
        /// <returns>Een lijst van de items die niet meer kunnen worden gekocht.</returns>
        public IList<Item> GetItemsOutOfStock(Account account)
        {
            IList<Item> itemsOutOfStock = new List<Item>();
            foreach(Item item in Items.Result)
            {
                if(IsOutOfStock(account, item))
                {
                    itemsOutOfStock.Add(item);
                }
            }
            return itemsOutOfStock;
        }

        // Controleert of het gegeven item al in bezit is van het account en of het item geen booster is.
        private bool IsOutOfStock(Account account, Item item)
        {
            return account.Inventory.HasItem(item);
        }

        // Controleert of het gegeven item kan worden gekocht door de gebruiker.
        private bool CanBuy(Account account, Item item)
        {
            return !IsOutOfStock(account, item) && CanAfford(account, item);
        }

        // Controleert of een gebruiker voldoende XP of coins heeft om het item te kopen.
        private bool CanAfford(Account account, Item item)
        {
            return item.Payment switch
            {
                Payment.XP => account.Level >= item.RequiredAmount,
                Payment.COINS => account.AmountOfCoins >= item.RequiredAmount,
                _ => false
            };
        }

        private void RemoveFunds(Account account, Item item)
        {
            if(item.Payment == Payment.COINS)
            {
                account.AmountOfCoins -= item.RequiredAmount;
            }
        }
    }
}
