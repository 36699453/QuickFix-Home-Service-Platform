using Microsoft.AspNetCore.Mvc;
using QuickFix.web.Data;
using QuickFix.web.Models;

namespace QuickFix.web.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Dashboard()
        {
            DashboardViewModel dashboard = new DashboardViewModel
            {
                TotalUsers = _context.Users.Count(),

                TotalServices = _context.Services.Count(),

                TotalBookings = _context.Bookings.Count(),

                RecentBookings = _context.Bookings
                    .OrderByDescending(x => x.BookingDate)
                    .Take(5)
                    .ToList()
            };

            return View(dashboard);
        }
    }
}