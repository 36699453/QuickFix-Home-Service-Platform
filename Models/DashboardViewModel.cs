namespace QuickFix.web.Models
{
    public class DashboardViewModel
    {
        public int TotalUsers { get; set; }

        public int TotalServices { get; set; }

        public int TotalBookings { get; set; }

        public List<Booking> RecentBookings { get; set; } = new();
    }
}