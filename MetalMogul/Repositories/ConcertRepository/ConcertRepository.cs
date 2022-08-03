using MetalMogul.Data;
using MetalMogul.JoinModels;
using MetalMogul.Models;
using Microsoft.EntityFrameworkCore;

namespace MetalMogul.Repositories.ConcertRepository
{
    public class ConcertRepository : IConcertRepository
    {
        private readonly MetalDbContext _metalDbContext;
        public ConcertRepository(MetalDbContext metalDbContext)
        {
            _metalDbContext = metalDbContext;
        }

        public async Task<List<ConcertInfo>> GetConcerts()
        {
            var concerts = await (from v in _metalDbContext.Venues
                                  join c in _metalDbContext.Concerts on v.Id equals c.VenueId
                                  join bc in _metalDbContext.Bands_Concerts on c.Id equals bc.ConcertId
                                  join b in _metalDbContext.Bands on bc.BandId equals b.Id
                                
                                  select new ConcertInfo
                                  {
                                      BandName = b.Name,
                                      StartTime = c.StartTime,
                                      Venue = v.Name,
                                      Price = c.Price,
                                      ConcertId = c.Id

                                  }).ToListAsync();

            return concerts;
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {
            _metalDbContext.Customers.Add(customer);

            await _metalDbContext.SaveChangesAsync();

            return customer;
        }

        public async Task<Customer> SearchCustomer(string email)
        {
            return await _metalDbContext.Customers.FirstOrDefaultAsync(c => c.Email == email);
        }

        public async Task<Concert> SearchConcert(Guid concertId)
        {
            return await _metalDbContext.Concerts.FindAsync(concertId);
        }

        public async Task<Order> AddOrder(Order order)
        {
            _metalDbContext.Orders.Add(order);

            await _metalDbContext.SaveChangesAsync();

            return order;
        }

        public async Task<ConcertOrder> AddConcertOrder(ConcertOrder ticket)
        {
            _metalDbContext.Concerts_Orders.Add(ticket);

            await _metalDbContext.SaveChangesAsync();

            return ticket;
        }

        public async Task<Concert> UpdateConcert(Concert concert)
        {
            _metalDbContext.Concerts.Update(concert);

            await _metalDbContext.SaveChangesAsync();

            return concert;
        }
    }
}
