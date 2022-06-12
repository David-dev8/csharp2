using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale
{
    public class BaseViewModel : Observable
    {
        protected NavigationStore _navigationStore;
        
        public BaseViewModel(NavigationStore store)
        {
            _navigationStore = store;
        }

        public virtual void Dispose()
        {
        }
    }
}
