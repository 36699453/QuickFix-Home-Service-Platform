using QuickFix.web.Models;

namespace QuickFix.web.Interfaces
{
    public interface IServiceRepository
    {
        List<Service> GetAll();

        Service? GetById(int id);

        void Add(Service service);

        void Update(Service service);

        void Delete(int id);
    }
}