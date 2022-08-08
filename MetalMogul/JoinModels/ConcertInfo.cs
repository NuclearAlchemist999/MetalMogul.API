using MetalMogul.Dto.DtoModels;

namespace MetalMogul.JoinModels
{
    public class ConcertInfo
    {
        public Guid ConcertId { get; set; }
        public DateTime StartTime { get; set; }
        public string Venue { get; set; }
        public double Price { get; set; }
        public List<BandDto> Bands { get; set; }
    }
}
