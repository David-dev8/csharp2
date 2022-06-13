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
        private HubConnection connection;
        public event EventHandler<JoinStatusArgs> joinStatus;
        public event EventHandler<PlayerArgs> joinPlayer;
        public event EventHandler<UpdateStatusArgs> updateStatus;
        public event EventHandler gameOver;
        public event EventHandler start;
        public event EventHandler startQuestion;
        public event EventHandler<NewQuestionArgs> newQuestion;
        public event EventHandler<ResultArgs> results;
        public event EventHandler<WinArgs> win;
        public event EventHandler<CategoryIncreaseArgs> catIncrease;
        public event EventHandler reduceTime;
        public event EventHandler<PlayerAnsweredArgs> playerAnswered;
        public event EventHandler<PlayersLeftArgs> playersLeft;

        public HubConnector()
        {
            connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5264/GameHub")
                .Build();

            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync();
            };

            connection.On<bool, string, IList<Player>, IList<CategoryMastery>>("joinStatus", (status, message, players, cats) =>
            {
                joinStatus?.Invoke(this, new JoinStatusArgs(status, message, players, cats));
            });

            connection.On<Player, string>("newPlayerJoin", (player, message) =>
            {
                joinPlayer?.Invoke(this, new PlayerArgs(player, message));
            });

            connection.On<string>("updateStatus", (message) =>
            {
                updateStatus?.Invoke(this, new UpdateStatusArgs(message));
            });

            connection.On("gameOver", () =>
            {
                gameOver?.Invoke(this, new EventArgs());
            });

            connection.On("start", () =>
            {
                start?.Invoke(this, new EventArgs());
            });

            connection.On("StartQuestion", () =>
            {
                startQuestion?.Invoke(this, new EventArgs());
            });
            
            connection.On<Question>("newQuestion", (question) =>
            {
                newQuestion?.Invoke(this, new NewQuestionArgs(question));
            });
            
            connection.On<bool, int, int>("result", (result, xp, coins) =>
            {
                results?.Invoke(this, new ResultArgs(result, xp, coins));
            });

            connection.On<int, int>("Win", (xp, coins) =>
            {
                win?.Invoke(this, new WinArgs(xp, coins));
            });

            connection.On<string>("categoryIncrease", (cat) =>
            {
                catIncrease?.Invoke(this, new CategoryIncreaseArgs(cat));
            });

            connection.On("reduceTime", () =>
            {
                reduceTime?.Invoke(this, new EventArgs());
            });

            connection.On<Player, double>("playerAnswered", (player, answerTime) => 
            {
                playerAnswered?.Invoke(this, new PlayerAnsweredArgs(player, answerTime));
            });

            connection.On<IList<Player>>("playersLeft", (players) =>
            {
                playersLeft?.Invoke(this, new PlayersLeftArgs(players));
            });

            try
            {
                 connection.StartAsync();
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
                await connection.InvokeAsync("join", username);
            }
            catch (Exception ex)
            {
                //TODO afhandelen
            }
        }

        public async Task Leave()
        {
            await connection.InvokeAsync("leave");
        }

        public async Task AnswerQuestion(char awnserId)
        {
            await connection.InvokeAsync("answerQuestion", awnserId);
        }

        public async Task UseBoost(string type, string options)
        {
            await connection.InvokeAsync("useBoost", type, options);
        }

        public async Task BreakConection()
        { 
            await connection.DisposeAsync();
        }
    }
}
