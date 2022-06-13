using Microsoft.Toolkit.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Quiz_Royale
{
    /// <summary>
    /// Deze klasse dient als ViewModel voor de homepagina.
    /// </summary>
    public class HomeViewModel : BaseViewModel
    {
        private IAccountDataProvider _accountDataProvider;
        private IAccountProvider _accountProvider;
        private IList<GameMode> _gameModes;
        private GameMode _selectedGameMode;

        public RelayCommand StartGame { get; }

        public NotifyTaskCompletion<IList<Result>> Results { get; }

        public NotifyTaskCompletion<Rank> CurrentRank { get; }

        public NotifyTaskCompletion<Account> Account { get; }

        /// <summary>
        /// Deze property geeft toegang tot de hudige gamemodi.
        /// </summary>
        public IList<GameMode> GameModes
        {
            get
            {
                return _gameModes;
            }
        }
        
        /// <summary>
        /// Deze property geeft toegang tot de geselecteerde gamemodus.
        /// </summary>
        public GameMode SelectedGameMode
        {
            get
            {
                return _selectedGameMode;
            }
            set
            {
                _selectedGameMode = value;
                NotifyPropertyChanged();
            }
        }

        // TODO COMMENT EN MET HOOFDLETTER
        private void startGame()
        {
            var factory = new GameFactory();
            Game game = factory.CreateGame(SelectedGameMode.Mode, Account.Result);
            _navigationStore.CurrentViewModel = new LobbyViewModel(_navigationStore, game);
        }

        private bool CanStartGame(object parameter)
        {
            return SelectedGameMode.Released;
        }

        /// <summary>
        /// Creëert de ViewModel van de homepagina.
        /// </summary>
        /// <param name="navigationStore">De navigationStore die wordt gebruikt voor navigatie.</param>
        public HomeViewModel(NavigationStore navigationStore) : base(navigationStore)
        {
            _accountDataProvider = new APIAccountDataProvider();
            _accountProvider = new APIAccountProvider();
            _gameModes = GameModeProvider.GetGameModes();
            SelectedGameMode = _gameModes.FirstOrDefault();
            StartGame = new RelayCommand(startGame, CanStartGame);
            _navigationStore.IsInMenu = true;

            Account = new NotifyTaskCompletion<Account>(_accountProvider.GetAccount());
            CurrentRank = new NotifyTaskCompletion<Rank>(_accountDataProvider.GetRank());
            Results = new NotifyTaskCompletion<IList<Result>>(_accountDataProvider.GetResults());
        }
    }
}
