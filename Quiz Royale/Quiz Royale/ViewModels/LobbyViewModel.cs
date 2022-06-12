using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Royale
{
    public class LobbyViewModel : BaseViewModel
    {
        private bool _waitingLobby;

        public Game Game { get; set; }

        public bool WaitingLobby
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

        public LobbyViewModel(NavigationStore store, Game game) : base(store)
        {
            Game = game;
            Game.PropertyChanged += _game_PropertyChanged;
        }

        private void _game_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch(Game.State)
            {
                case State.JOINED:
                    WaitingLobby = true;
                    break;
                case State.NEXT_CATEGORY:
                    _navigationStore.CurrentViewModel = new GameViewModel(_navigationStore, Game);
                    break;
                case State.ENDED:
                    _navigationStore.Error = "Joining went wrong";
                    break;
            }
        }

        public override void Dispose()
        {
            Game.PropertyChanged -= _game_PropertyChanged;
            if(Game.State == State.ENDED)
            {
                Game.Dispose();
            }
            base.Dispose();
        }
    }
}
