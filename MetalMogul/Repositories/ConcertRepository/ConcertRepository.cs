using MetalMogul.Data;
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

        public async Task<List<Concert>> GetConcerts()
        {
            return await _metalDbContext.Concerts
                   .Include(c => c.BandConcerts)
                   .ThenInclude(c => c.Band)
                   .Include(c => c.Venue)
                   .ToListAsync();
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
        public async Task<List<Order>> GetOrders()
        {
            return await _metalDbContext.Orders.Include(o => o.ConcertOrders)
                .ThenInclude(o => o.Concert)
                .ThenInclude(o => o.Venue)
                .Include(o => o.ConcertOrders)
                .ThenInclude(o => o.Concert)
                .ThenInclude(o => o.BandConcerts)
                .ThenInclude(o => o.Band) 
                .ToListAsync();
        }
    }
}
