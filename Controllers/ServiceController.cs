using Microsoft.AspNetCore.Mvc;
using QuickFix.web.Interfaces;
using QuickFix.web.Models;

namespace QuickFix.web.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceRepository _repository;

        public ServiceController(IServiceRepository repository)
        {
            _repository = repository;
        }

        // Display all services
        public IActionResult Index()
        {
            var services = _repository.GetAll();
            return View(services);
        }

        // Show Create Form
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        // GET: Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var service = _repository.GetById(id);

            if (service == null)
                return NotFound();

            return View(service);
        }

        // POST: Edit
        [HttpPost]
        public IActionResult Edit(Service service)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(service);
                return RedirectToAction(nameof(Index));
            }

            return View(service);
        }
        // GET: Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var service = _repository.GetById(id);

            if (service == null)
                return NotFound();

            return View(service);
        }

        // POST: Delete
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        // Save Service
        [HttpPost]
        public IActionResult Create(Service service)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(service);
                return RedirectToAction("Index");
            }

            return View(service);
        }
    }
}