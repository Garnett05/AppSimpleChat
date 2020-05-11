using AppSimpleChat.Model;
using AppSimpleChat.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using AppSimpleChat.Util;

namespace AppSimpleChat.ViewModel
{
    public class PrivateChatViewModel : INotifyPropertyChanged
    {
        private StackLayout _stackLayout;
        private List<Message> _messages;
        public List<Message> Messages
        {
            get { return _messages; }
            set
            {
                _messages = value;
                OnPropertyChanged("Messages");
                ShowOnScreen();
            }
        }
        public PrivateChatViewModel(Chat chat, StackLayout slMessage)
        {
            _stackLayout = slMessage;
            Messages = ServiceWS.GetMessages(chat);
        }

        private void ShowOnScreen()
        {
            var loggedUser = UserUtil.GetLoggedUser();
            _stackLayout.Children.Clear();            
            foreach (var msg in Messages)
            {
                if (msg.id_usuario == loggedUser.id)
                {
                    _stackLayout.Children.Add(CreateSenderMessage(msg));
                }
                else
                {
                    _stackLayout.Children.Add(CreateRecipientMessage(msg));
                }
            }
        }
        private Xamarin.Forms.View CreateSenderMessage(Message message) // Minhas mensagens
        {
            Frame frame = new Frame() { CornerRadius = 0, HorizontalOptions = LayoutOptions.End, VerticalOptions = LayoutOptions.Center, BackgroundColor = Color.LightGreen };
            StackLayout stackLayout = new StackLayout() { Padding = 5 };
            Label label1 = new Label() { TextColor = Color.White, FontSize = 16, Text = message.message };

            stackLayout.Children.Add(label1);
            frame.Content = stackLayout;

            return frame;
        }
        private Xamarin.Forms.View CreateRecipientMessage(Message message) // Mensagens de outra(s) pessoa(s)
        {
            Frame frame = new Frame() { HorizontalOptions = LayoutOptions.Start, VerticalOptions = LayoutOptions.Center, BorderColor = Color.LightGreen };
            StackLayout stackLayout = new StackLayout() { Spacing = 0 };
            Label label1 = new Label() { Text = "User name", FontSize = 10, TextColor = Color.LightGreen };
            Label label2 = new Label() { Text = message.message, TextColor = Color.LightGreen };

            stackLayout.Children.Add(label1);
            stackLayout.Children.Add(label2);
            frame.Content = stackLayout;

            return frame;
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