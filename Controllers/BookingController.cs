using Microsoft.AspNetCore.Mvc;
using QuickFix.web.Interfaces;
using QuickFix.web.Models;

namespace QuickFix.web.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingRepository _repository;

        public BookingController(IBookingRepository repository)
        {
            _repository = repository;
        }

        // Booking List
        public IActionResult Index()
        {
            var bookings = _repository.GetAll();
            return View(bookings);
        }

        // Create Booking
        [HttpGet]
        public IActionResult Create(int id = 0)
        {
            var booking = new Booking
            {
                ServiceId = id,
                BookingDate = DateTime.Today
            };

            return View(booking);
        }

        [HttpPost]
        public IActionResult Create(Booking booking)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(booking);
                return RedirectToAction(nameof(Success));
            }

            return View(booking);
        }

        // Success Page
        public IActionResult Success()
        {
            return View();
        }

        // Edit Booking
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var booking = _repository.GetById(id);

            if (booking == null)
                return NotFound();

            return View(booking);
        }

        [HttpPost]
        public IActionResult Edit(Booking booking)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(booking);

                return RedirectToAction(nameof(Index));
            }

            return View(booking);
        }

        // Delete Booking
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var booking = _repository.GetById(id);

            if (booking == null)
                return NotFound();

            return View(booking);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}