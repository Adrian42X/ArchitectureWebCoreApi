using Core.Contracts;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace ArchitectureWebCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;
        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public IEnumerable<MessageList> MessagesAsync()
        {
            return _messageService.GetAll();
        }
    }
}
