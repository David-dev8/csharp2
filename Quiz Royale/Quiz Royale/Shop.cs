using Microsoft.Toolkit.Helpers;
using Quiz_Royale.DataAccess;
using Quiz_Royale.DataAccess.API;
using Quiz_Royale.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Royale
{
    public class Shop: Observable
    {
        private IItemProvider _itemProvider;

        public NotifyTaskCompletion<IList<Item>> Items { get; }

        public Shop()
        {
            _itemProvider = new APIItemProvider(); // todo hebben we deze nog nodig als property?
            Items = new NotifyTaskCompletion<IList<Item>>(_itemProvider.GetItems());
        }

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

        private bool IsOutOfStock(Account account, Item item)
        {
            return !(item is Booster) && account.Inventory.HasItem(item);
        }

        private bool CanBuy(Account account, Item item)
        {
            return !IsOutOfStock(account, item) && CanAfford(account, item);
        }

        private bool CanAfford(Account account, Item item)
        {
            return item.Payment switch
            {
                Payment.XP => account.Level >= item.RequiredAmount,
                Payment.COINS => account.AmountOfCoins >= item.RequiredAmount,
                _ => false // todo exception?
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
