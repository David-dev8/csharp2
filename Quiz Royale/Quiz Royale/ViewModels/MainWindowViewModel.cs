using System;
using System.Windows;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Microsoft.Toolkit.Helpers;
using Quiz_Royale.Base;

namespace Quiz_Royale.ViewModels
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
            CurrentViewModel.Dispose();
            Application.Current.Shutdown();
        }
    }
}
