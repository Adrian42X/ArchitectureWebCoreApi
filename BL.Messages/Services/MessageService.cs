using Core.Contracts;
using Core.Models;
using Core.Repositories;
using ProjectDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Messages.Services
{
    public class MessageService : IMessageService
    {
        IRepository<Message> _messageRepository;
        public MessageService(IRepository<Message> message)
        {
            _messageRepository = message;
        }

        public List<MessageList> GetAll()
        {
            var DALMessageList = _messageRepository.GetAll();
            return DALMessageList.Select(entity => new MessageList
            {
                Title = entity.Title,
                Description = entity.Description,
            }).ToList();
        }
    }
}
