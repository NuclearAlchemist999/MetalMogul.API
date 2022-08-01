namespace MetalMogul.Models
{
    public class Concert
    {
        public Guid Id { get; set; }
        public City City { get; set; }
        public Guid CityId { get; set; }
        public DateTime StartTime { get; set; }
        public int TicketsLeft { get; set; }
        public string Position { get; set; }
        public double Price { get; set; }
    }
}
