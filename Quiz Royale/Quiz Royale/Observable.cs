using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Quiz_Royale
{
    public abstract class Observable: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
