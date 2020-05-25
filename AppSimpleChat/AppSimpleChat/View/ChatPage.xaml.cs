using AppSimpleChat.Model;
using AppSimpleChat.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppSimpleChat.Service;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppSimpleChat.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatPage : ContentPage
    {        
        public ChatPage()
        {
            InitializeComponent();
            BindingContext = new ChatViewModel();
        }        
        //O método override abaixo serve para realizar alguma ação quando a tela aparecer. No exemplo abaixo, realiza novamente a chamada da ViewModel
        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new ChatViewModel();
        }
    }
}