using Core.Contracts;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectDatabase.Models;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

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
  
        public ActionResult<IEnumerable<Message>> GetMessages([Range(0,int.MaxValue)] int offset = 0,[Range(0,100)] int limit = 20)
        {
            var messages=_messageService.GetAllMessages(offset, limit).ToList();
            return Ok(messages.Select(p => new MessageList(p)));
        }

        [HttpGet]
        [Route ("{userId}")]
        public ActionResult<IEnumerable<Message>> GetMessagesForUser([Required][FromRoute]int userId, int offset=0,int limit=3)
        {
            var messages= _messageService.GetAllMessagesForUser(userId,offset,limit).ToList();
            return Ok(messages.Select(p => new MessageList(p)));    
        }

        [HttpPost]
        
        public async Task<ActionResult<Message>> CreateMessage([Required][FromForm] string title,
            [Required][FromForm]string description, [Required][FromForm]float price)
        {
            string userIdString = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            int userId=int.Parse(userIdString);

            var createMessage=await _messageService.CreateMessage(userId,title,description,price);
            return Ok(createMessage);
        }
        
    }
}
