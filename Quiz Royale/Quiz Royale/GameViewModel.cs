using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Quiz_Royale
{
    public class GameViewModel : BaseViewModel
    {
        private Answer _currentAnswer;
        private bool _canAnswerQuestion;
        private Booster _selectedBooster;
        private bool _canUseBooster;
        
        public Game Game { get; set; }
        public ICommand GoToHome { get; set; }


        private bool _hasGameEnded;

        public bool HasGameEnded
        {
            get
            {
                return _hasGameEnded;
            }
            set
            {
                _hasGameEnded = value;
                OnPropertyChanged();
            }
        }


        private bool _canPickCategory;

        public bool CanPickCategory
        {
            get
            {
                return _canPickCategory;
            }
            set
            {
                _canPickCategory = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Item> Boosters
        {
            get
            {
                return Game.Boosters;
            }
        }

        public Booster SelectedBooster
        {
            get
            {
                return _selectedBooster;
            }
            set
            {
                if (value != null)
                {
                    _selectedBooster = value;
                    CanUseBooster = false;
                    NotifyPropertyChanged();
                }
            }
        }

        public bool CanUseBooster
        {
            get
            {
                return _canUseBooster;
            }
            set
            {
                _canUseBooster = value;
                NotifyPropertyChanged();
            }
        }

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
                    Game.Answer(value);
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

        public GameViewModel(NavigationStore navigationStore, Game game) : base(navigationStore)
        {
            Game = game;
            DetermineState();
            GoToHome = new RelayCommand(SelectHomeAsCurrentPage);
            Game.PropertyChanged += Game_PropertyChanged;
        }

        private void Game_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            DetermineState();
        }

        private void DetermineState()
        {
            switch (Game.State)
            {
                case State.QUESTION:
                    Reset();
                    break;
                case State.NEXT_CATEGORY:
                    CanPickCategory = true;
                    break;
                case State.ENDED:
                    HasGameEnded = true;
                    break;
            }
        }

        private void Reset()
        {
            CanPickCategory = false; // todo
            CanAnswerQuestion = true;
            CanUseBooster = true;
        }

        private void SelectHomeAsCurrentPage()
        {
            _navigationStore.CurrentViewModel = new HomeViewModel(_navigationStore);
        }

        public override void Dispose()
        {
            Game.Dispose();
            base.Dispose();
        }
    }
}
