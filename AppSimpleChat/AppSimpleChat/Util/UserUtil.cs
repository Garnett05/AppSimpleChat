using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Newtonsoft.Json;
using AppSimpleChat.Model;

namespace AppSimpleChat.Util
{
    public class UserUtil
    {
        public static void SetLoggedUser(User user)
        {
            App.Current.Properties["LOGIN"] = JsonConvert.SerializeObject(user);
        }
        public static User GetLoggedUser()
        {
            if (App.Current.Properties.ContainsKey("LOGIN")){
                return JsonConvert.DeserializeObject<User>((string)App.Current.Properties["LOGIN"]);
            }

            else
            {
                return null;
            }
        }
    }
}
