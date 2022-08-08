namespace MetalMogul.JoinModels
{
    public class OrderInfo
    {
        public Guid OrderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<OrderInfoDetails> OrderDetails { get; set; }
    }
}
