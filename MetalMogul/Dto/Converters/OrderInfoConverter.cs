using MetalMogul.Dto.DtoModels;
using MetalMogul.Models;

namespace MetalMogul.Dto.Converters
{
    public static class OrderInfoConverter
    {
        public static OrderInfoDto ToOrderInfoDto(this Order order)
        {
            return new OrderInfoDto
            {
                Name = $"{order.Customer.FirstName} {order.Customer.LastName}",
                Email = order.Customer.Email,
                OrderId = order.Id,
                OrderDetails = order.ConcertOrders.Select(c => new OrderInfoDetailsDto
                {
                    Venue = c.Concert.Venue.Name,
                    Price = (decimal)c.Concert.Price,
                    Quantity = c.NumberOfTickets,
                    Bands = c.Concert.BandConcerts.Select(x => x.Band.Name).ToList(),

                }).ToList(),
                TotalSum = (decimal)order.TotalSum
            };
        }
    }
}
