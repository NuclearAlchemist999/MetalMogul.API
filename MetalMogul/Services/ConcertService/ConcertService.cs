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

        public async Task<List<ConcertInfoDto>> GetConcerts()
        {
            var concerts = await _concertRepo.GetConcerts();

            return concerts.ToConcertInfoDtoList();
        }

        public async Task<ConcertInfoDto> GetConcert(Guid concertId)
        {
            var concerts = await _concertRepo.GetConcerts();

            var concert = concerts.FirstOrDefault(c => c.ConcertId == concertId);

            return concert.ToConcertInfoDto();
        }

        public async Task BookTickets(BookTicketsRequestDto request)
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
