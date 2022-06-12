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
        public ObservableCollection<Player> Players { get; set; }

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
        private const int START_TIME = 10;

        private Timer _timer;
        private int _currentTime;

        public int CurrentAmountOfPlayers 
        {
            get
            {
                return Players.Count;
            }
        }

        public int TotalAmountOfPlayersStarted { get; set; }

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
            FastestPlayers = new ObservableCollection<Player>();
            Players = new ObservableCollection<Player>();
            Chances = new List<CategoryMastery>();

            _connector = new HubConnector();
            _connector.newQuestion += SetCurrentQuestion;
            _connector.reduceTime += ReduceTime;
            _connector.playerAnswered += AddFastestPlayer;
            _timer = new Timer(1000);
            _timer.Elapsed += DecreaseTime;

            _connector.startQuestion += StartQuestion;
            _connector.results += Result;

            _connector.playersLeft += EliminatePlayers;

            _connector.gameOver += GameEnded;
            _connector.win += GameEnded;

            _connector.joinStatus += joinStatus;
            _connector.joinPlayer += joinPlayer;
            _connector.updateStatus += updateStatus;
            _connector.start += startGame;

            _connector.Join(Account.Username);
        }

        private void EliminatePlayers(object sender, PlayersLeftEventArgs e)
        {
            Players = new ObservableCollection<Player>(e.Players);
        }

        private void GameEnded(object sender, EventArgs e)
        {
            State = State.ENDED;
            _connector.BreakConection();
        }

        private void Result(object sender, ResultArgs e)
        {
            Account.CurrentXP += e.XP;
            Account.AmountOfCoins += e.Coins;
        }

        private void StartQuestion(object sender, EventArgs e)
        {
            _timer.AutoReset = true;
            _timer.Enabled = true;
            FastestPlayers.Clear();
            State = State.QUESTION;
        }

        private void SetCurrentQuestion(object sender, NewQuestionArgs e)
        {
            CurrentQuestion = e.Question;
            State = State.NEXT_CATEGORY;
            CurrentTime = START_TIME;
        }

        private void ReduceTime(object sender, EventArgs e)
        {
            CurrentTime = TIME_AFTER_BOOST; // TODO zelfde tijd als op de socket?
        }

        private void DecreaseTime(object sender, EventArgs e)
        {
            CurrentTime--;
        }

        private void AddFastestPlayer(object sender, PlayerAnsweredEventArgs e)
        {
            if(FastestPlayers.Count < 3)
            {
                FastestPlayers.Add(e.Player);
            }
        }

        protected override string GetResultMessage()
        {
            CurrentPosition = CurrentAmountOfPlayers;
            if(CurrentPosition == 1)
            {
                return WINNER_MESSAGE;
            }
            double percent = (double) CurrentPosition / TotalAmountOfPlayersStarted * 100;
            return LOSE_MESSAGES.Where(x => x.Key >= percent).Reverse().First().Value;
        }

        public void addPlayer(Player player)
        {
            Players.Add(player);
        }

        private void joinStatus(Object sender, JoinStatusArgs e)
        {
            if (e.Status)
            {
                foreach (Player player in e.Players)
                {
                    addPlayer(player);
                }
                State = State.JOINED;
                Chances = e.categories;
            }
            else
            {
                _connector.BreakConection();
                _connector = null;
                State = State.ENDED;
            }
            StatusMessage = e.Message;
        }

        private void joinPlayer(Object sender, PlayerArgs e)
        {
            addPlayer(e.Player);
            StatusMessage = e.Message;
        }

        private void startGame(Object sender, EventArgs e)
        {
            TotalAmountOfPlayersStarted = Players.Count;
            StatusMessage = "The game is starting!";
        }

        private void updateStatus(Object sender, UpdateStatusArgs e)
        {
            StatusMessage = e.Message;
        }
    }
}
