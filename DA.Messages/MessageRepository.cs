using Core.Repositories;
using ProjectDatabase.Context;
using ProjectDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Messages
{
    public class MessageRepository : IRepository<Message>
    {
        private readonly ProjectContext _projectContext;
        public MessageRepository(ProjectContext context)
        {
            _projectContext = context;
        }

        public Message Add(Message entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Message FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Message FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public Message Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Message> GetAll()
        {
            return _projectContext.Messsages;
        }

        public Message Update(Message entity)
        {
            throw new NotImplementedException();
        }
    }
}
