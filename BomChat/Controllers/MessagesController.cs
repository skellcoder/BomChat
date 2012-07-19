using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using BomChat.Hubs;



using BomChat.Models;

namespace BomChat.Controllers
{

    public class MessagesController : ApiControllerWithAHub<MessageHub>
    {
   
        static readonly IMessageRepo messRepo = new MessageRepo();
        //GET
        public IEnumerable<Message> GetMessages() {
            return messRepo.GetAll();
        
        }
       
            

        public IEnumerable<Message> GetMessagesByChatID(int chatId)
        {
               return messRepo.GetAll();
        }


        //POST
        public HttpResponseMessage PostMessage(Message item)
        {
           // HttpRequestMessage<Message> a = new HttpRequestMessage<Message>
            item = messRepo.Add(item);
            var response = Request.CreateResponse<Message>(HttpStatusCode.Created, item);

            Hub.Clients.addedMessage(item);

            string uri = Url.Link("DefaultApi", new { id = item.id });
            response.Headers.Location = new Uri(uri);
            return response;
        }
        public void PutMessage(int id, Message item)
        {
            item.id = id;
            if (!messRepo.Update(item))
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
        }
        public HttpResponseMessage DeleteMessage(int id)
        {
            messRepo.Remove(id);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

    }
}
