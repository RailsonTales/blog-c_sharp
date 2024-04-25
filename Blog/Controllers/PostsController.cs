using Microsoft.AspNetCore.Mvc;
using Blog.Entities;
using Blog.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Blog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IPostsService _postsService;

        public PostsController(IPostsService postsService)
        {
            _postsService = postsService;
        }

        [HttpGet(Name = "GetPosts")]
        [AllowAnonymous]
        public IEnumerable<Post> GetPosts(int? id)
        {
            return _postsService.GetPost(id);
        }

        [HttpPost(Name = "CreatePost")]
        [Authorize]
        public string CreatePost([Bind("Id,Name,Email,Password,CreatedDate")] Post post)
        {
            return _postsService.CreatePost(post);
        }

        [HttpPut(Name = "EditPost")]
        [Authorize]
        public string EditPost(int id, [Bind("Id,Name,Email,Password,CreatedDate")] Post post)
        {
            return _postsService.EditPost(id, post);
        }

        [HttpDelete(Name = "DeletePost")]
        [Authorize]
        public string DeletePost(int? id)
        {
            return _postsService.DeletePost(id);
        }
    }
}
