using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AppSimpleChat.ViewModel
{
    public class PrivateChatViewModel : INotifyPropertyChanged
    {
        public PrivateChatViewModel()
        {
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
