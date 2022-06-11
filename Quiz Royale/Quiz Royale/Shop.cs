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
            }
            else
            {
                throw new InsufficientFundsException();
            }
        }

        public bool CanBuy(Account account, Item item)
        {
            return item.Payment switch
            {
                Payment.XP => account.Level >= item.RequiredAmount,
                Payment.COINS => account.AmountOfCoins >= item.RequiredAmount,
                _ => false // todo exception?
            };
        }
    }
}
