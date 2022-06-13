using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Royale
{
    public abstract class Game : Observable // TODO geen constr?
    {
        private ObservableCollection<Item> _boosters;
        protected HubConnector _connector;

        public Question CurrentQuestion { get; set; }
        public IList<CategoryMastery> Chances { get; set; } // TODO categorie wordt meegegeven aan de question nu, hoe wordt dat gedaan met de float
        public Account Account { get; set; }
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

        public CategoryMastery CurrentCategory
        {
            get
            {
                if(CurrentQuestion == null)
                {
                    return null;
                }

                return Chances.Where(c => c.Category.Equals(CurrentQuestion.Category)).SingleOrDefault(); // todo
            }
        }


        private State _state;

        public State State
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
                OnPropertyChanged();
            }
        }


        private string _statusMessage;

        public string StatusMessage
        {
            get
            {
                return _statusMessage;
            }
            set
            {
                _statusMessage = value;
                OnPropertyChanged();
            }
        }

        protected abstract string GetResultMessage();

        public async Task Answer(Answer answer)
        {
            await _connector.AnswerQuestion(answer.Code);
        }

        public async Task UseBoost(Item booster)
        {
            await _connector.UseBoost(booster.Name, ""); // todo
            RemoveBooster(booster);
        }

        private void RemoveBooster(Item booster)
        {
            Boosters.Remove(booster);
        }

        public void Dispose()
        {
            if(_connector != null)
            {
                _connector.Leave();
                _connector.BreakConection();
            }
        }
    }

    public enum State
    {
        WAITING,
        JOINED,
        QUESTION,
        NEXT_CATEGORY,
        ENDED
    }
}
