using Blog.Entities;

namespace Blog.Interfaces
{
    public interface IPostsService
    {
        public IEnumerable<Post> GetPost(int? id);
        public string CreatePost(Post Post);
        public string EditPost(int id, Post Post);
        public string DeletePost(int? id);
    }
}
