using System;
using System.Windows;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Microsoft.Toolkit.Helpers;

namespace Quiz_Royale
{
    /// <summary>
    /// Deze klasse dient als de basis ViewModel voor de pagina's op de applicatie.
    /// In deze klasse zijn commands en properties aanwezig voor de werking van de navigatiebalk.
    /// </summary>
    public class MainWindowViewModel: Observable
    {
        private readonly NavigationStore _navigationStore;

        /// <summary>
        /// Deze property geeft toegang tot de huidige ViewModel.
        /// </summary>
        public BaseViewModel CurrentViewModel 
        {
            get
            {
                return _navigationStore.CurrentViewModel;
            }
            private set
            {
                _navigationStore.CurrentViewModel = value;
            }
        }

        /// <summary>
        /// Deze property geeft aan of een item in het menu aanwezig moet zijn of niet.
        /// </summary>
        public bool IsInMenu
        {
            get
            {
                return _navigationStore.IsInMenu;
            }
        }

        /// <summary>
        /// Deze property geeft toegang tot de error.
        /// </summary>
        public string Error
        {
            get
            {
                return _navigationStore.Error;
            }
        }

        /// <summary>
        /// Deze property geeft aan of er een error aanwezig is of niet.
        /// </summary>
        public bool HasError
        {
            get
            {
                return !string.IsNullOrEmpty(Error);
            }
        }

        public ICommand ShowHome { get; set; }

        public ICommand ShowShop { get; set; }

        public ICommand ExitProgram { get; set; }

        public ICommand ShowProfile { get; set; }

        public ICommand Dismiss { get; set; }

        /// <summary>
        /// Creëert een ViewModel voor de MainWindow met een navigationStore.
        /// </summary>
        /// <param name="navigationStore">De navigationStore die wordt gebruikt voor navigatie.</param>
        public MainWindowViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            GetFirstViewModel();
            NotifyForUpdates();

            ShowHome = new RelayCommand(SelectHomeAsCurrentPage);
            ShowShop = new RelayCommand(SelectShopAsCurrentPage);
            ExitProgram = new RelayCommand(CloseProgram);
            ShowProfile = new RelayCommand(SelectProfileAsCurrentPage);
            Dismiss = new RelayCommand(DismissAllErrors);
        }

        // Update de properties wanneer er wordt genavigeeerd. 
        private void NotifyForUpdates()
        {
            _navigationStore.Navigated += (object sender, EventArgs e) =>
            {
                OnPropertyChanged(nameof(CurrentViewModel));
                OnPropertyChanged(nameof(IsInMenu));
                OnPropertyChanged(nameof(Error));
                OnPropertyChanged(nameof(HasError));
            };
        }

        // Verwijder alle errors.
        private void DismissAllErrors()
        {
            _navigationStore.Error = null;
        }

        // Haal de eerste ViewModel bij het opstarten.
        private void GetFirstViewModel()
        {
            // Controleer of de gebruiker al een account heeft, dit is het geval wanneer er een access token aanwezig is
            if(Storage.Settings.Credentials?.AccessToken == null)
            {
                CurrentViewModel = new LoginViewModel(_navigationStore);
            } 
            else
            {
                TryToGoToHome();
            }
        }

        // TODO COMMENT
        private async void TryToGoToHome()
        {
            try
            {
                Account account = await new APIAccountProvider().GetAccount();
                CurrentViewModel = new HomeViewModel(_navigationStore);
            }
            catch(Exception)
            {
                CurrentViewModel = new LoginViewModel(_navigationStore);
                _navigationStore.Error = "Cannot connect to the server. Please try again";
            }

        }

        // Selecteert de homepagina als huidige pagina.
        private void SelectHomeAsCurrentPage()
        {
            CurrentViewModel = new HomeViewModel(_navigationStore);
        }

        // Selecteert de shop als de huidige pagina.
        private void SelectShopAsCurrentPage()
        {
            CurrentViewModel = new ShopViewModel(_navigationStore);
        }

        // Selecteert de profielpagina als huidige pagina.
        private void SelectProfileAsCurrentPage()
        {
            CurrentViewModel = new ProfileViewModel(_navigationStore);
        }

        // Sluit het programma af.
        private void CloseProgram()
        {
            CurrentViewModel.Dispose(); // todo
            Application.Current.Shutdown();
        }
    }
}
