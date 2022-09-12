using Core.Models;
using ProjectDatabase.Models;

namespace Core.Contracts
{
    public interface IMessageService
    {
        public Task<Message> CreateMessage(int userId, string title, string description, float price);
        public Task<Message> UpdateMessage(int id, string description, float price);
        public Task DeleteMessage(int id);
        public Task<Message> GetById(int id);
        public IEnumerable<Message> GetAllMessages(int offset,int limit);
        public IEnumerable<Message> GetAllMessagesForUser(int userId,int offset,int limit);
    }
}
