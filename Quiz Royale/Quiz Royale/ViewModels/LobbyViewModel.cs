using System;
using System.Collections.Generic;
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
                    ((QuizRoyale)_game).Players.Add(player);
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

        }

        private void joinPlayer(Object sender, JoinPlayerArgs e)
        {

        }

        private void startGame(Object sender, EventArgs e)
        {

        }
    }
}
