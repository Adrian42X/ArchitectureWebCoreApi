using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using ProjectDatabase.Context;
using ProjectDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Messages
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ProjectContext _projectContext;
        public MessageRepository(ProjectContext context)
        {
            _projectContext = context;
        }

        public async Task<Message> CreateMessage(int userId, string title, string description,float price)
        {
            Message message = new Message
            {
                UserId = userId,
                Title = title,
                Price = price,
                Description = description
            };

            _projectContext.Messsages.Add(message);
            await _projectContext.SaveChangesAsync();
            return message;
        }

        public Task DeleteMessage(Message message)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Message> GetAll(int offset, int limit)
        {
            return _projectContext.Messsages.Include(prop=>prop.User).Skip(offset).Take(limit);
        }

        public IEnumerable<Message> GetAllForUser(int userId, int offset, int limit)
        {
            return _projectContext.Messsages.Include(p=>p.User).Where(p => p.UserId == userId).Skip(offset).Take(limit);
        }

        public async Task<Message?> GetById(int messageId)
        {
           return await _projectContext.Messsages.Include(p => p.User).SingleOrDefaultAsync(p => p.Id == messageId);
        }    

        public Task<Message> UpdateMessage(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
