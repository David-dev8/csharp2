using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale
{
    public class NavigationStore
    {
        private BaseViewModel _currentViewModel;
        public BaseViewModel CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                _currentViewModel = value;
                if (value != null)
                {
                    Navigated?.Invoke(this, EventArgs.Empty);
                }
            }
        }


        private bool _isInMenu;

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

        private string _error;

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

        private bool _isLoading;

        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                _isLoading = value;
                Navigated?.Invoke(this, EventArgs.Empty);
            }
        }

        public event EventHandler Navigated;

        public NavigationStore(BaseViewModel currentViewModel = null)
        {
            CurrentViewModel = currentViewModel;
            IsInMenu = false;
        }
    }
}
