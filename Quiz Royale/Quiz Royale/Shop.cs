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

        private IList<Item> _items;

        public IList<Item> Items 
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
                OnPropertyChanged();
            }
        }

        public Shop()
        {
            _itemProvider = new APIItemProvider(); // todo hebben we deze nog nodig als property?
            LoadData();
        }

        private async Task LoadData()
        {
            try
            {
                var t = await _itemProvider.GetItems();
            }
            catch(Exception ex)
            {
                Console.WriteLine("mmm");
            }
            _items = null;
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
            return true; // todo implement
        }
    }
}
