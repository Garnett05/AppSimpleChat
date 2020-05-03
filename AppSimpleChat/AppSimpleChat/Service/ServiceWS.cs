using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Http;
using AppSimpleChat.Model;
using Newtonsoft.Json;

namespace AppSimpleChat.Service
{
    public class ServiceWS
    {
        private static string urlBase = "http://ws.spacedu.com.br/xf2018/rest/api";
        //User
        public static User GetUser (User user)
        {
            var url = urlBase + "/usuario";

            //StringContent param = new StringContent(string.Format("?nome={0}&password={1}", user.nome, user.password));
            // Acima é uma maneira alternativa de fazermos oq é possível pela linha debaixo
            FormUrlEncodedContent param = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("nome", user.nome),
                new KeyValuePair<string, string>("password", user.password)
            });


            HttpClient httpRequest = new HttpClient();
            HttpResponseMessage httpResponse = httpRequest.PostAsync(url, param).GetAwaiter().GetResult();
            if (httpResponse.StatusCode == HttpStatusCode.OK)
            {
                //Deserializar, retornar no método e salvar como login
            }
            return null;
        }
        public static List<Chat> GetChats()
        {
            var url = urlBase + "/chats";

            HttpClient request = new HttpClient();
            HttpResponseMessage httpResponse = request.GetAsync(url).GetAwaiter().GetResult();
            if (httpResponse.StatusCode == HttpStatusCode.OK)
            {
                string content = httpResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                List<Chat> list = JsonConvert.DeserializeObject<List<Chat>>(content);
            }
            return null;
        }

    }
}
