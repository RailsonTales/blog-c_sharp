using System.ComponentModel.DataAnnotations;

namespace Blog.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? CreatedDate { get; set; }

        public User() { }

        public User(int id, string name, string email, string password, DateTime? createdDate)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            CreatedDate = createdDate;
        }
    }
}