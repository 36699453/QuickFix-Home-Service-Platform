using QuickFix.web.Data;
using QuickFix.web.Interfaces;
using QuickFix.web.Models;

namespace QuickFix.web.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User? GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(x => x.Email == email);
        }

        public User? Login(string email, string password)
        {
            return _context.Users.FirstOrDefault(x =>
                x.Email == email &&
                x.Password == password);
        }

        public void Register(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}