using System.ComponentModel.DataAnnotations;

namespace QuickFix.web.Models
{
    public class Booking
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Customer Name is required")]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [Phone]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please describe your problem")]
        public string Problem { get; set; }

        [Required]
        [Display(Name = "Booking Date")]
        public DateTime BookingDate { get; set; }

        [Required]
        [Display(Name = "Booking Time")]
        public TimeSpan BookingTime { get; set; }

        // Which service is booked
        public int ServiceId { get; set; }

        // Booking Status
        public string Status { get; set; } = "Pending";

        // Booking Created Date
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}