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

        public event EventHandler Navigated;

        public NavigationStore(BaseViewModel currentViewModel = null)
        {
            CurrentViewModel = currentViewModel;
        }
    }
}
