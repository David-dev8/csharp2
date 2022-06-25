using Quiz_Royale.Base;
using Quiz_Royale.Models.Games;
using Quiz_Royale.Models.Items;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Quiz_Royale.ViewModels
{
    /// <summary>
    /// Deze klasse dient als ViewModel voor de game.
    /// </summary>
    public class GameViewModel : BaseViewModel
    {
        private Answer _currentAnswer;
        private bool _canAnswerQuestion;
        private Booster _selectedBooster;
        private bool _canUseBooster;
        private bool _hasGameEnded;
        private bool _canPickCategory;

        public Game Game { get; set; }

        public ICommand GoToHome { get; set; }

        /// <summary>
        /// Deze property geeft aan of een game is geëindigd.
        /// </summary>
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

        /// <summary>
        /// Deze property geeft aan of er een categorie kan worden gekozen.
        /// </summary>
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

        /// <summary>
        /// Deze property geeft toegang tot de boosters van de gebruiker die in de game kunnen worden ingezet.
        /// </summary>
        public ObservableCollection<Item> Boosters
        {
            get
            {
                return Game.Boosters;
            }
        }

        /// <summary>
        /// Deze property geeft toegang tot de geselecteerde booster.
        /// </summary>
        public Booster SelectedBooster
        {
            get
            {
                return _selectedBooster;
            }
            set
            {
                if(value != null)
                {
                    Game.UseBoost(value);
                    _selectedBooster = value;
                    CanUseBooster = false;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Deze property geeft aan of een booster kan worden gebruikt.
        /// </summary>
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

        /// <summary>
        /// Deze property geeft toegang tot het geselecteerde antwoord.
        /// </summary>
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

        /// <summary>
        /// Deze property geeft aan of een gebruiker een vraag kan beantwoorden of niet.
        /// </summary>
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

        /// <summary>
        /// Creëert een ViewModel voor de game.
        /// </summary>
        /// <param name="navigationStore">De navigationStore die wordt gebruikt voor navigatie.</param>
        /// <param name="game">De game die wordt gebruikt voor het spel.</param>
        public GameViewModel(NavigationStore navigationStore, Game game) : base(navigationStore)
        {
            Game = game;
            DetermineState();
            GoToHome = new RelayCommand(SelectHomeAsCurrentPage);
            Game.PropertyChanged += Game_PropertyChanged;
        }

        // Verandert de staat van het huidge spel.
        private void Game_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            DetermineState();
        }

        // Bepaalt de huidige staat van het spel.
        private void DetermineState()
        {
            switch(Game.State)
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

        // Reset de instellingen voor een vraag.
        private void Reset()
        {
            if(CanPickCategory)
            {
                CanPickCategory = false;
                CanAnswerQuestion = true;
                CanUseBooster = true;
            }
        }

        /// <summary>
        /// Selecteert de homepagina als de huidige pagina.
        /// </summary>
        private void SelectHomeAsCurrentPage()
        {
            _navigationStore.CurrentViewModel = new HomeViewModel(_navigationStore);
        }

        /// <summary>
        /// Verlaat de huidige game.
        /// </summary>
        public override void Dispose()
        {
            Game.Dispose();
            base.Dispose();
        }
    }
}
