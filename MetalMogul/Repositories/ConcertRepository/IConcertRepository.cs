using MetalMogul.JoinModels;
using MetalMogul.Models;

namespace MetalMogul.Repositories.ConcertRepository
{
    public interface IConcertRepository
    {
        Task<List<ConcertInfo>> GetConcerts();
        Task<Customer> AddCustomer(Customer customer);
        Task<Customer> SearchCustomer(string email);
        Task<Order> AddOrder(Order order);
        Task<ConcertOrder> AddConcertOrder(ConcertOrder ticket);
        Task<Concert> SearchConcert(Guid concertId);
        Task<Concert> UpdateConcert(Concert concert);
    }
}
