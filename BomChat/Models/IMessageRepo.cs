using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomChat.Models
{
    interface IMessageRepo
    {
        IEnumerable<Message> GetAll();
        Message Get(int id);
        Message Add(Message item);
        void Remove(int id);
        bool Update(Message item);

    }
}
