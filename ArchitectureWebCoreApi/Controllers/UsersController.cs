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
        public UsersController(IUserService userService)
        {
            _userService = userService;
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
            var createdUser=await _userService.AddUser(firstName, lastName, password);

            return Ok(createdUser);
        }

        [HttpDelete]
        public void DeleteUserAsync(int userId)
        {
            _userService.Delete(userId);
        }

        

        
    }
}
