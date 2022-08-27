using ProjectDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class MessageList
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }

        public MessageList()
        {

        }
        public MessageList(Message message)
        {
            Title = message.Title;
            Description = message.Description;
            Price = message.Price;
        }
    }
}
