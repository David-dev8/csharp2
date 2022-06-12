using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Royale
{
    public abstract class Game : Observable // TODO geen constr?
    {
        private ObservableCollection<Item> _boosters;
        
        public Question CurrentQuestion { get; set; }
        public IDictionary<Category, float> Categories { get; set; } // TODO categorie wordt meegegeven aan de question nu, hoe wordt dat gedaan met de float
        public Account Account { get; set; }
        public HubConnector HubConnector { get; set; }
        public ObservableCollection<Item> Boosters 
        {
            get
            {
                return _boosters;
            }
            set
            {
                _boosters = value;
            }
        }
        public string ResultMessage
        {
            get
            {
                return GetResultMessage();
            }
        }
        public ObservableCollection<Player> FastestPlayers { get; set; }
        public int CurrentPosition { get; set; }

        protected abstract string GetResultMessage();

        public async Task Answer(char answerId)
        {
            await HubConnector.AnswerQuestion(answerId);
        }

        public async Task UseBoost(Item booster)
        {
            await HubConnector.UseBoost(booster.Name, "");
            RemoveBooster(booster);
        }

        private void RemoveBooster(Item booster)
        {
            Boosters.Remove(booster);
        }
    }
}
