namespace MetalMogul.Dto.DtoModels
{
    public class OrderInfoDetailsDto
    {
        public string Venue { get; set; }
        public List<string> Bands { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
