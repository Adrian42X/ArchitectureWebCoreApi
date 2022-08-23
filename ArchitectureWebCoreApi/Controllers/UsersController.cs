using Core.Contracts;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using ProjectDatabase.Models;

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

        public IEnumerable<UserList> UsersAsync()
        {
            return _userService.GetAll();
        }
        

        [HttpPost]
        public void AddUserAsync(User newUser)
        {
            _userService.Add(newUser);
        }

        [HttpDelete]
        public void DeleteUserAsync(int userId)
        {
            _userService.Delete(userId);
        }

        [HttpPut]

        public void Update(User user)
        {
            _userService.Update(user);
        }
    }
}
