using Microsoft.AspNetCore.Mvc;
using Blog.Entities;
using Blog.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Blog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet(Name = "GetUsers")]
        [Authorize]
        public IEnumerable<User> GetUsers(int? id)
        {
            return _usersService.GetUsers(id);
        }

        [HttpPost(Name = "CreateUser")]
        [AllowAnonymous]
        public string CreateUser([Bind("Id,Name,Email,Password,CreatedDate")] User user)
        {
            return _usersService.CreateUser(user);
        }

        [HttpPut(Name = "EditUser")]
        [Authorize]
        public string EditUser(int id, [Bind("Id,Name,Email,Password,CreatedDate")] User user)
        {
            return _usersService.EditUser(id, user);
        }

        [HttpDelete(Name = "DeleteUser")]
        [Authorize]
        public string DeleteUser(int? id)
        {
            return _usersService.DeleteUser(id);
        }
    }
}
