using MetalMogul.JoinModels;

namespace MetalMogul.Dto.DtoModels
{
    public class OrderInfoDto
    {
        public Guid OrderId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<OrderInfoDetails> OrderDetails { get; set; }
    }
}
