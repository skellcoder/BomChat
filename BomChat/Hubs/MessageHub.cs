using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SignalR.Hubs;
namespace BomChat.Hubs
{
   [HubName("chat")]
    public class MessageHub : Hub
    {

    }
}