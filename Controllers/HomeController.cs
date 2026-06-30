using Microsoft.AspNetCore.Mvc;
using QuickFix.web.Interfaces;
using QuickFix.web.Models;
using System.Diagnostics;

namespace QuickFix.web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServiceRepository _repository;

        public HomeController(IServiceRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var services = _repository.GetAll();
            return View(services);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}