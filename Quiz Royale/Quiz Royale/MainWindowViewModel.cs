using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale
{
    public class MainWindowViewModel
    {
        private readonly NavigationStore _navigationStore;

        public BaseViewModel CurrentViewModel 
        {
            get
            {
                return _navigationStore.CurrentViewModel;
            }
        }

        public MainWindowViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            navigationStore.CurrentViewModel = new HomeViewModel(navigationStore);
        }

        private void changeResource()
        {
            

        } 
    }
}
