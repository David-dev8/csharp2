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
        private ICollection<GameMode> _gameModes;
        private GameMode _selectedGameMode;

        public ICollection<Result> Results
        {
            get
            {
                return _accountDataProvider.GetResults();
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

        public HomeViewModel(NavigationStore navigationStore) : base(navigationStore)
        {
            _accountDataProvider = new APIAccountDataProvider();
            _gameModes = GameModeProvider.GetGameModes();
            SelectedGameMode = _gameModes.FirstOrDefault();
        }
    }
}
