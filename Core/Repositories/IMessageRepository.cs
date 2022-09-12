using ProjectDatabase.Models;
namespace Core.Repositories
{
    public interface IMessageRepository
    {
        Task<Message> CreateMessage(int userId,string title,string description,float price);
        Task<Message> UpdateMessage(Message message);
        Task DeleteMessage(Message message);
        Task<Message> GetById(int messageId);
        IEnumerable<Message> GetAll(int offset,int limit);
        IEnumerable<Message> GetAllForUser(int userId,int offset,int limit);
    }
}
