using System;
using System.Windows;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;

namespace Quiz_Royale
{
    public class MainWindowViewModel: Observable
    {
        private readonly NavigationStore _navigationStore;

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

        public bool IsInMenu
        {
            get
            {
                return _navigationStore.IsInMenu;
            }
        }

        public string Error
        {
            get
            {
                return _navigationStore.Error;
            }
        }

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

        public ICommand Dismiss { get; set; }

        public MainWindowViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            navigationStore.CurrentViewModel = GetFirstViewModel();
            NotifyForUpdates();

            ShowHome = new RelayCommand(SelectHomeAsCurrentPage);
            ShowShop = new RelayCommand(SelectShopAsCurrentPage);
            ExitProgram = new RelayCommand(CloseProgram);
            Dismiss = new RelayCommand(DismissAllErrors);
        }

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

        private void DismissAllErrors()
        {
            _navigationStore.Error = null;
        }

        private BaseViewModel GetFirstViewModel()
        {
            // Controleer of de gebruiker al een account heeft, dit is het geval wanneer er een access token aanwezig is
            if(Storage.Settings.Credentials?.AccessToken == null)
            {
                return new LoginViewModel(_navigationStore);
            } 
            else
            {
                return new ShopViewModel(_navigationStore);
            }
        }

        private void SelectHomeAsCurrentPage()
        {
            CurrentViewModel = new HomeViewModel(_navigationStore);
        }

        private void SelectShopAsCurrentPage()
        {
            // aanpassen naar shop todo
            CurrentViewModel = new GameViewModel(_navigationStore);
        }

        private void CloseProgram()
        {
            Application.Current.Shutdown();
        }
    }
}
