using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Royale
{
    public class HubConector
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
        public event EventHandler win;
        public event EventHandler<CategoryIncreaseArgs> catIncrease;
        public event EventHandler reduceTime;
        public event EventHandler<PlayerArgs> playerAwnsered;



        public HubConector()
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
                joinStatus.Invoke(this, new JoinStatusArgs(status, message, players, cats));
            });

            connection.On<Player, string>("newPlayerJoin", (player, message) =>
            {
                joinPlayer.Invoke(this, new PlayerArgs(player, message));
            });

            connection.On<string>("updateStatus", (player) =>
            {
                updateStatus.Invoke(this, new UpdateStatusArgs(player));
            });

            connection.On("gameOver", () =>
            {
                gameOver.Invoke(this, new EventArgs());
            });

            connection.On("start", () =>
            {
                start.Invoke(this, new EventArgs());
            });

            connection.On("StartQuestion", () =>
            {
                startQuestion.Invoke(this, new EventArgs());
            });
            
            connection.On<Question>("newQuestion", (question) =>
            {
                newQuestion.Invoke(this, new NewQuestionArgs(question));
            });
            
            connection.On<bool>("result", (result) =>
            {
                results.Invoke(this, new ResultArgs(result));
            });

            connection.On("Win", () =>
            {
                win.Invoke(this, new EventArgs());
            });

            connection.On<string>("categoryIncrease", (cat) =>
            {
                catIncrease.Invoke(this, new CategoryIncreaseArgs(cat));
            });

            connection.On("reduceTime", () =>
            {
                reduceTime.Invoke(this, new EventArgs());
            });

            connection.On<Player>("playerAwnsered", (player) => 
            {
                playerAwnsered.Invoke(this, new PlayerArgs(player, ""));
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

        public async Task breakConection()
        { 
            await connection.DisposeAsync();
        }
    }
}
