using Quiz_Royale.Base;
using Quiz_Royale.DataAccess.Hub;
using Quiz_Royale.Models.Items;
using Quiz_Royale.Models.User;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz_Royale.Models.Games
{
    /// <summary>
    /// Deze klasse vertegenwoordigt de basis van een game in de applicatie.
    /// </summary>
    public abstract class Game : Observable
    {
        private ObservableCollection<Item> _boosters;
        protected HubConnector _connector;
        private State _state;
        private string _statusMessage;

        public Question CurrentQuestion { get; set; }

        public IList<CategoryIntensity> Chances { get; set; }

        public Account Account { get; set; }

        /// <summary>
        /// Deze property geeft toegang tot de boosters die kunnen worden gebruikt in de game.
        /// </summary>
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

        /// <summary>
        /// Deze property geeft toegang tot het bericht dat is gebaseerd op het resultaat van de gebruiker.
        /// </summary>
        public string ResultMessage
        {
            get
            {
                return GetResultMessage();
            }
        }

        public ObservableCollection<Player> FastestPlayers { get; set; }

        public int CurrentPosition { get; set; }

        /// <summary>
        /// Deze property geeft toegang tot de huidige categorie in het spel.
        /// </summary>
        public CategoryIntensity CurrentCategory
        {
            get
            {
                if(CurrentQuestion == null)
                {
                    return null;
                }

                return Chances.Where(c => c.Category.Equals(CurrentQuestion.Category)).SingleOrDefault();
            }
        }

        /// <summary>
        /// Deze property geeft toegang tot de staat van een game.
        /// </summary>
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

        /// <summary>
        /// Deze property geeft toegang tot het huidge statusbericht.
        /// </summary>
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

        /// <summary>
        /// Haalt het bericht op dat is gebaseerd op het resultaat van de gebruiker.
        /// </summary>
        /// <returns>Het resultaatbericht.</returns>
        protected abstract string GetResultMessage();

        /// <summary>
        /// Antwoordt op de huidige vraag.
        /// </summary>
        /// <param name="answer">Het antwoord dat is gekozen door de gebruiker.</param>
        /// <returns></returns>
        public async Task Answer(Answer answer)
        {
            await _connector.AnswerQuestion(answer.Code);
        }

        /// <summary>
        /// Gebruikt een booster en verwijdert deze uit de actieve boosters in een spel.
        /// </summary>
        /// <param name="booster">De geselecteerde booster.</param>
        /// <returns></returns>
        public async Task UseBoost(Item booster)
        {
            if(booster.Name == "Category increase")
            {
                await _connector.UseBoost(booster.Name, CurrentQuestion.Category.Name);
            }
            else
            {
                await _connector.UseBoost(booster.Name, "");
            }
            RemoveBooster(booster);
            Account.Inventory.RemoveItem(booster);
        }

        // Verwijder een booster uit de lijst in de game.
        private void RemoveBooster(Item booster)
        {
            Boosters.Remove(booster);
        }

        // Verlaat de game.
        public void Dispose()
        {
            if(_connector != null)
            {
                _connector.Leave();
                _connector.BreakConection();
            }
        }
    }

    /// <summary>
    /// Deze enum vertegenwoordigt de verschillende staten waarin de game zich kan bevinden.
    /// </summary>
    public enum State
    {
        WAITING,
        JOINED,
        QUESTION,
        NEXT_CATEGORY,
        ENDED
    }
}
