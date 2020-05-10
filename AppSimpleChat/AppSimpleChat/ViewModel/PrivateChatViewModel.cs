using AppSimpleChat.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AppSimpleChat.ViewModel
{
    public class PrivateChatViewModel : INotifyPropertyChanged
    {
        public PrivateChatViewModel(Chat chat)
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }
    }
}