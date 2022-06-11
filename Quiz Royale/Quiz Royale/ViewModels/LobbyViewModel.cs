using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Royale
{
    internal class LobbyViewModel : BaseViewModel
    {
        private string _loadingStatus;
        private string _statusMessage;
        private string _showError;
        private string _waitingLobby;
        private Game _game;

        public string LoadingStatus
        {
            get
            {
                return _loadingStatus;
            }
            set
            {
                _loadingStatus = value;
                NotifyPropertyChanged();
            }
        }

        public string StatusMessage
        {
            get
            {
                return _statusMessage;
            }
            set
            {
                _statusMessage = value;
                NotifyPropertyChanged();
            }
        }

        public string ShowError
        {
            get
            {
                return _showError;
            }
            set
            {
                _showError = value;
                NotifyPropertyChanged();
            }
        }

        public string WaitingLobby
        {
            get
            {
                return _waitingLobby;
            }
            set
            {
                _waitingLobby = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<Player> Players
        {
            get 
            {
                return ((QuizRoyale)_game).Players;
            }
        }

        public LobbyViewModel(NavigationStore store) : base(store)
        {
            LoadingStatus = "Visible";   
            StatusMessage = "";   
            ShowError = "Hidden";
            WaitingLobby = "Hidden";
            _game = new QuizRoyale(new APIAccountProvider().GetAccount("tim"));

            _game.HubConector.joinStatus += joinStatus;
            _game.HubConector.updateStatus += updateStatus;
            _game.HubConector.joinPlayer += joinPlayer;
            _game.HubConector.start += startGame;

            _game.HubConector.Join(_game.Account.Username);
        }

        private void joinStatus(Object sender, JoinStatusArgs e)
        {
            if (e.Status)
            {
                StatusMessage = e.Message;
                foreach (Player player in e.Players)
                {
                    App.Current.Dispatcher.Invoke(() =>
                    {
                        ((QuizRoyale)_game).addPlayer(player);
                    });
                }
                LoadingStatus = "Hidden";
                WaitingLobby = "Visible";
            }
            else 
            {
                LoadingStatus = "Hidden";
                ShowError = "Visible";
                _navigationStore.Error = "Joinen is niet gelukt, probeer het later opniew";
                _game.HubConector.breakConection();
                _game.HubConector = null;
            }
        }

        private void updateStatus(Object sender, UpdateStatusArgs e)
        {
            StatusMessage = e.Message;
        }

        private void joinPlayer(Object sender, PlayerArgs e)
        {
            App.Current.Dispatcher.Invoke(() => 
            {
                ((QuizRoyale)_game).addPlayer(e.Player);
            });
            StatusMessage = e.Message;
        }

        private void startGame(Object sender, EventArgs e)
        {
            StatusMessage = "De game Start!!";
            //ToDo ref naar de game
        }
    }
}
