using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Entities
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int UserId { get; set; }

        public Post() { }

        public Post (int id, string message, DateTime? createdDate, DateTime? updatedDate, int userId) 
        {
            Id = id;
            Message = message;
            CreatedDate = createdDate;
            UpdatedDate = updatedDate;
            UserId = userId;
        }
    }
}
