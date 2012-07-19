using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BomChat.Models
{
    public class Message
    {
        public int id { get; set; }
        public int chatId { get; set; } 
        public string user { get; set; }
        public string message { get; set; }
       
    }
}