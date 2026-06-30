using QuickFix.web.Data;
using QuickFix.web.Interfaces;
using QuickFix.web.Models;

namespace QuickFix.web.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly AppDbContext _context;

        public BookingRepository(AppDbContext context)
        {
            _context = context;
        }

        // Get All Bookings
        public List<Booking> GetAll()
        {
            return _context.Bookings.ToList();
        }

        // Get Booking By Id
        public Booking? GetById(int id)
        {
            return _context.Bookings.FirstOrDefault(x => x.Id == id);
        }

        // Add Booking
        public void Add(Booking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();
        }

        // Update Booking
        public void Update(Booking booking)
        {
            _context.Bookings.Update(booking);
            _context.SaveChanges();
        }

        // Delete Booking
        public void Delete(int id)
        {
            var booking = _context.Bookings.Find(id);

            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                _context.SaveChanges();
            }
        }
    }
}