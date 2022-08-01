namespace MetalMogul.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public Customer Customer { get; set; }
        public Guid CustomerId { get; set; }
        public double TotalSum { get; set; }
    }
}
