using Blog.Entities;
using Blog.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.WebSockets;
using System.Text;

namespace Blog.Services
{
    public class PostsService : AppDbContext, IPostsService
    {
        public readonly AppDbContext _context;

        public PostsService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Post> GetPost(int? id)
        {
            if (id == null)
                return _context.Posts.ToList();
            else
                return _context.Posts.Where(u => u.Id == id);
        }

        public string CreatePost(Post post)
        {
            if (post == null)
                return "Preencher os campos de post";
                        
            _context.Add(post);
            _context.SaveChanges();

            // disparo de mensagem para o WebSockets
            var retornoWebSockets = EnviarMensagemWebSockets.Conectando(post.Message);
            System.Diagnostics.Debug.WriteLine(retornoWebSockets);

            return "Post criado com sucesso";            
        }

        public string EditPost(int id, Post post)
        {
            if (id != post.Id)
            {
                return "erro";
            }

            try
            {
                _context.Update(post);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return "Post atualizado com sucesso";
        }

        public string DeletePost(int? id)
        {
            if (id == null)
            {
                return "campo de post vazio";
            }

            var post = _context.Posts.FirstOrDefault(m => m.Id == id);
            if (post == null)
            {
                return "post não encontrado";
            }

            try
            {
                _context.Remove(post);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return "post deletado com sucesso";
        }
    }
}
