using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Timers;

namespace Quiz_Royale
{
    /// <summary>
    /// Deze klasse vertegenwoordigt de gamemodus Quiz Royale.
    /// </summary>
    public class QuizRoyale : Game
    {
        private const int TIME_AFTER_BOOST = 2;
        private const int START_TIME = 10;
        private static readonly string WINNER_MESSAGE = "Congratulations!";
        private static readonly IDictionary<int, string> LOSE_MESSAGES = new Dictionary<int, string>
        {
            { 100, "That's quite unfortunate!" },
            { 75, "Better luck next time" },
            { 50, "Good job!" },
            { 25, "Excellent achievement!" },
            { 10, "Outsting " },
            { 1, "That was close..." },
        };

        private Timer _timer;
        private int _currentTime;
        private bool? _isCorrect;

        public ObservableCollection<Player> Players { get; set; }

        /// <summary>
        /// Deze property geeft aan of het gegeven antwoord correct is.
        /// </summary>
        public bool? IsCorrect
        {
            get
            {
                return _isCorrect;
            }
            set
            {
                _isCorrect = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Deze property geeft toegang tot het aantal spelers dat nog in de huidige game zitten.
        /// </summary>
        public int CurrentAmountOfPlayers 
        {
            get
            {
                return Players.Count;
            }
        }

        public int TotalAmountOfPlayersStarted { get; set; }


        /// <summary>
        /// Deze property geeft toegang tot de tijd die nog over is om de vraag te beantwoorden.
        /// </summary>
        public int CurrentTime
        {
            get
            {
                return _currentTime;
            }
            set
            {
                if(value > 0)
                {
                    _currentTime = value;
                    NotifyPropertyChanged();
                }
                else
                {
                    _currentTime = value;
                    NotifyPropertyChanged();
                    _timer.Stop();
                }
            }
        }


        /// <summary>
        /// Creëert een game van de gamemodus Quiz Royale.
        /// </summary>
        /// <param name="account">Het account dat meedoet aan Quiz Royale.</param>
        public QuizRoyale(Account account)
        {
            Account = account;
            Boosters = new ObservableCollection<Item>(Account.Inventory.Boosters);
            FastestPlayers = new ObservableCollection<Player>();
            Players = new ObservableCollection<Player>();
            Chances = new List<CategoryMastery>();

            setupConection();
        }

        // Deze methode doet de setup voor de hub en bind alle events
        private void setupConection()
        {
            _connector = new HubConnector();
            _connector.NewQuestion += SetCurrentQuestion;
            _connector.ReduceTime += ReduceTime;
            _connector.PlayerAnswered += AddFastestPlayer;
            _timer = new Timer(1000);
            _timer.Elapsed += DecreaseTime;

            _connector.StartQuestion += StartQuestion;
            _connector.Results += Result;

            _connector.PlayersLeft += EliminatePlayers;

            _connector.GameOver += GameEnded;
            _connector.Win += Win;

            _connector.JoinStatus += JoinStatus;
            _connector.JoinPlayer += JoinPlayer;
            _connector.UpdateStatus += UpdateStatus;
            _connector.Start += StartGame;

            _connector.CategoryIncrease += IncreaseCategoryChance;
            _connector.ReduceAnswers += ReduceAnswers;

            _connector.Join(Account.Username);
        }

        private void ReduceAnswers(object sender, ReduceAnswersArgs e)
        {
            foreach(Answer answer in e.WrongAnswers)
            {
                CurrentQuestion.Possibilities.Remove(answer);
            }
        }

        // Elimineert de spelers die zijn afgevallen.
        private void EliminatePlayers(object sender, PlayersLeftArgs e)
        {
            Players = new ObservableCollection<Player>(e.Players);
        }

        // Handelt een winst voor de gebruiker af.
        private void Win(object sender, WinArgs e)
        {
            Account.CurrentXP += e.XP;
            Account.AmountOfCoins += e.Coins;
            EndGame();
        }

        // Eidingt de game voor de gebruiker.
        private void GameEnded(object sender, EventArgs e)
        {
            EndGame();
        }

        // Eidingt de game voor de gebruiker.
        private void EndGame()
        {
            CurrentPosition = CurrentAmountOfPlayers;
            State = State.ENDED;
            _connector.BreakConection();
        }

        // Telt de juiste aantal XP en coins erbij op.
        private void Result(object sender, ResultArgs e)
        {
            IsCorrect = e.Result;
            Account.CurrentXP += e.XP;
            Account.AmountOfCoins += e.Coins;
        }

        // Stelt de juiste instellingen in voor de volgende vraag.
        private void StartQuestion(object sender, EventArgs e)
        {
            IsCorrect = null;
            _timer.AutoReset = true;
            _timer.Enabled = true;
            FastestPlayers.Clear();
            State = State.QUESTION;
        }

        // Creëert een nieuwe vraag.
        private void SetCurrentQuestion(object sender, NewQuestionArgs e)
        {
            CurrentTime = START_TIME;
            CurrentQuestion = e.Question;
            State = State.NEXT_CATEGORY;
        }

        // Verminderd de tijd naar een aantal seconden.
        private void ReduceTime(object sender, EventArgs e)
        {
            CurrentTime = TIME_AFTER_BOOST; // De soccet tijd is 2 seconden
        }

        // Vermindert de tijd met een seconde.
        private void DecreaseTime(object sender, EventArgs e)
        {
            CurrentTime--;
        }

        // Voegt een speler toe aan de lijst van de snelste spelers.
        // Wanneer er in totaal drie spelers zijn toegevoegd, wordt de rest genegeerd.
        private void AddFastestPlayer(object sender, PlayerAnsweredArgs e)
        {
            if(FastestPlayers.Count < 3)
            {
                FastestPlayers.Add(e.Player);
            }
        }

        // Maakt de kans hoger dat een catogorie wordt gekozen
        private void IncreaseCategoryChance(object sender, CategoryIncreaseArgs e)
        {
            foreach (CategoryMastery chance in Chances)
            {
                if (chance.Category.Name == e.CatId)
                {
                    chance.Mastery += 10;
                }
                else
                {
                    chance.Mastery -= (float)(10.0 / (Chances.Count - 1));
                }

                if (chance.Mastery < 1)
                {
                    chance.Mastery = 1;
                }
                if (chance.Mastery > (101 - Chances.Count))
                {
                    chance.Mastery = (101 - Chances.Count);
                }
            }
        }

        /// <summary>
        /// Haalt het juiste bericht op, gebaseerd op het resultaat van de gebruiker.
        /// </summary>
        /// <returns>Een bericht dat gebaseerd is op het resultaat van de gebruiker.</returns>
        protected override string GetResultMessage()
        {
            if(CurrentPosition == 1)
            {
                Account.TotalWins++;
                return WINNER_MESSAGE;
            }
            double percent = (double) CurrentPosition / TotalAmountOfPlayersStarted * 100;
            return LOSE_MESSAGES.Where(x => x.Key >= percent).Reverse().First().Value;
        }

        /// <summary>
        /// Voegt een speler toe aan de lijst met deelnemers van een game.
        /// </summary>
        /// <param name="player">De speler die wil meedoen aan een spel.</param>
        public void AddPlayer(Player player)
        {
            Players.Add(player);
        }

        /// <summary>
        /// Zorgt ervoor dat de staat van het spel wordt geüpdatet wanneer de speler in een spel komt.
        /// </summary>
        /// <param name="sender">De zender van het event.</param>
        /// <param name="e">Informatie over de staat van het spel wanneer er gejoind is.</param>
        private void JoinStatus(object sender, JoinStatusArgs e)
        {
            if (e.Status)
            {
                foreach (Player player in e.Players)
                {
                    AddPlayer(player);
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

        /// <summary>
        /// Zorgt ervoor dat nieuwe spelers die joinen terwijl de speler wacht, worden toegevoegd aan de collectie met spelers.
        /// </summary>
        /// <param name="sender">De zender van het event.</param>
        /// <param name="e">Informatie over de speler die gejoind is.</param>
        private void JoinPlayer(Object sender, PlayerArgs e)
        {
            AddPlayer(e.Player);
            StatusMessage = e.Message;
        }

        /// <summary>
        /// Zorgt ervoor dat het spel wordt gestart. 
        /// </summary>
        /// <param name="sender">De zender van het event.</param>
        /// <param name="e">Informatie over het event.</param>
        private void StartGame(Object sender, EventArgs e)
        {
            TotalAmountOfPlayersStarted = Players.Count;
            StatusMessage = "The game is starting!";
        }

        /// <summary>
        /// Zorgt ervoor dat het statusbericht wordt veranderd.
        /// </summary>
        /// <param name="sender">De zender van het event.</param>
        /// <param name="e">Informatie over het statusbericht.</param>
        private void UpdateStatus(Object sender, UpdateStatusArgs e)
        {
            StatusMessage = e.Message;
        }
    }
}
