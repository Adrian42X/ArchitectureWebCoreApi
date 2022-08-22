using Core.Contracts;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

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
    }
}
