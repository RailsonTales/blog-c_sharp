using Blog.Entities;
using Blog.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blog.Services
{
    public class UsersService : AppDbContext, IUsersService
    {
        public readonly AppDbContext _context;

        public UsersService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetUsers(int? id)
        {
            if (id == null)
                return _context.Users.ToList();
            else
                return _context.Users.Where(u => u.Id == id);
        }

        public string CreateUser(User user)
        {
            if (user == null)
                return "Preencher os campos de usuário";
                        
            _context.Add(user);
            _context.SaveChanges();
            return "Usuário criado com sucesso";
            
        }

        public string EditUser(int id, User user)
        {
            if (id != user.Id)
            {
                return "erro";
            }

            try
            {
                _context.Update(user);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return "Usuário atualizado com sucesso";
        }

        public string DeleteUser(int? id)
        {
            if (id == null)
            {
                return "campo de usuário vazio";
            }

            var user = _context.Users.FirstOrDefault(m => m.Id == id);
            if (user == null)
            {
                return "usuário não encontrado";
            }

            try
            {
                _context.Remove(user);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return "usuário deletado com sucesso";
        }
        public User Login(string name, string password)
        {
            return _context.Users.Where(u => u.Name == name && u.Password == password).FirstOrDefault();
        }
    }
}
