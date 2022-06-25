using Quiz_Royale.ViewModels;
using System;

namespace Quiz_Royale.Base
{
    /// <summary>
    /// Deze klasse dient als opslagplek voor de huidige pagina.
    /// </summary>
    public class NavigationStore
    {
        private BaseViewModel _currentViewModel;
        private bool _isInMenu;
        private string _error;

        /// <summary>
        /// Deze property geeft toegang tot de huidige ViewModel.
        /// </summary>
        public BaseViewModel CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                _currentViewModel?.Dispose();
                _currentViewModel = value;
                if (value != null)
                {
                    Navigated?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Deze property geeft aan of iets in het menu moet worden weergegeven of niet.
        /// </summary>
        public bool IsInMenu
        {
            get
            {
                return _isInMenu;
            }
            set
            {
                _isInMenu = value;
                Navigated?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Deze property geeft toegang tot de error.
        /// </summary>
        public string Error
        {
            get
            {
                return _error;
            }
            set
            {
                _error = value;
                Navigated?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Dit event zorgt ervoor dat de gesubscribede klassen op de hoogte worden gesteld van dat de gebruiker is genavigeerd.
        /// </summary>
        public event EventHandler Navigated;

        /// <summary>
        /// Creëert een navigationStore met een eventuele ViewModel.
        /// </summary>
        /// <param name="currentViewModel">De huidige ViewModel die wordt gebruikt.</param>
        public NavigationStore(BaseViewModel currentViewModel = null)
        {
            CurrentViewModel = currentViewModel;
            IsInMenu = false;
        }
    }
}
