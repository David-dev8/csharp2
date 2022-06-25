using Quiz_Royale.Base;
using Quiz_Royale.Models.Games;
using System.ComponentModel;

namespace Quiz_Royale.ViewModels
{
    /// <summary>
    /// Deze klasse dient als de ViewModel voor de lobby, wanneer de gebruiker wacht om in een spel te komen.
    /// </summary>
    public class LobbyViewModel : BaseViewModel
    {
        private bool _waitingLobby;

        public Game Game { get; set; }

        /// <summary>
        /// Deze property geeft aan of de gebruiker al in een spel zit en moet wachten tot het begint.
        /// Als deze false is, zit de gebruiker dus nog niet in een game.
        /// </summary>
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

        /// <summary>
        /// Creëert een LobbyViewModel met een navigationStore en de gegeven Game.
        /// </summary>
        /// <param name="navigationStore">De navigationStore die wordt gebruikt voor navigatie.</param>
        /// <param name="game">De Game waarmee de gebruiker probeert te joinen.</param>
        public LobbyViewModel(NavigationStore store, Game game) : base(store)
        {
            Game = game;
            Game.PropertyChanged += _game_PropertyChanged;
        }

        // Registreer veranderingen in staat van de game en acteer hierop.
        // Als de gebruiker joint, of niet kan joinen, zal dit worden geregistreerd.
        // Wanneer het spel begint, zal de huidige ViewModel een GameViewModel worden zodat het spel gespeeld kan worden.
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
            if(Game.State == State.ENDED || Game.State == State.JOINED)
            {
                Game.Dispose();
            }
            base.Dispose();
        }
    }
}
