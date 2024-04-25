using Blog.Entities;

namespace Blog.Interfaces
{
    public interface IUsersService
    {
        public IEnumerable<User> GetUsers(int? id);
        public string CreateUser(User user);
        public string EditUser(int id, User user);
        public string DeleteUser(int? id);
        public User Login(string name, string password);
    }
}
