namespace QuickFix.web.Models
{
    public class Service
    {
        public int Id { get; set; }

        public string ServiceName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public string ImageUrl { get; set; } = string.Empty;
    }
}