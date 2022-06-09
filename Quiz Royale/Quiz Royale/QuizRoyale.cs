using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Quiz_Royale
{
    public class QuizRoyale : Game
    {
        private static readonly IDictionary<int, string> LOSE_MESSAGES = new Dictionary<int, string>
        {
            { 100, "That's quite unfortunate!" },
            { 75, "Better luck next time" },
            { 50, "Good job!" },
            { 25, "Excellent achievement!" },
            { 10, "Outsting " },
            { 1, "That was close..." },
        };

        private static readonly string WINNER_MESSAGE = "Congratulations!";

        private IList<Player> _players;

        public IList<Player> Players
        {
            get
            {
                return _players.Take(10).ToList();
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
            CurrentPosition = 88;

            // TODO initialiseer de rest ook op een goede manier
        }

        protected override string GetResultMessage()
        {
            CurrentPosition = CurrentAmountOfPlayers + 1;
            double percent = CurrentPosition / TotalAmountOfPlayersStarted * 100;
            return CurrentAmountOfPlayers > 0 ? LOSE_MESSAGES.Where(x => x.Key >= percent).Reverse().First().Value 
                : WINNER_MESSAGE;
        }
    }
}
