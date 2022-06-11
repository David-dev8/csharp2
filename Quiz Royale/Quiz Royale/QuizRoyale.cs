using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Quiz_Royale
{
    public class QuizRoyale : Game
    {
        private IList<Player> _players;

        public IList<Player> Players
        {
            get
            {
                return _players.Take(10).ToList(); // TODO doe dit ook met de results van home
            }
            set
            {
                _players = value;
            }
        }

        public int CurrentAmountOfPlayers 
        {
            get
            {
                return _players.Count;
            }
        }

        public int TotalAmountOfPlayersStarted { get; set; }

        public QuizRoyale(Account account)
        {
            Account = account;
            FastestPlayers = new ObservableCollection<Player>();
            Players = new List<Player>();
            TotalAmountOfPlayersStarted = _players.Count;
            CurrentQuestion = null;
            Categories = new Dictionary<Category, float>();

            HubConector = new HubConector();
        }
    }
}
