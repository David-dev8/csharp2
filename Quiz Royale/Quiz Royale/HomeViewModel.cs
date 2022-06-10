using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Quiz_Royale
{
    public class HomeViewModel : BaseViewModel
    {
        private IAccountDataProvider _accountDataProvider;
        private IAccountProvider _accountProvider;
        private ICollection<GameMode> _gameModes;
        private GameMode _selectedGameMode;

        public ICollection<Result> Results
        {
            get
            {
                return _accountDataProvider.GetResults().Take(5).ToList(); // TODO er zijn geen resultaten toevoegen attribuut op de table
            }
        }

        public ICollection<GameMode> GameModes
        {
            get
            {
                return _gameModes;
            }
        }
        
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

        public Rank CurrentRank
        {
            get
            {
                return _accountDataProvider.GetRank();
            }
        }

        public Account Account
        {
            get
            {
                return _accountProvider.GetAccount();
            }
        }

        public HomeViewModel(NavigationStore navigationStore) : base(navigationStore)
        {
            _accountDataProvider = new APIAccountDataProvider();
            _accountProvider = new APIAccountProvider();
            _gameModes = GameModeProvider.GetGameModes();
            SelectedGameMode = _gameModes.FirstOrDefault();

            _navigationStore.IsInMenu = true;
        }
    }
}
