using Microsoft.EntityFrameworkCore;
using QuickFix.web.Models;

namespace QuickFix.web.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Service> Services { get; set; }

        public DbSet<Booking> Bookings { get; set; }

        public DbSet<User> Users { get; set; }
    }
}