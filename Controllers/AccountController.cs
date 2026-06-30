using Microsoft.AspNetCore.Mvc;
using QuickFix.web.Interfaces;
using QuickFix.web.Models;

namespace QuickFix.web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserRepository _repository;

        public AccountController(IUserRepository repository)
        {
            _repository = repository;
        }

        // ===========================
        // REGISTER
        // ===========================

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (!ModelState.IsValid)
                return View(user);

            var existingUser = _repository.GetByEmail(user.Email);

            if (existingUser != null)
            {
                ViewBag.Message = "Email already exists!";
                return View(user);
            }

            _repository.Register(user);

            TempData["Success"] = "Registration Successful! Please Login.";

            return RedirectToAction(nameof(Login));
        }

        // ===========================
        // LOGIN
        // ===========================

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _repository.Login(email, password);

            if (user == null)
            {
                ViewBag.Message = "Invalid Email or Password";
                return View();
            }

            // ===========================
            // CREATE SESSION
            // ===========================

            HttpContext.Session.SetString("UserName", user.FullName);
            HttpContext.Session.SetString("UserEmail", user.Email);
            HttpContext.Session.SetString("UserRole", user.Role);

            return RedirectToAction("Index", "Home");
        }

        // ===========================
        // LOGOUT
        // ===========================

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction(nameof(Login));
        }
    }
}