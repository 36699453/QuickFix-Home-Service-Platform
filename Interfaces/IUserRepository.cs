using QuickFix.web.Models;

namespace QuickFix.web.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAll();

        User? GetByEmail(string email);

        User? Login(string email, string password);

        void Register(User user);
    }
}