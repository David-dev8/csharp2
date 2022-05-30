using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale
{
    public class BaseViewModel : Observable
    {
        public NavigationStore NavigationStore { get; set; }
        
        public BaseViewModel(NavigationStore store)
        {
            NavigationStore = store;
        }


    }
}
