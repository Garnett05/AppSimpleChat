using AppSimpleChat.Model;
using AppSimpleChat.Service;
using AppSimpleChat.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace AppSimpleChat.ViewModel
{
    public class CreateChatViewModel : INotifyPropertyChanged
    {
        private string _messageError;
        public string ChatName { get; set; }
        public string MessageError { 
            get { return _messageError; } 
            set { _messageError = value;
                OnPropertyChanged("MessageError");
            } }
        public Command CreateChatCommand { get; set; }


        public CreateChatViewModel()
        {
            CreateChatCommand = new Command(CreateChat);
        }

        private void CreateChat()
        {
            Chat chat = new Chat() { nome = ChatName };
            bool done = ServiceWS.InsertChat(chat);
            if (done == true)
            {                
                ((NavigationPage)App.Current.MainPage).Navigation.PopAsync();
            }
            else
            {
                MessageError = "An error occured in registration";
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
