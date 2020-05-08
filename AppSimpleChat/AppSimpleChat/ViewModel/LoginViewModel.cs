using AppSimpleChat.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using AppSimpleChat.Service;
using Newtonsoft.Json;
using AppSimpleChat.View;

namespace AppSimpleChat.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _name;
        private string _password;
        private string _messageError;
        public string Name { get { return _name; } 
            set { _name = value; 
                PropertyChanged(this, new PropertyChangedEventArgs("Name")); 
            } }
        public string Password { get { return _password; }
            set { _password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password")); 
            } }        
        public string MessageError { get { return _messageError; } 
            set { _messageError = value;
                PropertyChanged(this, new PropertyChangedEventArgs("MessageError"));
            } }

        public Command LoginCommand { get; set; }
        public LoginViewModel()
        {
            LoginCommand = new Command(Access);
        }

        private void Access()
        {
            User user = new User { nome = Name, password = Password };   
            var userLogged = ServiceWS.GetUser(user);
            if (userLogged == null)
            {
                MessageError = "Error. Password incorrect";
            }
            else
            {
                App.Current.Properties["LOGIN"] = JsonConvert.SerializeObject(userLogged);
                App.Current.MainPage = new NavigationPage(new ChatPage());
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
