using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Timers;

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
        private const int TIME_AFTER_BOOST = 3;
        private const int START_TIME = 20;

        private IList<Player> _players;
        private Timer _timer;
        private int _currentTime;

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
        public int CurrentTime
        {
            get
            {
                return _currentTime;
            }
            set
            {
                if(value >= 0)
                {
                    _currentTime = value;
                    NotifyPropertyChanged();
                }
                else
                {
                    _timer.Stop(); // TODO moet je eigenlijk wel stoppen?
                }
            }
        }


        public QuizRoyale(Account account)
        {
            Account = account;
            Boosters = new ObservableCollection<Item>(Account.Inventory.Boosters);

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
            CurrentQuestion = new Question("What is the name of the biggest technology company in South Korea?", answers, new Category("Wetenschap", "/Assets/testCategory.png", "#5294DF"));
            CurrentPosition = 88;

            // TODO initialiseer de rest ook op een goede manier

            HubConnector = new HubConnector();
            HubConnector.newQuestion += SetCurrentQuestion;
            HubConnector.reduceTime += ReduceTime;
            _timer = new Timer(1000);
            _timer.Elapsed += DecreaseTime;
        }

        private void SetCurrentQuestion(object sender, NewQuestionArgs e)
        {
            CurrentQuestion = e.Question;
            CurrentTime = START_TIME;
            _timer.AutoReset = true;
            _timer.Enabled = true;
        }

        private void ReduceTime(object sender, EventArgs e)
        {
            CurrentTime = TIME_AFTER_BOOST; // TODO zelfde tijd als op de socket?
        }

        private void DecreaseTime(object sender, EventArgs e)
        {
            CurrentTime--;
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
