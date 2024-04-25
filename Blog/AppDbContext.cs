using Blog.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Blog
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=RAILSON-PC;Database=Blog;Trusted_Connection=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().HasKey(u => u.Id);
            builder.Entity<Post>().HasKey(p => p.Id);
        }
    }
}
