using Core.Models;

namespace Core.Contracts
{
    public interface IMessageService
    {
        List<MessageList> GetAll();
    }
}
