using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Quiz_Royale
{
    public abstract class Game
    {
        public Question CurrentQuestion { get; set; }
        public IDictionary<Category, float> Categories { get; set; } // TODO categorie wordt meegegeven aan de question nu, hoe wordt dat gedaan met de float
        public Account Account { get; set; }
        public HubConector HubConector { get; set; }
        public IList<Item> Boosters 
        {
            get
            {
                return Account.Inventory.Boosters;
            }
        }
        public ObservableCollection<Player> FastestPlayers { get; set; }
        // TODO Contentprovider toevoegen
    }
}
