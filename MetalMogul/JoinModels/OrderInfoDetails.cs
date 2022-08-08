using MetalMogul.Dto.DtoModels;

namespace MetalMogul.JoinModels
{
    public class OrderInfoDetails
    {
        public string Venue { get; set; }
        public List<string> Bands { get; set; }
        public double Price { get; set; } 
        public int Quantity { get; set; }
    }
}
