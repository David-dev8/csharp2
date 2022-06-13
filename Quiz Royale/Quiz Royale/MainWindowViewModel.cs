using System;
using System.Windows;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Microsoft.Toolkit.Helpers;

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


        public ICommand ShowProfile { get; set; }

        public ICommand Dismiss { get; set; }

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

        private void SelectHomeAsCurrentPage()
        {
            CurrentViewModel = new HomeViewModel(_navigationStore);
        }

        private void SelectShopAsCurrentPage()
        {
            CurrentViewModel = new ShopViewModel(_navigationStore);
        }

        private void SelectProfileAsCurrentPage()
        {
            CurrentViewModel = new ProfileViewModel(_navigationStore);
        }

        private void CloseProgram()
        {
            CurrentViewModel.Dispose(); // todo
            Application.Current.Shutdown();
        }
    }
}
