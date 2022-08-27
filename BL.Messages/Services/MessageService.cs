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

        public List<MessageList> GetAll(int offset,int limit)
        {
            var DALMessageList = _messageRepository.GetAll(offset,limit);
            return DALMessageList.Select(entity => new MessageList(entity)).ToList();
        }
    }
}
