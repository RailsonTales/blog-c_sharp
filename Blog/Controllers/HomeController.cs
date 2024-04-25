using Blog.Entities;
using Blog.Interfaces;
using Blog.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Blog.Controllers
{
    public class HomeController
    {
        private readonly IUsersService _usersService;
        private readonly TokenService _tokenService;

        public HomeController(IUsersService usersService, TokenService tokenService)
        {
            _usersService = usersService;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> login([FromBody] User model)
        {
            var user = _usersService.Login(model.Name, model.Password);

            if (user == null)
                return HttpStatusCode.NotFound;

            var token = _tokenService.Generate(user);

            user.Password = "";

            return new
            {
                user = user,
                token = token
            };
        }
    }
}
