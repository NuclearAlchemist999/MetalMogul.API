using MetalMogul.Dto.DtoModels;
using MetalMogul.JoinModels;
using MetalMogul.Models;

namespace MetalMogul.Dto.Converters
{
    public static class OrderInfoConverter
    {
        public static OrderInfoDto ToOrderInfoDto(this OrderInfo order)
        {
            return new OrderInfoDto
            {
                OrderId = order.OrderId,
                Name = $"{order.FirstName} {order.LastName}",
                Email = order.Email,
                OrderDetails = order.OrderDetails
            };
        }
    }
}
