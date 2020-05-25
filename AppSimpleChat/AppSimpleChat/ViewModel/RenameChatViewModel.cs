using AppSimpleChat.Model;
using AppSimpleChat.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppSimpleChat.ViewModel
{
    public class RenameChatViewModel : INotifyPropertyChanged
    {
        private string _chatName;
        private string _newChatName;
        private string _message;
        private Chat _chat;
        public string NewChatName
        {
            get { return _newChatName; }
            set
            {
                _newChatName = value;
                OnPropertyChanged("NewChatName");
            }
        }
        public string ChatName {
            get { return _chatName; }
            set {
                _chatName = value;
                OnPropertyChanged("ChatName");
            }
        }
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged("Message");
            }
        }

        public ICommand RenameCommand => new Command(() => RenameChat());

        public RenameChatViewModel(Chat chat)
        {
            ChatName = chat.nome;
            _chat = chat;
        }
        private void RenameChat()
        {
            _chat.nome = NewChatName;
            ServiceWS.UpdateChatName(_chat);
            Message = "Chat sucessfully renamed!";
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
