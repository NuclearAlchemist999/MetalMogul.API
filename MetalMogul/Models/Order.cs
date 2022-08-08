namespace MetalMogul.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public Customer Customer { get; set; }
        public Guid CustomerId { get; set; }
        public double TotalSum { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public List<ConcertOrder> ConcertOrders { get; set; }
    }
}
