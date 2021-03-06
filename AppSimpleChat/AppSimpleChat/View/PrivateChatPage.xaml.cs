﻿using AppSimpleChat.Model;
using AppSimpleChat.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppSimpleChat.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrivateChatPage : ContentPage
    {
        public PrivateChatPage(Chat chat)
        {
            InitializeComponent();
            BindingContext = new PrivateChatViewModel(chat, slMessage);
        }
    }
}