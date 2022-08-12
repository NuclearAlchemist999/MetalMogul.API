using MetalMogul.Models;

namespace MetalMogul.Exceptions
{
    public sealed class OrderNotFoundException : NotFoundException
    {
        public OrderNotFoundException(Guid orderId)
            : base($"The order with id {orderId} does not exist.")
        {
        }
    }
}
