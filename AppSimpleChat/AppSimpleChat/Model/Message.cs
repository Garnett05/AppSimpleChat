using System;
using System.Collections.Generic;
using System.Text;

namespace AppSimpleChat.Model
{
    public class Message
    {
        public int id { get; set; }
        public int id_chat { get; set; }
        public int id_usuario { get; set; }
        public string mensagem { get; set; }
        public User usuario { get; set; }
    }
}
