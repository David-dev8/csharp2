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

        public ICommand ShowHome { get; set; }

        public ICommand ShowShop { get; set; }

        public ICommand ExitProgram { get; set; }

        public ICommand ShowProfile { get; set; }

        public MainWindowViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            navigationStore.CurrentViewModel = GetFirstViewModel(); 
            _navigationStore.Navigated += (object sender, EventArgs e) =>
            {
                OnPropertyChanged(nameof(CurrentViewModel));
                OnPropertyChanged(nameof(IsInMenu));
            };

            ShowHome = new RelayCommand(SelectHomeAsCurrentPage);
            ShowShop = new RelayCommand(SelectShopAsCurrentPage);
            ExitProgram = new RelayCommand(CloseProgram);
            ShowProfile = new RelayCommand(SelectProfileAsCurrentPage);
        }

        private BaseViewModel GetFirstViewModel()
        {
            return new ProfileViewModel(_navigationStore);
            // Controleer of de gebruiker al een account heeft, dit is het geval wanneer er een access token aanwezig is
         /*   if(Storage.Settings.Credentials?.AccessToken == null)
            {
                return new LoginViewModel(_navigationStore);
            } 
            else
            {
                return new PlayersViewModel(_navigationStore);
            }*/
        }

        private void SelectHomeAsCurrentPage()
        {
            CurrentViewModel = new HomeViewModel(_navigationStore);
        }

        private void SelectShopAsCurrentPage()
        {
            // aanpassen naar shop
            CurrentViewModel = new GameViewModel(_navigationStore);
        }

        private void SelectProfileAsCurrentPage()
        {
            CurrentViewModel = new ProfileViewModel(_navigationStore);
        }

        private void CloseProgram()
        {
            Application.Current.Shutdown();
        }
    }
}
