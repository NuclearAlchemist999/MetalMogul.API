using MetalMogul.Dto.Converters;
using MetalMogul.Dto.DtoModels;
using MetalMogul.Dto.Request;
using MetalMogul.JoinModels;
using MetalMogul.Models;
using MetalMogul.Repositories.ConcertRepository;

namespace MetalMogul.Services.ConcertService
{
    public class ConcertService : IConcertService
    {
        private readonly IConcertRepository _concertRepo;

        public ConcertService(IConcertRepository concertRepo)
        {
            _concertRepo = concertRepo;
        }
        public async Task<List<ConcertInfo>> GetConcerts()
        {
            var concerts = await _concertRepo.GetConcerts();

            return concerts.Select(c => new ConcertInfo
            {
                ConcertId = c.Id,
                StartTime = c.StartTime,
                Venue = c.Venue.Name,
                Price = c.Price,
                Bands = c.BandConcerts.Select(b => new BandDto
                {
                    BandName = b.Band.Name,
                    Description = b.Band.Description

                }).ToList()

            }).ToList();
        }

        public async Task<OrderInfo> GetOrder(Guid orderId)
        {
            var ordersRep = await _concertRepo.GetOrders();

            var orders = ordersRep
               .Where(o => o.Id == orderId)
               .Select(o => new OrderInfo
               {
                   FirstName = o.Customer.FirstName,
                   LastName = o.Customer.LastName,
                   Email = o.Customer.Email,
                   OrderId = o.Id,
                   OrderDetails = o.ConcertOrders.Select(c => new OrderInfoDetails
                   {
                       Venue = c.Concert.Venue.Name,
                       Price = c.Concert.Price,
                       Quantity = c.NumberOfTickets,
                       Bands = c.Concert.BandConcerts.Select(x => x.Band.Name).ToList(),

                   }).ToList()

               }).ToList();

            return orders.FirstOrDefault(x => x.OrderId == orderId);
        }

        public async Task<ConcertInfo> GetConcert(Guid concertId)
        {
            var concerts = await GetConcerts();

            var concert = concerts.FirstOrDefault(c => c.ConcertId == concertId);

            return concert;
        }

        public async Task<OrderInfo> BookTickets(BookTicketsRequestDto request)
        {
            await CheckTicketsLeft(request);

            var customer = await _concertRepo.SearchCustomer(request.Email);

            if (customer == null)
            {
                customer = new Customer
                {
                    Id = Guid.NewGuid(),
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email
                };

                await _concertRepo.AddCustomer(customer);
            }

            var order = new Order
            {
                Id = Guid.NewGuid(),
                CustomerId = customer.Id,
                TotalSum = request.TotalSum
            };

            await _concertRepo.AddOrder(order);

            foreach (var ticket in request.Tickets)
            {
                var concertOrder = new ConcertOrder
                {
                    Id = Guid.NewGuid(),
                    ConcertId = ticket.ConcertId,
                    OrderId = order.Id,
                    NumberOfTickets = ticket.Quantity
                };

                await _concertRepo.AddConcertOrder(concertOrder);

                var concert = await _concertRepo.SearchConcert(ticket.ConcertId);

                concert.TicketsLeft = concert.TicketsLeft - ticket.Quantity;

                await _concertRepo.UpdateConcert(concert);
            }

            var orderInfo = await GetOrder(order.Id);

            return orderInfo;
        }

        public async Task CheckTicketsLeft(BookTicketsRequestDto request)
        {  
            foreach (var ticket in request.Tickets)
            {
                var concert = await _concertRepo.SearchConcert(ticket.ConcertId);
               
                if (concert.TicketsLeft < ticket.Quantity)
                {
                    throw new Exception("No more tickets than tickets left.");
                }
            }
        }
    }
}
