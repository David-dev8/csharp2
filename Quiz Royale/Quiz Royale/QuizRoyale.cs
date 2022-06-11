using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Quiz_Royale
{
    public class QuizRoyale : Game
    {
        public ObservableCollection<Player> Players { get; set; }

        public int CurrentAmountOfPlayers 
        {
            get
            {
                return Players.Count;
            }
        }

        public int TotalAmountOfPlayersStarted { get; set; }

        public QuizRoyale(Account account)
        {
            Account = account;
            FastestPlayers = new ObservableCollection<Player>();
            Players = new ObservableCollection<Player>();
            TotalAmountOfPlayersStarted = Players.Count;
            CurrentQuestion = null;
            Categories = new Dictionary<Category, float>();

            HubConector = new HubConector();
        }

        public void addPlayer(Player player)
        {
            Players.Add(player);
        }
    }
}
