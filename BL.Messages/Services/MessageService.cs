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
        IMessageRepository _messageRepository;
        public MessageService(IMessageRepository message)
        {
            _messageRepository = message;
        }

        public async Task<Message> CreateMessage(int userId, string title, string description, float price)
        {
            return await _messageRepository.CreateMessage(userId, title, description, price);
        }

        public async Task DeleteMessage(int id)
        {
            var message = await _messageRepository.GetById(id);

            if(message == null)
            {
                throw new InvalidOperationException("Message not found");
            }
            await _messageRepository.DeleteMessage(message);
        }

        public IEnumerable<Message> GetAllMessages(int offset, int limit)
        {
            return _messageRepository.GetAll(offset, limit);
        }

        public IEnumerable<Message> GetAllMessagesForUser(int userId, int offset, int limit)
        {
            return _messageRepository.GetAllForUser(userId, offset, limit);
        }

        public Task<Message> GetById(int id)
        {
            var message = _messageRepository.GetById(id);
            if(message == null)
            {
                throw new InvalidOperationException("Message not found");
            }
            return message;
        }

        public async Task<Message> UpdateMessage(int id, string description, float price)
        {
            var messagetoUpdate =await _messageRepository.GetById(id);
            if(messagetoUpdate == null)
            {
                throw new InvalidOperationException("Message not found");
            }

            messagetoUpdate.Description = description;
            messagetoUpdate.Price = price;
            var updatedMessage=await _messageRepository.UpdateMessage(messagetoUpdate);
            return updatedMessage;
        }
    }
}
