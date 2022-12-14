using Core.Contracts;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using ProjectDatabase.Models;
using System.ComponentModel.DataAnnotations;

namespace ArchitectureWebCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UsersController> _logger;
        public UsersController(IUserService userService, ILogger<UsersController> logger)
        {
            _userService = userService;
            _logger = logger;
        }
        [HttpGet]

        public ActionResult<IEnumerable<UserList>> GetUsers([Range(0,int.MaxValue)] int offset=0,[Range(0,100)]int limit=10)
        {
            return Ok(_userService.GetAll(offset,limit));
        }

        [HttpGet]
        [Route("{userId}")]
        public async Task<ActionResult<UserList>> GetUserById([Required][FromRoute]int userId)
        {
            var user = await _userService.GetById(userId);
            if(user == null)
            {
                _logger.LogWarning("Can't find user with id={userId}",userId);
                return NotFound();
            }
            return Ok(user);
        }
        

        [HttpPost]
        public async Task<ActionResult<UserList>> AddUser(
            [Required][FromForm]string firstName,
            [Required][FromForm] string lastName,
            [Required][FromForm] string password)
        {
            string username=firstName+lastName;
            var createdUser=await _userService.AddUser(firstName, lastName, password,username);

            return Ok(createdUser);
        }

        [HttpPatch]
        [Route("{userId}")]
        public async Task<ActionResult<UserList>> UpdateUser(
            [Required][FromRoute] int userId,
            [Required][FromForm] string firstname,
            [Required][FromForm] string lastname)
        {
            var user=await _userService.GetById(userId);
            if(user==null)
            {
                _logger.LogWarning("Can't find user with id={userId}",userId);
                return NotFound();
            }
            var updatedUser= await _userService.UpdateUser(userId, firstname, lastname);
            return Ok(updatedUser);
        }

        [HttpDelete]
        [Route("{userId}")]

        public async Task<ActionResult<UserList>> DeleteUser([Required][FromRoute] int userId)
        {
           var user= await _userService.GetById(userId);
           if(user==null)
           {
              _logger.LogWarning("Can't find user with id={userId}", userId);
                return NotFound();
           }
           await _userService.DeleteUser(userId);
           return Ok(user);
        }
        
    }
}
