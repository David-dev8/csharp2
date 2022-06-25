using Microsoft.Toolkit.Helpers;
using Quiz_Royale.Base;
using Quiz_Royale.DataAccess;
using Quiz_Royale.DataAccess.API;
using Quiz_Royale.Models.Factories;
using Quiz_Royale.Models.Games;
using Quiz_Royale.Models.User;
using System.Collections.Generic;
using System.Linq;

namespace Quiz_Royale.ViewModels
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

        // Probeert een game te starten door een game object te maken en je naar de lobby pagina te sturen
        private void InitiateGame()
        {
            var factory = new GameFactory();
            try
            {
                Game game = factory.CreateGame(SelectedGameMode.Mode, Account.Result);
                _navigationStore.CurrentViewModel = new LobbyViewModel(_navigationStore, game);
            }
            catch(Exceptions.UnableToConnectException e)
            {
                _navigationStore.Error = e.Message;
            }
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
            _gameModes = GameModeFactory.GetGameModes();
            SelectedGameMode = _gameModes.FirstOrDefault();
            StartGame = new RelayCommand(InitiateGame, CanStartGame);
            _navigationStore.IsInMenu = true;

            Account = new NotifyTaskCompletion<Account>(_accountProvider.GetAccount());
            CurrentRank = new NotifyTaskCompletion<Rank>(_accountDataProvider.GetRank());
            Results = new NotifyTaskCompletion<IList<Result>>(_accountDataProvider.GetResults());
        }
    }
}
