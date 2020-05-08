using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Http;
using AppSimpleChat.Model;
using Newtonsoft.Json;
using Xamarin.Forms;

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
                var content = httpResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                return JsonConvert.DeserializeObject<User>(content);
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
                if (content.Length > 2)
                {
                    List<Chat> list = JsonConvert.DeserializeObject<List<Chat>>(content);
                    return list;
                }
                else
                {
                    return null;
                }
                
            }
            return null;
        }
        public static bool InsertChat(Chat chat)
        {
            var url = urlBase + "/chat";

            FormUrlEncodedContent param = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("nome", chat.name),
            });

            HttpClient httpRequest = new HttpClient();
            HttpResponseMessage httpResponse = httpRequest.PostAsync(url, param).GetAwaiter().GetResult();
            if (httpResponse.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }
        public static bool UpdateChatName(Chat chat)
        {
            var url = urlBase + "/chat/" + chat.id;

            FormUrlEncodedContent param = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("nome", chat.name),
            });

            HttpClient httpRequest = new HttpClient();
            HttpResponseMessage httpResponse = httpRequest.PutAsync(url, param).GetAwaiter().GetResult();
            if (httpResponse.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }
        public static bool DeleteChat (Chat chat)
        {
            var url = urlBase + "/chat/delete/" + chat.id;

            HttpClient httpRequest = new HttpClient();
            HttpResponseMessage httpResponse = httpRequest.DeleteAsync(url).GetAwaiter().GetResult();

            if (httpResponse.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }
        public static List<Message> GetMessages(Chat chat)
        {
            var url = urlBase + "/chat/" + chat.id + "/msg"; 

            HttpClient httpRequest = new HttpClient();
            HttpResponseMessage httpResponse = httpRequest.GetAsync(url).GetAwaiter().GetResult();

            if (httpResponse.StatusCode == HttpStatusCode.OK)
            {
                string content = httpResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                if (content.Length > 2)
                {
                    List<Message> list = JsonConvert.DeserializeObject<List<Message>>(content);
                    return list;
                }
            }
            return null;
        }
        public static bool InsertMessage (Message message)
        {
            var url = urlBase + "/chat/" + message.id_chat + "/msg";

            FormUrlEncodedContent param = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("nome", message.message),
                new KeyValuePair<string, string>("nome", message.id_usuario.ToString())
            });

            HttpClient httpRequest = new HttpClient();
            HttpResponseMessage httpResponse = httpRequest.PostAsync(url, param).GetAwaiter().GetResult();

            if (httpResponse.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }
        public static bool DeleteMessage (Message message)
        {
            var url = urlBase + "/chat/" + message.id_chat + "/`delete/" + message.id;
            
            HttpClient httpRequest = new HttpClient();
            HttpResponseMessage httpResponse = httpRequest.DeleteAsync(url).GetAwaiter().GetResult();

            if (httpResponse.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }
    }
}
