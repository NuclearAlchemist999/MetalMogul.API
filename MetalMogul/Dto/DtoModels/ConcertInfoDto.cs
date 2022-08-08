namespace MetalMogul.Dto.DtoModels
{
    public class ConcertInfoDto
    {
        public string Venue { get; set; }
        public string StartTime { get; set; }   
        public decimal Price { get; set; }
        public List<BandDto> Bands { get; set; }
    }
}
