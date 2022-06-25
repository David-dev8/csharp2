using Microsoft.AspNetCore.SignalR.Client;
using Quiz_Royale.CustomEventArgs;
using Quiz_Royale.Models;
using Quiz_Royale.Models.Games;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quiz_Royale.DataAccess.Hub
{
    /// <summary>
    /// Deze klasse is verantwoordelijk voor verbinden met en regelen van events van een hub op de server zodat een spel gespeeld kan worden.
    /// </summary>
    public class HubConnector
    {
        private const string HUB_URL = "http://localhost:5264/GameHub";

        public event EventHandler<JoinStatusArgs> JoinStatus;
        public event EventHandler<PlayerArgs> JoinPlayer;
        public event EventHandler<UpdateStatusArgs> UpdateStatus;
        public event EventHandler GameOver;
        public event EventHandler Start;
        public event EventHandler StartQuestion;
        public event EventHandler<NewQuestionArgs> NewQuestion;
        public event EventHandler<ResultArgs> Results;
        public event EventHandler<WinArgs> Win;
        public event EventHandler<CategoryIncreaseArgs> CategoryIncrease;
        public event EventHandler ReduceTime;
        public event EventHandler<PlayerAnsweredArgs> PlayerAnswered;
        public event EventHandler<PlayersLeftArgs> PlayersLeft;
        public event EventHandler<ReduceAnswersArgs> ReduceAnswers;
        private HubConnection _connection;

        /// <summary>
        /// Creëert een HubConnector.
        /// </summary>
        /// <exception cref="Exceptions.UnableToConnectException">Gegooit wanneer geen verbinding met de hub op de server kon worden gemaakt</exception>
        public HubConnector() 
        {
            InitializeConnection();
            InitializeEvents();
            StartConnection();
        }

        /// <summary>
        /// Laat een speler met de gegeven username joinen bij de hub.
        /// </summary>
        /// <param name="username">De username van de speler die joint.</param>
        /// <returns></returns>
        public async Task Join(string username)
        {
            await _connection.InvokeAsync("Join", username);
        }

        /// <summary>
        /// Geef door aan de hub dat een speler het spel verlaat.
        /// </summary>
        /// <returns></returns>
        public async Task Leave()
        {
            await _connection.InvokeAsync("Leave");
        }

        /// <summary>
        /// Geef de hub een antwoord door.
        /// </summary>
        /// <param name="awnserId">Het id van het antwoord dat moet worden doorgegeven.</param>
        /// <returns></returns>
        public async Task AnswerQuestion(char awnserId)
        {
            await _connection.InvokeAsync("AnswerQuestion", awnserId);
        }

        /// <summary>
        /// Geef de hub door dat een booster gebruikt dient te worden.
        /// </summary>
        /// <param name="type">Het type booster.</param>
        /// <param name="options">Opties voor het gebruiken van de booster</param>
        /// <returns></returns>
        public async Task UseBoost(string type, string options)
        {
            await _connection.InvokeAsync("UseBoost", type, options);
        }

        /// <summary>
        /// Breek de connectie met de hub.
        /// </summary>
        /// <returns></returns>
        public async Task BreakConection()
        { 
            await _connection.DisposeAsync();
        }

        // Zorgt ervoor dat er een connectie wordt gebouwd.
        private void InitializeConnection()
        {
            _connection = new HubConnectionBuilder()
                .WithUrl(HUB_URL)
                .Build();

            _connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await _connection.StartAsync();
            };
        }

        // Zorgt ervoor dat alle benodigde event handlers worden aangeroepen wanneer er vanuit de hub een gebeurtenis plaatsvindt.
        private void InitializeEvents()
        {
            _connection.On<bool, string, IList<Player>, IList<CategoryIntensity>>("joinStatus", (status, message, players, cats) =>
            {
                JoinStatus?.Invoke(this, new JoinStatusArgs(status, message, players, cats));
            });

            _connection.On<Player, string>("newPlayerJoin", (player, message) =>
            {
                JoinPlayer?.Invoke(this, new PlayerArgs(player, message));
            });

            _connection.On<string>("updateStatus", (message) =>
            {
                UpdateStatus?.Invoke(this, new UpdateStatusArgs(message));
            });

            _connection.On("gameOver", () =>
            {
                GameOver?.Invoke(this, new EventArgs());
            });

            _connection.On("start", () =>
            {
                Start?.Invoke(this, new EventArgs());
            });

            _connection.On("StartQuestion", () =>
            {
                StartQuestion?.Invoke(this, new EventArgs());
            });

            _connection.On<Question>("newQuestion", (question) =>
            {
                NewQuestion?.Invoke(this, new NewQuestionArgs(question));
            });

            _connection.On<bool, int, int>("result", (result, xp, coins) =>
            {
                Results?.Invoke(this, new ResultArgs(result, xp, coins));
            });

            _connection.On<int, int>("Win", (xp, coins) =>
            {
                Win?.Invoke(this, new WinArgs(xp, coins));
            });

            _connection.On<string>("categoryIncrease", (cat) =>
            {
                CategoryIncrease?.Invoke(this, new CategoryIncreaseArgs(cat));
            });

            _connection.On("reduceTime", () =>
            {
                ReduceTime?.Invoke(this, new EventArgs());
            });

            _connection.On<Player, double>("playerAnswered", (player, answerTime) =>
            {
                PlayerAnswered?.Invoke(this, new PlayerAnsweredArgs(player, answerTime));
            });

            _connection.On<IList<Player>>("playersLeft", (players) =>
            {
                PlayersLeft?.Invoke(this, new PlayersLeftArgs(players));
            });

            _connection.On<IList<Answer>>("reduceAnswers", (answers) =>
            {
                ReduceAnswers?.Invoke(this, new ReduceAnswersArgs(answers));
            });
        }

        // Start de connectie
        private void StartConnection()
        {
            try
            {
                _connection.StartAsync();
            }
            catch (Exception)
            {
                throw new Exceptions.UnableToConnectException();
            }
        }
    }
}
