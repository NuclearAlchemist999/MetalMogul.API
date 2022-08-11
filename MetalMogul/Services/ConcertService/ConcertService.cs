using MetalMogul.Dto.Converters;
using MetalMogul.Dto.DtoModels;
using MetalMogul.Dto.Request;
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
        public async Task<List<ConcertInfoDto>> GetConcerts(string orderBy)
        {
            var concerts = await _concertRepo.GetConcerts(orderBy);

            return concerts.ToConcertInfoDtoList();
        }

        public async Task<Order> GetOrder(Guid orderId)
        {
            var orders = await _concertRepo.GetOrders();
     
            return orders.FirstOrDefault(x => x.Id == orderId);
        }

        public async Task<ConcertInfoDto> GetConcert(Guid concertId, string orderBy)
        {
            var concerts = await _concertRepo.GetConcerts(orderBy);

            var concert = concerts.FirstOrDefault(c => c.Id == concertId);

            return concert.ToConcertInfoDto();
        }

        public async Task<OrderInfoDto> BookTickets(BookTicketsRequestDto request)
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
                TotalSum = await TotalSum(request.Tickets),
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

                concert.TicketsLeft -= ticket.Quantity;

                await _concertRepo.UpdateConcert(concert);
            }
            
            var orderInfo = await GetOrder(order.Id);

            return orderInfo.ToOrderInfoDto();
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
        public async Task<List<ConcertInfoDto>> SearchBandsAndConcerts(string searchQuery, string orderBy)
        {
            var concerts = await _concertRepo.GetConcerts(orderBy);

            var searchItems = concerts.Where(c => c.BandConcerts.Any(b => b.Band.Name.ToLower().Contains(searchQuery.ToLower()))
            || c.Venue.Name.ToLower().Contains(searchQuery.ToLower())).ToList();

            return searchItems.ToConcertInfoDtoList();
        }

        public async Task<double> TotalSum(List<Ticket> tickets)
        {
            var items = tickets
                .Select(async ticket => new
                {
                    ConcertId = ticket.ConcertId,
                    Quantity = ticket.Quantity,
                    Concert = await _concertRepo.SearchConcert(ticket.ConcertId)
                }).ToList();

            var tasks = await Task.WhenAll(items);

            return tasks.Sum(x => x.Quantity * x.Concert.Price);
        }
    }
}
