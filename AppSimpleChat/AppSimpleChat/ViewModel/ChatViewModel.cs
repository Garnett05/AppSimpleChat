using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using AppSimpleChat.Model;
using AppSimpleChat.Service;
using Xamarin.Forms;
using System.Linq;
using AppSimpleChat.View;

namespace AppSimpleChat.ViewModel
{
    public class ChatViewModel : INotifyPropertyChanged
    {
        private List<Chat> _chats;
        private Chat _selectedItem;
        public List<Chat> Chats { 
            get { return _chats; } 
            set { _chats = value;
                OnPropertyChanged("Chats");                
            } }
        public Chat SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged("SelectedItem");
                GoPrivateMessagePage(value);
            }
        }
        public Command AddCommand { get; set; }
        public Command SortCommand { get; set; }
        public Command RefreshCommand { get; set; }
        public ChatViewModel()
        {
            Chats = ServiceWS.GetChats();
            AddCommand = new Command(AddChat);
            SortCommand = new Command(SortChat);
            RefreshCommand = new Command(RefreshChat);
        }

        private void AddChat()
        {
            ((NavigationPage)App.Current.MainPage).Navigation.PushAsync(new CreateChat());
        }
        private void SortChat()
        {
            Chats = Chats.OrderBy(x => x.nome).ToList();
        }
        private void RefreshChat()
        {
            Chats = ServiceWS.GetChats();
        }
        private void GoPrivateMessagePage(Chat chat)
        {
            if(chat != null)
            {
                ((NavigationPage)App.Current.MainPage).Navigation.PushAsync(new PrivateChatPage(chat));
            }            
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
