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

        public int TotalAmountOfPlayersStarted { get; set; }
        public int CurrentAmountOfPlayers { get; set; }

        public QuizRoyale(Account account)
        {
            Account = account;

            ObservableCollection<Player> fastestPlayers = new ObservableCollection<Player>
            {
                new Player("De super fantastische speler", "True Champion of All Times" , "/Assets/testProfilePicture.png", "/Assets/testBorder.png"),
                new Player("De super fantastische spelertjes", "True Champion of All Times" , "/Assets/testProfilePicture.png", "/Assets/testBorder.png"),
                new Player("De super fantastische spelers", "True Champion of All Times" , "/Assets/testProfilePicture.png", "/Assets/testBorder.png"),

            };

            FastestPlayers = fastestPlayers;

            IList<Player> players = new List<Player>
            {
                new Player("De super fantastische speler", "True Champion of All Times" , "/Assets/testProfilePicture.png", "/Assets/testBorder.png"),
                new Player("De super fantastische speler", "True Champion of All Times" , "/Assets/testProfilePicture.png", "/Assets/testBorder.png"),
                new Player("De super fantastische speler", "True Champion of All Times" , "/Assets/testProfilePicture.png", "/Assets/testBorder.png"),
                new Player("De super fantastische speler", "True Champion of All Times" , "/Assets/testProfilePicture.png", "/Assets/testBorder.png"),
                new Player("De super fantastische speler", "True Champion of All Times" , "/Assets/testProfilePicture.png", "/Assets/testBorder.png"),
                new Player("De super fantastische speler", "True Champion of All Times" , "/Assets/testProfilePicture.png", "/Assets/testBorder.png"),
                new Player("De super fantastische speler", "True Champion of All Times" , "/Assets/testProfilePicture.png", "/Assets/testBorder.png"),
                new Player("De super fantastische speler", "True Champion of All Times" , "/Assets/testProfilePicture.png", "/Assets/testBorder.png"),
                new Player("De super fantastische speler", "True Champion of All Times" , "/Assets/testProfilePicture.png", "/Assets/testBorder.png"),
                new Player("De super fantastische spelertje", "True Champion of All Times" , "/Assets/testProfilePicture.png", "/Assets/testBorder.png"),
                new Player("De super fantastische spel", "True Champion of All Times" , "/Assets/testProfilePicture.png", "/Assets/testBorder.png"),
                new Player("De super fantastische spele", "True Champion of All Times" , "/Assets/testProfilePicture.png", "/Assets/testBorder.png"),
                new Player("De super fantastische spelertjes", "True Champion of All Times" , "/Assets/testProfilePicture.png", "/Assets/testBorder.png"),
                new Player("De super fantastische spelers", "True Champion of All Times" , "/Assets/testProfilePicture.png", "/Assets/testBorder.png"),
            };

            Players = players;

            IList<Answer> answers = new List<Answer>
            {
                new Answer('A', "Samumsung Technologies"),
                new Answer('B', "Hitachi"),
                new Answer('C', "Huawei"),
                new Answer('D', "Sony"),
            };

            CurrentAmountOfPlayers = players.Count;
            TotalAmountOfPlayersStarted = players.Count;
            CurrentQuestion = new Question("What is the name of the biggest technology company in South Korea?", answers, 29, new Category("/Assets/testCategory.png", "Wetenschap", "#5294DF"));
            // TODO initialiseer de rest ook op een goede manier
        }
    }
}
