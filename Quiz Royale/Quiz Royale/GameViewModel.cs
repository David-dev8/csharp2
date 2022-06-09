using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Quiz_Royale
{
    public class GameViewModel : BaseViewModel
    {
        public Game Game { get; set; }
        public ICommand GoToHome { get; set; }

        public GameViewModel(NavigationStore navigationStore) : base(navigationStore)
        {
            var gameFactory = new GameFactory();
            Game = gameFactory.CreateGame("QuizRoyale");
            GoToHome = new RelayCommand(SelectHomeAsCurrentPage);
        }

        private void SelectHomeAsCurrentPage()
        {
            _navigationStore.CurrentViewModel = new HomeViewModel(_navigationStore);
        }
    }
}
