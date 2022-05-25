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
                OnPropertyChanged();
            }
        }

        public ICommand ShowHome { get; set; }

        public ICommand ShowShop { get; set; }

        public ICommand ExitProgram { get; set; }

        public MainWindowViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            navigationStore.CurrentViewModel = new HomeViewModel(navigationStore);
            _navigationStore.Navigated += (object sender, EventArgs e) =>
            {
                OnPropertyChanged(nameof(CurrentViewModel));
            };

            ShowHome = new RelayCommand(SelectHomeAsCurrentPage);
            ShowShop = new RelayCommand(SelectShopAsCurrentPage);
            ExitProgram = new RelayCommand(CloseProgram);
        }

        private void SelectHomeAsCurrentPage()
        {
            CurrentViewModel = new HomeViewModel(_navigationStore);
        }

        private void SelectShopAsCurrentPage()
        {
            CurrentViewModel = new ShopViewModel(_navigationStore);
        }

        private void CloseProgram()
        {
            Application.Current.Shutdown();
        }
    }
}
