namespace MetalMogul.Models
{
    public class Concert
    {
        public Guid Id { get; set; }
        public Venue Venue { get; set; }
        public Guid VenueId { get; set; }
        public DateTime StartTime { get; set; }
        public int TicketsLeft { get; set; }
        public string Position { get; set; }
        public double Price { get; set; }
    }
}
