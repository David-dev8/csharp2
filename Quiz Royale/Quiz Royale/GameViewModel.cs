using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Quiz_Royale
{
    public class GameViewModel : BaseViewModel
    {
        private Answer _currentAnswer;
        private bool _canAnswerQuestion;
        
        public Game Game { get; set; }
        public ICommand GoToHome { get; set; }

        public Answer SelectedAnswer
        {
            get
            {
                return _currentAnswer;
            }
            set
            {
                if(value != null)
                {
                    _currentAnswer = value;
                    CanAnswerQuestion = false;
                    NotifyPropertyChanged();
                }
            }
        }

        public bool CanAnswerQuestion
        {
            get
            {
                return _canAnswerQuestion;
            }
            set
            {
                _canAnswerQuestion = value;
                NotifyPropertyChanged();
            }
        }


        public GameViewModel(NavigationStore navigationStore) : base(navigationStore)
        {
            var gameFactory = new GameFactory();
            Game = gameFactory.CreateGame("QuizRoyale");
            GoToHome = new RelayCommand(SelectHomeAsCurrentPage);
            _canAnswerQuestion = true;
        }

        private void SelectHomeAsCurrentPage()
        {
            _navigationStore.CurrentViewModel = new HomeViewModel(_navigationStore);
        }
    }
}
