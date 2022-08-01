namespace MetalMogul.Models
{
    public class BandConcert
    {
        public Guid Id { get; set; }
        public Band Band { get; set; }
        public Guid BandId { get; set; }
        public Concert Concert { get; set; }
        public Guid ConcertId { get; set; }
    }
}
