﻿using Microsoft.Toolkit.Helpers;
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
        public RelayCommand NavigateToLobbyCommand { get; }

        public NotifyTaskCompletion<IList<Result>> Results { get; }

        public NotifyTaskCompletion<Rank> CurrentRank { get; }

        public NotifyTaskCompletion<Account> Account { get; }

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

        private void navigateToLobby()
        {
            var factory = new GameFactory();
            Game game = factory.CreateGame(SelectedGameMode.Mode, Account.Result);
            _navigationStore.CurrentViewModel = new LobbyViewModel(_navigationStore, game);
        }

        public HomeViewModel(NavigationStore navigationStore) : base(navigationStore)
        {
            _accountDataProvider = new APIAccountDataProvider();
            _accountProvider = new APIAccountProvider();
            _gameModes = GameModeProvider.GetGameModes();
            SelectedGameMode = _gameModes.FirstOrDefault();
            NavigateToLobbyCommand = new RelayCommand(navigateToLobby);

            _navigationStore.IsInMenu = true;

            Account = new NotifyTaskCompletion<Account>(_accountProvider.GetAccount());
            CurrentRank = new NotifyTaskCompletion<Rank>(_accountDataProvider.GetRank());
            Results = new NotifyTaskCompletion<IList<Result>>(_accountDataProvider.GetResults()); 


                // TODO er zijn geen resultaten toevoegen attribuut op de table
        }
    }
}
