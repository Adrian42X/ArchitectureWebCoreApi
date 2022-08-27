using Core.Contracts;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using ProjectDatabase.Models;
using System.ComponentModel.DataAnnotations;

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
        public IEnumerable<MessageList> GetMessages([Range(0,int.MaxValue)] int offset = 0,[Range(0,100)] int limit = 2)

        {
            return _messageService.GetAll(offset,limit);
        }
        
    }
}
