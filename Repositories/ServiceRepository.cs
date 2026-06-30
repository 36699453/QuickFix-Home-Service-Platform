using Microsoft.EntityFrameworkCore;
using QuickFix.web.Data;
using QuickFix.web.Interfaces;
using QuickFix.web.Models;

namespace QuickFix.web.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly AppDbContext _context;

        public ServiceRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Service> GetAll()
        {
            return _context.Services.ToList();
        }

        public Service? GetById(int id)
        {
            return _context.Services.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Service service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();
        }

        public void Update(Service service)
        {
            _context.Services.Update(service);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var service = _context.Services.Find(id);

            if (service != null)
            {
                _context.Services.Remove(service);
                _context.SaveChanges();
            }
        }
    }
}