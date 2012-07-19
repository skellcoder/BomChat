using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BomChat.Models
{
    public class MessageRepo : IMessageRepo
    {
        private List<Message> messages = new List<Message>();
        private int _nextId = 1;


        public MessageRepo()
        {

            Add(new Message {  chatId = 1, user = "UserA", message = "UserA says Hello" });
            Add(new Message {  chatId = 1, user = "UserB", message = "UserB says Hi" });
            Add(new Message {  chatId = 1, user = "UserC", message = "UserC says Howdy" });
        
        }

        public IEnumerable<Message> GetAll()
        {
            return messages;
        }

        public Message Get(int id)
        {
            return messages.Find(mess => mess.id == id); 
        }

        public Message Add(Message item)
        {
            item.id = _nextId++;
            messages.Add(item);
            return item;
        }

        public void Remove(int id)
        {
            messages.RemoveAll(mess => mess.id == id);
        }

        public bool Update(Message item)
        {
            int ind = messages.FindIndex(mess => mess.id == item.id);
            if (ind == -1)
            {
                return false;
            }

            messages.RemoveAt(ind);
            messages.Add(item);
            return true;
        }
    }
}