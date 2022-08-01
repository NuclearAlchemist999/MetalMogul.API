namespace MetalMogul.Models
{
    public class ConcertOrder
    {
        public Guid Id { get; set; }
        public Concert Concert { get; set; }
        public Guid ConcertId { get; set; }
        public Order Order { get; set; }
        public Guid OrderId { get; set; }
        public int NumberOfTickets { get; set; }
    }
}
