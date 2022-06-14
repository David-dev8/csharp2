using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Royale
{
    /// <summary>
    /// Deze klasse dient als basis voor elke ViewModel in de applicatie.
    /// </summary>
    public class BaseViewModel : Observable
    {
        protected NavigationStore _navigationStore;
        
        /// <summary>
        /// Creëert een basis ViewModel met een gegeven navigationStore.
        /// </summary>
        /// <param name="store"></param>
        public BaseViewModel(NavigationStore store)
        {
            _navigationStore = store;
        }

        /// <summary>
        /// Zorgt ervoor dat alle resources netjes worden opgeruimd en er geen verwijzingen meer aanwezig zijn.
        /// </summary>
        public virtual void Dispose()
        {
        }
    }
}
