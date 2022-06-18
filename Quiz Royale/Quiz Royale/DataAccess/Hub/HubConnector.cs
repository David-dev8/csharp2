using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Royale
{
    public class HubConnector
    {
        private HubConnection _connection;
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

        public HubConnector()
        {
            _connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5264/GameHub")
                .Build();

            _connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await _connection.StartAsync();
            };

            _connection.On<bool, string, IList<Player>, IList<CategoryMastery>>("joinStatus", (status, message, players, cats) =>
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

            try
            {
                 _connection.StartAsync();
            }
            catch (Exception ex)
            {
                //TODO afhandelen als de api niet beschikbaar is
            }

        }

        public async Task Join(string username)
        {
            try
            {
                await _connection.InvokeAsync("join", username);
            }
            catch (Exception ex)
            {
                //TODO afhandelen
            }
        }

        public async Task Leave()
        {
            await _connection.InvokeAsync("leave");
        }

        public async Task AnswerQuestion(char awnserId)
        {
            await _connection.InvokeAsync("answerQuestion", awnserId);
        }

        public async Task UseBoost(string type, string options)
        {
            await _connection.InvokeAsync("useBoost", type, options);
        }

        public async Task BreakConection()
        { 
            await _connection.DisposeAsync();
        }
    }
}
