namespace MetalMogul.Models
{
    public class Concert
    {
        public Guid Id { get; set; }
        public Venue Venue { get; set; }
        public Guid VenueId { get; set; }
        public DateTime StartTime { get; set; }
        public int TicketsLeft { get; set; }
        public double Price { get; set; }
        public List<ConcertOrder> ConcertOrders { get; set; }
        public List<BandConcert> BandConcerts { get; set; }

    }
}
