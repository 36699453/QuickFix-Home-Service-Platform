using Microsoft.AspNetCore.Mvc;
using QuickFix.web.Data;
using QuickFix.web.Models;

namespace QuickFix.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ServicesApiController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ServicesApi
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Services.ToList());
        }

        // GET: api/ServicesApi/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var service = _context.Services.Find(id);

            if (service == null)
                return NotFound();

            return Ok(service);
        }

        // POST: api/ServicesApi
        [HttpPost]
        public IActionResult Create(Service service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();

            return Ok(service);
        }

        // PUT: api/ServicesApi/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, Service service)
        {
            var existing = _context.Services.Find(id);

            if (existing == null)
                return NotFound();

            existing.ServiceName = service.ServiceName;
            existing.Description = service.Description;
            existing.Price = service.Price;
            existing.ImageUrl = service.ImageUrl;

            _context.SaveChanges();

            return Ok(existing);
        }

        // DELETE: api/ServicesApi/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var service = _context.Services.Find(id);

            if (service == null)
                return NotFound();

            _context.Services.Remove(service);
            _context.SaveChanges();

            return Ok("Service Deleted Successfully");
        }
    }
}